﻿using ApiPeliculasCompleto.Helpers;
using ApiPeliculasCompleto.Models;
using ApiPeliculasCompleto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiPeliculasCompleto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryPeliculas repo;
        private HelperOAuthToken helper;

        public AuthController(RepositoryPeliculas repo
            , HelperOAuthToken helper)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Cliente cliente =
                this.repo.ExisteCliente(model.UserName, int.Parse(model.Password));
            if (cliente == null)
            {
                return Unauthorized();
            }
            else
            {
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(cliente))
                };
                JwtSecurityToken token = new JwtSecurityToken
                    (
                    issuer: this.helper.Issuer,
                    audience: this.helper.Audience,
                    claims: claims ,
                    expires: DateTime.UtcNow.AddMinutes(20),
                    notBefore: DateTime.UtcNow,
                    signingCredentials:
new SigningCredentials(this.helper.GetKeyToken()
, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(
                    new
                    {
                        response = 
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }
    }
}
