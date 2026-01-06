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
    //Patrón decoratior
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        //Para usar la interfaz y no la clase
        private ITutorialData _tutorialData;
        //Para usar la interfaz domain
        private ITutorialDomain _tutorialDomain;

        private IMapper _mapper;
        
        //Inyecte la interfaz a tutorialData y tutorialDomain y el IMapper
        public TutorialController(ITutorialData tutorialData, ITutorialDomain tutorialDomain, IMapper mapper)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/Tutorial
        [HttpGet]
        //public IEnumerable<Tutorial> Get()
        public IActionResult Get()
        {
            //Hay que olvidarnos del new
            //TutorialData data = new TutorialData();
            //La comunicación ya no se va a dar a través de clases, sino de interfaes
            
            //return _tutorialData.GetAll();
            
            var data = _tutorialData.GetAll(); //obtiene el listado de objetos
            var result = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(data); //controla lo que devuelve

            return Ok(result);
            
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tutorial
        [HttpPost]
        public IActionResult Post([FromBody] TutorialRequest input)
        {
            /*
            Tutorial tutorial = new Tutorial()
            {
                Name = input.Name,
                Description = input.Description,
            };*/

            //Librería para reemplazar las líneas anteriores: AutoMapper
            //Conversión de TutorialRequest a Tutorial

            try
            {
                if (ModelState.IsValid) //Valida si el modelo es correcto formato de la carpeta request 
                {
                    var tutorial = _mapper.Map<TutorialRequest, Tutorial>(input);

                    var result = _tutorialDomain.Save(tutorial);

                    if (result)
                        //return Ok(); //200
                        //return Created(tutorial.Id.ToString(), tutorial); //201
                        return StatusCode(StatusCodes.Status201Created); //201
                }
                return BadRequest();
            }
            catch (Exception e) //Error inesperado
            {
                //return StatusCode(500);//500
                return StatusCode(StatusCodes.Status500InternalServerError); //500
            }
            
        }
        

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
