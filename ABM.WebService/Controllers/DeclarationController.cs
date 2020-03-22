using ABM.Application;
using ABM.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ABM.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclarationController : ControllerBase
    {
        private readonly IDeclarationValidator _declarationValidator;

        public DeclarationController(IDeclarationValidator declarationValidator)
        {
            _declarationValidator = declarationValidator;
        }
        public int Post([FromBody]InputContract input)
        {
            return _declarationValidator.Validate(input);
        }
    }
}
