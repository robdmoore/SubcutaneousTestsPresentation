using System;
using ChameleonForms.ModelBinders;
using SubcutaneousTestsPresentation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(RegisterChameleonFormsComponents), "Start")]

namespace SubcutaneousTestsPresentation
{
    public static class RegisterChameleonFormsComponents
    {
        public static void Start()
        {
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
        }
    }
}
