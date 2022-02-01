using System;
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

        [TestCase(5), TestCase(7)]
        public void AddingMultipleElementsIncreasesTheCount(int numberOfElements)
        {
            var list = new TurboList<int>();
            for(int i = 0; i < numberOfElements; i++)
                list.Add(5);
            Assert.AreEqual(numberOfElements, list.Count);
        }

        [Test]
        public void AnAddedElementCanBeGotten()
        {
            var list = new TurboList<int>();
            list.Add(1337);
            Assert.AreEqual(1337, list.Get(0));
        }
        
        [Test]
        public void MultipleAddedElementCanBeGotten()
        {
            var (numbers, list) = CreateTestData();
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }
        
        [TestCase(666)]
        public void ExistingItemsCanBeOverwrittenBySetting(int item)
        {
            var (_, list) = CreateTestData();
            list.Set(2, item);
            Assert.AreEqual(item, list.Get(2));
        }
        
        [Test]
        public void CanNotBeExtendedBySetting()
        {
            const int setIndex = 100;
            var (_, list) = CreateTestData();
            Assert.Throws<IndexOutOfRangeException>(()=>list.Set(setIndex, 666));
        }

        public class WhenClearing
        {
            [Test]
            public void ItIsEmpty()
            {
                var (_, list) = CreateTestData();
                list.Clear();
                Assert.Zero(list.Count);
            }
        
            [Test]
            public void AddingStartsAtIndexZero()
            {
                var (_, list) = CreateTestData();
            
                list.Clear();
                list.Add(5);
            
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(5, list.Get(0));
            }
        
            [Test]
            public void ItemsAreResetToDefault()
            {
                // given
                var (_numbers, list) = CreateTestData();
            
                // when
                list.Clear();
            
                // then
                for (int i = 0; i < _numbers.Length; i++)
                {
                    Assert.Zero(list.Get(i));
                }
            }
        }

        [Test]
        public void CountIsReducedWhenRemovingAt()
        {
            var (_numbers, list) = CreateTestData();

            list.RemoveAt(2);

            Assert.AreEqual(_numbers.Length - 1, list.Count);
        }
        
        [Test]
        public void ItemsAreMovedForwardWhenRemovingAt()
        {
            var (_numbers, list) = CreateTestData();

            list.RemoveAt(2);
            
            for(int i = 2; i < _numbers.Length-1; i++)
                Assert.AreEqual(_numbers[i+1], list.Get(i), $"Wrong item at index {i}");
        }
        
        static (int[] numbers, TurboList<int>) CreateTestData()
        {
            int[] numbers = { 5, 7, -12, 9, 3, -4, 104, 12 };
            var list = new TurboList<int>();
            foreach(var number in numbers)
                list.Add(number);

            return (numbers, list);
        }
    }
}