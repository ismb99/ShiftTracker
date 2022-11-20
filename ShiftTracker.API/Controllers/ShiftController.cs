using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftTracker.API.Interfaces;
using ShiftTracker.API.Models;
using ShiftTracker.API.Models.DTOs;
using ShiftTracker.API.Services;

namespace ShiftTracker.API.Controllers
{
    [Route("api/Shift")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public ShiftController(IShiftRepository shiftRepository, IMapper mapper)
        {
            _shiftRepository = shiftRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftDTO>>> GetAllShifts()
        {
            var shiftList = await _shiftRepository.GetAll();

            if (shiftList.Count() == 0)
            {
                return NotFound("No shitfs are found");
            }

            var shifts = _mapper.Map<List<ShiftDTO>>(shiftList);
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftDTO>> GetShift(int id)
        {
            if (id == 0)
                return BadRequest();

            var shift = await _shiftRepository.Get(id);

            if (shift == null)
                return NotFound();

            var shiftDto = _mapper.Map<ShiftDTO>(shift);
            return Ok(shiftDto);
        }

        [HttpPost]
        public async Task<ActionResult<ShiftDTO>> AddShift([FromBody] CreateShiftDTO createShiftDTO)
        {
            if (createShiftDTO == null)
                return BadRequest();

            var fullShift = ShiftService.CalculateMinutesByHour(createShiftDTO);

            var result = await _shiftRepository.Add(fullShift);

            var shifts = _mapper.Map<ShiftDTO>(result);

            return Ok(shifts);
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
