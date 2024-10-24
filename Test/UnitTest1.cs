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
    
    [Test]
    public void ItemsFitOnSamePage_ReturnsOne()
    {
        var list = Enumerable.Range(0, 6).ToList();
        var paginationHelper = new PaginationHelper<int>(list, 6);
        Assert.That(paginationHelper.PageCount, Is.EqualTo(1));
    }
}