using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ToolListPrinterLibrary.Models
{
    public class ToolListModel
    {
        public string ToolListId { get; set; }
        public string ToolListName { get; set; }
        public string Clamping { get
            {
                if (ToolListName == null)
                {
                    return null;
                }
                string pattern = @"_\w+";
                Match match = Regex.Match(ToolListName, pattern);
                if (!match.Success)
                {
                    return "1";
                }
                return match.Value[1..];
            }
}
        public List<ListPositionModel> ListPositions { get; set; }
        public string MachineId { get; set; }
        public string MachineName { get
            {
                if (MachineId == null)
                {
                    return null;
                }
                try
                {
                    return MachineKeyPairs[MachineId];
                }
                catch (System.Exception)
                {
                    return MachineId;
                }
            }
}
        private readonly Dictionary<string, string> MachineKeyPairs;
        public string DisplayName { get
            {
                return ToolListName + " - " + MachineId;
            }
}
        public ToolListModel()
        {
            MachineKeyPairs = new();
            MachineKeyPairs.Add("MCTX125A", "CTX");
            MachineKeyPairs.Add("MDMC60H", "DMC60");
            MachineKeyPairs.Add("MDMF260", "DMF");
            MachineKeyPairs.Add("MFSTMS1_DMC60H", "FASTEMS");
            MachineKeyPairs.Add("MFSTMS1_DMC60H_AUTO", "FASTEMS");
            MachineKeyPairs.Add("MMLCUBEB", "DATRON");
        }
    }
}