using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RetailerOffers.Api
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string errorMsg;
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    //we can write our exception and handle it here
                    case KeyNotFoundException e:
                        // not found error
                        errorMsg = JsonSerializer.Serialize(new { message = "User Not found" });
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        errorMsg = JsonSerializer.Serialize(new { message = "Please check the enter input" });
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                     //Log the exception to db or filer
                }

                await response.WriteAsync(errorMsg);
            }
        }
    }
}
