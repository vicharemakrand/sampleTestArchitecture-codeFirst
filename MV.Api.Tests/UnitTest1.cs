using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MV.Prometric.EntityModels;
using MV.Prometric.IDomainServices;
using MV.Prometric.ViewModels;
using MV.Test.Api.Controllers;

namespace MV.Api.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(repo => repo.GetAll())
                .Returns(new List<VehicleViewModel> { new VehicleViewModel { }, new VehicleViewModel { } });
            var controller = new ValuesController(mockService.Object);
             var result = controller.Get();
            Assert.IsInstanceOfType(result, typeof(List<VehicleViewModel>));
            Assert.AreEqual(2, result.Count);
        }
    }
}
