using System;
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
        public void AnAddedElementCanBeGotten()
        {
            int[] numbers = { 5, 7, -12, 9, 3, -4, 104, 12 };
            var list = new TurboList<int>();
            foreach (var number in numbers)
            {
                list.Add(number);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }
        
        [Test]
        public void ExistingItemsCanBeOverwrittenBySetting()
        {
            int[] numbers = { 5, 7, -12, 9, 3, -4, 104, 12 };
            var list = new TurboList<int>();
            foreach (var number in numbers)
            {
                list.Add(number);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }

        [TestCase(666)]
        public void ExistingItemsCanBeOverwrittenBySetting2(int item)
        {
            var (_, list) = CreateTestData();
            list.Set(2, item);
            Assert.AreEqual(item,list.Get(2));
        }
        
        [Test]
        public void CanNotBeExtendedBySetting()
        {
            const int setIndex = 100;
            var (_, list) = CreateTestData();
            Assert.Throws<IndexOutOfRangeException>(() => list.Set(setIndex, 666));
        }

        [Test]
        public void MultipleAddedElementCanBeGotten()
        {
            var (numbers , list) = CreateTestData();
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }

        [Test]
        public void IsEmptyAfterClearing()
        {
            /*var list = new TurboList<int>();
            list.Clear();
            Assert.AreEqual(0, list.Count);*/

            //mark edits
            var (_, list) = CreateTestData();
            list.Clear();
            Assert.Zero(list.Count);
        }

        [Test]
        public void FirstItemIsAddedAtIndexZeroAfterClearing()
        {
            var (_, list) = CreateTestData();
            list.Clear();
            list.Add(5);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list.Get(0));
        }
        
        [Test]
        public void ItemsAreClearedWhenClearing()
        {
            //given
            var (_numbers, list) = CreateTestData();
            //when
            list.Clear();
            //then
            for (int i = 0; i < _numbers.Length; i++)
            {
                Assert.Zero(list.Get(i));
            }
        }
        (int[]numbers, TurboList<int>) CreateTestData()
        {
            int[] numbers = { 5, 7, -12, 9, 3, -4, 104, 12 };
            var list = new TurboList<int>();
            foreach (var number in numbers)
            {
                list.Add(number);
            }

            return (numbers, list);
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
        public void CountIsReducesWhenRemovingAt()
        {
            var (_numbers, list) = CreateTestData();
            list.RemoveAt(2);
            Assert.AreEqual(_numbers.Length-1, list.Count);
        }
        
        [Test]
        public void ItemsAreMovedForwardWhenRemovingAt()
        {
            var (_numbers, list) = CreateTestData();
            list.RemoveAt(2);
            for (int i = 2; i < _numbers.Length-1; i++)
            {
                Assert.AreEqual(_numbers[i+1], list.Get(i), $"Wrong item at index {i}");
            }
            
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
            Assert.True(list.Contains(5));
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
            Assert.AreEqual(0,list.IndexOf(4));
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
            IEnumerable<int> items = new[] {24, 4, 53};
            var list = new TurboList<int>();
            list.Add(10);
            list.Add(7);
            list.Add(1);
            list.AddRange(items);
            
            Assert.AreEqual(6, list.Count);
        }
        
        [Test]
        public void AddRangeSingleShouldWork()
        {
            IEnumerable<int> items = new[] {666};
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.AddRange(items);
            
            Assert.AreEqual(4, list.Count);
        }
    }
}
