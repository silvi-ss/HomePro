namespace HomePro.Common
{
    public static class EntityValidationConstants
    {
        public static class Property
        {
            public const int DisplayNameMinLength = 5;
            public const int DisplayNameMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const double SquareMetersMinValue = 1;
            public const double SquareMetersMaxValue = 10000;

            public const int RoomsMinCount = 1;
            public const int RoomsMaxCount = 100;

            public const string DateTimeFormat = "dd-MM-yyyy HH:mm";

            public const int ImageMinLength = 3;
            public const int ImageMaxLength = 256;
            public const string DefaultImageName = "default.jpg";

        }
    }
}
