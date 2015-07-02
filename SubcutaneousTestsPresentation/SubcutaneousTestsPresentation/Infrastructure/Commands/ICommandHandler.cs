using System.Threading.Tasks;

namespace SubcutaneousTestsPresentation.Infrastructure.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task ExecuteAsync(T command);
    }
}