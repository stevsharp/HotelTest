using System;
using ApplicationLayer.DTO;
using ApplicationLayer.Hotel;
using HotelClient.Controllers;
using InfrastructureLayer.Data;
using InfrastructureLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelClient.Tests.Controllers
{
    [TestClass]
    public class HotelControllerTest
    {
        [TestMethod]
        public void Create()
        {
            IHotelRepository hotelRepository = new HotelRepository(new HotelDBContext());

            IHotelService srv = new HotelService(hotelRepository);

            var controller = new HotelController(srv);

            // Act
            controller.PostHotel(new HotelDTO() { Name = "Test" , StarRating =  1 , Address =  "Test Address"});

            // Assert
        }

        [TestMethod]
        public void Update()
        {
            IHotelRepository hotelRepository = new HotelRepository(new HotelDBContext());

            IHotelService srv = new HotelService(hotelRepository);

            var controller = new HotelController(srv);

            // Act
            controller.PutHotel(1, new HotelDTO() { Name = "Test 1", StarRating = 1, Address = "Test Address 1" });
        }

        [TestMethod]
        public void Delete()
        {
            IHotelRepository hotelRepository = new HotelRepository(new HotelDBContext());

            IHotelService srv = new HotelService(hotelRepository);

            var controller = new HotelController(srv);

            // Act
            controller.DeleteHotel(1);
        }
    }
}
