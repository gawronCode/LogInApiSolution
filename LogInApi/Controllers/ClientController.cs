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



    }
}
