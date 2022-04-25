using Application.Shared.Services;
using MagicOnion;
using MagicOnion.Server;

namespace Services
{
    public class ApplicationService : ServiceBase<IApplicationService>, IApplicationService
    {
        // `UnaryResult<T>` allows the method to be treated as `async` method.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }
    }
}
