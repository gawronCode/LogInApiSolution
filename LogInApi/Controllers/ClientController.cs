using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogInApi.Data;
using LogInApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogInApi.Controllers
{
    [Route("loginApi/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogInRepository _repository;

        public ClientController(ILogInRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppClient>> GetAllAppClients()
        {
            return Ok(_repository.GetAllAppClients());
        }

        [HttpGet("{id}", Name = "GetAppClientById")]
        public ActionResult<AppClient> GetAppClientById(int id)
        {
            var appClient = _repository.GetAppClientById(id);
            if (appClient is null) return NotFound();
            return Ok(appClient);
        }

        [HttpGet("validateCredentials")]
        public ActionResult<string> ValidateCredentials(AppClient appClient)
        {
            var appClientFromRepo = _repository.ValidateCredentials(appClient);
            if (appClientFromRepo is null) return NoContent();
            return Ok("session_token_string"); //mock session token string
        }

        [HttpPost]
        public ActionResult<AppClient> CreateAppClient(AppClient appClient)
        {
            _repository.CreateAppClient(appClient);
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetAppClientById), new {Id = appClient.Id}, appClient);
        }



    }
}
