using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    //token üretmek için aşağıdaki interface'i kullanıyoruz. usere göre token üretecek. list ile roller veriliyor.
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);                 
    }
}