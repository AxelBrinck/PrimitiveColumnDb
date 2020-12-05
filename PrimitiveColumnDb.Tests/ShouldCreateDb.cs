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
                Assert.Fail($"Tried to instantiate with argument: {DbRelativePath}. This argument should be the name of a subfolder. This subfolder was not found.");
            }

            Assert.Pass();
        }
    }
}