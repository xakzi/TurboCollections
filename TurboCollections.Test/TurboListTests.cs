using System.Collections.Generic;
using NUnit.Framework;

namespace TurboCollections.Test
{
    public class TurboListTests
    {
        [Test]
        public void NewListIsEmpty()
        {
            var list = new TurboList<int>();
            Assert.Zero(list.Count);
        }

        [Test]
        public void AddingAnElementIncreasesCountToOne()
        {
            var list = new TurboList<int>();
            list.Add(5);
            Assert.AreEqual(1, list.Count);
        }
        
        [Test, TestCase(5), TestCase(7)]
        public void AddingMultipleElementsIncreasesTheCount(int numberOfElements)
        {
            var list = new TurboList<int>();
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(5);
            }
            Assert.AreEqual(numberOfElements, list.Count);
        }

        [Test]
        public void AnAddedElementCanBeGet()
        {
            var list = new TurboList<int>();
            list.Add(1337);
            Assert.AreEqual(1337, list.Get(0));
        }

        [Test]
        public void RemoveAllElements()
        {
            var list = new TurboList<int>();
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        // removes one item from the list. If the 4th item is removed, then the 5th item becomes the 4th, the 6th becomes the 5th and so on.
        public void RemoveOneSpecificItemAndMoveTheRestToTheLeftFromTheRightOfIt()
        {
            var list = new TurboList<int>(); 
            list.Add(5);
            list.Add(2);
            list.Add(6);
            list.RemoveAt(1);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void SeeIfItemExists()
        {
            var list = new TurboList<int>();
            list.Add(24);
            list.Add(4);
            list.Add(53);
            list.Add(10);
            list.Add(7);
            Assert.True(list.Contains(4));
        }
        
        [Test]
        public void SeeIfItemDoesntExist()
        {
            var list = new TurboList<int>();
            list.Add(24);
            list.Add(4);
            list.Add(53);
            list.Add(10);
            list.Add(7);
            Assert.False(list.Contains(5));
        }

        [Test]
        public void ReturnIndexOfGivenItem()
        {
            var list = new TurboList<int>();
            list.Add(24);
            list.Add(4);
            list.Add(53);
            list.Add(10);
            list.Add(7);
            Assert.AreEqual(1,list.IndexOf(4));
        }

        [Test]
        public void RemovesSpecificItem()
        {
            var list = new TurboList<int>();
            list.Add(24);
            list.Add(4);
            list.Add(53);
            list.Add(10);
            list.Add(7);
            list.Remove(53);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void AddARangeOfItems()
        {
            IEnumerable<int> itemsToAdd = new[] {24, 4, 53};
            var list = new TurboList<int>();
            list.Add(10);
            list.Add(7);
            list.Add(1);
            list.AddRange(itemsToAdd);
            
            Assert.AreEqual(6, list.Count);
        }
        
        [Test]
        public void AddRangeSingleShouldWork()
        {
            IEnumerable<int> itemsToAdd = new[] {666};
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.AddRange(itemsToAdd);
            
            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list.Contains(666));
        }
    }
}
