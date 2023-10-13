namespace GildedRoseKata
{
    internal class ItemUpdateFactory
    {
        // Known Items
        private const string legendary = "Sulfuras, Hand of Ragnaros";
        private const string brie = "Aged Brie";
        private const string backstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string conjured = "Conjured";

        internal static IItemUpdater Create(Item item)
        {
            return item.Name switch
            {
                legendary => new LegendaryItemUpdater(),
                brie => new AgedBrieItemUpdater(),
                backstagePass => new BackstagePassItemUpdater(),
                string s when s.StartsWith(conjured) => new ConjuredItemUpdater(),  // Leave open just in case more conjured items appear
                _ => new DefaultItemUpdater(),
            };
        }
    }
}
