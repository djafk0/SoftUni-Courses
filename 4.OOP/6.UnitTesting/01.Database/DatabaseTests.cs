using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3)]
        [TestCase(0)]
        [TestCase(15)]
        [TestCase(16)]
        public void AddMethodShouldAddNewElementsWhileCountIsLessThan16(int j)
        {
            Database database = new Database();

            for (int i = 0; i < j; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(j, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenItemsAreAboveThan16()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCollectionIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCase(15)]
        [TestCase(15)]
        [TestCase(1)]
        public void RemoveMethodShouldRemoveElementWhenTheyAreAbove0(int count)
        {
            Database database = new Database();

            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            database.Remove();

            Assert.AreEqual(count - 1, database.Count);
        }
        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddAllItemsWhileTheyAreBelow16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database database = new Database(elements);

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void ConstructorShouldThrowExcepetionWhenItemsAreAbove16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }
        [Test]
        public void FetchMethod()
        {
            Database array = new Database(1,2,3);
            array.Add(4);
            array.Add(5);

            array.Remove();
            array.Remove();
            array.Remove();

            int[] fetechedData = array.Fetch();

            int[] expectedArray = new int[] { 1, 2 };

            Assert.AreEqual(expectedArray, fetechedData);
        }

    }
}