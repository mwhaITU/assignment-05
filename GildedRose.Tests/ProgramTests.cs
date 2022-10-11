using System.Reflection;

namespace GildedRose.Tests;

public class ProgramTests
{
    Program app;

    public ProgramTests()
    {
        app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }}                  
        };
    }

        [Fact]
    public void Standard_Item_Updated_Correctly_shouldBe_minus_one() 
    {
        //Act
        app.UpdateQuality();

        //Assert
        app.Items[0].Quality.Should().Be(19);
    }


    [Fact]
    public void Quality_Cant_be_negative(){
        //Act
        for (var i = 0; i < 22; i++){
            app.UpdateQuality();
        }

        //Assert
        app.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void SellDatePassed_quality_degrades_twice_as_fast(){
        //Act
        for (var i = 0; i < 12; i++){
            app.UpdateQuality();
        }

        //Assert
        app.Items[0].Quality.Should().Be(6); //quality now degresses wih -2 after SellIn is done
    }

    [Fact]
    public void Standard_Item_Updated_Once_Correctly() 
    {
        app.UpdateQuality();

        app.Items[0].SellIn.Should().Be(9);
        app.Items[0].Quality.Should().Be(19);
    }

    [Fact]
    public void Brie_Item_Updated_Once_Correctly() 
    {
        app.UpdateQuality();

        app.Items[1].SellIn.Should().Be(1);
        app.Items[1].Quality.Should().Be(1);
    }

    [Fact]
    public void Legendary_Item_Updated_Once_Correctly() 
    {
        app.UpdateQuality();

        app.Items[2].SellIn.Should().Be(0);
        app.Items[2].Quality.Should().Be(80);
    }

    [Fact]
    public void Backstage_Pass_Item_After_One_Update_Updated_Correctly() 
    {
        app.UpdateQuality();

        app.Items[3].SellIn.Should().Be(14);
        app.Items[3].Quality.Should().Be(21);
    }

    [Fact]
    public void Backstage_Pass_Item_After_Multiple_Updates_Updated_Correctly() 
    {
        for(int i = 0; i < 14; i++) 
        {
            app.UpdateQuality();
        }

        app.Items[3].SellIn.Should().Be(1);
        app.Items[3].Quality.Should().Be(47);
    }

    [Fact]
    public void Backstage_Pass_Item_After_SellIn_Depleted_Updated_Correctly() 
    {
        for(int i = 0; i < 16; i++) 
        {
            app.UpdateQuality();
        }

        app.Items[3].SellIn.Should().Be(-1);
        app.Items[3].Quality.Should().Be(0);
    }

    [Fact]
    public void Brie_Item_After_More_Than_Fifty_Updates_Updated_Correctly() 
    {
        for(int i = 0; i < 60; i++) 
        {
            app.UpdateQuality();
        }

        app.Items[1].SellIn.Should().Be(-58);
        app.Items[1].Quality.Should().Be(50);
    }

    [Fact]
    public void Conjured_Item_After_Updated_Once_Correctly() 
    {
        app.UpdateQuality();

        app.Items[4].SellIn.Should().Be(2);
        app.Items[4].Quality.Should().Be(4);
    }

    [Fact]
    public void Main_Prints_Correct_Output() 
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        var output = writer.GetStringBuilder().ToString().TrimEnd();
        var readMe = File.ReadAllText("Readme.txt");
        output.Should().Be(readMe);
    }
}