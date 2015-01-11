using Roslyn.Compilers.CSharp;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class ParameterItem
    {
        public string Text { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }

        public ParameterItem(ParameterSyntax parameterSyntax)
        {
            Name = parameterSyntax.Identifier.ValueText;
            Type = parameterSyntax.Type.ToString();
            Text = parameterSyntax.GetText().ToString();
        }
    }
}
