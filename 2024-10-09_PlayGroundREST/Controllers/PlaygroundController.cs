using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PlayGroundLib;

namespace _2024_10_09_PlayGroundREST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaygroundController : ControllerBase
    {
        private PlayGroundsRepository _playgroundsRepository = new PlayGroundsRepository();

        // Get All
        [EnableCors("AllowAll")]
        [HttpGet]
        public ActionResult<IEnumerable<PlayGround>> Get()
        {
            return _playgroundsRepository.GetAll();
        }

        // Get By Id
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<PlayGround> Get(int id)
        {
            PlayGround? target = _playgroundsRepository.GetById(id);
            
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(target);
            }
        }

        // Create
        [DisableCors]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<PlayGround> Post([FromBody] PlayGround newPlayground)
        {
            try
            {
                PlayGround playground = _playgroundsRepository.Add(newPlayground);

                return Created("/" + playground.Id, playground);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update
        [DisableCors]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<PlayGround> Put(int id, [FromBody] PlayGround target)
        {
            try
            {
                PlayGround? playground = _playgroundsRepository.Update(id, target);
                
                if (playground != null)
                {
                    return Ok(playground);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
