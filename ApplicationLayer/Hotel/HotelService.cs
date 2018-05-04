using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ApplicationLayer.DTO;
using InfrastructureLayer.Repositories;

namespace ApplicationLayer.Hotel
{
    public class HotelService : IHotelService
    {
        protected readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public bool CreateHotel(HotelDTO hotel)
        {
            try
            {
                _hotelRepository.CreateHotel(new InfrastructureLayer.Data.Hotel()
                {
                    Name= hotel.Name ,
                    Address = hotel.Address ,
                    StarRating = hotel.StarRating
                });
            }
            catch (Exception e)
            {
               // Do Some Loggoing
                return false;
            }

            return true;
        }

        public bool UpdateHotel(int id, HotelDTO hotel)
        {
            try
            {
                var editHotel = _hotelRepository.Find(id);
                if (editHotel == null)
                    return false;

                editHotel.StarRating = hotel.StarRating;
                editHotel.Address = hotel.Address;
                editHotel.Id = id;
                editHotel.Name = hotel.Name;

                _hotelRepository.UpdateHotel(editHotel);
            }
            catch (Exception e)
            {
                // Do Some Loggoing
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteHotel(int id)
        {
            try
            {
                _hotelRepository.DeleteHotel(id);
            }
            catch (Exception e)
            {
                // Do Some Loggoing
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelDTO GetByID(int id)
        {
            var hotel = _hotelRepository.Find(id);
            if (hotel != null)
            {
                return new HotelDTO()
                {
                    StarRating = hotel.StarRating,
                    Name = hotel.Name,
                    Address = hotel.Address
                };
            }

            return null;
        }
    }
}