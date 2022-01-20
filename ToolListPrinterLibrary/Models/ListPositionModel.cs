namespace ToolListPrinterLibrary.Models
{
    public class ListPositionModel
    {
        public string CompId { get; set; }
        public string ToolId { get; set; }
        public string Name { get
            {
                if (CompId != null)
                {
                    return CompId;
                }
                if (ToolId != null)
                {
                    return ToolId;
                }
                return null;
            }
}
        public string Description { get; set; }
        public string OrderCode { get; set; }
    }
}