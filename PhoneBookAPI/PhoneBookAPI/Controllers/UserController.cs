using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Contracts.User.Requests;
using Contracts.User.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace PhoneBookAPI.Controllers;

/// <summary>
/// Эндпоинт для работы с пользователями
/// </summary>
/// <param name="serviceManager"></param>
[ApiController]
[Route("[controller]")]
[TranslateResultToActionResult]
public class UserController(IServiceManager serviceManager) : ControllerBase
{
    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <param name="ct"></param>
    /// <returns>Список пользователей</returns>
    /// <response code="200">Успешно получен список пользователей</response>
    [HttpGet("users/")]
    [ProducesResponseType(200)]
    public Result<IEnumerable<UserDto>> GetUsers(CancellationToken ct)
    {
        return serviceManager.UserService.GetUsers();
    }

    /// <summary>
    /// Получить пользователя через ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns>Пользователь</returns>
    /// <response code="200">Успешно получен пользователь</response>
    /// <response code="400">Плохой запрос: неправильный ID</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpGet("users/{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public Result<UserDto> GetById([FromRoute] int id, CancellationToken ct)
    {
        return serviceManager.UserService.GetUser(id);
    }

    /// <summary>
    /// Создать пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns>Созданный пользователь</returns>
    /// <response code="201">Успешно создан пользователь</response>
    /// <response code="400">Плохой запрос</response>
    [HttpPost("create/")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public Result<UserDto> Create(CreateUserDto dto, CancellationToken ct)
    {
        return serviceManager.UserService.Create(dto.Name, dto.Email, dto.DateOfBirth);
    }

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns>Обновленный пользователь</returns>
    /// <response code="200">Успешно обновлен пользователь</response>
    /// <response code="400">Плохой запрос</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpPut("update/")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public Result<UserDto> Update(UpdateUserDto dto, CancellationToken ct)
    {
        return serviceManager.UserService.Update(dto.UserId, dto.Name, dto.Email, dto.DateOfBirth);
    }

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Сообщение об удалении</returns>
    /// <response code="200">Успешно удален пользователь</response>
    /// <response code="400">Плохой запрос: неправильный ID</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public Result Delete(int id)
    {
        return serviceManager.UserService.Delete(id);
    }
}