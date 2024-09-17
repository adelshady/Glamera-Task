using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.Common.SharedDto
{
    public class ResponseHandler
    {
        public ResponseHandler() { }

        public ApiResponse<T> Deleted<T>()
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully",
            };
        }

        public ApiResponse<T> Success<T>(T entity, object Meta = null)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Success",
                Meta = Meta
            };
        }

        public ApiResponse<T> EditSuccess<T>(T entity, object Meta = null)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated Successfully",
                Meta = Meta
            };
        }

        public ApiResponse<T> Success<T>(T entity, string message, object Meta = null)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }

        public ApiResponse<T> Unauthorized<T>(string message = null)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = string.IsNullOrEmpty(message) ? "Unauthorized" : message
            };
        }

        public ApiResponse<T> BadRequest<T>(string message = null)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = string.IsNullOrEmpty(message) ? "Bad Request" : message
            };
        }

        public ApiResponse<T> NotFound<T>(string message = null)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = string.IsNullOrEmpty(message) ? "Not Found" : message
            };
        }

        public ApiResponse<T> Created<T>(T entity, object Meta = null)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created Successfully",
                Meta = Meta
            };
        }

        public ApiResponse<T> UnprocessableEntity<T>(string message = null)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = string.IsNullOrEmpty(message) ? "UnprocessableEntity" : message
            };
        }
    }
}
