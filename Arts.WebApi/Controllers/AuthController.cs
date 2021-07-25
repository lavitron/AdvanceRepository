using System;
using System.Linq;
using System.Threading.Tasks;
using Arts.Business.Abstract;
using Arts.Entity.Dto.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Arts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<UserLoginDto> _userLoginValidator;
        private readonly IValidator<UserRegisterDto> _userRegisterValidator;

        public AuthController(IAuthService authService, IValidator<UserLoginDto> userLoginValidator,
            IValidator<UserRegisterDto> userRegisterValidator)
        {
            _authService = authService;
            _userLoginValidator = userLoginValidator;
            _userRegisterValidator = userRegisterValidator;
        }

        [HttpPost]
        [Route("UserRegister")]
        public async Task<ActionResult<string>> UserRegister(UserRegisterDto user)
        {
            try
            {
                var validationResult = await _userRegisterValidator.ValidateAsync(user);
                if (!validationResult.IsValid)
                {
                    var errorList = validationResult.Errors
                        .Select(validationResultError => validationResultError.ErrorMessage).ToList();
                    return Ok(new {code = StatusCode(1002), message = errorList, type = "error"});
                }

                var userRegisterResult = await _authService.RegisterAsync(user);
                return Ok(userRegisterResult <= 0
                    ? new {code = StatusCode(1001), message = "Kullanıcı kayıt işlemi başarısız", type = "error"}
                    : new {code = StatusCode(1000), message = "Kullanıcı kayıt işlemi başarılı", type = "success"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("UserLogin")]
        public async Task<ActionResult<string>> UserLogin(UserLoginDto user)
        {
            try
            {
                var validationResult = await _userLoginValidator.ValidateAsync(user);
                if (!validationResult.IsValid)
                {
                    var errorList = validationResult.Errors
                        .Select(validationResultError => validationResultError.ErrorMessage).ToList();
                    return Ok(new {code = StatusCode(1002), message = errorList, type = "error"});
                }

                var currentUser = await _authService.GetLoginUserAsync(user);
                if (currentUser == null)
                    return Ok(new
                        {code = StatusCode(1001), message = "Kullanıcı adı veya şifre yanlış.", type = "error"});
                var accessToken = await _authService.CreateAccessTokenAsync(currentUser);

                return accessToken == null
                    ? Ok(new
                    {
                        code = StatusCode(1001), message = "Kullanıcı giriş işlemi sırasında bir hata meydana geldi.",
                        type = "error"
                    })
                    : Ok(accessToken);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}