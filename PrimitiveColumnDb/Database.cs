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
        
        public void DeleteTable(string tableName)
        {
            var path = 
                FolderPath.FullName + 
                Path.DirectorySeparatorChar + 
                tableName;

            Directory.Delete(path, true);
        }

        public void Purge()
        {
            foreach (var file in FolderPath.GetFiles())
            {
                file.Delete(); 
            }
            
            foreach (var directory in FolderPath.GetDirectories())
            {
                directory.Delete(true); 
            }
        }
    }
}
