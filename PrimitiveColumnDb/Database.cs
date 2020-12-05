using System;
using System.IO;

namespace PrimitiveColumnDb
{
    public class Database
    {
        public DirectoryInfo FolderPath { get; private set; }

        public Database(string path)
        {
            FolderPath = Directory.CreateDirectory(path);
        }

        public void CreateTable(string tableName)
        {
            var path = 
                FolderPath.FullName + 
                Path.DirectorySeparatorChar + 
                tableName;

            Directory.CreateDirectory(path);
        }
    }
}
