using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using _3_Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //decorator
    
    //Siempre termina en controller, hereda del controlbase
    public class TutorialController : ControllerBase
    {
        private iTutorialData _tutorialData;
        private iTutorialDomain _tutorialDomain;
        private IMapper _mapper;
        
        public TutorialController(iTutorialData tutorialData, iTutorialDomain tutorialDomain, IMapper mapper)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
        }
        
        
        
        // GET: api/Tutorial
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            // TutorialData data = new TutorialData();
            //TutorialOracle data = new TutorialOracle();
           
            var data =  await _tutorialData.GetAllAsync(); //10m min
            var result = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(data);

            return Ok(result);
        }
        
        /*public IEnumerable<Tutorial> Get()
        {
            // Clases que implementan la interfaz
            // TutorialData data = new TutorialData();
            //TutorialOracle data = new TutorialOracle();
            
            
            return _tutorialData.getAll();
        }*/

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var data =  _tutorialData.GetById(id);
            var result = _mapper.Map<Tutorial, TutorialResponse>(data);
            
            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound);
        }

        // POST: api/Tutorial
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TutorialRequest input)
        {
            /*Tutorial tutorial = new Tutorial()
            {
                Name = input.Name,
                Description = input.Description
            };
            */
            
            //Inicio de validacion
            //Para error inesperado
            try
            { 
                if (ModelState.IsValid) 
                {
                    var tutorial = _mapper.Map<TutorialRequest, Tutorial>(input);
                    var result=await _tutorialDomain.SaveAsync(tutorial); 
                    if (result)
                        /*return Ok();*/
                        return StatusCode(StatusCodes.Status201Created);
                
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
            //transferencia de información
            /*var tutorial = _mapper.Map<TutorialRequest, Tutorial>(input);
            
            return _tutorialDomain.Save(tutorial);*/
            
            //Fin de validacion
            
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TutorialRequest input)
        {
            if (ModelState.IsValid)
            {

                var tutorial = _mapper.Map<TutorialRequest, Tutorial>(input);

                var result = _tutorialDomain.Update(tutorial, id);

                if (result)
                    return Ok();
            }

            return StatusCode(StatusCodes.Status400BadRequest);

        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tutorialDomain.Delete(id);

            return Ok();
        }
    }
}
