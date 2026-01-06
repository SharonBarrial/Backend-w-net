using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Whereto.Domain.Booking.Models.Commands;
using Whereto.Domain.Booking.Services;

namespace Whereto.Presentation.Booking.Controllers
{
    
    [Route("api/v1/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingCommandService _bookingCommandService;
        private readonly IBookingQueryService _bookingQueryService;

        public BookingController( IBookingQueryService bookingQueryService, IBookingCommandService bookingCommandService,
            IMapper mapper)
        {
            _bookingQueryService = bookingQueryService;
            _bookingCommandService = bookingCommandService;
            _mapper = mapper;
        }

        /*// GET: api/Booking
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Booking
        /// <summary>
        /// Creates a new tutorial.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/tutorial
        ///     {
        ///        "name": "New tutorial",
        ///        "description": ""
        ///     }
        ///
        /// </remarks>
        /// <param name="command">The tutorial to create</param>
        /// <returns>A newly created tutorial</returns>
        /// <response code="201">Returns the newly created tutorial</response>
        /// <response code="400">If the tutorial has invalid property</response>
        /// <response code="409">Error validating data</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateBookingCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(void),StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> PostAsync([FromBody] CreateBookingCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();


            var result = await _bookingCommandService.Handle(command);

            if (result > 0)
                return StatusCode(StatusCodes.Status201Created, result);

            return BadRequest();
        }

       /* // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
