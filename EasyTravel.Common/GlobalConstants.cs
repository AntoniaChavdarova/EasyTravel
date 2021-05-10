namespace EasyTravel.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "EasyTravel";

        public const string AdministratorRoleName = "Administrator";

        public static class DataValidations
        {
            public const int NameMaxLength = 40;

            public const int NameMinLength = 2;

            public const int AddressMaxLength = 100;

            public const int AddressMinLength = 4;

            public const int DescriptionMinLength = 20;
        }

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd-MM-yyyy";

            public const string TimeFormat = "h:mmtt";

            public const string DateTimeFormat = "dd-MM-yyyy h:mmtt";
        }
    }
}
