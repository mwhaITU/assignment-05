public static class Extensions
{
    // It would have been preferrable to add an isConjured property to Item, but since we cannot change Item, this is the best we can do.
    public static bool isConjured(this Item item)
    {
        return item.Name.StartsWith("Conjured");
    }

    public static void defaultUpdate(this Item item)
    {
        var multiplier = item.isConjured() ? 2 : 1;
        item.Quality -= multiplier * (item.SellIn <= 0 ? 2 : 1);
        item.Quality = Math.Max(item.Quality, 0);
        item.SellIn -= 1;
    }
}