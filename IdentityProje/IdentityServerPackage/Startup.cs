// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServerPackage.Data;
using IdentityServerPackage.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServerPackage.Models.Entities;
using IdentityServerPackage.Services;
using IdentityServerPackage.WebModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using IdentityServerPackage;

namespace IdentityServerPackage
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        string CorsPolicy = "CorsPolicy";
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLocalApiAuthentication();
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MvcLoginContext")));

            services.AddIdentity<AppUser, IdentityRole>(opts => {

                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 3;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;

            }).AddPasswordValidator<CustomPasswordValidator>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            //services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<DataContext>()


            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                //options.EmitStaticAudienceClaim = false;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<AppUser>();

            builder.AddResourceOwnerValidator<IdentityResourceOwnerPasswordValidator>();
            builder.AddExtensionGrantValidator<TokenExchangeExtensionGrantValidator>();
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000", "http://localhost:5000", "http://10.10.10.192:3000",
                                         "http://localhost/Me.ApiGateway", "http://localhost:3000/Me.ApiGateway")
                                      //builder.WithOrigins("http://10.10.10.190:5000",
                                      //                  "http://10.10.10.80:5000",
                                      //                    "http://localhost:60999",
                                      //                    "http://10.10.10.192:3000",

                                      //                    //, "null"
                                      //                    ) // null must remove on Product
                                      //                      // .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials()

                                      ;
                                  });
            });


            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Web Api",
                    Version = "V1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authorization0",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                }

                    );
            });
            //string authenticationProviderKey = "Bearer";
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(authenticationProviderKey,option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = true,
            //        ValidateIssuer = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Token:Issuer"],
            //        ValidAudience = Configuration["Token:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
            //        ClockSkew = TimeSpan.Zero
            //        // ClockSkew = TimeSpan.Zero
            //    };
            //});
            SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            string authenticationProviderKey = "TestKey";
            services.AddAuthentication(option => option.DefaultAuthenticateScheme = authenticationProviderKey)
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = Configuration["IdentityServerURL"];
                    options.Audience = "einvoiceresource";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signInKey,
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Token:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true
                    };
                });

        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(CorsPolicy);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { ///Niba.Login.Api
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}