public class ValueIncrease : Item, IUpdateable
{
    public void update()
    {
        var multiplier = this.isConjured() ? 2 : 1;
        Quality += multiplier * (SellIn < 0 ? 2 : 1);
        Quality = Math.Min(50, Quality);
        SellIn -= 1;
    }
}