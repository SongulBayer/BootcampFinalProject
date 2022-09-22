//using Moq;
//using PycApi.Data;
//using System.Collections.Generic;
//using Xunit;

//namespace FinalProject.UnitTest
//{
//    [TestClass]
//    public class BrandTest
//    {
//        private readonly Mock<IHibernateRepository<Book>> _mockRepo;
//        private readonly BookController _controller;


//        public MoqTest()
//        {
//            _mockRepo = new Mock<IHibernateRepository<Book>>();
//            _controller = new BookController(_mockRepo.Object);

//            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Book>() { new Book { Title = "Doly" }, new Book { Title = "Mopsa" } });
//        }

//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}
