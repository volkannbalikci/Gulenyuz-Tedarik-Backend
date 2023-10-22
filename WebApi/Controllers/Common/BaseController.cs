using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Controllers.Common
{
    public class BaseController : ControllerBase
    {
        protected String GetCurrentUsersFirstName() => HttpContext.User.Claims.SingleOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;

        protected String GetCurrentUsersLastName() => HttpContext.User.Claims.SingleOrDefault(e => e.Type.Equals(ClaimTypes.Surname)).Value;

        protected String GetCurrentUsersEmail() => HttpContext.User.Claims.SingleOrDefault(e => e.Type.Equals(JwtRegisteredClaimNames.Email)).Value;

        protected int GetCurrentUsersId() => Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value);


       protected List<String> GetCurrentUsersRoles()
        {
            List<String> userRoles = new List<String>();

            return userRoles;
        }

        protected ObjectResult GetDataResultResponseBySuccessStatus<TData>(IDataResult<TData> result)
        {
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        protected ObjectResult GetResultResponseBySuccessStatus(Core.Utilities.Results.Abstract.IResult result)
        {
            if (result.IsSuccess)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }
    }
}
