using NUnit.Framework;
using System.IO;

namespace PrimitiveColumnDb.Tests
{
    [TestFixture]
    public class ShouldCreateTable
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
        public void ShouldCreateATableGivenAName()
        {
            database = new Database(DbRelativePath);

            database.CreateTable(TableNameA);

            var path = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            if (!Directory.Exists(path))
            {
                Assert.Fail($@"Could not locate directory {path}.");
            }

            Assert.Pass();
        }

        [Test]
        public void ShouldCreateSeveralTables()
        {
            database = new Database(DbRelativePath);

            database.CreateTable(TableNameA);
            database.CreateTable(TableNameB);

            var pathA = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            var pathB = 
                DbRelativePath + 
                Path.DirectorySeparatorChar + 
                TableNameA;

            if (!Directory.Exists(pathA) || !Directory.Exists(pathB))
            {
                Assert.Fail($@"Tried to create two tables. 
                Their root paths should be located in {pathA} and {pathB}, 
                but could not find at least one of these subfolders.");
            }

            Assert.Pass();
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