using MagicOnion;

namespace Application.Shared.Services
{
    // Defines .NET interface as a Server/Client IDL.
    // The interface is shared between server and client.
    public interface IApplicationService : IService<IApplicationService>
    {
        // The return type must be `UnaryResult<T>`.
        UnaryResult<int> SumAsync(int x, int y);
    }
}