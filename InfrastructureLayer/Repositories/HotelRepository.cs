using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories
{
    public interface IHotelRepository
    {
        void CreateHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
        Hotel Find(int id);
    }

    public class HotelRepository : IHotelRepository
    {
        protected readonly HotelDBContext _context;
        public HotelRepository(HotelDBContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var exist = _context.Hotels.Find(id);
            if (exist== null) 
                return;

            _context.Entry(exist).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Hotel Find(int id)
        {
            return _context.Hotels.Find(id);
        }
    }

   
}
