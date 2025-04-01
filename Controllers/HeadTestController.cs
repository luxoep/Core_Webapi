using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Phone_Class;
using Phone_Data;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeadTestController : ControllerBase
{
    [HttpHead]
    public IActionResult HeadRequest()
    {
        Response.Headers.Append("X-Custom-Header", "This is a HEAD response");
        return Ok("HttpHead");
    }
    [HttpOptions]
    public IActionResult Options()
    {
        Response.Headers.Append("Allow", "POST,OPTIONS");
        Response.Headers.Append("IsWrite", "TRUE");
        return Ok("HttpOptions");
    }
    // 注入PhoneData
    private readonly PhoneData _phoneData;
    public HeadTestController(PhoneData phoneData)
    {
        _phoneData = phoneData;
    }
    [HttpPatch("Replace/{id}")]
    public IActionResult PatchRequest(int id, JsonPatchDocument<Phone> jsonPatchDocument)
    {
        jsonPatchDocument.ApplyTo(_phoneData.SelectPhone(id));
        return Ok(_phoneData.GetPhones());
    }
    [HttpPatch("{id}")]
    public IActionResult PatchRequestId(int id, JsonPatchDocument<Phone> jsonPatchDocument)
    {
        jsonPatchDocument.ApplyTo(_phoneData.SelectPhone(id));
        return Ok(_phoneData.GetPhones());
    }
}

