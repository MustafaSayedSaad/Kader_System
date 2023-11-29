﻿namespace Kader_System.Services.Services.Setting;

public class SubMainScreenService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer, IMapper mapper, ILoggingRepository loggingRepository) : ISubMainScreenService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IMapper _mapper = mapper;
    private readonly ILoggingRepository _loggingRepository = loggingRepository;

    #region Sub main screen

    public async Task<Response<IEnumerable<StSelectListForSubMainScreenResponse>>> ListOfSubMainScreensAsync(string lang)
    {
        var result =
                await _unitOfWork.SubMainScreens.GetSpecificSelectAsync(null!,
                select: x => new StSelectListForSubMainScreenResponse
                {
                    Id = x.Id,
                    Sub_title = lang == Localization.Arabic ? x.Screen_sub_title_ar : x.Screen_sub_title_en,
                    Screen_main_id = x.Screen_main_id,
                    Url = x.Url
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<StSelectListForSubMainScreenResponse>>()
            {
                Data = [],
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new Response<IEnumerable<StSelectListForSubMainScreenResponse>>()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<StGetAllSubMainScreensResponse>> GetAllSubMainScreensAsync(string lang, StGetAllFiltrationsForSubMainScreenRequest model)
    {
        Expression<Func<StSubMainScreen, bool>> filter = x => x.IsDeleted == model.IsDeleted;

        var result = new StGetAllSubMainScreensResponse
        {
            TotalRecords = await _unitOfWork.SubMainScreens.CountAsync(filter: filter),

            Items = (await _unitOfWork.SubMainScreens.GetSpecificSelectAsync(filter: filter,
                 take: model.PageSize,
                 skip: (model.PageNumber - 1) * model.PageSize,
                 select: x => new SubMainScreenData
                 {
                     Sub_id = x.Id,
                     Sub_title = lang == Localization.Arabic ? x.Screen_sub_title_ar : x.Screen_sub_title_en,
                     Url = x.Url,
                     Screen_cat_id = x.MainScreen.Screen_cat_id,
                     Cat_title = lang == Localization.Arabic ? x.MainScreen.MainScreenCategory.Screen_main_title_ar : x.MainScreen.MainScreenCategory.Screen_main_title_en,
                     Main_id = x.Screen_main_id,
                     Main_title = lang == Localization.Arabic ? x.MainScreen.Screen_cat_title_ar : x.MainScreen.Screen_cat_title_en,
                     Main_image = string.Concat(ReadRootPath.SettingImagesPath, x.MainScreen.MainScreenCategory.Screen_main_image)
                 }, orderBy: x =>
                   x.OrderByDescending(x => x.Id))).ToList()
        };
        if (result.TotalRecords is 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<StGetAllSubMainScreensResponse>()
            {
                Data = new()
                {
                    Items = []
                },
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new Response<StGetAllSubMainScreensResponse>()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<StCreateSubMainScreenRequest>> CreateSubMainScreenAsync(StCreateSubMainScreenRequest model)
    {
        var obj = await _unitOfWork.SubMainScreens.AddAsync(new StSubMainScreen
        {
            Screen_sub_title_en = model.Screen_sub_title_en,
            Screen_sub_title_ar = model.Screen_sub_title_ar,
            Screen_main_id = model.Screen_main_id,
            Url = model.Url,
            ListOfActions = model.Actions.Select(ob => new StSubMainScreenAction
            {
                ActionId = ob,

            }).ToList()
        });
        await _unitOfWork.CompleteAsync();

        return new Response<StCreateSubMainScreenRequest>()
        {
            Msg = _sharLocalizer[Localization.Done],
            Check = true,
            Data = model
        };
    }

    public async Task<Response<StGetSubMainScreenByIdResponse>> GetSubMainScreenByIdAsync(int id)
    {
        var obj = await _unitOfWork.SubMainScreens.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "ListOfActions.Action");

        if (obj is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<StGetSubMainScreenByIdResponse>()
            {
                Data = new(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new Response<StGetSubMainScreenByIdResponse>()
        {
            Data = new StGetSubMainScreenByIdResponse
            {
                Id = id,
                Screen_cat_id = obj.Id,
                Screen_sub_title_ar = obj.Screen_sub_title_ar,
                Screen_sub_title_en = obj.Screen_sub_title_en,
                Url = obj.Url,
                Actions = obj.ListOfActions.Select(x => new ActionsData
                {
                    Id = x.ActionId,
                    Name = x.Action.Name,
                    NameInEnglish = x.Action.NameInEnglish
                }).ToList()
            },
            Check = true
        };
    }

    public async Task<Response<StUpdateSubMainScreenRequest>> UpdateSubMainScreenAsync(int id, StUpdateSubMainScreenRequest model)
    {
        var obj = await _unitOfWork.SubMainScreens.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "ListOfActions");

        if (obj is null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.SubMainScreen]);

            return new Response<StUpdateSubMainScreenRequest>()
            {
                Data = new(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
             _unitOfWork.SubMainScreenActions.RemoveRange(obj.ListOfActions);
            await _unitOfWork.CompleteAsync();

            var resultObj = await _unitOfWork.SubMainScreens.AddAsync(new StSubMainScreen
            {
                Screen_sub_title_en = model.Screen_sub_title_en,
                Screen_sub_title_ar = model.Screen_sub_title_ar,
                Screen_main_id = model.Screen_main_id,
                Url = model.Url,
                ListOfActions = model.Actions.Select(ob => new StSubMainScreenAction
                {
                    ActionId = ob
                }).ToList()
            });
            await _unitOfWork.CompleteAsync();
            transaction.Commit();

            return new Response<StUpdateSubMainScreenRequest>()
            {
                Msg = _sharLocalizer[Localization.Done],
                Check = true,
                Data = model
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            await _loggingRepository.LogExceptionInDb(ex, JsonConvert.SerializeObject(model));
            return new Response<StUpdateSubMainScreenRequest>()
            {
                Error = ex.Message,
                Msg = ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message)
            };
        }
    }

    public Task<Response<string>> UpdateActiveOrNotSubMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteSubMainScreenAsync(int id)
    {
        var obj = await _unitOfWork.SubMainScreens.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "ListOfActions");

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.SubMainScreen]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        _unitOfWork.SubMainScreens.Remove(obj);

        bool result = await _unitOfWork.CompleteAsync() > 0;

        if (!result)
            return new Response<string>()
            {
                Check = false,
                Data = string.Empty,
                Error = err,
                Msg = err
            };
        return new Response<string>()
        {
            Check = true,
            Data = string.Empty,
            Msg = _sharLocalizer[Localization.Deleted]
        };
    }

    #endregion
}
