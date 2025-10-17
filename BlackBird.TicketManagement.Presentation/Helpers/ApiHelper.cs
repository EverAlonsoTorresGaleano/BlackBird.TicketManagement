using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Builder;
using BlackBird.TicketManagement.Entities.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlackBird.TicketManagement.Presentation.Helpers;

public static class ApiHelper
{

    public static IHostApplicationBuilder AddAuthenticationForJwtServer(this IHostApplicationBuilder builder, IdentityServiceServerSettingsOptions serverOptions)
    {
        IdentityServiceServerSettingsOptions serverOptions2 = serverOptions;
        builder.Services.AddAuthentication(delegate (AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(delegate (JwtBearerOptions options)
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(serverOptions2.Key)),
                ValidIssuer = serverOptions2.Issuer,
                ValidAudience = serverOptions2.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
        return builder;
    }


}
