using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Demo.CarTrade.API.Controllers;
using Demo.CarTrade.Interfaces;
using System.Net.Http;
using System.Web.Http;
using Demo.CarTrade.Entity;
using System.Web.Http.Results;
using System.Threading.Tasks;
using Demo.CarTrade.Repository;

namespace Demo.CarTrade.API.Tests
{
    [TestClass]
    public class BrandControllerTests
    {
        [TestMethod]
        public async Task Test_Invalid_GetBrand()
        {
            var mockClient = new Mock<IBrandManagementService>();
            var controller = new BrandController(mockClient.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = await controller.Get(1011111111);
            Assert.AreEqual(Convert.ToInt32(response.StatusCode), 204);

            //// IMPLEMENTATION IN PROGRESS
        }

        //// IMPLEMENTATION IN PROGRESS /////////////////////

    }
}
