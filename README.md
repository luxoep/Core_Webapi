# Webapi(ASP.NET Core Web API)

## DLC

    IActionResult 是一个接口，提供了更高的灵活性，允许返回多种类型的响应。
    ActionResult<T> 是一个泛型类，继承自 IActionResult，提供了类型安全和更明确的返回类型。

    ActionResult类：
        示例：
            // 定义一个 Web API 控制器，使用 [ApiController] 特性标记为 API 控制器
            // 路由路径为 "api/[controller]"，即控制器名称对应的 API 路径
            [ApiController]
            [Route("api/[controller]")]
            public class MyController : ControllerBase
            {
                // 成功响应示例
                [HttpGet("success")]
                public ActionResult Success()
                {
                    // 返回 HTTP 状态码 200 OK，并附带一个 JSON 对象作为响应内容
                    return Ok(new { message = "Request succeeded" });
                }

                // 未找到资源的示例
                [HttpGet("not-found")]
                public ActionResult NotFoundExample()
                {
                    // 返回 HTTP 状态码 404 Not Found，并附带一个 JSON 对象作为错误信息
                    return NotFound(new { error = "Resource not found" });
                }

                // 请求无效的示例
                [HttpGet("bad-request")]
                public ActionResult BadRequestExample()
                {
                    // 返回 HTTP 状态码 400 Bad Request，并附带一个 JSON 对象作为错误信息
                    return BadRequest(new { error = "Invalid input" });
                }

                // 创建资源的示例
                [HttpGet("created")]
                public ActionResult CreatedExample()
                {
                    // 创建一个新实体对象
                    var newEntity = new { Id = 1, Name = "New Entity" };
                    // 返回 HTTP 状态码 201 Created，并附带新创建资源的 URI 和实体内容
                    // 使用 CreatedAtAction 方法生成指向新资源的 URI
                    return CreatedAtAction(nameof(GetById), new { id = newEntity.Id }, newEntity);
                }

                // 禁止访问的示例
                [HttpGet("forbidden")]
                public ActionResult ForbiddenExample()
                {
                    // 返回 HTTP 状态码 403 Forbidden
                    return Forbidden();
                }

                // 自定义状态码的示例
                [HttpGet("custom-status")]
                public ActionResult CustomStatus()
                {
                    // 返回自定义的 HTTP 状态码 503 Service Unavailable，并附带错误信息
                    return StatusCode(503, new { error = "Service Unavailable" });
                }

                // 返回文件的示例
                [HttpGet("file")]
                public ActionResult FileExample()
                {
                    // 读取本地文件的内容（假设文件名为 "example.pdf"）
                    byte[] fileContents = System.IO.File.ReadAllBytes("example.pdf");
                    // 返回文件内容，并指定 MIME 类型为 "application/pdf"
                    return File(fileContents, "application/pdf");
                }

                // 重定向的示例
                [HttpGet("redirect")]
                public ActionResult RedirectExample()
                {
                    // 返回 HTTP 状态码 302 Found，并重定向到指定的 URL
                    // 注意：URL 应该是一个有效的地址
                    return Redirect("https://example.com");
                }

                // 返回问题详情的示例
                [HttpGet("problem")]
                public ActionResult ProblemExample()
                {
                    // 返回 HTTP 状态码 500 Internal Server Error，并附带详细的错误信息
                    return Problem(detail: "An error occurred", statusCode: 500);
                }
            }
    IActionResult类：
        - 属性：
            示例：
                namespace YourNamespace
                {
                    [ApiController]
                    [Route("api/[controller]")]
                    public class MyController : ControllerBase
                    {
                        // 模拟的用户数据
                        private static List<Person> people = new List<Person>
                        {
                            new Person { Id = 1, Name = "张三", Age = 12, Gender = "男" },
                            new Person { Id = 2, Name = "王五", Age = 19, Gender = "男" }
                        };

                        // 成功响应示例
                        [HttpGet("success")]
                        public IActionResult Success()
                        {
                            // 返回 HTTP 状态码 200 OK，并附带一个 JSON 对象作为响应内容
                            return Ok(new { message = "Request succeeded" });
                        }

                        // 未找到资源的示例
                        [HttpGet("not-found")]
                        public IActionResult NotFoundExample()
                        {
                            // 返回 HTTP 状态码 404 Not Found，并附带一个 JSON 对象作为错误信息
                            return NotFound(new { error = "Resource not found" });
                        }

                        // 请求无效的示例
                        [HttpGet("bad-request")]
                        public IActionResult BadRequestExample()
                        {
                            // 返回 HTTP 状态码 400 Bad Request，并附带一个 JSON 对象作为错误信息
                            return BadRequest(new { error = "Invalid input" });
                        }

                        // 禁止访问的示例
                        [HttpGet("forbidden")]
                        public IActionResult ForbiddenExample()
                        {
                            // 返回 HTTP 状态码 403 Forbidden
                            return StatusCode(403, new { error = "Access is forbidden." });
                        }

                        // 自定义状态码的示例
                        [HttpGet("custom-status")]
                        public IActionResult CustomStatus()
                        {
                            // 返回自定义的 HTTP 状态码 503 Service Unavailable，并附带错误信息
                            return StatusCode(503, new { error = "Service Unavailable" });
                        }

                        // 返回文件的示例
                        [HttpGet("file")]
                        public IActionResult FileExample()
                        {
                            // FileContentResult：返回文件二进制内容。
                            // FileStreamResult：返回文件流。
                            // PhysicalFileResult：返回物理路径上的文件。
                            // 读取本地文件的内容（假设文件名为 "example.pdf"）
                            byte[] fileContents = System.IO.File.ReadAllBytes("example.pdf");
                            // 返回文件内容，并指定 MIME 类型为 "application/pdf"
                            return File(fileContents, "application/pdf");
                        }

                        // 重定向的示例
                        [HttpGet("redirect")]
                        public IActionResult RedirectExample()
                        {
                            // 返回 HTTP 状态码 302 Found，并重定向到指定的 URL
                            // 可用作错误查询数据返回内容
                            return Redirect("https://example.com");
                        }

                        // 返回问题详情的示例
                        [HttpGet("problem")]
                        public IActionResult ProblemExample()
                        {
                            // 返回 HTTP 状态码 500 Internal Server Error，并附带详细的错误信息
                            return Problem(detail: "An error occurred", statusCode: 500);
                        }

                        // 返回挑战响应的示例（通常用于身份验证）
                        [HttpGet("challenge")]
                        public IActionResult ChallengeExample()
                        {
                            // 返回 HTTP 状态码 401 Unauthorized，并触发身份验证挑战
                            return Challenge();
                        }

                        // 返回登出响应的示例
                        [HttpGet("signout")]
                        public IActionResult SignOutExample()
                        {
                            // 返回 HTTP 状态码 200 OK，并触发用户登出
                            return SignOut();
                        }

                        // 返回 JSON 格式的响应的示例
                        [HttpGet("json")]
                        public IActionResult json()
                        {
                            // 返回 JSON 格式的响应内容
                            var data = new { Message = "Hello, World!" };
                            return Json(data);
                        }
                        // 返回任意内容响应的示例
                        [HttpGet("any")]
                        public IActionResult any()
                        {
                            // 返回任意内容响应内容
                            return Content("Hello, World!");
                        }
                    }

                    // 定义 Person 类
                    public class Person
                    {
                        public int Id { get; set; }
                        public string Name { get; set; }
                        public int Age { get; set; }
                        public string Gender { get; set; }
                    }
                }
        - 使用方法：
          1. 通过查询字符串传递参数
              查询字符串是附加在 URL 末尾的键值对，通常用于传递可选参数。例如：
              https://example.com/api/mycontroller?param1=value1&param2=value2
              在 ASP.NET Core 中，你可以通过方法参数接收查询字符串参数。例如：
                  [HttpGet("search")]
                  public IActionResult Search(string param1, int param2)
                  {
                      // param1 和 param2 是查询字符串参数
                      return Ok(new { param1, param2 });
                  }
                  调用示例：
                  GET /api/mycontroller/search?param1=example&param2=123
          2. 通过路由参数传递参数
              路由参数是嵌入在 URL 路径中的参数，通常用于传递必需的参数。例如：
              https://example.com/api/mycontroller/123
              在 ASP.NET Core 中，可以通过在路由模板中定义参数来接收路由参数。例如：
                  [HttpGet("{id}")]
                  public IActionResult GetById(int id)
                  {
                      // id 是路由参数
                      return Ok(new { id });
                  }
                  调用示例：
                  GET /api/mycontroller/123
          3. 同时使用查询字符串和路由参数
              可以在同一个方法中同时使用查询字符串和路由参数。例如：
                  [HttpGet("{id}")]
                  public IActionResult GetById(int id, [FromQuery] string queryParam)
                  {
                      // id 是路由参数，queryParam 是查询字符串参数
                      return Ok(new { id, queryParam });
                  }
                  调用示例：
                  GET /api/mycontroller/123?queryParam=example
          4. 使用 [FromQuery] 特性
              对于复杂的查询参数，可以使用 [FromQuery] 特性明确指定参数来源。例如：
                  [HttpGet("search")]
                  public IActionResult Search([FromQuery] string param1, [FromQuery] int param2)
                  {
                      return Ok(new { param1, param2 });
                  }
                  调用示例：
                  GET /api/mycontroller/search?param1=example&param2=123
          5. 接收多个查询参数
              如果需要接收多个查询参数，可以定义一个模型类来封装这些参数。例如：
                  public class SearchParams
                  {
                      public string Param1 { get; set; }
                      public int Param2 { get; set; }
                  }

                  [HttpGet("search")]
                  public IActionResult Search([FromQuery] SearchParams params)
                  {
                      return Ok(params);
                  }
                  调用示例：
                  GET /api/mycontroller/search?param1=example&param2=123
          6. 默认值和可选参数
              可以为查询字符串参数提供默认值或标记为可选。例如：
                  [HttpGet("search")]
                  public IActionResult Search(string param1 = "default", int? param2 = null)
                  {
                      return Ok(new { param1, param2 });
                  }
                  调用示例：
                  GET /api/mycontroller/search
                  GET /api/mycontroller/search?param1=example
                  GET /api/mycontroller/search?param2=123
        
    [FromBody] 请求正文
    [FromForm] 请求正文中的表单数据
    [FromHeader] 请求标头
    [FromQuery] 请求查询字符串参数
    [FromRoute] 当前请求中的路由数据
    [FromServices] 作为操作参数插入的请求服务
    [AsParameters] 方法参数

