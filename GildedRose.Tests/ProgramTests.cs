namespace GildedRose.Tests;

public class ProgramTests
{
    Program app;

    public ProgramTests()
    {
        app = new Program();
    }

    [Fact]
    public void Standard_Item_Updated_Correctly() 
    {
        var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }}                  
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(19);
    }
}