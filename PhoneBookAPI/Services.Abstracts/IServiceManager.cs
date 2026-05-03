namespace Services.Abstracts;

public interface IServiceManager
{
    IUserService UserService { get; }
    IPhoneService PhoneService { get; }
}