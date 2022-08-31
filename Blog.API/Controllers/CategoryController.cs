using AutoMapper;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetList();

            var categoriesDto = _mapper.Map<List<CategoryWithIdDTO>>(result);

            return new ObjectResult(CustomResponse<List<CategoryWithIdDTO>>.Success(categoriesDto, 200)) { StatusCode = 200 };
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetCategoriesWithCounts()
        {
            var result = _categoryService.GetCategoriesWithPostsCount();

            var categoriesDto = _mapper.Map<List<CategoryWithPostsCount>>(result);

            return new ObjectResult(CustomResponse<List<CategoryWithPostsCount>>.Success(categoriesDto, 200)) { StatusCode = 200 };
        }


        [HttpGet("{id}")]
        public IActionResult GetCategoryWithPosts(int id)
        {
            var result = _categoryService.GetCategoryByIdWithPosts(id);

            return new ObjectResult(CustomResponse<CategoryWithPostsDTO>.Success(result, 200)) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO categoryDto)
        {
            _categoryService.Create(_mapper.Map<Category>(categoryDto));
            return new ObjectResult(CustomResponse<NoDataDto>.Success( 200)) { StatusCode = 200 };
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryUpdateDTO categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }
    }
}
