using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PieControls;
using StaticSourceCodeSmellAnalysis.Models;

namespace StaticSourceCodeSmellAnalysis
{
    public partial class MainWindow
    {
        public List<Project> Projects;
        public List<ClassReportItem> ClassReportItems;
        public List<MethodReportItem> MethodReportItems;
        public Project Project;
        public Filter Filter = new Filter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(PathTextBox.Text))
            {
                AnalyzeButton.Content = "Analyze Files in Directory";
                AnalyzeButton.IsEnabled = true;
            }
            else if (File.Exists(PathTextBox.Text))
            {
                if (PathTextBox.Text.EndsWith(".cs"))
                {
                    AnalyzeButton.Content = "Analyze .CS File";
                    AnalyzeButton.IsEnabled = true;
                }
            }
            else if(AnalyzeButton.IsEnabled)
            {
                AnalyzeButton.IsEnabled = false;
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            Projects = new List<Project>();

            Project = new Project(PathTextBox.Text);

            Projects.Add(Project);

            FilesLabel.Content = Project.NumberOfFiles;
            ClassesLabel.Content = Project.NumberOfClasses;
            MethodLabel.Content = Project.NumberOfMethods;
            LinesLabel.Content = Project.LinesOfCode;

            DetailPanel.Visibility = Visibility.Visible;
            ReportViewer.Visibility = Visibility.Visible;

            ClassReportItems = new List<ClassReportItem>();

            foreach (var classItem in Project.GetClassList())
            {
                ClassReportItems.Add(Filter.GetClassReport(classItem));
            }

            MethodReportItems = new List<MethodReportItem>();

            foreach (var methodItem in Project.GetMethodList())
            {
                MethodReportItems.Add(Filter.GetMethodReport(methodItem));
            }


            GenerateGodClassReport();
            GenerateLazyClassReport();
            GenerateLongMethodReport();
            GenerateLongParameterListReport();
            GenerateSwitchStatementReport();
        }

        private void GenerateLongMethodReport()
        {
            int low = 0, moderate = 0, high = 0;

            foreach (var methodReportItem in MethodReportItems)
            {
                if (methodReportItem.LongMethod == 1)
                {
                    low++;
                }
                else if (methodReportItem.LongMethod == 2)
                {
                    moderate++;
                }
                else
                {
                    high++;
                }
            }

            var pieCollection = new ObservableCollection<PieSegment>();


            pieCollection.Add(new PieSegment { Color = Colors.Green, Value = low, Name = "Low Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Yellow, Value = moderate, Name = "Moderate Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Red, Value = high, Name = "High Risk" });
            LongMethodChart.Data = pieCollection;
        }

        private void GenerateSwitchStatementReport()
        {
            int low = 0, moderate = 0, high = 0;

            foreach (var methodReportItem in MethodReportItems)
            {
                if (methodReportItem.SwitchStatement == 1)
                {
                    low++;
                }
                else if (methodReportItem.SwitchStatement == 2)
                {
                    moderate++;
                }
                else
                {
                    high++;
                }
            }

            var pieCollection = new ObservableCollection<PieSegment>();


            pieCollection.Add(new PieSegment { Color = Colors.Green, Value = low, Name = "Low Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Yellow, Value = moderate, Name = "Moderate Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Red, Value = high, Name = "High Risk" });
            SwitchStatementChart.Data = pieCollection;
        }

        private void GenerateLongParameterListReport()
        {
            int low = 0, moderate = 0, high = 0;

            foreach (var methodReportItem in MethodReportItems)
            {
                if (methodReportItem.LongParameterList == 1)
                {
                    low++;
                }
                else if (methodReportItem.LongParameterList == 2)
                {
                    moderate++;
                }
                else
                {
                    high++;
                }
            }

            var pieCollection = new ObservableCollection<PieSegment>();


            pieCollection.Add(new PieSegment { Color = Colors.Green, Value = low, Name = "Low Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Yellow, Value = moderate, Name = "Moderate Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Red, Value = high, Name = "High Risk" });
            LongParameterListChart.Data = pieCollection;
        }

        private void GenerateGodClassReport()
        {
            int low = 0, moderate = 0, high = 0;

            foreach (var classReportItem in ClassReportItems)
            {
                if (classReportItem.GodClass == 1)
                {
                    low++;
                }
                else if (classReportItem.GodClass == 2)
                {
                    moderate++;
                }
                else
                {
                    high++;
                }
            }

            var pieCollection = new ObservableCollection<PieSegment>();


            pieCollection.Add(new PieSegment {Color = Colors.Green, Value = low, Name = "Low Risk"});
            pieCollection.Add(new PieSegment {Color = Colors.Yellow, Value = moderate, Name = "Moderate Risk"});
            pieCollection.Add(new PieSegment {Color = Colors.Red, Value = high, Name = "High Risk"});
            GodClassChart.Data = pieCollection;
        }

        private void GenerateLazyClassReport()
        {
            int low = 0, moderate = 0, high = 0;

            foreach (var classReportItem in ClassReportItems)
            {
                if (classReportItem.LazyClass == 1)
                {
                    low++;
                }
                else if (classReportItem.LazyClass == 2)
                {
                    moderate++;
                }
                else
                {
                    high++;
                }
            }

            var pieCollection = new ObservableCollection<PieSegment>();
            

            pieCollection.Add(new PieSegment { Color = Colors.Green, Value = low, Name = "Low Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Yellow, Value = moderate, Name = "Moderate Risk" });
            pieCollection.Add(new PieSegment { Color = Colors.Red, Value = high, Name = "High Risk" });
            LazyClassChart.Data = pieCollection;
        }

        private void FilesButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Project.GetFileList();
        }

        private void ClassesButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Project.GetClassList();
        }

        private void MethodsButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Project.GetMethodList();
        }

        private void FilterClassesButton_Click(object sender, RoutedEventArgs e)
        {
            

            DataGrid.ItemsSource = ClassReportItems;
        }

        private void FilterMethodsButton_Click(object sender, RoutedEventArgs e)
        {

            DataGrid.ItemsSource = MethodReportItems;
            
        }
    }
}
