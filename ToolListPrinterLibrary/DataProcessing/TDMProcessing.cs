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
                $"SELECT LISTID AS ListId, NCPROGRAM AS ToolListName FROM TDM_LIST WHERE NCPROGRAM LIKE '{partName}%'",
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
                        string[] compData = connection.Query<string[]>($"SELECT NAME, NAME2 FROM TDM_COMP WHERE COMPID = '{position.CompId}'").First();
                        position.Description = compData[0];
                        position.OrderCode = compData[1];
                    }
                    if (position.Name == position.ToolId)
                    {
                        // populate data from tools table
                        string[] compData = connection.Query<string[]>($"SELECT NAME, NAME2 FROM TDM_TOOL WHERE TOOLID = '{position.CompId}'").First();
                        position.Description = compData[0];
                        position.OrderCode = compData[1];
                    }
                }
            }
            // return partmodel
            return model;
        }

    }
}
