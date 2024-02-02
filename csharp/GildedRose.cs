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
                if (IsLegendary(item))
                {
                    //Nothing need be done here
                }
                else if (IsValueIncreaseItem((item)))
                {
                    item.Quality = int.Min(50, item.SellIn switch
                    {
                        > 0 => item.Quality + 1,
                        <= 0 => item.Quality + 2
                    });
                    --item.SellIn;
                }
                else if (IsBackstagePass(item))
                {
                    item.Quality = item.SellIn switch
                    {
                        > 10 =>
                            item.Quality + 1,
                        <= 10 and > 5 =>
                            item.Quality + 2,
                        <= 5 and > 0 =>
                            item.Quality + 3,
                        <= 0 =>
                            0
                    };
                    --item.SellIn;
                }
                else if (IsConjuredItem(item))
                {
                    item.Quality = item.SellIn switch
                    {
                        > 0 => int.Max(0, item.Quality - 2),
                        <= 0 => int.Max(0, item.Quality - 4)
                    };
                    --item.SellIn;
                }
                else
                {
                    item.Quality = item.SellIn switch
                    {
                        > 0 => int.Max(0, item.Quality - 1),
                        <= 0 => int.Max(0, item.Quality - 2)
                    };
                    --item.SellIn;
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

        /// <summary>
        /// Check if an item is Conjured
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns></returns>
        public static bool IsConjuredItem(Item item)
        {
            return item.Name.StartsWith("Conjured");
        }
    }
}
