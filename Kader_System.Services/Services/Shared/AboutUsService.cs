namespace Kader_System.Services.Services.Shared;

public class AboutUsService : IAboutUsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer;
    private readonly IMapper _mapper;


    public AboutUsService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer,
                          IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _sharLocalizer = sharLocalizer;
        _mapper = mapper;
    }

    #region About us

    public async Task<Response<SharGetAllAboutUsResponse>> GetAboutUsAsync(string lang)
    {

        var result =
                await _unitOfWork.AboutUs.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllAboutUsResponse
                {
                    Id = x.Id,
                    WhoAreWe = lang == Localization.Arabic ? x.WhoAreWe : x.WhoAreWeInEnglish,
                    Details = lang == Localization.Arabic ? x.Details : x.DetailsInEnglish,
                    OurVision = lang == Localization.Arabic ? x.OurVision : x.OurVisionInEnglish,
                    Image = x.ImageName != null ? string.Concat(ReadRootPath.SharedImagesPath, x.ImageName) : string.Empty
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetAllAboutUsResponse>()
            {
                Data = new SharGetAllAboutUsResponse(),
                Message = resultMsg
            };
        }
        return new Response<SharGetAllAboutUsResponse>
        {
            Data = result.First(),
            IsSuccess = true
        };

    }

    public async Task<Response<SharCreateAboutUsRequest>> CreateAboutUsAsync(SharCreateAboutUsRequest model)
    {

        var mapped = _mapper.Map<SharAboutUs>(model);

        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath!, GoRootPath.SharedImagesPath);
        mapped.ImageName = fileObj.FileName;
        mapped.ImageExtension = fileObj.FileExtension;

        await _unitOfWork.AboutUs.AddAsync(mapped);
        await _unitOfWork.CompleteAsync();

        return new Response<SharCreateAboutUsRequest>()
        {
            Data = model,
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true
        };
    }

    public async Task<Response<SharGetAboutUsResponse>> GetAboutUsForEditAsync()
    {
        var obj = await _unitOfWork.AboutUs.GetLastObjectOrDefaultAsync();

        if (obj is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetAboutUsResponse>()
            {
                Data = new SharGetAboutUsResponse(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<SharGetAboutUsResponse>()
        {
            Data = _mapper.Map<SharGetAboutUsResponse>(obj),
            IsSuccess = true
        };
    }

    public async Task<Response<SharEditAboutUsRequest>> UpdateAboutUsAsync(SharEditAboutUsRequest model)
    {
        var obj = await _unitOfWork.AboutUs.GetLastObjectOrDefaultAsync();

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound]);

            return new Response<SharEditAboutUsRequest>()
            {
                Data = model,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        var mapped = _mapper.Map<SharEditAboutUsRequest, SharAboutUs>(model, obj);

        if (model.ImagePath != null)
        {
            string newsPath = GoRootPath.SharedImagesPath;

            ManageFilesHelper.RemoveFile(newsPath + "/" + obj.ImageName);

            var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, newsPath);
            mapped.ImageName = fileObj.FileName;
            mapped.ImageExtension = fileObj.FileExtension;
        }

        _unitOfWork.AboutUs.Update(obj);
        bool result = await _unitOfWork.CompleteAsync() > 0;

        return new Response<SharEditAboutUsRequest>()
        {
            IsSuccess = result,
            Data = model,
            Message = result ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
        };


    }

    public async Task<Response<string>> DeleteAboutUsAsync(int id)
    {
        var obj = await _unitOfWork.AboutUs.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }
        string err = _sharLocalizer[Localization.Error];

        _unitOfWork.AboutUs.Remove(obj);

        bool result = await _unitOfWork.CompleteAsync() > 0;

        if (!result)
            return new Response<string>()
            {
                IsSuccess = false,
                Data = obj.Details,
                Error = err,
                Message = err
            };
        return new Response<string>()
        {
            IsSuccess = true,
            Data = obj.Details,
            Message = _sharLocalizer[Localization.Deleted]
        };
    }

    public Task<Response<IEnumerable<SelectListResponse>>> ListOfAboutUsAsync(string lang)
    {
        throw new NotImplementedException();
    }

    #endregion
}
