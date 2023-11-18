namespace Kader_System.Services.Services.Shared;

public class PoliticsService : IPoliticsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer;
    private readonly IMapper _mapper;


    public PoliticsService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer,
                       IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _sharLocalizer = sharLocalizer;
        _mapper = mapper;
    }

    #region Politics

    public async Task<Response<SharCreatePolicyRequest>> CreatePolicyAsync(SharCreatePolicyRequest model)
    {

        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, GoRootPath.SharedImagesPath);
        string imageName = fileObj.FileName;
        string imageExtension = fileObj.FileExtension;

        var fileObj2 = ManageFilesHelper.UploadFile(model.FilePath, GoRootPath.SharedFilesPath);
        string fileName = fileObj2.FileName;
        string fileExtension = fileObj2.FileExtension;

        await _unitOfWork.Politics.AddAsync(new SharPolitics
        {
            Title = model.Title,
            ImageName = imageName,
            ImageExtension = imageExtension,
            FileName = fileName,
            FileExtension = fileExtension
        });
        await _unitOfWork.CompleteAsync();

        return new Response<SharCreatePolicyRequest>()
        {
            Message = _sharLocalizer[Localization.Done],
            IsSuccess = true,
            Data = model
        };
    }

    public async Task<Response<IEnumerable<SharGetAllPoliciesResponse>>> GetAllPoliciesAsync()
    {
        var result =
                await _unitOfWork.Politics.GetSpecificSelectAsync(null!,
                select: x => new SharGetAllPoliciesResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImagePath = string.Concat(ReadRootPath.SharedImagesPath, x.ImageExtension),
                    FilePath = string.Concat(ReadRootPath.SharedFilesPath, x.FileExtension),
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (result == null || result.ToList().Count == 0)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SharGetAllPoliciesResponse>>()
            {
                Data = new List<SharGetAllPoliciesResponse>(),
                Message = resultMsg
            };
        }
        return new Response<IEnumerable<SharGetAllPoliciesResponse>>()
        {
            Data = result,
            IsSuccess = true
        };
    }

    public async Task<Response<string>> DeletePolicyAsync(int id)
    {
        var politics = await _unitOfWork.Politics.GetByIdAsync(id);

        if (politics == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Policy]);

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Message = resultMsg
            };
        }
        string err = _sharLocalizer[Localization.Error];

        _unitOfWork.Politics.Remove(politics);

        bool result = await _unitOfWork.CompleteAsync() > 0;

        if (!result)
            return new Response<string>()
            {
                IsSuccess = false,
                Data = politics.Title,
                Error = err,
                Message = err
            };
        return new Response<string>()
        {
            IsSuccess = true,
            Data = politics.Title,
            Message = _sharLocalizer[Localization.Deleted]
        };
    }

    public async Task<Response<SharGetPolicyResponse>> GetPolicyByIdAsync(int id)
    {

        var politics = await _unitOfWork.Politics.GetByIdAsync(id);

        if (politics is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<SharGetPolicyResponse>()
            {
                Data = new SharGetPolicyResponse(),
                Error = resultMsg,
                Message = resultMsg
            };
        }
        return new Response<SharGetPolicyResponse>()
        {
            Data = _mapper.Map<SharGetPolicyResponse>(politics),
            IsSuccess = true
        };
    }

    public async Task<Response<SharEditPolicyRequest>> UpdatePolicyAsync(int id, SharEditPolicyRequest model)
    {
        var obj = await _unitOfWork.Politics.GetByIdAsync(id);

        if (obj == null || model.Id != id)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Policy], id);

            return new Response<SharEditPolicyRequest>()
            {
                Data = model,
                Error = resultMsg,
                Message = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        var mapped = _mapper.Map<SharEditPolicyRequest, SharPolitics>(model, obj);

        if (model.ImagePath != null)
        {
            string newsPath = GoRootPath.SharedImagesPath;

            if (obj.ImageName != null)
                ManageFilesHelper.RemoveFile(newsPath + "/" + obj.ImageName);

            var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, newsPath);
            mapped.ImageName = fileObj.FileName;
            mapped.ImageExtension = fileObj.FileExtension;
        }

        if (model.FilePath != null)
        {
            string newsPath = Directory.GetCurrentDirectory() + GoRootPath.SharedVideosPath;

            if (obj.FileName != null)
                ManageFilesHelper.RemoveFile(newsPath + "/" + obj.FileName);

            var fileObj = ManageFilesHelper.UploadFile(model.FilePath, newsPath);
            mapped.FileName = fileObj.FileName;
            mapped.FileExtension = fileObj.FileExtension;
        }

        _unitOfWork.Politics.Update(mapped);
        bool result = await _unitOfWork.CompleteAsync() > 0;

        return new Response<SharEditPolicyRequest>()
        {
            IsSuccess = result,
            Data = model,
            Message = result ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
        };
    }

    public Task<Response<string>> UpdateActiveOrNotPolicyAsync(int id)
    {
        throw new NotImplementedException();
    }



    private async Task<string> GetUserNameById(string userId) =>
    (await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.Id == userId)).UserName!;

    #endregion
}
