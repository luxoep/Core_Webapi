using Microsoft.AspNetCore.Mvc;
using Teacher_Class;
using TeacherSource;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PutTestController : ControllerBase
{
    public static TeacherSource_Data teacherdata = new TeacherSource_Data();

    [HttpPut("UpdateOnly")]
    public IActionResult UpdateContent([FromBody] Teacher teacher)
    {
        if (teacher == null) return BadRequest(new { error = "Invalid input" });

        Teacher? target = teacherdata.UpdateTeacher(teacher);

        if (target == null) return BadRequest(new { error = "Invalid Data" });

        // 返回更新后的完整教师列表
        return Ok(teacherdata.TeacherList());
    }
}
