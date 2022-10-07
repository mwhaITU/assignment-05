namespace GildedRose.Tests;

public class ProgramTests
{
    Program app;

    public ProgramTests()
    {
        app = new Program();
    }

    [Fact]
    public void Standard_Item_Updated_Correctly_shouldBe_minus_one() 
    {
        //Arange
        var app = new Program()
        {
            Items = new List<Item>
                                          {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }}                  
        };
        
        //Act
        app.UpdateQuality();

        //Assert
        app.Items[0].Quality.Should().Be(19);
    }


    [Fact]
    public void Quality_Cant_be_negative(){
        //Arrange
        var app = new Program()
        {
            Items = new List<Item>
                                          {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }}                  
        };

        //Act
        for (var i = 0; i < 22; i++){
            app.UpdateQuality();
        }

        //Assert
        app.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void SellDatePassed_quality_degrades_twice_as_fast(){
          //Arrange
        var app = new Program()
        {
            Items = new List<Item>
                                          {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }}                  
        };

        //Act
        for (var i = 0; i < 12; i++){
            app.UpdateQuality();
        }

        //Assert
        app.Items[0].Quality.Should().Be(6); //quality now degresses wih -2 after SellIn is done
    }
}