using AutoMapper;
using casetravelers.Domain;
using casetravelers.Infrastructure.Entities;
using casetravelers.Infrastructure.Repositories;
using casetravelers.Presentation.Publishing.Request;
using casetravelers.Presentation.Publishing.Response;
using Microsoft.AspNetCore.Mvc;

namespace pc2casetravelers.Presentation.Publishing.Controllers
{       
    /// <summary>
    /// This class is responsible for handling HTTP requests related to Destinations.
    /// routing them to the appropriate service methods to process the requests,
    /// and returning the results as HTTP responses.
    /// </summary>
    [Route("api/v1/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IDestinationData _destinationData;
        private readonly IDestinationDomain _destinationDomain;
        
        /// <summary>
        /// Initializes a new instance of the DestinationController class.
        /// </summary>
        /// <param name="destinationData"></param>
        /// <param name="destinationDomain"></param>
        /// <param name="mapper"></param>
        public DestinationController(IDestinationData destinationData, IDestinationDomain destinationDomain, IMapper mapper)
        {
            _destinationData = destinationData;
            _destinationDomain = destinationDomain;
            _mapper = mapper;
        }
        
        // GET: api/destination
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _destinationData.GetAllAsync();
            var result = _mapper.Map<List<Destination>, List<DestinationResponse>>(data);

            if (result.Count == 0) return NotFound();

            return Ok(result);
        }
        
        // POST: api/destination
        /// <summary>
        /// Creates a new destination.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/tutorial
        ///     {
        ///        "name": "New Destination",
        ///        "maxUsers": 10,
        ///        "isRisk: 1
        ///     }
        ///
        /// </remarks>
        /// <param name="input">The destination to create</param>
        /// <returns>A newly created destination</returns>
        /// <response code="201">Returns the newly created destination</response>
        /// <response code="400">If the destination has invalid property</response>
        /// <response code="409">Error validating data</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DestinationRequest input)
        {
            //if (!ModelState.IsValid) { // Get the details of the validation errors
            if (!ModelState.IsValid) { 
                
                var errorMessages = ModelState.Values .SelectMany(v => v.Errors) .Select(e => e.ErrorMessage) .ToList();
                
                return BadRequest(new { Errors = errorMessages });
                
            }
            
            var destination = _mapper.Map<DestinationRequest, Destination>(input);
            try
            {
                var result = await _destinationDomain.SaveDestinationAsync(destination);
                
                if (result > 0)
                    return StatusCode(StatusCodes.Status201Created, result);

            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest();
        }
        
        

       // GET: api/Destination/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var data = _destinationData.GetById(id);
            var result = _mapper.Map<Destination, DestinationResponse>(data);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound);
        } 
        
        // PUT: api/Destination/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DestinationRequest input)
        {
            if (ModelState.IsValid)
            {
                var destination = _mapper.Map<DestinationRequest, Destination>(input);

                var result = _destinationDomain.UpdateDestination(destination, id);

                if (result)
                    return Ok();
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
        
        // GET: api/Tutorial/Search
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetSearchAsync(string name)
        {

            var data = await _destinationData.GetSearchAsync(name);
            var result = _mapper.Map<List<Destination>, List<DestinationResponse>>(data);

            if (result.Count == 0) return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
        }

       // DELETE: api/Destination/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //_destinationDomain.DeleteData(id);
            _destinationData.DeleteData(id);

         return Ok();
         
        }
    }
}
