using TokenApi.Base;
using TokenApi.Dto;

namespace TokenApi.Service;

public interface ITokenManagementService
{
    BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
}
