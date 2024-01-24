using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/devises")]
    [ApiController]
    public class DevisesController : ControllerBase
    {

        private List<Devise> devises;

        public List<Devise> Devises
        {
            get { return devises; }
            set { devises = value; }
        }

        public DevisesController()
        {
            Devises = new List<Devise>();
            Devises.Add(new Devise(1, "Dollar", 1.08));
            Devises.Add(new Devise(2, "Franc Suisse", 1.07));
            Devises.Add(new Devise(3, "Yen", 120));
        }

        /// <summary>
        /// Get all devises
        /// </summary>
        /// <returns>Http repsponse</returns>
        // GET: api/<DevisesController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Devise> GetAll()
        {
            return Devises;
        }

        /// <summary>
        /// Get a single devise
        /// </summary>
        /// <param name="id">the id of the single</param>
        /// <returns>Http repsponse</returns>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? _devise = Devises.FirstOrDefault(d => d.Id == id);
            if (_devise == null)
            {
                return NotFound();
            }
            return _devise;
        }

        /// <summary>
        /// Add a devise
        /// </summary>
        /// <param name="_devise">The devise to add</param>
        /// <returns>Http response</returns>
        /// <response code="201">When the devise is created</response>
        /// <response code="400">When the devise is not valid</response>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Devise> Post([FromBody] Devise _devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Devises.Add(_devise);
            return CreatedAtRoute("GetDevise", new { id = _devise.Id }, _devise);
        }

        /// <summary>
        /// Update data of a devise
        /// </summary>
        /// <param name="id">the id of the devise to update</param>
        /// <param name="_devise">new data of the devise</param>
        /// <returns>Http reponse</returns>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise _devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != _devise.Id)
            {
                return BadRequest();
            }
            int index = Devises.FindIndex(d => d.Id == id);
            if(index < 0)
            {
                return NotFound();
            }
            devises[index] = _devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a devise
        /// </summary>
        /// <param name="id">The id of the devise to delete</param>
        /// <returns>Http response</returns>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? _devise = Devises.FirstOrDefault(d => d.Id == id);
            if( _devise == null)
            {
                return NotFound();
            }
            Devises.Remove(_devise);
            return _devise;
        }
    }
}
