using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListPrinterLibrary.Models;

namespace ToolListPrinterLibrary.DataProcessing
{
    public class TDMProcessing
    {
        private static string GetTDMConnectionString() => ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString;
        private static IDbConnection GetTDMConnection()
        {
            return new SqlConnection(GetTDMConnectionString());
        }
        public static PartModel CreatePartModel(string partName)
        {
            PartModel model = new() { PartName = partName };
            using IDbConnection connection = GetTDMConnection();
            // Collect tool lists
            model.ToolLists = connection.Query<ToolListModel>(
                $"SELECT LISTID AS ToolListId, NCPROGRAM AS ToolListName, MACHINEID AS MachineId FROM TDM_LIST WHERE NCPROGRAM LIKE '{partName}%' ORDER BY ToolListName",
                commandType: CommandType.Text).ToList();
            // Collect positions
            foreach (ToolListModel list in model.ToolLists)
            {
                list.ListPositions = connection.Query<ListPositionModel>(
                    $"SELECT COMPID AS CompId, TOOLID AS ToolId FROM TDM_LISTLISTB WHERE LISTID = '{list.ToolListId}'",
                    commandType: CommandType.Text).ToList();
                // populate position data
                foreach (ListPositionModel position in list.ListPositions)
                {
                    if (position.Name == position.CompId)
                    {
                        // populate data from comps table
                        //List<string> compData = connection.Query<string>($"SELECT NAME, NAME2 FROM TDM_COMP WHERE COMPID = '{position.CompId}'").ToList();
                        position.Description = connection.Query<string>($"SELECT NAME FROM TDM_COMP WHERE COMPID = '{position.CompId}'").First();
                        position.OrderCode = connection.Query<string>($"SELECT NAME2 FROM TDM_COMP WHERE COMPID = '{position.CompId}'").First();
                        position.IsPresent = connection.Query<bool>(
$@"IF EXISTS (SELECT COMPID FROM LGM_COMPSTOCKBASELIST
WHERE COMPID = '{position.Name}' AND COSTUNIT = '{list.MachineId}')
SELECT 1
ELSE
SELECT 0",
                        commandType: CommandType.Text).First();
                    }
                    if (position.Name == position.ToolId)
                    {
                        // populate data from tools table
                        // List<string> compData = connection.Query<string>($"SELECT NAME, NAME2 FROM TDM_TOOL WHERE TOOLID = '{position.CompId}'").ToList();
                        position.Description = connection.Query<string>($"SELECT NAME FROM TDM_TOOL WHERE TOOLID = '{position.ToolId}'").First();
                        position.OrderCode = connection.Query<string>($"SELECT NAME2 FROM TDM_TOOL WHERE TOOLID = '{position.ToolId}'").First();
                        position.IsPresent = connection.Query<bool>(
$@"IF EXISTS (SELECT TOOLID FROM LGM_TOOLSTOCKBASELIST
WHERE TOOLID = '{position.Name}' AND COSTUNIT = '{list.MachineId}')
SELECT 1
ELSE
SELECT 0",
                        commandType: CommandType.Text).First();
                    }
                }
            }
            // return partmodel
            return model;
        }

        public static List<ToolListModel> OverrideByPresettingList(List<ToolListModel> toolLists)
        {
            using IDbConnection connection = GetTDMConnection();
            // get tools to be marked as missing
            string[] toolIds = Array.Empty<string>();
            // get commision id by first listid
            string commissionId = connection.Query<string>($"SELECT COMMISSIONID FROM CIR_ORDER WHERE LISTID = '{toolLists[0].ToolListId}'", commandType: CommandType.Text).FirstOrDefault();
            // get tool list in commision
            toolIds = connection.Query<string>($"SELECT ID FROM CIR_SHOPTOOLORDER WHERE COMMISSIONID = '{commissionId}'").ToArray();
            // ovverride IsPresent param in every list position
            foreach (ToolListModel tl in toolLists)
            {
                foreach (ListPositionModel lp in tl.ListPositions)
                {
                    lp.IsPresent = !toolIds.Any(id => id == lp.ToolId || id == lp.CompId);
                }
            }
            return toolLists;
        }

        public static List<ToolListModel> OverrideByAssemblyList(List<ToolListModel> toolLists)
        {
            using IDbConnection connection = GetTDMConnection();
            // get tools to be marked as missing
            string[] toolIds = Array.Empty<string>();
            // get commision id by first listid
            string commissionId = connection.Query<string>($"SELECT COMMISSIONID FROM CIR_ORDER WHERE LISTID = '{toolLists[0].ToolListId}'", commandType: CommandType.Text).FirstOrDefault();
            // get tool list in commision
            toolIds = connection.Query<string>($"SELECT ID FROM TPS_COMMISSIONLIST WHERE COMMISSIONID = '{commissionId}'").ToArray();
            // ovverride IsPresent param in every list position
            foreach (ToolListModel tl in toolLists)
            {
                foreach (ListPositionModel lp in tl.ListPositions)
                {
                    lp.IsPresent = !toolIds.Any(id => id == lp.ToolId || id == lp.CompId);
                }
            }
            return toolLists;
        }
    }
}
