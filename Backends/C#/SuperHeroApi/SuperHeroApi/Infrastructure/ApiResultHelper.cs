using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace SuperHeroApi.Infrastructure
{
    public static class ApiResultHelper
    {
        public static readonly JsonSerializerSettings DefaultSerializerSettings = null;

        public static readonly System.Text.Json.JsonSerializerOptions DefaultSerializerOptions = null;

        static ApiResultHelper()
        {
            DefaultSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            DefaultSerializerOptions = new System.Text.Json.JsonSerializerOptions();
        }

        public static IActionResult ApiResult(this ControllerBase controller, object content)
        {
            return ApiResult(controller.Request, HttpStatusCode.OK, content, DefaultSerializerOptions);
        }

        public static IActionResult ApiResult(this ControllerBase controller, HttpStatusCode statusCode, object content)
        {
            return ApiResult(controller.Request, statusCode, content, DefaultSerializerOptions);
        }

        public static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content)
        {
            return ApiResult(request, statusCode, content, DefaultSerializerOptions);
        }

        public static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content, System.Text.Json.JsonSerializerOptions serializerSettings)
        {
            var supportedResponseTypes = new string[] { "json", "xml" };
            var responseType = "json";

            string requestedContentType = request.Query["type"];

            if (!string.IsNullOrEmpty(requestedContentType) && supportedResponseTypes.Contains(requestedContentType, StringComparer.OrdinalIgnoreCase))
            {
                responseType = requestedContentType;
            }

            // todo, add more response types (xml, etc)

            if (responseType.Equals("json"))
            {
                var result = new JsonResult(content, serializerSettings)
                {
                    StatusCode = (int)statusCode
                };

                return result;
            }
            else
                throw new NotSupportedException("output format not supported");
        }
    }
}
