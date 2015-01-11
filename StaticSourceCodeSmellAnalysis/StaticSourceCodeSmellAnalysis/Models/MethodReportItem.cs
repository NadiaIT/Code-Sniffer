namespace StaticSourceCodeSmellAnalysis.Models
{
    public class MethodReportItem
    {
        public MethodReportItem(MethodItem methodItem)
        {
            _methodItem = methodItem;
        }

        private MethodItem _methodItem;

        public MethodItem GetMethodItem()
        {
            return _methodItem;
        }

        public string MethodName
        {
            get { return _methodItem.Name; }
        }

        public int LongMethod { get; set; }
        
        public int LongParameterList { get; set; }
        
        public int SwitchStatement { get; set; }

        public string Path
        {
            get
            {
                return _methodItem.Path;
            }
        }
    }
}
