﻿namespace HomePro.Common
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

        public static class Address 
        {
            public const int CountryMinLength = 5;
            public const int CountryMaxLength = 60;

            public const int CityMinLength = 2;
            public const int CityMaxLength = 170;

            public const int DistrictMinLength = 5;
            public const int DistrictMaxLength = 50;

            public const int StreetNameMinLength = 1;
            public const int StreetNameMaxLength = 50;

            public const int StreetNumberMinLength = 1;
            public const int StreetNumberMaxLength = 50;

            public const int BuildingNumberMinLength = 1;
            public const int BuildingNumberMaxLength = 10;

            public const int FloorMinLength = 1;
            public const int FloorMaxLength = 10;

            public const int EntryMinLength = 1;
            public const int EntryMaxLength = 10;

            public const int PostalCodeMinLength = 4;
            public const int PostalCodeMaxLength = 10;

        }

        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;
        }
    }
}
