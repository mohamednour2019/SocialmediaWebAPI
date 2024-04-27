﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class CommentController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddCommentResponseDto))]
        public async Task<IActionResult>addComment(AddCommentRequestDto requestDto,
            [FromServices]IAddCommentService addCommentService)=>
            await _presenter.Handle(requestDto, addCommentService);

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCommentResponseDto))]
        public async Task<IActionResult> deleteComment(DeleteCommentRequestDto requestDto,
        [FromServices] IDeleteCommentService deleteCommentService) =>
        await _presenter.Handle(requestDto, deleteCommentService);


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCommentResponseDto))]
        public async Task<IActionResult> updateComment(UpdateCommentRequestDto requestDto,
        [FromServices] IUpdateCommentService updateCommentService) =>
        await _presenter.Handle(requestDto, updateCommentService);


    }
}