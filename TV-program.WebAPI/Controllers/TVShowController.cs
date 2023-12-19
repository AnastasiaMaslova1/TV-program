using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Configuration;
using TV_program.BL.TVShow;
using TV_program.BL.TVShow.Entities;
using TV_program.WebAPI.Controllers.Entiteis;

namespace TV_program.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TVShowController : Controller
    {
        private readonly ITVShowProvider _TVShowProvider;
        private readonly ITVShowManager _TVShowManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TVShowController(ITVShowProvider TVShowProvider, ITVShowManager TVShowManager, IMapper mapper, ILogger logger)
        {
            _TVShowManager = TVShowManager;
            _TVShowProvider = TVShowProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //TVShow/
        public IActionResult GetAllTVShow()
        {
            var products = _TVShowProvider.GetTVShow();
            return Ok(new TVShowListResponce()
            {
                TVShow = products.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //TVShow/filter?filter.Price = 500&filter.Status = 1&filter.PublishingHouseId = 1&filter.LanguageId = 1&filter.ProductType = 1 
        public IActionResult GetFilteredTVShow([FromQuery] TVShowFilter filter)
        {
            var products = _TVShowProvider.GetTVShow(_mapper.Map<TVShowModelFilter>(filter));
            return Ok(new TVShowListResponce()
            {
                TVShow = products.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //TVShow/{id}
        public IActionResult GetTVShowInfo([FromRoute] Guid id)
        {
            try
            {
                var product = _TVShowProvider.GetTVShowInfo(id);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTVShow([FromBody] CreateTVShowRequest request)
        {
            try
            {
                var product = _TVShowManager.CreateTVShow(_mapper.Map<CreateTVShowModel>(request));
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTVShowInfo([FromRoute] Guid id, UpdateTVShowRequest request)
        {
            try
            {
                var product = _TVShowManager.UpdateTVShow(id, _mapper.Map<UpdateTVShowModel>(request));
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTVShow([FromRoute] Guid id)
        {
            try
            {
                _TVShowManager.DeleteTVShow(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
