# Webapi(ASP.NET Core Web API)

## DLC

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
