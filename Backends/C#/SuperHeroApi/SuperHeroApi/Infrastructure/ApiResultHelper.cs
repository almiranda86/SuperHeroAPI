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
        static readonly JsonSerializerSettings customSerializerSettings = null;

        static ApiResultHelper()
        {
            customSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public static IActionResult ApiResult(this ControllerBase controller, object content)
        {
            return ApiResult(controller.Request, HttpStatusCode.OK, content);
        }

        public static IActionResult ApiResult(this ControllerBase controller, HttpStatusCode statusCode, object content)
        {
            return ApiResult(controller.Request, statusCode, content);
        }

        internal static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content)
        {
            var supportedResponseTypes = new string[] { "json", "xml" };
            var responseType = "json";

            string requestedContentType = request.Query["type"];

            if (!string.IsNullOrEmpty(requestedContentType) && supportedResponseTypes.Contains(requestedContentType, StringComparer.OrdinalIgnoreCase))
            {
                responseType = requestedContentType;
            }

            if (responseType.Equals("json"))
            {
                var result = new JsonResult(content, customSerializerSettings)
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
