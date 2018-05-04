using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ApplicationLayer.DTO;
using ApplicationLayer.Hotel;

namespace HotelClient.Controllers
{
    public class HotelController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IHotelService _hotelService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelService"></param>
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult DeleteHotel(int id)
        {
            var customer = _hotelService.GetByID(id);
            if (customer == null)
                return NotFound();

            _hotelService.DeleteHotel(id);
            return Ok(customer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // POST api/Hotel  
        [ResponseType(typeof(HotelDTO))]
        public IHttpActionResult PostHotel(HotelDTO hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _hotelService.CreateHotel(hotel);

            return CreatedAtRoute("DefaultApi", new { Hotel = hotel }, hotel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [ResponseType(typeof(HotelDTO))]
        public IHttpActionResult PutHotel(int id , HotelDTO hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _hotelService.UpdateHotel(id,hotel);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
