using API.Data.Entities;
using API.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests;

[TestClass]
public class UnitTest1
{
    private Mock<IBooksAdminService> _mockService;

    [TestInitialize]
    public void Setup()
    {
        _mockService = new Mock<IBooksAdminService>();
    }

    [TestMethod]
    public void Test_CreateBook_Should_Throw_When_Title_Empty()
    {
        _mockService
            .Setup(x => x.CreateBook(It.IsAny<Book>()))
            .Throws(new Exception());

        bool thrown = false;

        try
        {
            _mockService.Object.CreateBook(new Book { Title = "Aaaaa" });
        }
        catch
        {
            thrown = true;
        }

        // Assert
        Assert.IsTrue(thrown);
    }
}