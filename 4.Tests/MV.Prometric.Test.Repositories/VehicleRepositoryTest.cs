using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using MV.Prometric.Repositories;
using System.Data.Entity;
using System.Linq;

namespace MV.Prometric.Test.Repositories
{
    [TestClass]
    public class VehicleRepositoryTest
    {
        IQueryable<Vehicle> vehicleList ;
        Mock<IUnitOfWork> unitOfWork;
        [TestInitialize]
        public void InitializeTest()
        {
            vehicleList = FizzWare.NBuilder.Builder<Vehicle>.CreateListOfSize(10).Build().AsQueryable();
            unitOfWork = new Mock<IUnitOfWork>();
        }

        [TestCleanup]
        public void ClearTest(){ }

        private Mock<IDataContext> GetDataContext()
        {
            var dataContext = new Mock<IDataContext>();
            var dbSet = new Mock<DbSet<Vehicle>>();
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(vehicleList.GetEnumerator());
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(vehicleList.Provider);
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(vehicleList.Expression);
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(vehicleList.ElementType);
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(vehicleList.GetEnumerator);

           // dataContext.Setup(x => x.Vehicles).Returns(dbSet.Object);
            dataContext.Setup(x => x.DbSet<Vehicle>()).Returns(dbSet.Object);

            return dataContext;
        }


        [TestMethod]
        public void GetVehicles_Should_ReturnsRecords()
        {
            //Arrange
            var expected = 10;
            var dataContext = GetDataContext();
            unitOfWork.Setup(o => o.DataContext).Returns(dataContext.Object);
            unitOfWork.Setup(o => o.VehicleRepository).Returns(new VehicleRepository { DbContext = dataContext .Object});

            //Act
            var vehicles = unitOfWork.Object.VehicleRepository.GetAll();
            //Assert
            Assert.AreEqual(expected, vehicleList.Count());
        }

        [TestMethod]
        public void SaveShouldReturnSavedId()
        {
            var expected = 10;
            var dataContext = GetDataContext();
            dataContext.Setup(x => x.Vehicles.Add(It.IsAny<Vehicle>())).Returns((Vehicle u) => u);

            unitOfWork.Setup(o => o.DataContext).Returns(dataContext.Object);
            unitOfWork.Setup(o => o.VehicleRepository).Returns(new VehicleRepository { DbContext = dataContext.Object });

            var vehicle = Builder<Vehicle>.CreateNew().With(s => s.Id = 0).Build();
            unitOfWork.Object.VehicleRepository.Insert(vehicle);
            unitOfWork.Object.VehicleRepository.Save();
            Assert.AreNotEqual(11, vehicle.Id);
        }
    }
}
