﻿using System.Configuration;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using ChameleonForms;
using Owin;
using SubcutaneousTestsPresentation.Infrastructure.Database;
using SubcutaneousTestsPresentation.Views;

namespace SubcutaneousTestsPresentation
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ContainerConfig.CreateContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var connectionString = ConfigurationManager.ConnectionStrings["SubcutaneousTestsPresentation"].ConnectionString;
            new SubcutaneousTestsPresentationDbContext(connectionString).Database.Initialize(false);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeaturesViewEngine());
            HumanizedLabels.Register();

            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
        }
    }
}