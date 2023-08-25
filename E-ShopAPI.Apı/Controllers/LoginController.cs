using E_Shop.Business.Abstract;
using E_ShopAPI.Apı.Aspects;
using E_ShopAPI.Apı.Validation.FluentValidation;
using E_ShopAPI.Entity.DTO.Login;
using E_ShopAPI.Entity.Poco;
using E_ShopAPI.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace E_ShopAPI.Apı.Controllers
{

        [ApiController]
        [Route("[action]")]
        public class LoginController : Controller
        {
            private readonly ICustomerService _customerService;
            private readonly IConfiguration _configuration;

            public LoginController(ICustomerService customerService, IConfiguration configuration)
            {
                _customerService = customerService;
                _configuration = configuration;
            }
            [ValidationFilter(typeof(LoginValidator))]
            [HttpPost("/Login")]
            [ProducesResponseType(typeof(Sonuc<LoginResponseDTO>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
            {



                var customer = await _customerService.GetAsync(q => q.Customername == loginRequestDTO.KullaniciAdi && q.Password == loginRequestDTO.Sifre);

                if (customer == null)
                {
                    return NotFound(Sonuc<LoginResponseDTO>.AuthenticationError());
                }
                else
                {
                    var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                    var claims = new List<Claim>();
                    claims.Add(new Claim("KullaniciAdi", customer.Customername));
                    claims.Add(new Claim("KullaniciID", customer.ID.ToString()));

                    var jwt = new JwtSecurityToken(
                        expires: DateTime.Now.AddDays(30),
                        claims: claims,
                        issuer: "http://aasfsdagfsd.com",
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                    var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                    LoginResponseDTO loginResponseDTO = new()
                    {
                        AdSoyad = customer.FirstName + " " + customer.LastName,
                        CustomerID = customer.ID,
                        EPosta = customer.Email,
                        Adres = customer.Adress,
                        Token = token
                    };

                    return Ok(Sonuc<LoginResponseDTO>.SuccessWithData(loginResponseDTO));

                }



            }
        }
    }

