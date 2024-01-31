using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check if an item is legendary based on conditions.
        /// </summary>
        /// <param name="item">The Item to check.</param>
        /// <returns></returns>
        public static bool IsLegendary(Item item)
        {
            return item.Quality >= 80;
        }

        /// <summary>
        /// Check if an item is one whose value increases over time.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns></returns>
        public static bool IsValueIncreaseItem(Item item)
        {
            return item.Name == "Aged Brie";
        }

        /// <summary>
        /// Check if an item is backstage passes.
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns></returns>
        public static bool IsBackstagePass(Item item)
        {
            return item.Name.StartsWith("Backstage passes");
        }
    }
}
