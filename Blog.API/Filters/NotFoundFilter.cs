using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IPostRepository _repository;

        public NotFoundFilter(IPostRepository repository)
        {
            _repository = repository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                return;
            }

            var id = Convert.ToInt32(idValue);
            var hasProduct = _repository.Any(x => x.Id == id);

            if (hasProduct == false)
            {

                context.Result = new NotFoundObjectResult(CustomResponse<NoDataDto>.Fail("Geçerli id veritabanından bulunamadı", 404));
            }

        }
    }
}
