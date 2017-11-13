using System;

namespace ProjectName.Business.Core.Models.Configuration
{
    public class AccountOptions
    {
        public byte[]   EncryptionKey { get; set; }
        public TimeSpan TokenLifespan { get; set; }
    }
}
