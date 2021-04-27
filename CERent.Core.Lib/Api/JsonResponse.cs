using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;

namespace CERent.Core.Lib.Api
{
    public class JsonResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object Data { get; }

        public string Type { get; }

        public string Message { get;  }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        public JsonResponse(JsonResponseType type, Object data, string message, string code)
        {
            Type = type.ToString("f");
            Data = data;
            Message = message;
            Code = code;
        }

        public JsonResponse(Exception ex)
        {
            Type = JsonResponseType.Error.ToString("f");
            Message = ex.Message;
        }

        public JsonResponse(JsonResponseType type, string message, string code)
        {
            Type = type.ToString("f");
            Message = message;
            Message = code;
        }

        public static JsonResponse Success(Object data = null, string message = null, string code = null)
        {
            return new JsonResponse(JsonResponseType.Success, data, message, code);
        }

        public static JsonResponse Error(string message, string code = null)
        {
            return new JsonResponse(JsonResponseType.Error, message, code);
        }

        public enum JsonResponseType { Success, Error}
    }
}
