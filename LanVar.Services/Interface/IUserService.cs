using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;


namespace LanVar.Service.Interface;

public interface IUserService
{
    Task<User> Register(CreateAccountDTORequest createAccountDTORequest); 
    Task<(string, LoginDTOResponse)> Login(LoginDTORequest loginDtoRequest);
    string GetUserID();
    Task<User> RegisterForProductOwner(CreateAccountDTORequest createAccountDTORequest);
}