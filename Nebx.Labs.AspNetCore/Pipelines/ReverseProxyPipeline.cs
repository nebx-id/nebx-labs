using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Nebx.Labs.AspNetCore.Pipelines;

/// <summary>
/// Configures the ASP.NET Core request pipeline to correctly process
/// forwarded headers when the application is running behind a reverse proxy.
/// </summary>
/// <remarks>
/// This enables support for the <c>X-Forwarded-For</c> and
/// <c>X-Forwarded-Proto</c> headers so that client IP address and
/// request scheme are resolved correctly.
///
/// Proxy trust is intentionally not restricted here; infrastructure-level
/// controls and <see cref="ForwardedHeadersOptions.ForwardLimit"/> should be
/// used to constrain header processing.
/// </remarks>
public static class ReverseProxyPipeline
{
    /// <summary>
    /// Adds reverse proxy support to the request pipeline by enabling
    /// forwarded header processing.
    /// </summary>
    /// <param name="app">
    /// The application builder used to configure the HTTP request pipeline.
    /// </param>
    public static void UseSupportReverseProxy(this IApplicationBuilder app)
    {
        var options = new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
            KnownProxies = { },
            KnownNetworks = { },
        };

        app.UseForwardedHeaders(options);
    }
}