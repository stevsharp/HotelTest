using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.DTO;

namespace ApplicationLayer.Hotel
{
    public interface IHotelService
    {
        bool CreateHotel(HotelDTO hotel);

        bool UpdateHotel(int id , HotelDTO hotel);

        bool DeleteHotel(int id);
        HotelDTO GetByID(int id);
    }
}
