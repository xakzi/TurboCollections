using System;
using NUnit.Framework;
using TurboCollections;

namespace TurboCollections.Test
{
    [TestFixture]
    public class TurboQueueTests
    {
        [Test]
        public void NewEmptyQueueList()
        {
            var newQueueList = new TurboQueue<int>();
            Assert.AreEqual(0, newQueueList.Count);
        }

        [Test]
        public void AddToQueueList()
        {
            TurboQueue<int> queueList = new TurboQueue<int>();
            queueList.Enqueue(1);
            queueList.Enqueue(3);
            queueList.Enqueue(3);
            queueList.Enqueue(7);
            Assert.AreEqual(4, queueList.Count);
        }

        [Test]
        public void PeekFirstItem()
        {
            TurboQueue<int> queueList = new TurboQueue<int>();
            queueList.Enqueue(1);
            queueList.Enqueue(3);
            queueList.Enqueue(3);
            queueList.Enqueue(7);
            Assert.AreEqual(1, queueList.Peek());
        }
        [Test]
        public void DequeueRemovesFirstItem()
        {
            TurboQueue<int> queueList = new TurboQueue<int>();
            queueList.Enqueue(1);
            queueList.Enqueue(3);
            queueList.Enqueue(3);
            queueList.Enqueue(7);
            Assert.AreEqual(1, queueList.Dequeue());
            queueList.Dequeue();
            Assert.AreEqual(3, queueList.Dequeue());
        }

        [Test]
        public void ClearQueueList()
        {
            TurboQueue<int> queueList = new TurboQueue<int>();
            queueList.Enqueue(1);
            queueList.Enqueue(3);
            queueList.Enqueue(3);
            queueList.Enqueue(7);
            queueList.Clear();
            Assert.AreEqual(0, queueList.Count);
        }
    }
}
