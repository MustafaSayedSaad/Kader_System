﻿namespace Kader_System.Services.Services.HR;

public class ShiftService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> sharLocalizer, IMapper mapper) : IShiftService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IMapper _mapper = mapper;

    #region Shift

    public async Task<Response<IEnumerable<SelectListResponse>>> ListOfShiftsAsync(string lang)
    {
        var result =
                await _unitOfWork.Shifts.GetSpecificSelectAsync(null!,
                select: x => new SelectListResponse
                {
                    Id = x.Id,
                    Name = lang == Localization.Arabic ? x.Name_ar : x.Name_en
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

    public async Task<Response<HrGetAllShiftsResponse>> GetAllShiftsAsync(string lang, HrGetAllFiltrationsForShiftsRequest model)
    {
        Expression<Func<HrShift, bool>> filter = x => x.IsDeleted == model.IsDeleted;

        var result = new HrGetAllShiftsResponse
        {
            TotalRecords = await _unitOfWork.Shifts.CountAsync(filter: filter),

            Items = (await _unitOfWork.Shifts.GetSpecificSelectAsync(filter: filter,
                 take: model.PageSize,
                 skip: (model.PageNumber - 1) * model.PageSize,
                 select: x => new ShiftData
                 {
                     Id = x.Id,
                     Name = lang == Localization.Arabic ? x.Name_ar : x.Name_en,
                     Start_shift = x.Start_shift,
                     End_shift = x.End_shift
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

    public async Task<Response<HrCreateShiftRequest>> CreateShiftAsync(HrCreateShiftRequest model)
    {
        bool exists = false;
        exists = await _unitOfWork.Shifts.ExistAsync(x => x.Name_ar.Trim() == model.Name_ar
        && x.Name_en.Trim() == model.Name_en.Trim());

        if (exists)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.IsExist],
                _sharLocalizer[Localization.Qualification]);

            return new()
            {
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        await _unitOfWork.Shifts.AddAsync(new()
        {
            Name_en = model.Name_en,
            Name_ar = model.Name_ar
        });
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Msg = _sharLocalizer[Localization.Done],
            Check = true,
            Data = model
        };
    }

    public async Task<Response<HrGetShiftByIdResponse>> GetShiftByIdAsync(int id)
    {
        var obj = await _unitOfWork.Shifts.GetByIdAsync(id);

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
                Name_ar = obj.Name_ar,
                Name_en = obj.Name_en
            },
            Check = true
        };
    }

    public async Task<Response<HrUpdateShiftRequest>> UpdateShiftAsync(int id, HrUpdateShiftRequest model)
    {
        var obj = await _unitOfWork.Shifts.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Qualification]);

            return new()
            {
                Data = model,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        obj.Name_ar = model.Name_ar;
        obj.Name_en = model.Name_en;

        _unitOfWork.Shifts.Update(obj);
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Check = true,
            Data = model,
            Msg = _sharLocalizer[Localization.Updated]
        };
    }

    public Task<Response<string>> UpdateActiveOrNotShiftAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteShiftAsync(int id)
    {
        var obj = await _unitOfWork.Shifts.GetByIdAsync(id);

        if (obj == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Qualification]);

            return new()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        _unitOfWork.Shifts.Remove(obj);
        await _unitOfWork.CompleteAsync();

        return new()
        {
            Check = true,
            Data = string.Empty,
            Msg = _sharLocalizer[Localization.Deleted]
        };
    }

    #endregion
}


