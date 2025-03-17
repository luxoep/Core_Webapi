using Childs_Cat;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AniamalController : ControllerBase
{
    Cat cats = new Cat();

    #region HttpGet

    [HttpGet("GetAllAniamal")]
    public ActionResult<List<Cat>> GetAllListAniamal()
    {
        return Ok(cats.GetCats());
    }
    [HttpGet("GetSelectAniamal/{uuid}")]
    public IActionResult GetSelectAniamal(int uuid)
    {
        Cat? SelectCat = cats.RequiredCatId(uuid);

        return Ok(SelectCat);
    }
    [HttpGet("GetSelectAniamalFromQuery")]
    public IActionResult GetSelectAniamalFromQuery([FromQuery] int uuid)
    {
        Cat? SelectCat = cats.RequiredCatId(uuid);

        return Ok(SelectCat);
    }
    public class CatSearchMore
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }
    [HttpGet("GetSearchMore")]
    public IActionResult GetSearchMoreAniamal([FromQuery] CatSearchMore catSearchMore)
    {
        List<Cat> resCats = new List<Cat>();

        foreach (Cat item in cats.GetCats())
        {
            if (item.UUid == catSearchMore.Id && item.Age == catSearchMore.Age)
            {
                resCats.Add(item);
                return Ok(resCats);
            }
        }

        return BadRequest(new { error = " Not Cat Data " });
    }

    #endregion

    #region HttpPost

    [HttpPost("AddNewCat")]
    public IActionResult AddNewCat([FromBody] Cat newcat)
    {
        if (newcat == null) return BadRequest(new { error = "Invalid input" });

        cats.AddNew(newcat);

        return Ok(new { message = "猫咪添加成功", data = cats.GetCats() });
    }
    [HttpPost("AddNewMoreCat")]
    public IActionResult AddNewMoreCat([FromBody] Cat[] newcat)
    {
        if (newcat == null) return BadRequest(new { error = "Invalid input" });

        foreach (Cat item in newcat)
        {
            if (cats.AddNew(item) == null) return BadRequest(new { error = "Duplicate input" });
            cats.AddNew(item);
        }
        return Ok(new { message = "猫咪添加成功", data = cats.GetCats() });
    }


    #endregion

    #region HttpPut

    [HttpPut("UpdateCatResultNewCat")]
    public IActionResult ResultNewCat([FromBody] Cat cat)
    {
        Cat? updatecat = cats.ResultUpdateCat(cat);

        if (updatecat == null) return BadRequest(new { error = "Not Cat" });

        return Ok(updatecat);
    }
    [HttpPut("UpdateCatResultCatList")]
    public IActionResult ResultCatList([FromBody] Cat cat)
    {
        List<Cat>? updatecatList = cats.ResultUpdateCatList(cat);

        if (updatecatList == null) return BadRequest(new { error = "Not Cat" });

        return Ok(updatecatList);
    }
    [HttpPut("UpdateCatSelectUUid/{uuid}")]
    public IActionResult SelectUUid(int uuid, [FromBody] Cat cat)
    {
        Cat? updatecat = cats.ResultSelectUpdateCatUUid(uuid, cat);

        if (updatecat == null) return BadRequest(new { error = "Not Cat" });

        return Ok(updatecat);
    }
    [HttpPut("{uuid}")]
    public IActionResult SelectUUid_A(int uuid, [FromBody] Cat cat)
    {
        Cat? updatecat = cats.ResultSelectUpdateCatUUid_A(uuid, cat);

        if (updatecat == null) return BadRequest(new { error = "Not Cat_A" });

        return Ok(updatecat);
    }
    #endregion
}
