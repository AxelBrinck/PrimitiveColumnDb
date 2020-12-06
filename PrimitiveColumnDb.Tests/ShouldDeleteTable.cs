using NUnit.Framework;
using System.IO;

namespace PrimitiveColumnDb.Tests
{
    [TestFixture]
    public class ShouldDeleteTable
    {
        private static readonly string DbRelativePath = "test_data";
        private static readonly string TableNameA = "test_table_a";
        private static readonly string TableNameB = "test_table_b";
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
        public void Should_Be_Able_To_Delete_Specified_Table()
        {
            database.CreateTable(TableNameA);

            var pathA = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            if (!Directory.Exists(pathA))
            {
                Assert.Fail($@"Could not locate a table named {TableNameA} 
                with an expected location at {pathA}.");
            }

            database.DeleteTable(TableNameA);

            if (Directory.Exists(pathA))
            {
                Assert.Fail($@"Table {TableNameA} should have been removed. 
                But was found at {pathA}.");
            }

            Assert.Pass();
        }

        [Test]
        public void Should_Be_Able_To_Delete_All_Tables()
        {
            database.CreateTable(TableNameA);
            database.CreateTable(TableNameB);

            var pathA = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            var pathB = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameB;

            if (!Directory.Exists(pathA))
            {
                Assert.Fail($@"Could not locate a table named {TableNameA} 
                with an expected location at {pathA}.");
            }

            if (!Directory.Exists(pathB))
            {
                Assert.Fail($@"Could not locate a table named {TableNameB} 
                with an expected location at {pathB}.");
            }

            database.Purge();

            if (Directory.Exists(pathA))
            {
                Assert.Fail($@"Table {TableNameA} should have been removed. 
                But was found at {pathA}.");
            }

            if (Directory.Exists(pathB))
            {
                Assert.Fail($@"Table {TableNameB} should have been removed. 
                But was found at {pathB}.");
            }
            
            Assert.Pass();
        }
    }
}