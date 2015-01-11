using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class Filter
    {
        public ClassReportItem GetClassReport(ClassItem classItem)
        {
            var classReortItem = new ClassReportItem (classItem);

            if (classItem.LinesOfCode > 900 || classItem.NumberOfProperty > 30 || classItem.MethodCount > 30)
            {
                classReortItem.GodClass = 3;
            }
            else if (classItem.LinesOfCode > 750 || classItem.NumberOfProperty > 20 || classItem.MethodCount > 20)
            {
                classReortItem.GodClass = 2;
            }
            else
                classReortItem.GodClass = 1;


            if (classItem.NumberOfProperty + classItem.MethodCount < 2)
            {
                classReortItem.LazyClass = 3;
            }
            else if (classItem.NumberOfProperty < 3 && classItem.MethodCount < 3)
            {
                classReortItem.LazyClass = 2;
            }
            else
                classReortItem.LazyClass = 1;


            return classReortItem;
        }

        public MethodReportItem GetMethodReport(MethodItem methodItem)
        {
            var methodReortItem = new MethodReportItem(methodItem);

            if (methodItem.LinesOfCode > 65)
            {
                methodReortItem.LongMethod = 3;
            }
            else if (methodItem.LinesOfCode > 20)
            {
                methodReortItem.LongMethod = 2;
            }
            else
            {
                methodReortItem.LongMethod = 1;
            }

            if (methodItem.NumberOfParameters > 5)
            {
                methodReortItem.LongParameterList = 3;
            }
            else if (methodItem.NumberOfParameters > 3)
            {
                methodReortItem.LongParameterList = 2;
            }
            else
            {
                methodReortItem.LongParameterList = 1;
            }

            if (methodItem.NumberOfSwitchStatement > 5)
            {
                methodReortItem.SwitchStatement = 3;
            }
            else if (methodItem.NumberOfSwitchStatement > 3)
            {
                methodReortItem.SwitchStatement = 2;
            }
            else
            {
                methodReortItem.SwitchStatement = 1;
            }

            return methodReortItem;
        }
    }
}
