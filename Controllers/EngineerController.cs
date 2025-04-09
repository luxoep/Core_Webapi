using Eng;
using EngParent;
using EngService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EngineerController : ControllerBase
{
    private IEngineerService _engineerService;

    public EngineerController(IEngineerService engineerService)
    {
        _engineerService = engineerService;
    }

    #region Get
    [HttpGet("GetAllEngineer")]
    public IActionResult GetAllEng()
    {
        return Ok(_engineerService.GetEngineereds());
    }

    [HttpGet("{id}")]
    public IActionResult GetOneEngineer_A(int id)
    {
        if (_engineerService.GetEngineeredById(id) == null) return NotFound(new { message = "No Engineer" });

        return Ok(_engineerService.GetEngineeredById(id));
    }
    [HttpGet("GetOneEngineer")]
    public IActionResult GetOneEngineer_B([FromQuery] int id)
    {
        if (_engineerService.GetEngineeredById(id) == null) return NotFound(new { message = "No Engineer" });

        return Ok(_engineerService.GetEngineeredById(id));
    }
    [HttpGet("GetMoreEngineer")]
    public IActionResult GetMoreEngineer([FromQuery] int id)
    {
        if (_engineerService.GetMoreEngineereds(id).Count <= 0) return NotFound(new { message = "No Engineer" });

        return Ok(_engineerService.GetMoreEngineereds(id));
    }
    #endregion

    #region Post
    [HttpPost("AddOneNewEngineer")]
    public IActionResult AddOneNewEngineer([FromBody] Engineered engineered)
    {
        if (_engineerService.GetEngineeredById(engineered.EngID) != null) return NotFound(new { message = "Already Exist" });

        return Ok(_engineerService.AddEngineer(engineered));
    }
    [HttpPost("PostUpdateOneNewEngineer/{id}")]
    public IActionResult PostUpdateOneNewEngineer([FromBody] Engineered engineered, int id)
    {
        if (_engineerService.GetEngineeredById(id) == null) return NotFound(new { message = "No Engineer" });

        return Ok(_engineerService.PostUpdateEngineer(engineered, id));
    }
    #endregion

    #region Put
    [HttpPut("PutUpdateOneEngineer")]
    public IActionResult PutUpdateOneEngineer_A([FromBody] Engineered engineered, [FromQuery] int id)
    {
        if (_engineerService.GetEngineeredById(id) == null) return NotFound(new { error = "Resource not Engineer" });

        return Ok(_engineerService.PutUpdateEnginner(engineered, id));
    }
    [HttpPut("{id}")]
    public IActionResult PutUpdateOneEngineer_B([FromBody] Engineered engineered, int id)
    {
        if (_engineerService.GetEngineeredById(id) == null) return NotFound(new { error = "Resource not Engineer" });

        return Ok(_engineerService.PutUpdateEnginner(engineered, id));
    }
    #endregion

    #region Delete
    [HttpDelete("DeleteEngineer")]
    public IActionResult DeleteEngineer([FromQuery] int id)
    {
        return Ok(_engineerService.DeleteEngineer(id));
    }
    [HttpDelete("DeleteEngMoreConditions/{id}")]
    public IActionResult DeleteEngMoreConditions(int id, [FromQuery] int card)
    {
        if (_engineerService.DeleteDoubleConditionsEngineer(id, card) != null) return BadRequest(new { ok = "Delete successful" });

        return NotFound(new { error = "Delete Not successful" });
    }
    #endregion

    #region Patch
    [HttpPatch("PatchUpdateDetail")]
    /*
        [
            { "op": "replace", "path": "/Name", "value": "Jerry_A" }
        ]
    */
    public IActionResult PatchUpdateDetail(int id, JsonPatchDocument<Engineered> jsonPatchDocument)
    {
        jsonPatchDocument.ApplyTo(_engineerService.GetEngineeredById(id));
        return Ok(_engineerService.GetEngineereds());
    }
    #endregion
}
