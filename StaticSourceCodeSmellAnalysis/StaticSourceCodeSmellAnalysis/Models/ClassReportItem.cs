namespace StaticSourceCodeSmellAnalysis.Models
{
    public class ClassReportItem
    {
        public ClassReportItem(ClassItem classItem)
        {
            _classItem = classItem;
        }

        private ClassItem _classItem;

        public ClassItem GetClassItem()
        {
            return _classItem;
        }

        public string ClassName
        {
            get
            {
                return _classItem.Name;
            }
        }

        public int GodClass { get; set; }
        
        public int LazyClass { get; set; }

        public string Path
        {
            get
            {
                return _classItem.Path;
            }
        }
        
    }
}
