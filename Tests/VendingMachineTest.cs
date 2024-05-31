namespace Tests;

using Service.Services;

public class VendingMachineTest
{
    private VendingMachine _vendingMachine;

    public VendingMachineTest()
    {
        _vendingMachine = new VendingMachine(capacity: 100);
        _vendingMachine.AddItem(new Product("Chips", 2.0M));
        _vendingMachine.AddItem(new Product("Soda", 1.25M));
        _vendingMachine.AddItem(new Product("Milk", 2.5M));
    }

    [Fact]
    public void AddItemToVendingMachine_ListOfItems_ReturnNumberOfItemsStored()
    {
        var vendingMachine = new VendingMachine(2);

        vendingMachine.AddItem(new Product("Bread", 0.5M));
        vendingMachine.AddItem(new Product("Cookies", 1.0M));

        Assert.Equal(2, vendingMachine.Items.Count);
    }

    [Theory]
    [InlineData ("Chips", 1.99)]
    [InlineData ("Milk", 0.0)]
    [InlineData ("Soda", 1.2)]
    public void BuyItemFromVendingMachine_NotEnoughMoneyToBuyProduct_ThrowsException(string productName, double money)
    {
        Assert.Throws<Exception>(() => _vendingMachine.BuyItem(productName, (decimal)money));
    }

    [Theory]
    [InlineData("Chips", 2.1, 0.1)]
    [InlineData("Chips", 2.0, 0.0)]
    [InlineData("Milk", 3.0, 0.5)]
    [InlineData("Milk", 2.5, 0.0)]
    [InlineData("Soda", 2.0, 0.75)]
    [InlineData("Soda", 1.25, 0.0)]
    public void BuyItemFromVendingMachine_EnoughMoneyToBuyProduct_ReturnChange(string productName, double money, double expectedChange)
    {
        var actualChange = _vendingMachine.BuyItem(productName, (decimal)money);
        Assert.Equal((decimal)expectedChange, actualChange, precision: 2);
    }

    [Fact]
    public void AddItemToVendingMachine_MoreItemsThanItSupports_ThrowsException()
    {
        var vendingMachine = new VendingMachine(2);

        vendingMachine.AddItem(new Product("Bread", 0.5M));
        vendingMachine.AddItem(new Product("Cookies", 1.0M));

        Assert.Throws<Exception>(() => vendingMachine.AddItem(new Product(" ", 0.0m)));
    }
}