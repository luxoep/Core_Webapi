using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SomeOtherController : ControllerBase
{
    private LinkGenerator _linkGenerator;
    public SomeOtherController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }
    // 通过路由名称动态生成 URL
    [HttpGet]
    public IActionResult GetLink()
    {

        // 使用路由名称 "GetById" 和参数 { id = 123 } 生成 URL
        // string? url = _linkGenerator.GetPathByRouteValues("GetById", new { id = 20 });

        #region GetPathByAction(/api/Values/20)
        string? url_1 = _linkGenerator.GetPathByAction(
                action: "Get_A",
                controller: "Values",
                values: new { id = 20 }
                );
        #endregion

        #region GetUriByAction(http://localhost:5255/api/Values/20)
        string? url_2 = _linkGenerator.GetUriByAction(
                        action: "Get_A",
                        controller: "Values",
                        values: new { id = 20 },
                        scheme: Request.Scheme,
                        host: Request.Host
                        );
        #endregion

        #region GetPathByRouteValues(/api/Values/20)
        string? url_3 = _linkGenerator.GetPathByRouteValues(
                        routeName: "GetByIdA",
                        values: new { id = 20 }
                        );
        #endregion

        #region GetUriByRouteValues(http://localhost:5255/api/Values/20#section1)
        string? url = _linkGenerator.GetUriByRouteValues(
                        routeName: "GetByIdA",
                        values: new { id = 20 },
                        scheme: Request.Scheme,
                        host: Request.Host,
                        pathBase: null,
                        fragment: new FragmentString("#section1")
                        );
        #endregion

        if (url == null)
        {
            return NotFound("URL not found");
        }
        return Ok(url); // 返回生成的 URL
    }
}
