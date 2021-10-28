using BMSLoanService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BMSLoanService.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using System.IO;

namespace BMSLoanService.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registration;
        public IConfiguration Configuration { get; }
        public RegistrationController(IRegistrationRepository registration, IConfiguration configuration)
        {
            _registration = registration;
            Configuration = configuration;
        }
       
        public IActionResult getbyId(string Id)
        {
            try
            {
                if (Id != null)
                {
                    var data = _registration.GetById(Id);
                    if (data !=null)
                        return Ok(data);
                    else
                        return NotFound();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                string filePath = @"D:\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }

                return NotFound(ex.Message);
            }
        }
               
        public IActionResult GetbyUserName(LoginUser loginuser)
        {
            try
            {
                var data = _registration.GetByUserName(loginuser.username, loginuser.password);

                var data_token = new
                {
                    ifs="as",
                    token = GenerateJSONWebToken(loginuser),
                    data.Id,
                    data.Name,
                    data.UserName,
                    data.Password,
                    data.GaurdianType,
                    data.GaurdianName,
                    data.Address,
                    data.CitizenStatus,
                    data.Citizenship,
                    data.Country,
                    data.State,
                    data.EmailAddress,
                    data.Gender,
                    data.MaritalStatus,
                    data.ContactNo,
                    data.DOB,
                    data.RegDate,
                    data.AccountType,
                    data.InitialDepAmt,
                    data.IDProofType,
                    data.IDDocNo,
                    data.RefAccholderNo,
                    data.RefAccholderName,
                    data.RefAccholderAddress
                };               
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data_token);
            }
            catch (Exception ex)
            {
                string filePath = @"D:\Error.txt";               

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }

                return NotFound();
            }

        }
        public string GenerateJSONWebToken(LoginUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.username)
            };
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
              Configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        [HttpPost]
        public IActionResult Add(Registration _reg)
        {
            try
            {
                if (_reg == null) return BadRequest();
                int RndCustId = RandomNumber(1, 1000);
                _reg.Id = "R" + RndCustId;

                var result =_registration.Add(_reg);
                if (result!=null)
                    return Ok(_reg);
                else
                    return BadRequest();

            }
            catch (Exception ex)
            {
                string filePath = @"D:\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }               
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]        
        public IActionResult Update(Registration _reg)
        {
            try
            {
                var res = _registration.Update(_reg);

                if (res != null)
                    return Ok(res);
                else
                    return BadRequest();
                
            }
            catch (Exception ex)
            {
                string filePath = @"D:\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                
                return BadRequest(ex.Message);
            }
        }




    }
}
