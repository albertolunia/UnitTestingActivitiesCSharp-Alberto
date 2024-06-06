namespace Atividade09.Tests;

public class ItemCollectionTests
{
    [Fact]
    public void AddItem_ItemEhNulo_RetornaArgumentException()
    {
        var itemCollection = new ItemCollection();
        Item? item = null;

        // Act
        var act = () => itemCollection.AddItem(item);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void AddItem_ItemNaoEhNulo_AdicionaItemAColecao()
    {
        // Arrange
        var itemCollection = new ItemCollection();
        var item = new Item("Item 1");

        // Act
        itemCollection.AddItem(item);

        // Assert
        Assert.Contains(item, itemCollection.GetItems());
    }

    [Fact]
    public void RemoveItem_ItemNaoEstaEmColecao_RetornaArgumentException()
    {
        // Arrange
        var itemCollection = new ItemCollection();
        var item = new Item("Item 1");

        // Act
        var act = () => itemCollection.RemoveItem(item);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void RemoveItem_ItemEstaNaColecao_RemoveItemDaColecao()
    {
        // Arrange
        var itemCollection = new ItemCollection();
        var item = new Item("Item 1");
        itemCollection.AddItem(item);

        // Act
        itemCollection.RemoveItem(item);

        // Assert
        Assert.DoesNotContain(item, itemCollection.GetItems());
    }


}
