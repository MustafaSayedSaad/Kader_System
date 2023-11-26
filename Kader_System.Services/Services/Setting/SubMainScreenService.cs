using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Kader_System.Services.Services.Setting;

public class SubMainScreenService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer, IMapper mapper) : ISubMainScreenService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IMapper _mapper = mapper;

    #region Sub main screen


    public async Task<Response<StCreateMainScreenRequest>> CreateMainScreenAsync(StCreateMainScreenRequest model)
    {
        await _unitOfWork.MainScreens.AddAsync(new StMainScreen
        {
            Screen_cat_title_ar = model.Screen_main_title_ar,
            Screen_cat_title_en = model.Screen_main_title_en,
            Screen_cat_id = model.Screen_main_id
        });
        await _unitOfWork.CompleteAsync();

        return new Response<StCreateMainScreenRequest>()
        {
            Msg = _sharLocalizer[Localization.Done],
            Check = true,
            Data = model
        };
    }

    public async Task<Response<StGetMainScreenByIdResponse>> GetMainScreenByIdAsync(int id)
    {
        var obj = await _unitOfWork.MainScreens.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "MainScreenCategory");

        if (obj is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<StGetMainScreenByIdResponse>()
            {
                Data = new StGetMainScreenByIdResponse(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }
        return new Response<StGetMainScreenByIdResponse>()
        {
            Data = new StGetMainScreenByIdResponse
            {
                Id = id,
                Screen_cat_id = obj.Id,
                Screen_cat_title_ar = obj.Screen_cat_title_ar,
                Screen_cat_title_en = obj.Screen_cat_title_en,
                Screen_main_id = obj.Screen_cat_id,
                Main_title_ar = obj.MainScreenCategory.Screen_main_title_ar,
                Main_title_en = obj.MainScreenCategory.Screen_main_title_en
            },
            Check = true
        };
    }

    public async Task<Response<StUpdateMainScreenRequest>> UpdateMainScreenAsync(int id, StUpdateMainScreenRequest model)
    {
        var obj = await _unitOfWork.MainScreens.GetFirstOrDefaultAsync(x => x.Id == model.Screen_cat_id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Service]);

            return new Response<StUpdateMainScreenRequest>()
            {
                Data = model,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        obj.Screen_cat_title_ar = model.Screen_main_title_ar;
        obj.Screen_cat_title_en = model.Screen_main_title_en;
        obj.Screen_cat_id = model.Screen_main_id;

        _unitOfWork.MainScreens.Update(obj);
        await _unitOfWork.CompleteAsync();

        return new Response<StUpdateMainScreenRequest>()
        {
            Check = true,
            Data = model,
            Msg = _sharLocalizer[Localization.Updated]
        };
    }

    public Task<Response<string>> UpdateActiveOrNotMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteMainScreenAsync(int id)
    {
        var obj = await _unitOfWork.MainScreens.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.MainScreen]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        _unitOfWork.MainScreens.Remove(obj);

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
                    ActionId = ob
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

    public Task<Response<StGetSubMainScreenByIdResponse>> GetSubMainScreenByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<StUpdateSubMainScreenRequest>> UpdateSubMainScreenAsync(int id, StUpdateMainScreenRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateActiveOrNotSubMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DeleteSubMainScreenAsync(int id)
    {
        throw new NotImplementedException();
    }

    #endregion
}
