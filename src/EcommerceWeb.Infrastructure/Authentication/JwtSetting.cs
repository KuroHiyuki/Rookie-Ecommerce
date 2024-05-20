using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Authentication
{
    public record JwtSetting
    {
        public const string SectionName = "JwtSetting";
        public string? Secret { get; init; }
        public int ExpiryMinutes { get; init; }
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
    }
}
