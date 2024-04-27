﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.ServicesInterfaces;
using System.Net;
using System.Text.Json;

namespace SocialMedia.Presentation.API.ControllerPresenter
{
    public class Presenter
    {
        private ContentResult Response {  get; set; }
        public Presenter()
        {
            Response = new ContentResult()
            {
                ContentType = "application/json",
            };
        }
        public async Task<IActionResult> Handle<TRequest,TResponse>(TRequest requestDto,IGenericService<TRequest,TResponse>service)
        {
            var result = await service.Perform(requestDto);
            Response.Content = JsonSerializer.Serialize(result);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Response;
        }
     }

}
