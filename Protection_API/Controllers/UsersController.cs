using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Protection_API.Models;

namespace Protection_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    public IEnumerable<string> Get()
    {
        throw new Exception("Something bad in Get");
        //return new string[] { Random.Shared.Next(1, 101).ToString() };
    }

    [HttpGet("{id}")]
    //[ResponseCache(Duration = 20, Location = ResponseCacheLocation.Any, NoStore = false)]
    public IActionResult Get(int id)
    {
        return Ok($"Random Number : {Random.Shared.Next(1, 101).ToString()} for Id {id}");
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserModel user)
    {
        if (ModelState.IsValid)
        {
            return Ok("Model was valid");
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}
