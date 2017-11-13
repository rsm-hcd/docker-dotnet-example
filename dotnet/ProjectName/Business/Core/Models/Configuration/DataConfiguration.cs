namespace ProjectName.Business.Core.Models.Configuration
{
    public class DataConfiguration
    {
        public const int EmailLength            = 250;
        public const int ShortCodeLength        = 10;
        public const int ShortStringLength      = 150;
        public const int ShortDescriptionLength = 500;
        public const int LongDescriptionLength  = 1000;
        public const int UrlLength              = 2083;  // IE has a max of 2083
    }
}
