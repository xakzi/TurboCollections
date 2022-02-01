using NUnit.Framework;

namespace TurboCollections.Test
{
    [TestFixture]
    public class TurboStackTests
    {
        [Test]
        public void HasEmptyConstructor()
        {
            new TurboStack<int>();
            Assert.Pass();
        }

        public class GivenANewStack
        {
            private static TurboStack<int> Give()
            {
                return new TurboStack<int>();
            }
            
            [Test]
            public void ItHasACountOfZero()
            {
                Assert.Zero(Give().Count);
            }
            
            public class WhenPushing
            {
                private static TurboStack<int> GiveAndPush(int count)
                {
                    var stack = Give();
                    for (int i = 0; i < count; i++)
                    {
                        stack.Push(3);
                    }
                    return stack;
                }
                
                [TestCase(1), TestCase(5), TestCase(1337)]
                public void ItIncreasesCount(int count)
                {
                    var stack = GiveAndPush(count);
                    
                    Assert.AreEqual(count, stack.Count);
                }

                [TestCase(1, -7)]
                [TestCase(5, 0)]
                [TestCase(1337, 777)]
                public void TheLatestItemCanBePeeked(int count, int item)
                {
                    var stack = GiveAndPush(count);
                    stack.Push(item);
                    Assert.AreEqual(item, stack.Peek());
                }
                
                [TestCase(1, -7)]
                [TestCase(5, 0)]
                [TestCase(1337, 777)]
                public void TheLatestItemCanBePopped(int count, int item)
                {
                    var stack = GiveAndPush(count);
                    stack.Push(item);
                    Assert.AreEqual(item, stack.Pop());
                }
            }
        }

        public class GivenAStackWithContent
        {
            private static TurboStack<int> Give(int count)
            {
                var stack = new TurboStack<int>();
                for (int i = 0; i < count; i++)
                {
                    stack.Push(3);
                }
                return stack;
            }

            [Test]
            public void CountIsNotZero()
            {
                var stack = Give(7);
                Assert.NotZero(stack.Count);
            }

            public class WhenPopping
            {
                [TestCase(1)]
                [TestCase(7)]
                [TestCase(999)]
                public void ItDecreasesCount(int count)
                {
                    var stack = Give(count);
                    stack.Pop();
                    Assert.AreEqual(count - 1, stack.Count);
                }
            }
        }

        [Test]
        public void PassesSmokeTest()
        {
            var stack = new TurboStack<int>(); // --
            Assert.Zero(stack.Count);
            
            stack.Push(5); // 5
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(5, stack.Peek());
            
            stack.Push(7);// 5-7
            Assert.AreEqual(7, stack.Pop()); // 5
            
            stack.Push(9); // 5-9
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(9, stack.Pop()); // 5
            Assert.AreEqual(1, stack.Count);
            
            Assert.AreEqual(5, stack.Pop()); // --
            Assert.Zero(stack.Count);
        }
    }
}