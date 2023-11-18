namespace Kader_System.Services.Services.Shared;

public class ContactUsService : IContactUsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer;
    private readonly IMapper _mapper;


    public ContactUsService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer,
                            IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _sharLocalizer = sharLocalizer;
        _mapper = mapper;
    }


    #region Contact us

    public async Task<Response<SharCreateContactUsRequest>> CreateContactUsAsync(SharCreateContactUsRequest model)
    {
        await _unitOfWork.ContactUs.AddAsync(new SharContactUs
        {
            Name = model.Name,
            Email = model.Email,
            Description = model.Description,
            Mobile = model.Mobile
        });
        await _unitOfWork.CompleteAsync();

        return new Response<SharCreateContactUsRequest>()
        {
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true,
            Data = model
        };
    }

    public async Task<Response<IEnumerable<SharGetAllContactUsResponse>>> GetAllContactUsAsync()
    {
        var result =
                await _unitOfWork.ContactUs.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllContactUsResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    Email = x.Email,
                    Name = x.Name,
                    Mobile = x.Mobile
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SharGetAllContactUsResponse>>()
            {
                Data = new List<SharGetAllContactUsResponse>(),
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SharGetAllContactUsResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    #endregion
}
