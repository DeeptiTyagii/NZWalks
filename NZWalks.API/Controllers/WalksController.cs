using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Domain.DTO;
using NZWalks.API.Domain.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //api/Walks
    [Route("api/[controller]")] 
    [ApiController]  //tells the app that this is api controller not mvc controller
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        //CREATE WALKS
        //POST: /api/Walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if(ModelState.IsValid)
            {
                //Map DTO to domain model
                var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
                await _walkRepository.CreateAsync(walkDomainModel);

                //Map Domain model to DTO
                return Ok(_mapper.Map<WalkDto>(walkDomainModel));
            }
            
            return BadRequest(ModelState);
            
        }

        //GET ALL WALKS
        //GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();

            //Map domain model to DTO
            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        }
        
        //GET WALK by ID
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{Id:Guid}")]  //:guid is to make it type safe (optional)
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var walksDomainModel = await _walkRepository.GetByIdAsync(Id);

            if(walksDomainModel == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            return Ok(_mapper.Map<WalkDto>(walksDomainModel));
        }

        //UPDATE WALK by ID
        //PUT: /api/walks/{id}
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map dto to domain model
                var walksDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

                walksDomainModel = await _walkRepository.UpdateAsync(Id, walksDomainModel);

                if (walksDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<WalkDto>(walksDomainModel));
            }
            return BadRequest(ModelState);
            
        }

        //DELETE Walk By ID
        //DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var deletedWalkDomainModel = await _walkRepository.DeleteAsync(Id);

            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map domain to DTO

            return Ok(_mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
