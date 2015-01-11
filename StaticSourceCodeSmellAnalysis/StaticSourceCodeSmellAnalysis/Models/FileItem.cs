using System.Collections.Generic;
using System.IO;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class FileItem
    {
        public string Name { get; private set; }
        
        private List<ClassItem> _classList; 
        public List<ClassItem> GetClassList()
        {
            return _classList;
        }
        public int NumberOfClasses
        {
            get
            {
                return _classList.Count;
            }
        }

        public FileItem(string csFile)
        {
            var fileInfo = new FileInfo(csFile);
            Path = fileInfo.FullName;
            Name = fileInfo.Name;
            _classList = new List<ClassItem>();
            var syntaxTree = SyntaxTree.ParseFile(Path);
            var root = syntaxTree.GetRoot();
            LinesOfCode = root.GetText().LineCount;
            var classes = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>().ToList();

            foreach (ClassDeclarationSyntax classDeclarationSyntax in classes)
            {
                var classItem = new ClassItem(classDeclarationSyntax, Path);
                _classList.Add(classItem);
            }
        }

        public List<MethodItem> GetMethodList()
        {
          
                var methodList = new List<MethodItem>();
                foreach (ClassItem classItem in _classList)
                {
                    methodList.AddRange(classItem.GetMethodList());
                }
                return methodList;
           
        }

        public int NumberOfMethods
        {
            get
            {
                return GetMethodList().Count;
            }
        }

        public int LinesOfCode { get; private set; }

        public string Path { get; private set; }
    }
}
