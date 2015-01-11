using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class ClassItem
    {
        private List<MethodItem> _methodList; 
        private string _classText; 
        public string Name { get; private set; }
        public int LinesOfCode { get; private set; }
        public int MethodCount
        {
            get
            {
                return _methodList.Count;
            }
        }
        public int NumberOfProperty { get; private set; }
        public string Path { get; set; }
        

        public string GetClassText()
        {
            return _classText;
        }
        public List<MethodItem> GetMethodList()
        {
            return _methodList;
        }

        public ClassItem(ClassDeclarationSyntax classDeclarationSyntax, string path)
        {
            Name = classDeclarationSyntax.Identifier.ToString();
            Path = path;
//            _classText = classDeclarationSyntax.GetText().ToString();

            LinesOfCode = classDeclarationSyntax.GetText().LineCount;

            _methodList = new List<MethodItem>();

            var methods = classDeclarationSyntax.DescendantNodes()
                .OfType<MethodDeclarationSyntax>().ToList();

            foreach (MethodDeclarationSyntax methodDeclarationSyntax in methods)
            {
                _methodList.Add(new MethodItem(methodDeclarationSyntax, path));
            }

            var constructors = classDeclarationSyntax.DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>().ToList();

            foreach (ConstructorDeclarationSyntax constructorDeclarationSyntax in constructors)
            {
                _methodList.Add(new MethodItem(constructorDeclarationSyntax, path));
            }

            NumberOfProperty = classDeclarationSyntax.DescendantNodes()
                .OfType<PropertyDeclarationSyntax>().Count();
        }
    }
}
