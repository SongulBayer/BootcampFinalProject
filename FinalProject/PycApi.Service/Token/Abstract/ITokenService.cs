using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi.Service
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
