public class Limited : Item, IUpdateable
{
    public void update()
    {
        var multiplier = this.isConjured() ? 2 : 1;
        Quality += multiplier * (SellIn switch
        {
            <= 5 => 3,
            <= 10 => 2,
            _ => 1,
        });
        Quality = Math.Min(50, Quality);
        SellIn -= 1;
        Quality = SellIn < 0 ? 0 : Quality;
    }
}