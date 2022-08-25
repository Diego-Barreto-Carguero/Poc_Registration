// <copyright file="SwaggerConfiguration.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using System.Reflection;
using Carguero.Registration.Poc.Api.Patterns.OpenApiSamples.V1;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Carguero.Registration.Poc.Api.Configurations
{
    public static class SwaggerConfig
    {
        private static IApiVersionDescriptionProvider _provider;

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            _provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var startupAssembly = typeof(Program).GetTypeInfo().Assembly;

            services.AddFluentValidationRulesToSwagger();

            services.AddSwaggerGen(options =>
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    var assemblyDetails = startupAssembly.GetCustomAttribute<AssemblyProductAttribute>();

                    options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                    {
                        Title = $"Registration API - {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = "Service responsible for all registration flows",
                        Contact = new OpenApiContact
                        {
                            Name = "Carguero",
                            Email = "atendimento@carguero.com.br",
                            Url = new Uri("https://carguero.com.br")
                        },
                        Extensions = new Dictionary<string, IOpenApiExtension>
                        {
                            {
                                "x-logo", new OpenApiObject
                                {
                                    {
                                        "url", new OpenApiString("/Contents/Images/docs_logo.png")
                                    }
                                }
                            }
                        }
                    });
                }

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        new[] {"public_api"}
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.SchemaFilter<EnumSchemaFilter>();
                options.DocumentFilter<CustomSwaggerDocumentAttribute>();
                options.IncludeXmlComments(xmlFilePath);
                options.ExampleFilters();
                options.EnableAnnotations();
            });

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        public static void UseSwaggerPage(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Registration API - V{description.ApiVersion}");
                    options.InjectStylesheet("/Contents/Styles/Swagger-Custom.css");
                }
            });
        }

        public static void UseReDocPage(this IApplicationBuilder app)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                app.UseReDoc(options =>
                {
                    options.DocumentTitle = $"Carguero Developer Portal - {description.GroupName}";
                    options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
                    options.RoutePrefix = $"api-docs/{description.GroupName}";
                    options.EnableUntrustedSpec();
                    options.HideDownloadButton();
                    options.ExpandResponses(string.Empty);
                });
            }
        }

        private class CustomSwaggerDocumentAttribute : IDocumentFilter
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CustomSwaggerDocumentAttribute(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                swaggerDoc.ExternalDocs = new OpenApiExternalDocs
                {
                    Description = $"Carguero Developer Portal v{swaggerDoc.Info.Version}",
                    Url = new Uri(
                        $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/api-docs/{context.DocumentName}")
                };
            }
        }

        private class EnumSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (!context.Type.IsEnum)
                {
                    return;
                }

                schema.Enum.Clear();

                Enum.GetNames(context.Type).ToList()
                    .ForEach(name => schema.Enum.Add(
                        new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} = {name}")));
            }
        }
    }
}
