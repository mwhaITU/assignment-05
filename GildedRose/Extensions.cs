public static class Extensions
{
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