using ABM.Application.Contracts;
using System.Linq;

namespace ABM.Application
{
    public class DeclarationValidator : IDeclarationValidator
    {
        public int Validate(InputContract input)
        {
            if (input.DeclarationList.Any(x => x.Command != "DEFAULT"))
                return -1;
            else if (input.DeclarationList.Any(x => x.DeclarationHeader.SiteID != "DUB"))
                return -2;

            return 0;
        }
    }
}