## WebAPI基础

### 1-8

    理解HTTP协议
        - HTTP是一种超文本传输协议，也就是说HTTP是一种协议，当我们在浏览器中输入任意一个网址时，都会使用http://或https://开头来访问
          - http:// https:// 后者比前者多一个SSL，安全协议
        - HTTP协议是基于TCP/IP这个通信协议在互联网上传送数据，所传送的数据有：文本、图片、音频、视频等。
        - TCP/IP是传输控制协议/网际协议，其中包括了FTP（上传文件协议）、SMTP（邮件协议）、TCP、UDP、IP等组成的协议簇，而TCP和IP是核心协议。
    HTTP工作原理
        - HTTP协议主要工作在服务器端和客户端（浏览器）之间：
            客户端通过URL地址向服务器端发送HTTP请求
            服务器端接收到HTTP请求后进行处理，并向客户端发送HTTP响应
        - HTTP协议默认的访问端口号是80，访问时可以省略
        - HTTP协议是无状态的，无状态表示无法存储数据，也就是没有记忆能力
    理解HTTP消息
        - HTTP消息：
          - 不管是从客户端向服务器端发送HTTP请求，还是从服务器端向客户端发送HTTP响应，其内容都会包含在HTTP消息体中
            HTTP请求消息体
                HTTP请求消息体由三部分组成：
                  - 请求行：在请求行中，包含一些与请求相关的核心对象，主要有请求方法（Get/Post/Put/Delete）、请求URL
                  - 请求头：包含在Headers中的Request Header中，以键值对的形式传输与请求相关的额外信息
                  - 请求正文：包含从客户端向服务器端发送的正文内容，如注册用户的用户名、密码、手机号等信息
            HTTP响应消息体
                HTTP响应消息体由三部分组成：
                  - 包含HTTP协议和版本号，状态码，状态码的文本描述等。其中状态码最为重要，可以得到服务器响应的情况，如200表示请求成功，已被处理
                  - 常见的状态码如下：
                    1xx 指示信息（Informational）
                        表示请求已接收，需要继续处理。
                            常见状态码：
                            100 Continue：服务器已收到请求的初始部分，客户端应继续发送请求的其余部分。
                            101 Switching Protocols：服务器同意更改协议。
                    2xx 成功（Success）
                        表示请求已被成功接收、理解、接受。
                        常见状态码：
                            200 OK：请求成功。
                            201 Created：请求成功并且服务器创建了新的资源。
                            202 Accepted：服务器已接受请求，但尚未处理。
                            204 No Content：服务器成功处理了请求，但没有返回任何内容。
                    3xx 重定向（Redirection）
                        要完成请求必须进行更进一步的操作。
                        常见状态码：
                            301 Moved Permanently：请求的资源已永久移动到新位置。
                            302 Found：请求的资源临时移动到另一个位置。
                            304 Not Modified：自从上次请求后，资源没有被修改过。
                    4xx 客户端错误（Client Error）
                        请求有语法错误或请求无法实现。
                        常见状态码：
                            400 Bad Request：服务器无法理解请求。
                            401 Unauthorized：请求需要用户的身份认证。
                            403 Forbidden：服务器理解请求但拒绝执行。
                            404 Not Found：服务器找不到请求的资源。
                            405 Method Not Allowed：请求中指定的方法不被允许。
                    5xx 服务器端错误（Server Error）
                        服务器未能实现合法的请求。
                        常见状态码：
                            500 Internal Server Error：服务器遇到意外情况，无法完成请求。
                            501 Not Implemented：服务器不支持请求的功能，无法完成请求。
                            503 Service Unavailable：服务器暂时无法处理请求，通常是过载或维护。
                响应头：
                    包含响应的附加信息，如响应时间、内容类型和内容长度等
                响应正文：
                    包含服务器向客户端发送的响应内容，如文本、图片、音视频、html、Json、文本等内容
    理解HTTP对象
        - HTTP请求方法是值在客户端（浏览器）向服务器端（ASP.NET Core WebApi）请求时，所采用的请求方式
        - 每个HTTP请求必须使用一种请求当时才能符合HTTP协议要求，并能让Web服务器接收请求
        - 常见的HTTP请求方法如下：
            ---使用最频繁（核心）
                1.HTTP Get请求：主要用于从服务器端获取数据，所传递的数据保留在URL地址上，不安全，便于书签收藏
                2.HTTP Post请求：主要用于向服务器添加、提交新数据，数据包含在消息体中传输，安全，不能书签收藏
                3.HTTP Put请求：主要用于向服务器更改数据，数据包含在消息体中传输，安全，不能书签收藏
                4.HTTP Delete请求：主要用于在服务器上删除数据
            ---使用比较少
                5.HTTP Head请求：主要用于获取服务器端返回的报文头信息
                6.HTTP Options请求：主要用于获取当前URL所在服务器支持的HTTP请求方法，若请求成功，则它会在HTTP HEAD中包含一个名为“Allow”的头，值是所支持的HTTP请求方法，如“GET, POST, PUT, DELETE”等
                7.HTTP TRACE请求：主要用于反馈服务器收到的请求，主要用于测试或诊断。
                8.HTTP PATCH请求：主要用来对已知资源进行局部更新
        - HTTP内容类型
            - HTTP内容类型使用Content-Type表示，是指在Web服务器上响应给客户端内容的类型，如果服务器返回的是HTML页面，则内容类型为text/html。通常还会包括编码、UTF-8等
                通常内容类型为application/json，表示返回的是JSON字符串
            - 数据返回的类型格式
                以下是提取的常见文件扩展名及其对应的MIME类型：
                  - .java -> java/*
                  - .jpe -> image/jpeg
                  - .jpeg -> image/jpeg
                  - .jpg -> application/x-jpg
                  - .jsp -> text/html
                  - .lar -> application/x-laplayer-reg
                  - .lavs -> audio/x-liquid-secure
                  - .lmsff -> audio/x-la-lms
                  - .ltr -> application/x-ltr
                  - .m2v -> video/x-mpeg
                  - .m4e -> video/mpeg4
                  - .man -> application/x-troff-man
                  - .mdb -> application/msaccess
                  - .mfp -> application/x-shockwave-flash
                  - .jff -> image/jpeg
                  - .jpe -> application/x-jpe
                  - .jpg -> image/jpeg
                  - .js -> application/x-javascript
                  - .la1 -> audio/x-liquid-file
                  - .latex -> application/x-latex
                  - .lbm -> application/x-lbm
                  - .ls -> application/x-javascript
                  - .m1v -> video/x-mpeg
                  - .m3u -> audio/mpegurl
                  - .mac -> application/x-mac
                  - .math -> text/xml
                  - .mdb -> application/x-mdb
                  - .mht -> message/rfc822
                媒体类型是由扩展名和内容类型组成，媒体类型使用MIME类型表示，除了包括内容类型，还会包括扩展名
    理解WebApi
        - API是应用程序编程接口，向客户端提供服务的接口
        - WebAPI是在API的基础上使用HTTP协议构建的API
        - WebAPI是放在一台提供服务的Web服务器上的，然后公开一些API接口供外部通过URL地址调用
        - WebAPI就是通过HTTP协议在互联网上提供服务的，相比API来说，在应用上有些限制WebAPI只是通过URL地址来提供服务
        - WebAPI提供的服务是存放在一个固定的Web服务器上的，通过一个URL地址开放服务
        - 而调用WebAPI的一端，统一称为客户端，例如：浏览器、手机端APP、桌面应用程序等都是客户端
        - 对于WebApi能够提供的服务主要包括：获取数据、添加数据、更新数据、删除数据和查询数据（CURD）
    理解Restful
        - Restful是API设计的一种规范，主要用于Web服务的接口设计
            如果有一个架构符合Rest原则，就称它为Restful架构
        - 微软在ASP.NET中设计的WebApi就是基于Restful设计的，所有可以提供多种应用程序调用
        - Rest规范
          - Rest组成：
            - Resource：表示资源，即数据，如学生基本信息等。
            - Representational：表现形式，比如用JSON，XML，JPEG等
            - State Transfer：状态变化，通过HTTP动词实现
          - 使用Restful架构的好处是它只提供资源，可供各种各样的客户端调用，不再像MVC、PHP、JSP等这种一体的设计，即前后端分离
          - 服务器端：服务器端通过Restful标准的WebApi提供资源，使用什么语言实现无所谓
          - 客户端：而在客户端，只需要调用这个WebApi处理资源即可，实现了前后端分离
        - HTTP动词
            在ASP.NET Core WebAPI中，微软定义了4种用于执行资源的CRUD操作。
                MVC、WebApi等是BS结构Web应用程序大多数都是基于ASP.NET Core
                    Browser-Server（浏览器-服务器）结构，这是一种客户端-服务器架构
                MVC 和 Web API 都是构建在 ASP.NET Core 上的框架，用于开发 BS 结构的 Web 应用程序
            常用HTTP动词：
              - HTTP GET：用于获取服务器上的资源。
                  GET: http://xx/api/TodoItems/(id)，根据id获取资源。
              - HTTP POST：用于添加资源到服务器上。
                  POST: http://xx/api/TodoItems，添加新资源。
              - HTTP PUT：用于更新资源到服务器上。
                  PUT: http://xx/api/TodoItems/(id)，根据id更新资源。
              - HTTP DELETE：用于删除服务器上的资源。
                  DELETE: http://xx/api/TodoItems/(id)，根据id删除资源。
    理解ASP.NET Core中的WebApi
        1.WebApi是提供数据服务的一种HTTP服务接口，使用URL地址提供，可以在任意客户端（如JavaScript、jQuery、VUE、React、Angular、手机APP端、PC端等）调用，通过URL地址实现数据的添加、更新、删除和查询操作
        2.WebApi只是一种提供数据的HTTP服务，实现了服务器与客户端的分离，且客户端不再受限制
    ASP.NET WebApi
        1.微软官方定义：可以对接各种客户端（浏览器、移动设备、桌面应用等），构建HTTP服务框架
        2.ASP.NET的WebAPI是在.NET Framework下的ASP.NET MVC框架中产生的，利用了MVC框架中的M（模型）和C（控制器），但没有V（视图）
        3.若要处理HTTP请求，Web API需要使用控制器，Web API中的控制器是继承了ControllerBase的子类，与MVC中的控制器继承的Controller是不一样的
            - WebApi不需要视图，所以可以继承ControllerBase类
            - MVC需要视图，所以要继承Controller类
        4.在ASP.NET Core中，WebApi是通过控制器中的操作（方法）提供资源和服务
    ASP.NET Core WebApi应用程序
        - ASP.NET Core是一个跨平台开源的Web开发框架，基于此框架可以开发MVC应用、Razor单页应用、WebAPI等
        - 在ASP.NET Core框架上开发的WebAPI是基于RESTful规范创建出优秀WebAPI，供客户端应用调用，适合服务器端和客户端分离的应用程序
    创建WebApi项目
        vs2022中选择ASP.NET Core Web Api
            1.控制器文件需要放在Controllers文件夹中，并且以Controller为结尾命名
            2.WebApi的控制器需要使用[ApiController]特性，表示该控制器是一个API控制器
            3.appsetting.json:JSON格式的应用程序配置文件(数据库连接字符串、发布到生产环境等)
                appsettings.Development.json:为开发环境配置
            4.Program.cs:控制台应用程序入口，针对WebApi进行初始化基础配置
    理解ASP.NET Core WebApi控制器
        ControllerBase基类
            1.ControllerBase类提供了很多用于处理HTTP请求的属性和方法
            2.ControllerBase类不支持视图的MVC控制器的抽象类
            3.ControllerBase基类只支持HTTP请求的相关操作，所以适合WebApi
            4.MVC中的控制器是Controller基类，是继承ControllerBase的基类
                - MVC具备WebApi功能
        ApiController特性
            1.默认情况下，API控制器是具有ApiController特性
            2.ApiController继承了ControllerAttribute
            3.ApiController属性提供的额外功能如下：
                - 自动模型状态验证：框架会自动验证ModelState，在Action执行之前，Model绑定之后，在内部会检查ModelState的IsValid是否为False
                  - - Action参数就是在控制器下面创建的方法
                - 参数绑定策略的自动推断：例如[FromBody]标注的Action参数，在反序列化时，使用了[ApiController]属性之后，则可不再使用[FromBody]特性
                - 处理multipart/form-data请求：如果你的Action里面的一个参数指定了[FromFile]特性（主要用于文件上传），框架会自动假设请求是multipart/form-data类型
                - ApiExplorer的可见性：默认所有的Controller对ApiExplorer都是可见的，所以，不影响swagger的生成
                - 基于特性的路由：框架要求只使用基于特性的路由，使用[Route("")]指定路由
        Route特性
            1.对于API控制器，如果使用了[ApiController]属性，则要求必须使用特性路由来匹配请求的URL。
            2.特性路由也称为属性路由，是指直接在控制器上使用[Route]特性指定路由模板实现URL匹配。

            在launchSettings.json中可以配置访问地址等参数

## HTTP资源操作

### 2_1_HTTPGet

    创建控制器
      1. MVC控制器继承的是Controller基类
      2. API控制器继承的是ControllerBase基类
      3. 控制器都是以Controller为结尾
    添加操作
        1. 在控制器下面创建的方法叫做操作
        2. 属性路由
            - [Route("api/[controller]")]
            - URL地址以api/开头，后跟控制器名称，不需要带后缀（api/GetTest）
            - 路由模板中匹配的URL地址不区分大小写
        3. 在控制器内，创建的方法没有指定操作方式关键字或者没有指定路由，则默认为Get请求，有且只能由一个
            - 在使用指定路由时，可以直接通过地址栏修改路由访问地址获取数据
              - 示例：
                    [Route("GetStr1")]
                    public string GetMain1() {}
                    [Route("GetStr2")]
                    public string GetMain2(){}
        4. 可以直接使用类来存储数据
            示例：
                public List<Person> Get_3()
                {
                    List<Person> per = new List<Person>()
                    {
                        new Person(1,"张三",12,'男'),
                        new Person(2,"王五",19,'男')
                    };
                    return per;
                }
        8. 返回一行数据
            - HttpGet标注，表示这个是一个Get请求，用于获取数据
            - ActionResult<xxx>表示返回一个xxx的一个对象
            - 在操作内实例化xxx对象，并返回实例化后的对象
            示例：
                [HttpGet("OneRowGetPerson")]
                public ActionResult<Person> GetOnePerson()
                {
                    Person person = new Person(3, "何七", 34, '女');
                    return person;
                }

### 2_2_HTTPPost

    1. 在客户端执行Http Post请求时，是将数据放在了Http请求正文中，提交到服务器上
    2. 而到了Webapi服务器端，从Http请求正文获取数据对象，并通过C#代码实现后续操作
    3. 使用Http post实现数据的添加功能，并使用Jquery在客户端调用
    4. POST 请求必须有 Content-Type: application/json，否则 FromBody 可能无法正确解析。
    5. 如果不加 [FromBody]，默认情况下 ASP.NET Core 可能无法正确解析 JSON。
    6. 处理大文件上传（如图片、文档）POST 还常用于 文件上传，但 JSON 不能直接传递二进制文件，建议使用 multipart/form-data
        - 示例：
          - [HttpPost("Upload")]
            public async Task<IActionResult> UploadFile(IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("请选择一个文件");
                }

                var filePath = Path.Combine("uploads", file.FileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { Message = "文件上传成功", FileName = file.FileName });
            }



    启用静态文件（Program.cs）
        app.UseStaticFiles()
    使用html页面测试
        在没有配置跨域的前提下，在同一服务器上是可以自动匹配路径访问到api地址
    传参方式
        1.只传递一个参数
            如果只是传递一个参数可以使用如下方法，需要注意的是该参数的key必须为空，同时后台必须加上[FromBody]标识
            示例：
                [HttpPost]
                public string GetUserInfo([FromBody] string userName)
                {
                    return string.Format("名称：{0}", userName);
                }
        2.传递多个参数映射到实体类（推荐）
            如果希望前端参数映射到实体类可以使用如下方法
            示例：
                [HttpPost]
                public string GetUserInfo([FromBody] User user)
                {
                    return string.Format("编号：{0}，用户名：{1}，密码：{2}", user.Id, user.UserName, user.Password);
                }
        3.利用JObject接收多个参数
            这种方法比较推荐，无论是一个参数还是多个参数都能使用
            示例：
                [HttpPost]
                public string GetUserInfo([FromBody] JObject obj)
                {
                    int id = int.Parse(obj["id"].ToString());
                    string userName = obj["userName"].ToString();
                    string password = obj["password"].ToString();
                    return string.Format("编号：{0}，用户名：{1}，密码：{2}", id, userName, password);
                }
    使用 ModelState 进行请求数据校验
        示例：
            定义
                using System.ComponentModel.DataAnnotations;
                public class UserDto
                {
                    [Required(ErrorMessage = "ID 不能为空")]
                    public int Id { get; set; }

                    [Required(ErrorMessage = "用户名不能为空")]
                    [StringLength(20, ErrorMessage = "用户名长度不能超过 20 个字符")]
                    public string UserName { get; set; }

                    [Required(ErrorMessage = "密码不能为空")]
                    [MinLength(6, ErrorMessage = "密码至少需要 6 个字符")]
                    public string Password { get; set; }
                }
            调用校验
                [HttpPost("AddUser")]
                public IActionResult AddUser([FromBody] UserDto user)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    return Ok(new { Message = "用户添加成功", UserId = user.Id });
                }
    防止 CSRF（跨站请求伪造）
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

### 2_2_HTTPPut

    基本PUT
        public IActionResult UpdateCat(int UUid, [FromBody] Product newCat)
    表单更新
        public IActionResult UpdateCat(int UUid, [FromForm] Product newCat)
    使用查询字符串
        public IActionResult UpdateCat(int UUid, [FromQuery] string name, [FromQuery] int age)
    使用路由
        public IActionResult UpdateCat(int UUid, [FromBody] Product newCat)
        {
            ...
            ReqCat.UUid = uuid;
            ReqCat.Name = newCat.Name;
            ...
        }
    使用请求标头
    用依赖注入
    使用方法参数(直接传递参数)
        public IActionResult UpdateCat(int UUid, string name, int age)

    更新数据使用Put请求
        对于更新操作，可以只更新其中的部分数据，也可以更新整个数据
        从客户端向服务器传送数据时，是按照JSON对象字符串形式传递的，所以对于不更新的数据，可以传空值，但对象中的属性需要都带上
