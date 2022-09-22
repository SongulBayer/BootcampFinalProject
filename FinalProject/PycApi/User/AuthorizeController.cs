using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Data;
using PycApi.Service;
using PycApi.StartUpExtension;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace PycApi
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        protected readonly IHibernateRepository<Account> hibernateRepository;

        public AuthorizeController(ITokenService tokenService)
        {
            this.tokenService = tokenService;

        }

        // The process of authorizing users with correct login.
        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
      
        }
    }
}
