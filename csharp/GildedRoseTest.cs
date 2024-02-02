using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// Check value increase item (e.g. Aged Brie) special handling
        /// </summary>
        [Test]
        public void ValueIncreaseItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };

            var sellInValues = Enumerable.Range(-20, 31).Reverse().ToArray();
            var values = new[] { 10,11,12,13,14,15,16,17,18,19,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,50,50,50,50,50,50,50};

            var rose = new GildedRose(items);
            for (var i = 0; i < 30; ++i)
            {
                Assert.AreEqual(sellInValues[i], items[0].SellIn);
                Assert.AreEqual(values[i], items[0].Quality);
                rose.UpdateQuality();
            }
            Assert.AreEqual("Aged Brie", items[0].Name);
        }

        /// <summary>
        /// Check regular item handling
        /// </summary>
        [Test]
        public void RegularItem()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 17 }
            };

            var sellInValues = Enumerable.Range(-25, 31).Reverse().ToArray();
            var qualityValues = new[] {17,16, 15, 14, 13, 12, 10, 8, 6, 4, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            var rose = new GildedRose(items);
            for (var i = 0; i < 30; ++i)
            {
                Assert.AreEqual(sellInValues[i], items[0].SellIn);
                Assert.AreEqual(qualityValues[i], items[0].Quality);
                rose.UpdateQuality();
            }
            Assert.AreEqual("Elixir of the Mongoose", items[0].Name);
        }

        /// <summary>
        /// Check backstage pass item handling.
        /// </summary>
        [Test]
        public void BackstagePassItem()
        {
            IList<Item> items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }
            };

            var sellInValues = Enumerable.Range(-15, 31).Reverse().ToArray();
            var qualityValues = new[] {20,21,22,23,24,25,27,29,31,33,35,38,41,44,47,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

            var rose = new GildedRose(items);
            for (var i = 0; i < 30; ++i)
            {
                Assert.AreEqual(sellInValues[i], items[0].SellIn);
                Assert.AreEqual(qualityValues[i], items[0].Quality);
                rose.UpdateQuality();
            }
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
        }

        /// <summary>
        /// Check conjured item handling.
        /// </summary>
        [Test]
        public void ConjuredItem()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Conjured Mana Biscuit", SellIn = 6, Quality = 10 }
            };

            var sellInValues = Enumerable.Range(-24, 31).Reverse().ToArray();
            var qualityValues = new[] {10,8,6,4,2,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0, 0};

            var rose = new GildedRose(items);
            for (var i = 0; i < 30; ++i)
            {
                Assert.AreEqual(sellInValues[i], items[0].SellIn);
                Assert.AreEqual(qualityValues[i], items[0].Quality);
                rose.UpdateQuality();
            }
            Assert.AreEqual("Conjured Mana Biscuit", items[0].Name);
        }

        /// <summary>
        /// Check IsBackstagePass to make sure it correctly assesses the item
        /// </summary>
        [Test]
        public void TestIsBackstagePass()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
            };
            var rose = new GildedRose(items);

            Assert.False(GildedRose.IsBackstagePass(items[0]));
            Assert.True(GildedRose.IsBackstagePass(items[1]));
        }

        /// <summary>
        /// Check IsLegendary test to make sure it correctly assesses the item
        /// </summary>
        [Test]
        public void TestIsLegendary()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };

            var rose = new GildedRose(items);

            Assert.False(GildedRose.IsLegendary(items[0]));
            Assert.True(GildedRose.IsLegendary(items[1]));
        }

        /// <summary>
        /// Check IsLinearIncrease to make sure it correctly identifies the item
        /// </summary>
        [Test]
        public void TestIsValueIncrease()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 69}
            };

            var rose = new GildedRose(items);

            Assert.False(GildedRose.IsValueIncreaseItem(items[0]));
            Assert.True(GildedRose.IsValueIncreaseItem(items[1]));
        }

        [Test]
        public void TestIsConjured()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Conjured Mana Biscuit", SellIn = 6, Quality = 69}
            };

            var rose = new GildedRose(items);

            Assert.False(GildedRose.IsConjuredItem(items[0]));
            Assert.True(GildedRose.IsConjuredItem(items[1]));
        }
    }
}
