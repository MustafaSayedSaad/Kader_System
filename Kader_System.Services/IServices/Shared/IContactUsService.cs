namespace Kader_System.Services.IServices.Shared;

public interface IContactUsService
{
    Task<Response<IEnumerable<SharGetAllContactUsResponse>>> GetAllContactUsAsync();
    Task<Response<SharCreateContactUsRequest>> CreateContactUsAsync(SharCreateContactUsRequest model);
}
