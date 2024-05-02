using APIModels.InputModels;
using Domain;
using IData;
using Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.LogicTest
{
    [TestClass]
    public class CategoryServiceLogicTest
    {
        private Mock<IGenericRepository<CategoryService>> _mockRepository;
        private CategoryServiceLogic _categoryServiceLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IGenericRepository<CategoryService>>();
            _categoryServiceLogic = new CategoryServiceLogic(_mockRepository.Object);
        }

        [TestMethod]
        public void ValidCreateCategoryService()
        {
            // Arrange
            var categoryServiceRequest = new CategoryServiceRequest("Maintenance", 1);
            var categoryService = new CategoryService { Id = 1, Name = "Maintenance" };

            _mockRepository.Setup(repo => repo.Insert(It.IsAny<CategoryService>())).Returns(categoryService);

            // Act
            var result = _categoryServiceLogic.CreateCategoryService(categoryServiceRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Maintenance", result.Name);
            Assert.AreEqual(1, result.Id);
        }

    }
}
