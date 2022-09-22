using FluentAssertions;
using Moq;
using PycApi;
using PycApi.Controller;
using PycApi.Data;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Xunit;

namespace FinalProject.Test
{
    // Checking if the brand in the parameter exists
    public class BrandTest
    {
        private readonly Mock<IHibernateRepository<Brand>> _mockRepo;
        private readonly Mock<BrandController> _brandController;
        private readonly BrandController _controller;

        public BrandTest()
        {
            _mockRepo = new Mock<IHibernateRepository<Brand>>();
            _brandController = new Mock<BrandController>(_mockRepo.Object);
            //_controller = new BrandController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll());
        }
        [Fact]
        public void WhenAlreadyExistBrandNameIsGiven_InvalidOperationException_ShoulBeReturn()
        {
            var brand = new Brand() { BrandName = "AHUWARE" };
            FluentActions
                .Invoking(() => _brandController)
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Brand already exist");
            //Arrange
            var result = _controller.GetAll();
           //Assert
            Assert.IsType<List<Brand>>(result);
        }
    }
}