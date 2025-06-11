using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Domain.DTO;
using NZWalks.API.Domain.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //https://localhost:port/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(/*NZWalksDbContext dbContext,*/ 
            IRegionRepository regionRepository, 
            IMapper mapper) 
        {
            //_dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        //GET ALL REGIONS
        //GET://https://localhost:port/api/Regions
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DB - domain models
            var regions = await _regionRepository.GetAllAsync();

            //Map domain models to DTOs
            //var regionDto = new List<RegionDto>();

            //foreach (var region in regions)
            //{
            //    regionDto.Add(new RegionDto() { 
            //        Id = region.Id, 
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl
            //    });  
            //}

            //Map domain models to DTOs
            var regionDto = _mapper.Map<List<RegionDto>>(regions);

            //return DTOs

            return Ok(regionDto);
        }

        //GET REGION  BY ID
        //GET://https://localhost:port/api/Regions/{Id}
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            //var region = _dbContext.Regions.Find(Id); // only takes primary key

            var region = await _regionRepository.GetByIdAsync(Id); 

            if(region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(region));
        }

        //POST TO CREATE A NEW REGION
        //POST://https://localhost:port/api/Regions/{Id}
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionDto)
        {
            //Map DTO to domain model

            var regionDomainModel = _mapper.Map<Region>(addRegionDto);

            //Use Domain model to create region in dbcontext

            //await _dbContext.Regions.AddAsync(regionDomainModel);  //AddAsync
            //await _dbContext.SaveChangesAsync();    //SaveChangesAsync - its important to save changes else it wont add the object to DB

            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            //map domain model back to DTO (cant send the domain model)
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            
        }

        //UPDATE REGION
        //PUT://https://localhost:port/api/Regions/{Id}
        [HttpPut]
        [Authorize(Roles = "Writer")]
        [Route("{Id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto updateRegionDto)
        {
            //Map DTO to domain model
            var regionDomainModel = _mapper.Map<Region>(updateRegionDto);

            //Check if region exists
            regionDomainModel = await _regionRepository.UpdateAsync(Id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert domain model to dto

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
            
        }

        //DELETE REGION
        //DELETE://https://localhost:port/api/Regions/{Id}
        [HttpDelete]
        [Authorize(Roles = "Writer")]
        [Route("{Id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            //Check if region exists
            var regionDomainModel = await _regionRepository.DeleteAsync(Id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete Region

            //Convert domain model to dto

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);

            //or simply return Ok()
        }
    }
}
