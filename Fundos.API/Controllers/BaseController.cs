using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Fundos.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string GetErrorModel(ModelStateDictionary modelState)
        {
            return string.Join(" | ", modelState.Values
                                      .SelectMany(x => x.Errors)
                                      .Select(x => x.ErrorMessage));
        }

    }
}
