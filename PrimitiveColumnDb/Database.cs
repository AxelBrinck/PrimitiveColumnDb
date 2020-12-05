using System;
using System.IO;

namespace PrimitiveColumnDb
{
    public class Database
    {
        public string Path { get; private set; }

        public Database(string path)
        {
            Directory.CreateDirectory(path);
            Path = path;
        }

        public void test()
        {
            
        }
    }
}
