using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Autofac;
using Http.TestLibrary;
using SubcutaneousTestsPresentation.Tests.TestHelpers.Fixtures;
using SubcutaneousTestsPresentation.Features;
using SubcutaneousTestsPresentation.Infrastructure.Database;
using TestStack.BDDfy;
using TestStack.FluentMVCTesting;
using Xunit;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers
{
    [UseReporter(typeof(DiffReporter))]
    [UseApprovalSubdirectory("Approvals")]
    public abstract class SubcutaneousMvcTest<TController> : IDisposable
        where TController : BaseController
    {
        private readonly HttpSimulator _httpRequest;
        private readonly ILifetimeScope _container;
        private readonly DatabaseFixture _database;
        protected TController Controller { get; set; }
        protected ControllerResultTest<TController> ActionResult { get; set; }

        protected SubcutaneousMvcTest()
        {
            _database = new DatabaseFixture();
            _container = ContainerFixture.GetTestLifetimeScope(cb => cb
                .Register(c => _database.WorkDbContext)
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerTestRun());

            RouteTable.Routes.Clear();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _httpRequest = new HttpSimulator().SimulateRequest();
            Controller = _container.Resolve<TController>();
            Controller.ControllerContext = new ControllerContext(new HttpContextWrapper(HttpContext.Current), new RouteData(), Controller);
        }

        protected void ExecuteControllerAction(Expression<Func<TController, Task<ActionResult>>> action)
        {
            ActionResult = Controller.WithCallTo(action);
        }

        protected void ExecuteControllerAction(Expression<Func<TController, ActionResult>> action)
        {
            ActionResult = Controller.WithCallTo(action);
        }

        [Fact]
        public virtual void ExecuteScenario()
        {
            this.BDDfy();
        }

        protected T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        protected SubcutaneousTestsPresentationDbContext SeedDbContext { get { return _database.SeedDbContext; } }
        protected SubcutaneousTestsPresentationDbContext VerifyDbContext { get { return _database.VerifyDbContext; } }

        public void Dispose()
        {
            _httpRequest.Dispose();
            _database.Dispose();
            _container.Dispose();
        }

        protected void Approve(string textToApprove)
        {
            using (NamerFactory.AsEnvironmentSpecificTest(() => GetType().Name))
            {
                Approvals.Verify(textToApprove);
            }
        }
    }
}