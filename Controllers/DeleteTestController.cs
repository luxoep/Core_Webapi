using EngData;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeleteTestController : ControllerBase
{
    [HttpDelete("DelEng/{id}")] // http://localhost:5255/api/DeleteTest/DelEng/2
    public IActionResult DelEng(int id)
    {
        EngineerData engineerData = new EngineerData();
        return Ok(engineerData.RemoveEng(id));
    }
    [HttpDelete] // http://localhost:5255/api/DeleteTest?id=1
    public IActionResult DelEng_A([FromQuery]int id)
    {
        EngineerData engineerData = new EngineerData();
        return Ok(engineerData.RemoveEng(id));
    }
}
