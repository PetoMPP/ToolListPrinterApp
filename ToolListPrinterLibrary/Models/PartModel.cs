using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListPrinterLibrary.Models
{
    public class PartModel
    {
        public string PartName { get; set; }
        public List<ToolListModel> ToolLists { get; set; }
    }
}
