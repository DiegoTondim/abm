using ABM.Application.Contracts;

namespace ABM.Application
{
    public interface IDeclarationValidator
    {
        int Validate(InputContract input);
    }
}