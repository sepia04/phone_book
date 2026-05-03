using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Contracts.Phone.Requests;
using Contracts.Phone.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace PhoneBookAPI.Controllers;

/// <summary>
/// Эндпоинт для работы с телефонными номерами
/// </summary>
/// <param name="serviceManager"></param>
[ApiController]
[Route("[controller]")]
[TranslateResultToActionResult]
public class PhoneController(IServiceManager serviceManager) : ControllerBase
{
    /// <summary>
    /// Получить телефоны с привязкой к пользователям
    /// </summary>
    /// <param name="ct"></param>
    /// <returns>Телефоны с привязкой к пользователям</returns>
    /// <response code="200">Успешно получен список телефонов</response>
    [HttpGet("phones/")]
    [ProducesResponseType(200)]
    public Result<IEnumerable<PhoneDto>> GetPhones(CancellationToken ct)
    {
        return serviceManager.PhoneService.GetPhones();
    }

    /// <summary>
    /// Получить телефон через ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns>Телефон</returns>
    /// <response code="200">Успешно получен телефон</response>
    /// <response code="400">Плохой запрос: неправильный ID</response>
    /// <response code="404">Телефон не найден</response>
    [HttpGet("phones/{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public Result<PhoneDto> GetById([FromRoute] int id, CancellationToken ct)
    {
        return serviceManager.PhoneService.GetPhone(id);
    }

    /// <summary>
    /// Создать телефон
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns>Созданный телефон</returns>
    /// <response code="201">Успешно создан телефон</response>
    /// <response code="400">Плохой запрос</response>
    [HttpPost("create/")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public Result<PhoneDto> Create(CreatePhoneDto dto, CancellationToken ct)
    {
        return serviceManager.PhoneService.Create(dto.PhoneNumber, dto.UserId);
    }

    /// <summary>
    /// Обновить телефон
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns>Обновленный телефон</returns>
    /// <response code="200">Успешно обновлен телефон</response>
    /// <response code="400">Плохой запрос</response>
    /// <response code="404">Телефон не найден</response>
    [HttpPut("update/")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public Result<PhoneDto> Update(UpdatePhoneDto dto, CancellationToken ct)
    {
        return serviceManager.PhoneService.Update(dto.PhoneId, dto.PhoneNumber, dto.UserId);
    }

    /// <summary>
    /// Удалить телефон
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Сообщение об удалении</returns>
    /// <response code="200">Успешно удален телефон</response>
    /// <response code="400">Плохой запрос: неправильный ID</response>
    /// <response code="404">Телефон не найден</response>
    /// <response code="409">Конфликт: телефон имеет привязку к номеру</response>
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    public Result Delete(int id)
    {
        return serviceManager.PhoneService.Delete(id);
    }
}