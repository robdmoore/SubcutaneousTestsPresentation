using System.Threading.Tasks;
using Autofac;

namespace SubcutaneousTestsPresentation.Infrastructure.Commands
{
    public interface ICommandExecutor
    {
        Task ExecuteAsync<T>(T command) where T : ICommand;
    }

    public class CommandExecutor : ICommandExecutor
    {
        private readonly ILifetimeScope _currentScope;

        public CommandExecutor(ILifetimeScope currentScope)
        {
            _currentScope = currentScope;
        }

        public Task ExecuteAsync<T>(T command) where T : ICommand
        {
            var handler = _currentScope.Resolve<ICommandHandler<T>>();

            return handler.ExecuteAsync(command);
        }
    }
}