using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// Check Aged Brie special handling (1 cycle)
        /// </summary>
        [Test]
        public void AgedBrieValue1()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 25 } };

            var rose = new GildedRose(items);

            rose.UpdateQuality();
            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(26, items[0].Quality);
        }

        /// <summary>
        /// Check Aged Brie special handling (30 cycles)
        /// </summary>
        [Test]
        public void AgedBrieValue30()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };

            var rose = new GildedRose(items);

            for (var i = 0; i < 30; ++i)
            {
                rose.UpdateQuality();
            }

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(-20, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);
        }
    }
}
