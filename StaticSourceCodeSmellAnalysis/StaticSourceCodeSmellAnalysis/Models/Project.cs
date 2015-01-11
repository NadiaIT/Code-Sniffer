using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StaticSourceCodeSmellAnalysis.Models
{
    public class Project
    {
        public string Name { get; set; }

        public string Path { get; set; }

        private List<FileItem> _fileList; 

        public List<FileItem> GetFileList()
        {
            return _fileList;
        }

        public int NumberOfFiles
        {
            get
            {
                return _fileList.Count;
            }
        }

        public int NumberOfClasses
        {
            get
            {
                return GetClassList().Count;
            }
        }

        public int NumberOfMethods
        {
            get
            {
                return GetMethodList().Count;
            }
        }

        public Project(string path)
        {
            Path = path;
            Name = path;
            _fileList = new List<FileItem>();

            if (File.Exists(Path) && Path.EndsWith(".cs"))
            {
                _fileList.Add(new FileItem(Path));
            }
            else
            {
                var directoryInfo = new DirectoryInfo(Path);
                CreateFileList(directoryInfo);
            }

        }


        private void CreateFileList(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (var csFile in directoryInfo.GetFiles("*.cs"))
                {
                    _fileList.Add(new FileItem(csFile.FullName));
                }

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    CreateFileList(directory);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public List<ClassItem> GetClassList()
        {
            var classList = new List<ClassItem>();
            foreach (FileItem fileItem in _fileList)
            {
                classList.AddRange(fileItem.GetClassList());
            }
            return classList;
        }

        public List<MethodItem> GetMethodList()
        {
            var methodList = new List<MethodItem>();
            foreach (FileItem fileItem in _fileList)
            {
                methodList.AddRange(fileItem.GetMethodList());
            }
            return methodList;
        }

        public int LinesOfCode
        {
            get
            {
                return _fileList.Sum(fileItem => fileItem.LinesOfCode);
            }
        }
    }
}
