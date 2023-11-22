
namespace Kader_System.Services.Services.Setting;

public class MainScreenService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer, IMapper mapper) : IMainScreenService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IMapper _mapper = mapper;

    #region Main screen

    public async Task<Response<SharCreateServicesCategoryRequest>> CreateServicesCategoryAsync(SharCreateServicesCategoryRequest model)
    {
        if (await _unitOfWork.ServicesCategories.ExistAsync(x =>
            (x.Name.Trim().ToLower() == model.Name.Trim().ToLower()) || (x.NameInEnglish.Trim().ToLower() == model.NameInEnglish.Trim().ToLower())))
        {
            string msg = string.Format(_sharLocalizer[Localization.IsExist], model.Name);

            return new Response<SharCreateServicesCategoryRequest>()
            {
                Message = msg,
                Data = model
            };
        }
        var servicesCategory = _mapper.Map<SharServicesCategory>(model);

        await _unitOfWork.ServicesCategories.AddAsync(servicesCategory);
        await _unitOfWork.CompleteAsync();


        return new Response<SharCreateServicesCategoryRequest>()
        {
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true,
            Data = _mapper.Map<SharCreateServicesCategoryRequest>(model)
        };
    }

    public async Task<Response<IEnumerable<SelectListResponse>>> GetAllServicesCategoriesAsync(string lang)
    {
        var result =
                await _unitOfWork.ServicesCategories.GetSpecificSelectAsync(null!,
                select: x => new SelectListResponse
                {
                    Id = x.Id,
                    Name = lang == Localization.Arabic ? x.Name : x.NameInEnglish,

                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (result == null || result.ToList().Count == 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SelectListResponse>>()
            {
                Data = new List<SelectListResponse>(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SelectListResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    public async Task<Response<SharGetServicesCategoryResponse>> GetServicesCategoryByIdAsync(int id)
    {
        var servicesCategory = await _unitOfWork.ServicesCategories.GetByIdAsync(id);

        if (servicesCategory is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetServicesCategoryResponse>()
            {
                Data = new SharGetServicesCategoryResponse(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<SharGetServicesCategoryResponse>()
        {
            Data = new SharGetServicesCategoryResponse
            {
                Id = id,
                Name = servicesCategory.Name,
                NameInEnglish = servicesCategory.NameInEnglish
            },
            IsSuccess = true
        };
    }

    public async Task<Response<SharEditServicesCategoryRequest>> UpdateServicesCategoryAsync(int id, SharEditServicesCategoryRequest model)
    {
        var servicesCategory = await _unitOfWork.ServicesCategories.GetByIdAsync(id);

        if (servicesCategory == null || model.Id != id)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.ServicesCategory], id);

            return new Response<SharEditServicesCategoryRequest>()
            {
                Data = null!,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        servicesCategory.Name = model.Name;
        servicesCategory.NameInEnglish = model.NameInEnglish;

        _unitOfWork.ServicesCategories.Update(servicesCategory);
        bool result = await _unitOfWork.CompleteAsync() > 0;

        return new Response<SharEditServicesCategoryRequest>()
        {
            IsSuccess = result,
            Data = null!,
            Message = result ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
        };
    }

    public async Task<Response<string>> UpdateActiveOrNotServicesCategoryAsync(int id)
    {
        var servicesCategory = await _unitOfWork.ServicesCategories.GetByIdAsync(id);

        if (servicesCategory is null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.ServicesCategory]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        servicesCategory.IsActive = !servicesCategory.IsActive;
        _unitOfWork.ServicesCategories.Update(servicesCategory);

        return new Response<string>()
        {
            IsSuccess = await _unitOfWork.CompleteAsync() > 0,
            Data = servicesCategory!.Name,
            IsActive = servicesCategory.IsActive,
            Message = servicesCategory.IsActive
            ? _sharLocalizer[Localization.Activated]
            : _sharLocalizer[Localization.DeActivated]
        };
    }

    public async Task<Response<string>> DeleteServicesCategoryAsync(int id)
    {
        var servicesCategory = await _unitOfWork.ServicesCategories.GetByIdAsync(id);

        if (servicesCategory == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.ServicesCategory], id);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }
        string err = _sharLocalizer[Localization.Error];
        try
        {
            _unitOfWork.ServicesCategories.Remove(servicesCategory);

            bool result = await _unitOfWork.CompleteAsync() > 0;

            if (!result)
                return new Response<string>()
                {
                    IsSuccess = false,
                    Data = servicesCategory.Name,
                    Error = err,
                    Message = err
                };
            return new Response<string>()
            {
                IsSuccess = true,
                Data = servicesCategory.Name,
                Message = _sharLocalizer[Localization.Deleted]
            };
        }
        catch (Exception ex)
        {
            return new Response<string>()
            {
                Error = err,
                Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message)
            };
        }
    }

    public async Task<Response<SharGetServicesCategoryWthAllServicesResponse>> GetServicesCategoryWithAllServicesByIdAsync(int id)
    {
        try
        {
            var servicesCategory = await _unitOfWork.ServicesCategories.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "Services");

            if (servicesCategory is null)
            {
                string resultMsg = _sharLocalizer[Localization.NotFoundData];

                return new Response<SharGetServicesCategoryWthAllServicesResponse>()
                {
                    Data = new SharGetServicesCategoryWthAllServicesResponse(),
                    Error = resultMsg,
                    Message = resultMsg
                };
            }
            return new Response<SharGetServicesCategoryWthAllServicesResponse>()
            {
                Data = _mapper.Map<SharGetServicesCategoryWthAllServicesResponse>(servicesCategory),
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new Response<SharGetServicesCategoryWthAllServicesResponse>()
            {
                Error = ex.Message,
                Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message)
            };
        }
    }

    private async Task<string> GetUserNameById(string userId) =>
    (await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.Id == userId)).UserName!;





    public async Task<Response<IEnumerable<StSelectListResponse>>> ListOfMainScreensAsync(string lang)
    {
        var result =
                await _unitOfWork.MainScreens.GetSpecificSelectAsync(null!,
                select: x => new StSelectListResponse
                {
                    Id = x.Id,
                    Title = lang == Localization.Arabic ? x.Screen_cat_title_ar : x.Screen_cat_title_en,
                    Image = null
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (result == null || result.ToList().Count == 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<StSelectListResponse>>()
            {
                Data = new List<StSelectListResponse>(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }
        return new Response<IEnumerable<StSelectListResponse>>()
        {
            Data = result,
            Check = true
        };
    }

    public Task<Response<IEnumerable<StGetAllMainScreensResponse>>> GetAllMainScreensAsync(string lang)
    {
        throw new NotImplementedException();
    }

    public Task<Response<StCreateMainScreenRequest>> CreateMainScreenAsync(StCreateMainScreenRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<StGetMainScreenByIdResponse>> GetMainScreenByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<StUpdateMainScreenRequest>> UpdateMainScreenAsync(int id, StUpdateMainScreenRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateActiveOrNotMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DeleteMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    #endregion
}
