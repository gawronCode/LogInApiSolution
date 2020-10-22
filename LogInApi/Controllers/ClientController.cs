using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogInApi.Data;
using LogInApi.Dtos;
using LogInApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogInApi.Controllers
{
    [Route("loginApi/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogInRepository _repository;
        private readonly IMapper _mapper;

        public ClientController(ILogInRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("{id}", Name = "GetAppClientById")]
        public ActionResult<AppClientReadDto> GetAppClientById(int id)
        {
            var appClient = _repository.GetAppClientById(id);
            if (appClient is null) return NotFound();
            return Ok(_mapper.Map<AppClientReadDto>(appClient));
        }

        [HttpGet("credentials")]
        public ActionResult<string> ValidateCredentials(AppClientCredentialsDto appClientCredentialsDto)
        {
            var appClient = _mapper.Map<AppClient>(appClientCredentialsDto);
            var appClientFromRepo = _repository.ValidateCredentials(appClient);
            if (appClientFromRepo is null) return NoContent();
            return Ok("session_token_string"); //mock session token string
        }

        [HttpPost]
        public ActionResult<AppClientReadDto> CreateAppClient(AppClientCreateDto appClientCreateDto)
        {
            var appClient = _mapper.Map<AppClient>(appClientCreateDto);
            _repository.CreateAppClient(appClient);
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetAppClientById), new {Id = appClient.Id}, _mapper.Map<AppClientReadDto>(appClient));
        }



    }
}
