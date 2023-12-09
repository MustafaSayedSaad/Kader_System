using Kader_System.Domain.Models.HR;

namespace Kader_System.Services.Services.HR;

public class CompanyService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer, IMapper mapper) : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IMapper _mapper = mapper;

    #region Company


    public async Task<Response<StGetAllMainScreensCategoriesResponse>> GetAllMainScreensCategoriesAsync(string lang, StGetAllFiltrationsForMainScreenCategoryRequest model)
    {
        Expression<Func<StMainScreenCategory, bool>> filter = x => x.IsDeleted == model.IsDeleted;

        var result = new StGetAllMainScreensCategoriesResponse
        {
            TotalRecords = await _unitOfWork.MainScreenCategories.CountAsync(filter: filter),

            Items = (await _unitOfWork.MainScreenCategories.GetSpecificSelectAsync(filter: filter,
                 take: model.PageSize,
                 skip: (model.PageNumber - 1) * model.PageSize,
                 select: x => new MainScreenCategoryData
                 {
                     Id = x.Id,
                     Screen_main_title = lang == Localization.Arabic ? x.Screen_main_title_ar : x.Screen_main_title_en,
                     Screen_main_image = x.Screen_main_image != null ? string.Concat(ReadRootPath.SettingImagesPath, x.Screen_main_image) : string.Empty
                 }, orderBy: x =>
                   x.OrderByDescending(x => x.Id))).ToList()
        };

        if (result.TotalRecords is 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new()
            {
                Data = new()
                {
                    Items = []
                },
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<StCreateMainScreenCategoryRequest>> CreateMainScreenCategoryAsync(StCreateMainScreenCategoryRequest model)
    {
        bool exists = false;
        exists = await _unitOfWork.MainScreenCategories.ExistAsync(x => x.Screen_main_title_ar.Trim() == model.Screen_main_title_ar
        && x.Screen_main_title_en.Trim() == model.Screen_main_title_en.Trim());

        if (exists)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.IsExist],
                _sharLocalizer[Localization.MainScreenCategory]);

            return new()
            {
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string imageName = null!, imageExtension = null!;
        if (model.Screen_main_image is not null)
        {
            var fileObj = ManageFilesHelper.UploadFile(model.Screen_main_image, GoRootPath.SettingImagesPath);
            imageName = fileObj.FileName;
            imageExtension = fileObj.FileExtension;
        }


        await _unitOfWork.MainScreenCategories.AddAsync(new()
        {
            Screen_main_title_ar = model.Screen_main_title_ar,
            Screen_main_title_en = model.Screen_main_title_en,
            Screen_main_image = imageName,
            ImageExtension = imageExtension,
        });
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Msg = _sharLocalizer[Localization.Done],
            Check = true,
            Data = model
        };
    }

    public async Task<Response<StGetMainScreenCategoryByIdResponse>> GetMainScreenCategoryByIdAsync(int id)
    {
        var obj = await _unitOfWork.MainScreenCategories.GetByIdAsync(id);

        if (obj is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new()
            {
                Data = new(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new()
        {
            Data = new()
            {
                Id = id,
                Screen_main_title_ar = obj.Screen_main_title_ar,
                Screen_main_title_en = obj.Screen_main_title_en,
                Screen_main_image = string.Concat(ReadRootPath.SettingImagesPath, obj.Screen_main_image)
            },
            Check = true
        };
    }

    public async Task<Response<StUpdateMainScreenCategoryRequest>> UpdateMainScreenCategoryAsync(int id, StUpdateMainScreenCategoryRequest model)
    {
        var obj = await _unitOfWork.MainScreenCategories.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.MainScreenCategory]);

            return new()
            {
                Data = model,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        if (model.Screen_main_image is not null)
        {
            string path = GoRootPath.SettingImagesPath;

            ManageFilesHelper.RemoveFile(path + "/" + obj.Screen_main_image);

            var fileObj = ManageFilesHelper.UploadFile(model.Screen_main_image, path);
            obj.Screen_main_image = fileObj.FileName;
            obj.ImageExtension= fileObj.FileExtension;
        }

        obj.Screen_main_title_ar = model.Screen_main_title_ar;
        obj.Screen_main_title_en = model.Screen_main_title_en;

        _unitOfWork.MainScreenCategories.Update(obj);
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Check = true,
            Data = model,
            Msg = _sharLocalizer[Localization.Updated]
        };
    }

    public Task<Response<string>> UpdateActiveOrNotMainScreenCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteMainScreenCategoryAsync(int id)
    {
        var obj = await _unitOfWork.MainScreenCategories.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.MainScreenCategory]);

            return new()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        _unitOfWork.MainScreenCategories.Remove(obj);
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Check = true,
            Data = string.Empty,
            Msg = _sharLocalizer[Localization.Deleted]
        };
    }




    public async Task<Response<IEnumerable<StSelectListForMainScreenCategoryResponse>>> ListOfCompaniesAsync(string lang)
    {
        var result =
                await _unitOfWork.Companys.GetSpecificSelectAsync(null!,
                select: x => new StSelectListForMainScreenCategoryResponse
                {
                    Id = x.Id,
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new()
            {
                Data = [],
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<HrGetAllCompaniesResponse>> GetAllCompaniesAsync(string lang, HrGetAllFiltrationsForCompaniesRequest model)
    {
        Expression<Func<HrCompany, bool>> filter = x => x.IsDeleted == model.IsDeleted;

        var result = new HrGetAllCompaniesResponse
        {
            TotalRecords = await _unitOfWork.Companies.CountAsync(filter: filter),

            Items = (await _unitOfWork.Companies.GetSpecificSelectAsync(filter: filter,
                 take: model.PageSize,
                 skip: (model.PageNumber - 1) * model.PageSize,
                 select: x => new CompanyData
                 {
                     Id = x.Id,
                     Added_by = x.Added_by,
                     Add_date = x.Add_date.ToGetFullyDate(),
                     Company_owner = x.Company_owner,
                     Company_type_name = lang == Localization.Arabic ? x.CompanyType.Name : x.CompanyType.NameInEnglish,
                     Name = lang == Localization.Arabic ? x.Name_ar : x.Name_en
                 }, orderBy: x =>
                   x.OrderByDescending(x => x.Id))).ToList()
        };

        if (result.TotalRecords is 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new()
            {
                Data = new()
                {
                    Items = []
                },
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<HrCreateCompanyRequest>> CreateCompanyAsync(HrCreateCompanyRequest model)
    {
        bool exists = false;
        exists = await _unitOfWork.Companies.ExistAsync(x => x.Name_ar.Trim() == model.Name_ar
        && x.Name_en.Trim() == model.Name_en.Trim());

        if (exists)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.IsExist],
                _sharLocalizer[Localization.Company]);

            return new()
            {
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string imageName = null!, imageExtension = null!;
        if (model.Company_licenses is not null)
        {
            var fileObj = ManageFilesHelper.UploadFile(model.Company_licenses, GoRootPath.HRImagesPath);
            imageName = fileObj.FileName;
            imageExtension = fileObj.FileExtension;
        }


        await _unitOfWork.MainScreenCategories.AddAsync(new()
        {
            Screen_main_title_ar = model.Name_ar,
            Screen_main_title_en = model.Name_en,
            Screen_main_image = imageName,
            ImageExtension = imageExtension,
        });
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Msg = _sharLocalizer[Localization.Done],
            Check = true,
            Data = model
        };
    }

    public async Task<Response<StGetMainScreenCategoryByIdResponse>> GetCompanyByIdAsync(int id)
    {
        var obj = await _unitOfWork.Companies.GetByIdAsync(id);

        if (obj is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new()
            {
                Data = new(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new()
        {
            Data = new()
            {
                Id = id,
                Screen_main_title_ar = obj.Name_ar,
                Screen_main_title_en = obj.Name_en,
                Screen_main_image = string.Concat(ReadRootPath.HRImagesPath, obj.)
            },
            Check = true
        };
    }

    public Task<Response<StUpdateMainScreenCategoryRequest>> UpdateCompanyAsync(int id, StUpdateMainScreenCategoryRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateActiveOrNotCompanyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DeleteCompanyAsync(int id)
    {
        throw new NotImplementedException();
    }

    #endregion
}
