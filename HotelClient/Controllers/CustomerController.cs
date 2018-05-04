using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ApplicationLayer.Customer;
using ApplicationLayer.DTO;

namespace HotelClient.Controllers
{
    public class CustomerController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICustomerService _customerService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Customer/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var customer = _customerService.GetByID(id);
            if (customer == null){
                return NotFound();
            }
            return Ok(customer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Customer/GetAll")]
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerService.GetAll();
        }
        /// <summary>
        ///  DELETE api/Customers/5  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetByID(id);
            if (customer == null)
                return NotFound();
           
            _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // POST api/Customers  
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult PostCustomer(CustomerDTO customer)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            _customerService.CreateCustomer(customer);

            return CreatedAtRoute("DefaultApi", new { Customer = customer},customer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult PutCustomer(int id, CustomerDTO customer)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            _customerService.UpdateCustomer(id,customer);
            return StatusCode(HttpStatusCode.NoContent);
        }



    }
}