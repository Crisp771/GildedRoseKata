namespace GildedRoseKata
{
    internal static class ItemUpdateConstants
    {
        internal const int MaxQuality = 50;
    }
    internal class DefaultItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality > 0) item.Quality -= 1; // Quality decreses per day
            item.SellIn -= 1; // Sell in value decreases per day
            if (item.SellIn < 0 && item.Quality > 0) item.Quality -= 1; // Items past their sellby date decrease twice as fast until quality is 0.
        }
    }

    internal class LegendaryItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            // Noop.  Legendary items never have to be sold or change in quality.
        }
    }

    internal class AgedBrieItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality < ItemUpdateConstants.MaxQuality) item.Quality += 1; // Aged Brie increases in quality as it ages to a max of 50
            item.SellIn -= 1;  // Sell in value decreases per day
            if (item.SellIn < 0 && item.Quality < ItemUpdateConstants.MaxQuality) item.Quality += 1;  // Past it's sellin day, aged brie increases in quality twice as fast.
        }
    }

    internal class BackstagePassItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality < ItemUpdateConstants.MaxQuality) item.Quality += 1; // Like Aged Brie, backstage passes increases in quality as it ages 
            if (item.SellIn < 11 && item.Quality < ItemUpdateConstants.MaxQuality) item.Quality += 1; // With 10 days to go quality increase per day goes to 2
            if (item.SellIn < 6 && item.Quality < ItemUpdateConstants.MaxQuality) item.Quality += 1;  // With 5 days to go quality increase per day goes to 3
            item.SellIn -= 1;  // Sell in value decreases per day
            if (item.SellIn < 0) item.Quality = 0; // After the concert, quality drops to 0
        }
    }

    internal class ConjuredItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality > 0) item.Quality -= 2; // Quality decreases twice as fast as normal items per day
            item.SellIn -= 1; // Sell in value decreases per day
            if (item.SellIn < 0 && item.Quality > 0) item.Quality -= 2; // Items past their sellby date decrease twice as fast until quality is 0.

        }
    }
}