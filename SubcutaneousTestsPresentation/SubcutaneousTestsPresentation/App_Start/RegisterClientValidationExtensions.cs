using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SubcutaneousTestsPresentation.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace SubcutaneousTestsPresentation.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}