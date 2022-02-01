using System;
using NUnit.Framework;

namespace TurboCollections.Test
{
    [TestFixture]
    public class TurboSortTests
    {
        
        private static TurboList<int> GiveUnordered()
        {
            var list = new TurboList<int>();
            list.Add(0);
            list.Add(3);
            list.Add(-12);
            list.Add(2);
            list.Add(1000);
            list.Add(-300);
            return list;
        }

        public class BubbleSort
        {
            [Test]
            public void OrdersAnUnorderedList()
            {
                var list = GiveUnordered();
                TurboSort.BubbleSort(list);
                CollectionAssert.IsOrdered(list);
            }
            
            public class Player : IComparable<Player>
            {
                public int score;

                public int CompareTo(Player other)
                {
                    if (ReferenceEquals(this, other)) return 0;
                    if (ReferenceEquals(null, other)) return 1;
                    return other.score.CompareTo(score);
                }

                public override string ToString()
                {
                    return base.ToString() + " Score: "+score;
                }
            }

            [Test]
            public void SortsPlayersCorrectly()
            {
                TurboList<Player> players = new TurboList<Player>();
                players.Add(new Player { score = 50 });
                players.Add(new Player { score = 0 });
                players.Add(new Player { score = 200 });
                players.Add(new Player { score = 1000 });
                players.Add(new Player { score = 12 });
                TurboSort.BubbleSort(players);
                CollectionAssert.IsOrdered(players);
            }
        }
        public class QuickSort
        {
            [Test]
            public void OrdersAnUnorderedList()
            {
                var list = GiveUnordered();
                TurboSort.QuickSort(list);
                CollectionAssert.IsOrdered(list);
            }
        }
    }
}