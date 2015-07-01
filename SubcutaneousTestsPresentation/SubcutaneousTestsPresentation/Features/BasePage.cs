using System;
using System.Web.Mvc;
using SubcutaneousTestsPresentation.Domain;

namespace SubcutaneousTestsPresentation.Features
{
    public abstract class BasePage : BasePage<dynamic> {}

    public abstract class BasePage<T> : WebViewPage<T>
    {
        protected string PageTitle
        {
            get { return ViewBag.Title; }
            set { ViewBag.Title = value; }
        }

        protected DateTimeOffset Now
        {
            get { return DependencyResolver.Current.GetService<IDateTimeProvider>().Now(); }
        }
    }
}