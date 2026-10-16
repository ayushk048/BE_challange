using Microsoft.AspNetCore.Mvc;
using _Diabetes_BE_challenge.DTOs;
using _Diabetes_BE_challenge.Services;
using FluentValidation;
using FluentValidation.Results;
using _Diabetes_BE_challenge.Validator;
using _Diabetes_BE_challenge.CustomException;

namespace _Diabetes_BE_challenge.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserDTO> _userValidator;

        public UsersController(IUserService userService, IValidator<UserDTO> userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }


        [HttpGet]
        public async Task<ActionResult> GetUser(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                IEnumerable<UserResponseDTO> users = await _userService.GetAllUsers();
                return Ok(users);
            }
            else
            {
                EmailValidator emailValidator = new EmailValidator();
                ValidationResult result = await emailValidator.ValidateAsync(email);

                if (!result.IsValid)
                {
                    return BadRequest(result.Errors[0].ErrorMessage);
                }

                UserResponseDTO users = await _userService.GetUserByEmail(email);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO body)
        {
            ValidationResult result = await _userValidator.ValidateAsync(body);
            if (!result.IsValid)
            {
                var messages = new Dictionary<string, string>();

                result.Errors.ForEach(s =>
                {
                    messages.Add(s.PropertyName, s.ErrorMessage);
                });

                return BadRequest(messages);
            }
            try
            {
                UserResponseDTO createdUser = await _userService.CreateUser(body);
                return Created("api/users", createdUser);
            }
            catch (AlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }

        }
    }
}
