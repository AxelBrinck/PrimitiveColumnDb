using NUnit.Framework;
using System.IO;
using System;

namespace PrimitiveColumnDb.Tests
{
    [TestFixture]
    public class ShouldCreateDb
    {
        private Database database;
        private static readonly string DbRelativePath = "test_data";

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(DbRelativePath))
            {
                Directory.Delete(DbRelativePath, true);
            }
        }

        [Test]
        public void ShouldInstantiateGivenAPath()
        {
            database = new Database(DbRelativePath);

            Assert.Pass();
        }

        [Test]
        public void ShouldCreateDbFolder()
        {
            database = new Database(DbRelativePath);

            if (!Directory.Exists(DbRelativePath))
            {
                Assert.Fail($@"Could not find directory: {DbRelativePath}");
            }

            Assert.Pass();
        }
    }
}