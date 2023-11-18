using static Kader_System.Domain.Constants.SD.ApiRoutes;

namespace Kader_System.Services.Services.Shared;

public class NewsService : INewsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer;
    private readonly IMapper _mapper;


    public NewsService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer,
                       IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _sharLocalizer = sharLocalizer;
        _mapper = mapper;
    }

    #region News

    public async Task<Response<IEnumerable<SelectListForNewsResponse>>> ListOfNewsAsync(string lang)
    {
        try
        {
            var result =
                    await _unitOfWork.News.GetSpecificSelectAsync(null!,
                    select: x => new SelectListForNewsResponse
                    {
                        Id = x.Id,
                        Title = lang == Localization.Arabic ? x.Title : x.TitleInEnglish
                    }, orderBy: x =>
                      x.OrderByDescending(x => x.Id));

            if (result == null || result.ToList().Count == 0)
            {
                string resultMsg = _sharLocalizer[Localization.NotFoundData];

                return new Response<IEnumerable<SelectListForNewsResponse>>()
                {
                    Data = new List<SelectListForNewsResponse>(),
                    Error = resultMsg,
                    Message = resultMsg
                };
            }
            return new Response<IEnumerable<SelectListForNewsResponse>>()
            {
                Data = result,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<SelectListForNewsResponse>>()
            {
                Error = ex.Message,
                Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message)
            };
        }
    }

    public async Task<Response<IEnumerable<SharGetAllNewsResponse>>> GetAllNewsAsync(string lang)
    {
        try
        {
            var result =
                    await _unitOfWork.News.GetSpecificSelectAsync(null!,
                    select: x => new SharGetAllNewsResponse
                    {
                        Id = x.Id,
                        Title = lang == Localization.Arabic ? x.Title : x.TitleInEnglish,
                        TitleMeta = lang == Localization.Arabic ? x.TitleMeta : x.TitleMetaInEnglish,
                        Description = x.Description,
                        ImagePath = string.Concat(ReadRootPath.SharedImagesPath, x.ImageName),
                       
                        VideoPath = string.Concat(ReadRootPath.SharedVideosPath, x.VideoName),
                        HtmlBody = x.HtmlBody,
                        InsertDate = x.InsertDate.ToGetFullyDate()
                    }, orderBy: x =>
                      x.OrderByDescending(x => x.Id));

            if (result == null || result.ToList().Count == 0)
            {
                string resultMsg = _sharLocalizer[Localization.NotFoundData];

                return new Response<IEnumerable<SharGetAllNewsResponse>>()
                {
                    Data = new List<SharGetAllNewsResponse>(),
                    Message = resultMsg
                };
            }
            return new Response<IEnumerable<SharGetAllNewsResponse>>()
            {
                Data = result,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<SharGetAllNewsResponse>>()
            {
                Error = ex.Message,
                Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message)
            };
        }
    }

    public async Task<Response<IEnumerable<SharGetAllLastThreeNewsResponse>>> GetLastThreeNewsAsync(string lang)
    {
        var result =
                await _unitOfWork.News.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllLastThreeNewsResponse
                {
                    Id = x.Id,
                    Title = lang == Localization.Arabic ? x.Title : x.TitleInEnglish,
                    TitleMeta = lang == Localization.Arabic ? x.TitleMeta : x.TitleMetaInEnglish,
                    Description = x.Description,
                    ImagePath = x.ImageName != null ? string.Concat(ReadRootPath.SharedImagesPath, x.ImageName) : string.Empty,
                    
                    VideoPath = x.VideoName != null ? string.Concat(ReadRootPath.SharedVideosPath, x.VideoName) : string.Empty,
                    HtmlBody = x.HtmlBody,
                    InsertDate = x.InsertDate.ToGetOnlyDate()
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id), take: 3);

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SharGetAllLastThreeNewsResponse>>()
            {
                Data = new List<SharGetAllLastThreeNewsResponse>(),
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SharGetAllLastThreeNewsResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    public async Task<Response<SharCreateNewsRequest>> CreateNewsAsync(SharCreateNewsRequest model)
    {
        if (await _unitOfWork.News.ExistAsync(x => x.Title.Trim().ToLower() == model.Title.Trim().ToLower()))
        {
            string msg = string.Format(_sharLocalizer[Localization.IsExist], model.Title);

            return new Response<SharCreateNewsRequest>()
            {
                Message = msg,
                Data = model
            };
        }

        if (await _unitOfWork.News.ExistAsync(x => x.TitleMeta.Trim().ToLower() == model.TitleMeta.Trim().ToLower()))
        {
            string msg = string.Format(_sharLocalizer[Localization.IsExist], model.TitleMeta);
            return new Response<SharCreateNewsRequest>()
            {
                Message = msg,
                Data = model
            };
        }

        var obj = _mapper.Map<SharNews>(model);

        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, GoRootPath.SharedImagesPath);

        obj.ImageName = fileObj.FileName;
        obj.ImageExtension = fileObj.FileExtension;

        if (model.VideoPath is not null)
        {
            var fileObj2 = ManageFilesHelper.UploadFile(model.VideoPath, GoRootPath.SharedVideosPath);

            obj.VideoName = fileObj2.FileName;
            obj.VideoExtension = fileObj2.FileExtension;
        }

        await _unitOfWork.News.AddAsync(obj);
        await _unitOfWork.CompleteAsync();

        return new Response<SharCreateNewsRequest>()
        {
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true,
            Data = _mapper.Map<SharCreateNewsRequest>(model)
        };
    }

    public async Task<Response<SharGetNewsResponse>> GetNewsByIdAsync(int id)
    {
        var News = await _unitOfWork.News.GetByIdAsync(id);

        if (News is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetNewsResponse>()
            {
                Data = new SharGetNewsResponse(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<SharGetNewsResponse>()
        {
            Data = _mapper.Map<SharGetNewsResponse>(News),
            IsSuccess = true
        };
    }

    public async Task<Response<SharEditNewsRequest>> UpdateNewsAsync(int id, SharEditNewsRequest model)
    {
        var obj = await _unitOfWork.News.GetByIdAsync(id);

        if (obj == null || model.Id != id)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.News], id);

            return new Response<SharEditNewsRequest>()
            {
                Data = model,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        var mapped = _mapper.Map<SharEditNewsRequest, SharNews>(model, obj);

        if (model.Image != null)
        {
            string newsPath = GoRootPath.SharedImagesPath;

            if (obj.ImageName != null)
                ManageFilesHelper.RemoveFile(newsPath + "/" + obj.ImageName);

            var fileObj = ManageFilesHelper.UploadFile(model.Image, newsPath);
            mapped.ImageName = fileObj.FileName;
            mapped.ImageExtension = fileObj.FileExtension;
        }

        if (model.Video != null)
        {
            string newsPath = GoRootPath.SharedVideosPath;

            if (obj.VideoName != null)
                ManageFilesHelper.RemoveFile(newsPath + "/" + obj.VideoName);

            var fileObj = ManageFilesHelper.UploadFile(model.Video, newsPath);
            mapped.VideoName = fileObj.FileName;
            mapped.VideoExtension = fileObj.FileExtension;
        }

        _unitOfWork.News.Update(mapped);
        bool result = await _unitOfWork.CompleteAsync() > 0;

        return new Response<SharEditNewsRequest>()
        {
            IsSuccess = result,
            Data = model,
            Message = result ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
        };
    }

    public async Task<Response<string>> UpdateActiveOrNotNewsAsync(int id)
    {
        var news = await _unitOfWork.News.GetByIdAsync(id);

        if (news is null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.News]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        news.IsActive = !news.IsActive;
        _unitOfWork.News.Update(news);

        return new Response<string>()
        {
            IsSuccess = await _unitOfWork.CompleteAsync() > 0,
            Data = news!.Title,
            IsActive = news.IsActive,
            Message = news.IsActive
            ? _sharLocalizer[Localization.Activated]
            : _sharLocalizer[Localization.DeActivated]
        };
    }

    public async Task<Response<string>> DeleteNewsAsync(int id)
    {
        var News = await _unitOfWork.News.GetByIdAsync(id);

        if (News == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.News], id);

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
            _unitOfWork.News.Remove(News);

            bool result = await _unitOfWork.CompleteAsync() > 0;

            if (!result)
                return new Response<string>()
                {
                    IsSuccess = false,
                    Data = News.Title,
                    Error = err,
                    Message = err
                };
            return new Response<string>()
            {
                IsSuccess = true,
                Data = News.Title,
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

    #endregion
}
