using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class GeneralStatisticsController : BaseApiController
    {
        private readonly IGeneralStatisticsRepository _generalStatisticsRepository;
        private readonly IMapper _mapper;

        public GeneralStatisticsController(IGeneralStatisticsRepository generalStatisticsRepository,
            IMapper mapper)
        {
            _generalStatisticsRepository = generalStatisticsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralStatisticsDto>>> GetGeneralStatisticsAsync()
        {
            var generalStatistics = await _generalStatisticsRepository.GetGeneralStatisticsAsync();

            var generalStatisticsToReturn = _mapper.Map<IEnumerable<GeneralStatisticsDto>>(generalStatistics);

            return Ok(generalStatisticsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralStatisticsDto>> GetGeneralStatisticsByIdAsync(int id)
        {
            var generalStatistics = await _generalStatisticsRepository.GetGeneralStatisticsByIdAsync(id);

            return _mapper.Map<GeneralStatisticsDto>(generalStatistics);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralStatisticsDto>> CreateGeneralStatistics(GeneralStatisticsDto generalStatisticsDto)
        {
            var newGeneralStatistics = new GeneralStatistics()
            {
                EventsParticipated = generalStatisticsDto.EventsParticipated,
                EventsWon = generalStatisticsDto.EventsWon,
                PostWritten = generalStatisticsDto.PostWritten,
                UserId = generalStatisticsDto.UserId
            };

            _generalStatisticsRepository.AddGeneralStatistics(newGeneralStatistics);

            if (await _generalStatisticsRepository.SaveAllAsync())
                return Ok(_mapper.Map<GeneralStatisticsDto>(newGeneralStatistics));
            return BadRequest("Failed to add general statistics");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGeneralStatistics(int id)
        {
            var generalStatistics = await _generalStatisticsRepository.GetGeneralStatisticsByIdAsync(id);

            _generalStatisticsRepository.DeleteGeneralStatistics(generalStatistics);

            if (await _generalStatisticsRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting general statistics");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGeneralStatistics(GeneralStatistics generalStatistics, int id)
        {
            var generalStatisticsAsync = await _generalStatisticsRepository.GetGeneralStatisticsByIdAsync(id);

            generalStatisticsAsync.GeneralStatisticsId = generalStatisticsAsync.GeneralStatisticsId;
            if (generalStatistics.EventsParticipated != null)
                generalStatisticsAsync.EventsParticipated = generalStatistics.EventsParticipated;
            if (generalStatistics.EventsWon != null)
                generalStatisticsAsync.EventsWon = generalStatistics.EventsWon;
            if (generalStatistics.PostWritten != null)
                generalStatisticsAsync.PostWritten = generalStatistics.PostWritten;
            
            if (await _generalStatisticsRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update general statistics");
        }
    }
}