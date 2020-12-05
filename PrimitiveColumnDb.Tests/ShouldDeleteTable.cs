using NUnit.Framework;
using System.IO;

namespace PrimitiveColumnDb.Tests
{
    [TestFixture]
    public class ShouldDeleteTable
    {
        private static readonly string DbRelativePath = "test_data";
        private static readonly string TableNameA = "test_table";
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(DbRelativePath);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(DbRelativePath))
            {
                Directory.Delete(DbRelativePath, true);
            }
        }
        
        [Test]
        public void ShouldDeleteATable()
        {
            database = new Database(DbRelativePath);

            database.CreateTable(TableNameA);

            var pathA = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            if (!Directory.Exists(pathA))
            {
                Assert.Fail($@"Could not create a table named {TableNameA} 
                with an expected location at {pathA}.");
            }

            database.DeleteTable(TableNameA);

            if (Directory.Exists(pathA))
            {
                Assert.Fail($@"Could not delete a table named {TableNameA} 
                with an expected location at {pathA}.");
            }

            Assert.Pass();
        }
    }
}