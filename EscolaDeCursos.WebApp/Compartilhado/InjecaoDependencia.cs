using EscolaDeCursos.Dominio.Compartilhado.Identity;
using EscolaDeCursos.WebApp.Compartilhado.Identity;
using EscolaDeCursos.WebApp.Compartilhado.Mapping;
using Microsoft.AspNetCore.Identity;

namespace EscolaDeCursos.WebApp.Compartilhado;

public static class InjecaoDependencia
{
    public static void AddPresentationConfig(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            // Reseta a configuração padrão do MVC
            options.ViewLocationFormats.Clear();

            // Localização das Views dos módulos: Modulos/ModuloCaixa/Apresentacao/Views/Listar.cshtml
            options.ViewLocationFormats.Add("/Modulos/Modulo{1}/Views/{0}.cshtml");

            // Localização das Views compartilhadas: /Compartilhado/Apresentacao/Views/_Layout.cshtml
            options.ViewLocationFormats.Add("/Compartilhado/Views/{0}.cshtml");
        });

        services.AddAuthentication(options =>
        {
            //aplicacao tera um parametro de Cookies
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
        }).AddCookie(IdentityConstants.ApplicationScheme, CookieOptions =>
        {
            //local para o usuario logar
            CookieOptions.LoginPath = "/Autenticacao/Entrar";
            //local para o usuario ser redicionado caso entre em uma acao que precise de login
            CookieOptions.AccessDeniedPath = "/Autenticacao/Entrar";
        });


        services.AddAuthorization(o =>
        {
            o.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserProvider, UserProvider>();

        services.AddAutoMapper(mapperConfig =>
        {
            AutoMapperOptions autoMapperOptions = configuration
                .GetSection(AutoMapperOptions.SectionName)
                .Get<AutoMapperOptions>() ?? new AutoMapperOptions();

            string? licenseKey = autoMapperOptions.LicenseKey;

            if (!string.IsNullOrWhiteSpace(licenseKey))
                mapperConfig.LicenseKey = licenseKey;

            mapperConfig.AddMaps(typeof(Program));
        });
    }
}
