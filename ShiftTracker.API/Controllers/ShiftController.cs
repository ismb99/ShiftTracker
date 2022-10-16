using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftTracker.API.Interfaces;
using ShiftTracker.API.Models;

namespace ShiftTracker.API.Controllers
{
    [Route("api/Shift")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shift>>> GetAllShifts()
        {
            var shiftList = await _shiftRepository.GetAll();
            if (shiftList.Count() == 0)
                return NotFound();

            return Ok(shiftList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShift(int id)
        {
            if (id == 0)
                return BadRequest();

            var shift = await _shiftRepository.Get(id);

            if (shift == null)
                return NotFound();

            return Ok(shift);
        }

        [HttpPost]
        public async Task<ActionResult<Shift>> AddShift([FromBody] Shift Shift)
        {
            if (Shift == null)
                return BadRequest();

            var result = await _shiftRepository.Add(Shift);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Shift>> UpdateShift([FromBody] Shift shift)
        {

            if (shift != null)
            {
                var result = await _shiftRepository.Update(shift);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShift(int id)
        {
            if (id == 0)
                return BadRequest();
            var shift = await _shiftRepository.Get(id);
            if (shift == null)
                return NotFound();
            _shiftRepository.Delete(shift.Id);

            return NoContent();
        }
    }
}
