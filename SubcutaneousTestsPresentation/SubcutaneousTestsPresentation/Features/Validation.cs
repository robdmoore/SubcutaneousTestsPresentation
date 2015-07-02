namespace SubcutaneousTestsPresentation.Features
{
    public static class Validation
    {
        public const string PasswordCriteriaText = "Password must be at least 8 characters and have at least one number, one uppercase character and one lowercase character";
        public const string PasswordHint = PasswordCriteriaText;
        public const string PasswordRegex = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*";

        public const string TitleCriteriaText = "Please leave out the comma and period characters from the title.";
        public const string TitleHint = "e.g. Ms, Mr, Mrs, etc. Do not use any punctuation.";
        public const string TitleRegex = "^[^\\.,]+$";

        public const string PhoneCriteriaText = "Please enter in the format +[country_code][phone_number] with no dashes or spaces.";
        public const string PhoneHint = "Please enter the number in the following format: +country code then the number without dashes or spaces (for example +41123456789 – where 41 is the country code, 12 is the area code and 3456789 is the phone number)";
        public const string PhonePlaceholder = "+[country_code][area_code][phone_number]";
        public const string PhoneRegex = @"^\+\d+$";
    }
}