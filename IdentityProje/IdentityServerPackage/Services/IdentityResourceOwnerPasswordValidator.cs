using IdentityServerPackage.Models.Entities;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using IdentityServerPackage.WebModel;
using IdentityServerPackage.Models.Response.AppUser;
using System.Security.Claims;

namespace IdentityServerPackage.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityResourceOwnerPasswordValidator(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
       IConfiguration configuration, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
          
                AppUser user = await _userManager.FindByNameAsync(context.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = _signInManager.PasswordSignInAsync(user, context.Password, false, false).Result;
                    if (result.Succeeded)
                    {
                    if (user.AccessTokenExpiration == null || user.AccessToken== null ||
                        user.RefreshToken == null || user.AccessToken != null || user.RefreshToken != null)
                    {
                        UserHandler tokenHandler = new UserHandler(_configuration);
                        Token token = tokenHandler.CreateAccessToken(user);
                        token.UserName = user.UserName;
                        token.FirstName = user.FirstName;
                        token.LastName = user.LastName;
                        IList<string> rolename = await _userManager.GetRolesAsync(user);
                        token.RoleName = rolename.FirstOrDefault();
                        user.AccessToken = token.AccessToken;
                        user.RefreshToken = token.RefreshToken;
                        user.AccessTokenExpiration = token.AccessTokenExpiration.AddMinutes(3);
                        user.RefreshTokenExpiration = user.AccessTokenExpiration.Value.AddMinutes(3);
                        await _userManager.UpdateAsync(user);
          
                       
                        context.Result = new
                             GrantValidationResult(user.Id.ToString(),
                           
                             OidcConstants.AuthenticationMethods.Password,

                               new List<Claim>
                               {
                                   new Claim(JwtClaimTypes.Name, user.UserName),
                                   new Claim(JwtClaimTypes.Email, user.Email),
                                   new Claim(JwtClaimTypes.Role,"admin"),
                                   new Claim(JwtClaimTypes.Id,user.Id.ToString())
                                  
                               }
                             );
                        //var tokenbilgi = new Dictionary<string, object>();
                        //tokenbilgi.Add("token bilgi",new List<Token> { token });
                        //context.Result.CustomResponse = tokenbilgi;
                    }
                    else if (user.AccessTokenExpiration < DateTime.Now)
                    {
                        var durumkodu = new Dictionary<string, object>();
                        durumkodu.Add("message", new List<ResponseResultAppUser>() { 
                        
                             new ResponseResultAppUser
                             {
                                  Message = "Kullanıcının Yetkisi Yoktur",
                                  StatusCode = 403.ToString(),
                                  Error = "Kullanıcının Yetkisi Yoktur"
                             }
                        });  
                        context.Result.CustomResponse = durumkodu;

                    }
                        else
                        {
                        var durumkodu = new Dictionary<string, object>();
                        durumkodu.Add("message", new List<ResponseResultAppUser>() {

                             new ResponseResultAppUser
                             {
                                 Message = "Kullanıcının Yetkisi Yoktur",
                                StatusCode = 401.ToString(),
                                Error = "Kullanıcının Yetkisi Yoktur"
                             }
                        });
                        context.Result.CustomResponse = durumkodu;
                        }
                    }
                    else
                    {
                    var durumkodu = new Dictionary<string, object>();
                    durumkodu.Add("message", new List<ResponseResultAppUser>() {

                             new ResponseResultAppUser
                             {
                              Message = "Kullanıcı Adı veya Şifre yanlıştır",
                            StatusCode = 401.ToString(),
                            Error = "Kullanıcı Adı veya Şifre yanlıştır"
                             }
                        });
                    context.Result.CustomResponse = durumkodu;
                    }
                }
                else
                {

                var durumkodu = new Dictionary<string, object>();
                durumkodu.Add("message", new List<ResponseResultAppUser>() {

                             new ResponseResultAppUser
                             {
                         Message = "Böyle Bir Kullanıcı Yoktur.",
                        StatusCode = 401.ToString(),
                        Error = "Böyle Bir Kullanıcı Yoktur."
                             }
                        });
                context.Result.CustomResponse = durumkodu;
         
                }
            
          
        }
        //public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        //{
        //    var existUser = await _userManager.FindByEmailAsync(context.UserName);

        //    if (existUser == null)
        //    {
        //        var errors = new Dictionary<string, object>();
        //        errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
        //        context.Result.CustomResponse = errors;

        //        return;
        //    }
        //    var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);

        //    if (passwordCheck == false)
        //    {
        //        var errors = new Dictionary<string, object>();
        //        errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
        //        context.Result.CustomResponse = errors;

        //        return;
        //    }

        //    context.Result = new 
        //        GrantValidationResult(existUser.Id.ToString(), 
        //        OidcConstants.AuthenticationMethods.Password
        //        );
        //}
    }
}