namespace Kader_System.Services.Services.Shared;

public class ServicesService : IServicesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _accessor;


    public ServicesService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer,
                           IMapper mapper, IHttpContextAccessor accessor)
    {
        _unitOfWork = unitOfWork;
        _sharLocalizer = sharLocalizer;
        _mapper = mapper;
        _accessor = accessor;
    }

    public Task<Response<IEnumerable<SelectListResponse>>> ListOfServicesAsync(string lang)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<SharCreateServiceRequest>> CreateServiceAsync(SharCreateServiceRequest model)
    {
        if (await _unitOfWork.Services.ExistAsync(x =>
            (x.Title.Trim().ToLower() == model.Title.Trim().ToLower())
            ||
            (x.TitleInEnglish.Trim().ToLower() == model.TitleInEnglish.Trim().ToLower())))
        {
            string msg = string.Format(_sharLocalizer[Localization.IsExist], model.Title);

            return new Response<SharCreateServiceRequest>()
            {
                Message = msg,
                Data = model
            };
        }

        var obj = _mapper.Map<SharService>(model);

        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, GoRootPath.SharedImagesPath);
        obj.ImageName = fileObj.FileName;
        obj.ImageExtension = fileObj.FileExtension;


        await _unitOfWork.Services.AddAsync(obj);
        await _unitOfWork.CompleteAsync();

        return new Response<SharCreateServiceRequest>()
        {
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true,
            Data = _mapper.Map<SharCreateServiceRequest>(model)
        };

    }

    public async Task<Response<IEnumerable<SharGetAllServicesResponse>>> GetAllServicesAsync(string lang)
    {
        var result =
                await _unitOfWork.Services.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllServicesResponse
                {
                    Id = x.Id,
                    Title = lang == Localization.Arabic ? x.Title : x.TitleInEnglish,
                    Description = x.Description,
                    ImagePath = string.Concat(ReadRootPath.SharedImagesPath, x.ImageName),
                    ImageExtension = x.ImageExtension,
                    ServicesCategoryId = x.ServicesCategoryyId,
                    //InsertBy = GetUserNameById(x.InsertBy!).Result
                    HtmlBody = x.HtmlBody
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SharGetAllServicesResponse>>()
            {
                Data = new List<SharGetAllServicesResponse>(),
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SharGetAllServicesResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    public async Task<Response<IEnumerable<SharGetAllServicesResponse>>> GetLastThreeServicesAsync(string lang)
    {
        var result =
                await _unitOfWork.Services.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllServicesResponse
                {
                    Id = x.Id,
                    Title = lang == Localization.Arabic ? x.Title : x.TitleInEnglish,
                    Description = x.Description,
                    ImagePath = string.Concat(ReadRootPath.SharedImagesPath, x.ImageName),
                    ImageExtension = x.ImageExtension,
                    ServicesCategoryId = x.ServicesCategoryyId,
                    HtmlBody = x.HtmlBody
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id), take: 4);

        if (result.IsNullOrEmpty())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SharGetAllServicesResponse>>()
            {
                Data = new List<SharGetAllServicesResponse>(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SharGetAllServicesResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    public async Task<Response<SharGetServiceResponse>> GetServiceByIdAsync(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);

        if (service is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetServiceResponse>()
            {
                Data = new SharGetServiceResponse(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<SharGetServiceResponse>()
        {
            Data = _mapper.Map<SharGetServiceResponse>(service),
            IsSuccess = true
        };
    }

    public async Task<Response<SharEditServiceRequest>> UpdateServiceAsync(int id, SharEditServiceRequest model)
    {
        var obj = await _unitOfWork.Services.GetByIdAsync(id);

        if (obj == null || model.Id != id)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Service]);

            return new Response<SharEditServiceRequest>()
            {
                Data = model,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        var mapped = _mapper.Map<SharEditServiceRequest, SharService>(model, obj);

        if (model.ImagePath != null)
        {
            string servicesPath = GoRootPath.SharedImagesPath;

            if (obj.ImageName != null)
                ManageFilesHelper.RemoveFile(servicesPath + "/" + obj.ImageName);

            var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, servicesPath);
            mapped.ImageName = fileObj.FileName;
            mapped.ImageExtension = fileObj.FileExtension;
        }

        _unitOfWork.Services.Update(mapped);
        await _unitOfWork.CompleteAsync();

        return new Response<SharEditServiceRequest>()
        {
            IsSuccess = true,
            Data = model,
            Message = _sharLocalizer[Localization.Updated]
        };
    }

    public async Task<Response<string>> UpdateActiveOrNotServiceAsync(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);

        if (service is null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Service]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        service.IsActive = !service.IsActive;
        _unitOfWork.Services.Update(service);

        return new Response<string>()
        {
            IsSuccess = await _unitOfWork.CompleteAsync() > 0,
            Data = service!.Title,
            IsActive = service.IsActive,
            Message = service.IsActive
            ? _sharLocalizer[Localization.Activated]
            : _sharLocalizer[Localization.DeActivated]
        };
    }

    public async Task<Response<string>> DeleteServiceAsync(int id)
    {
        var obj = await _unitOfWork.Services.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Service], id);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }
        string err = _sharLocalizer[Localization.Error];

        _unitOfWork.Services.Remove(obj);

        bool result = await _unitOfWork.CompleteAsync() > 0;

        if (!result)
            return new Response<string>()
            {
                IsSuccess = false,
                Data = obj.Title,
                Error = err,
                Message = err
            };
        return new Response<string>()
        {
            IsSuccess = true,
            Data = obj.Title,
            Message = _sharLocalizer[Localization.Deleted]
        };
    }


    //private string GetUserId() =>
    //_accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.GetUserId();

    private async Task<string> GetUserNameById(string userId) =>
        (await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.Id == userId)).UserName!;
}
