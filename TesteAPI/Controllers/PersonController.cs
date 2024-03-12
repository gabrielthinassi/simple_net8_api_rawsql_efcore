using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TesteAPI.Models;
using TesteAPI.Repository;

namespace TesteAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository) {
            _personRepository = personRepository;
        }

        [ProducesResponseType(typeof(List<Person>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> FindAll() {
            try
            {
                return Ok(await _personRepository.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var person = await _personRepository.FindById(id);
                if (person == null) {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            try
            {
                bool isSuccess = await _personRepository.CreateAsync(person);
                if (isSuccess)
                {
                    return Ok("Person Added!");
                }
                return BadRequest("Person Failed to Add!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            try
            {
                bool isSuccess = await _personRepository.UpdateAsync(person);
                if (isSuccess)
                {
                    return Ok("Person Updated!");
                }
                return BadRequest("Person Failed to Update!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccess = await _personRepository.DeleteAsync(id);
                if (isSuccess)
                {
                    return Ok("Person Deleted!");
                }
                return BadRequest("Person Failed to Delete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
