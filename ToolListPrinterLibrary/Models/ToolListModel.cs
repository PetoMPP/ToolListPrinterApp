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
                return match.Value.Substring(1);
            }
}
        public List<ListPositionModel> ListPositions { get; set; }
    }
}