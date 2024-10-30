using PaginationHelper;

namespace Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Theory]
    [TestCase(0,0)]
    [TestCase(1,1)]
    [TestCase(6,6)]
    public void ItemCount_ReturnsNumberOfItems(int length, int expectedItemCount)
    {
        var list = Enumerable.Range(0, length).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 1);
        Assert.That(paginationHelper.ItemCount, Is.EqualTo(expectedItemCount));
    }
    
    [Theory]
    [TestCase(2, 3)]
    [TestCase(5, 2)]
    [TestCase(6, 1)]
    public void PageCount_ReturnsNumberOfPagesRequired(int itemsPerPage, int expectedPageCount)
    {
        var list = Enumerable.Range(0, 6).ToList();
        var paginationHelper = new PaginationHelper<int>(list, itemsPerPage);
        Assert.That(paginationHelper.PageCount, Is.EqualTo(expectedPageCount));
    }
    
    [Theory]
     [TestCase(-1)]
     [TestCase(0)]
    public void InvalidItemsPerPage_ThrowsException(int itemsPerPage)
    {
        var list = Enumerable.Range(0, 6).ToList();
        Assert.Throws<ArgumentException>(() => new PaginationHelper<int>(list, itemsPerPage));
    }
    
    [Theory]
    [TestCase(0, 2)]
    [TestCase(1, 2)]
    [TestCase(3, 1)]
    public void PageItemCount_ReturnsNumberOfItemsOnPage(int pageIndex, int expectedItemCount)
    {
        var list = Enumerable.Range(0, 7).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 2);
        Assert.That(paginationHelper.PageItemCount(pageIndex), Is.EqualTo(expectedItemCount));
    }
    
    [Theory]
    [TestCase(4)]
    [TestCase(-1)]
    public void PageItemCount_ReturnsNegativeOneForInvalidPageIndex(int pageIndex)
    {
        var list = Enumerable.Range(0, 7).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 2);
        Assert.That(paginationHelper.PageItemCount(pageIndex), Is.EqualTo(-1));
    }
    
    [Test]
    public void PageIndex_FirstItem_ReturnsPageOne()
    {
        var list = Enumerable.Range(0, 7).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 2);
        Assert.That(paginationHelper.PageIndex(0), Is.EqualTo(1));
    }

    [Theory]
    [TestCase(7)]
    [TestCase(-2)]
    public void PageIndex_ItemIndexOutOfRange_ReturnsMinusOne(int itemIndex)
    {
        var list = Enumerable.Range(0, 7).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 2);
        Assert.That(paginationHelper.PageIndex(itemIndex), Is.EqualTo(-1));
    }
}