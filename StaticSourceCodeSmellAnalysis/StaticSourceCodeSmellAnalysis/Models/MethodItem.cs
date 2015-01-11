using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class MethodItem
    {
        private string _methodText;

        public string GetMethodText()
        {
            return _methodText;
        }

        private List<ParameterItem> _parameterList;

        public List<ParameterItem> ParameterList()
        {
            return _parameterList;
        }

        public string Name { get; private set; }

        public int LinesOfCode { get; private set; }

        public int NumberOfParameters
        {
            get
            {
                return _parameterList.Count;
            }
        }
       
        public int NumberOfVariables { get; private set; }

        public int NumberOfSwitchStatement { get; private set; }

        public string Path { get; private set; }


        public MethodItem(MethodDeclarationSyntax methodDeclarationSyntax, string path)
        {
            Name = methodDeclarationSyntax.Identifier.ToString();
            Path = path;
            CreateMethod(methodDeclarationSyntax);
        }

        public MethodItem(ConstructorDeclarationSyntax constructorDeclarationSyntax, string path)
        {
            Name = constructorDeclarationSyntax.Identifier.ToString();
            Path = path;

            CreateMethod(constructorDeclarationSyntax);
        }

        private void CreateMethod(BaseMethodDeclarationSyntax methodDeclarationSyntax)
        {
//            _methodText = methodDeclarationSyntax.GetText().ToString();

            LinesOfCode = methodDeclarationSyntax.GetText().LineCount;

            NumberOfVariables = methodDeclarationSyntax.DescendantNodes()
                .OfType<VariableDeclarationSyntax>().Count();

            _parameterList = new List<ParameterItem>();

            var parameters = methodDeclarationSyntax.ParameterList.Parameters;

            foreach (var parameter in parameters)
            {
                _parameterList.Add(new ParameterItem(parameter));
            }

            NumberOfSwitchStatement = methodDeclarationSyntax.DescendantNodes()
                .OfType<SwitchSectionSyntax>().Count();
        }


    }
}
