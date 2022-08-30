﻿using AutoMapper;
using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;


        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var result = _postService.GetList();

            var postDTO = _mapper.Map<List<PostDTO>>(result);

            return new ObjectResult(CustomResponse<List<PostDTO>>.Success(postDTO, 200)) { StatusCode = 200 };
        }

        [HttpGet("{count}")]
        public IActionResult GetLastNPosts(int count)
        {
            var result = _postService.GetLastNPost(count);

            return new ObjectResult(CustomResponse<List<MiniPostViewDTO>>.Success(result, 200)) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostDTO createPostDto)
        {
            _postService.Create(_mapper.Map<Post>(createPostDto));
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _postService.GetById(id);
            _postService.Delete(post);
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }


        [HttpPut]
        public IActionResult UpdateProduct(UpdatePostDTO updatePostDTO)
        {
            _postService.Update(_mapper.Map<Post>(updatePostDTO));
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }

    }
}
