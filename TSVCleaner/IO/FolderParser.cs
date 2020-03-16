using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TSVCleaner.IO
{
    class FolderParser
    {
        string[] fileExtensions;
        public FolderParser(string[] fileExtensions)
        {
            this.fileExtensions = fileExtensions;
        }
        public List<string> parseFolder(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            List<string> tradosFiles = new List<string>();

            for (int i = 0; i < files.Length; i++)
            {
                if (fileExtensions.Any(files[i].Contains))
                {
                    tradosFiles.Add(files[i]);
                }
            }
            return tradosFiles;
        }
        public List<string> parseFolderRecursively(string folderPath)
        {
            List<string> tradosFiles = new List<string>();
            tradosFiles.AddRange(parseFolder(folderPath));

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (string directory in directories)
            {
                tradosFiles.AddRange(parseFolder(directory));
                tradosFiles.AddRange(parseFolderRecursively(directory));
            }
            return tradosFiles;
        }

    }
}