namespace Kader_System.Api.Profiles;

public class SharProfile : Profile
{
    public SharProfile()
    {
        #region Shared

        CreateMap<SharNews, SharCreateNewsRequest>()
                .ReverseMap();

        CreateMap<SharAboutUs, SharCreateAboutUsRequest>()
                .ReverseMap();

        CreateMap<SharEditAboutUsRequest, SharAboutUs>()
                .ReverseMap();

        CreateMap<SharAboutUs, SharGetAboutUsResponse>()
            .ForMember(dest => dest.Image, src => src.MapFrom(src => string.Concat(ReadRootPath.SharedImagesPath, src.ImageName)))
                .ReverseMap();

        CreateMap<SharNews, SharEditNewsRequest>()
                .ReverseMap();

        CreateMap<SharNews, SharGetNewsResponse>()
            .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => src.ImageName != null ? string.Concat(ReadRootPath.SharedImagesPath, src.ImageName) : string.Empty))
            .ForMember(dest => dest.VideoPath, src => src.MapFrom(src => src.VideoName != null ? string.Concat(ReadRootPath.SharedVideosPath, src.VideoName) : string.Empty))
            .ForMember(dest => dest.InsertDate, src => src.MapFrom(src => src.InsertDate.ToGetFullyDate()))
                .ReverseMap();

        CreateMap<SharServicesCategory, SharCreateServicesCategoryRequest>()
                .ReverseMap();

        CreateMap<SharService, SharCreateServiceRequest>()
            .ForMember(dest => dest.ImagePath, src => src.Ignore())
                .ReverseMap();


        CreateMap<SharPolitics, SharGetPolicyResponse>()
            .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => string.Concat(ReadRootPath.SharedImagesPath, src.ImageName)))
                .ReverseMap();

        #endregion

        #region Services

        CreateMap<SharService, SharGetServiceResponse>()
            .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => string.Concat(ReadRootPath.SharedImagesPath, src.ImageName)))
            .ForMember(dest => dest.ServicesCategoryId, src => src.MapFrom(src => src.ServicesCategoryyId))
            .ForMember(dest => dest.InsertDate, src => src.MapFrom(src => src.InsertDate.ToGetFullyDate()))
                .ReverseMap();

        CreateMap<SharServicesCategory, SharGetServicesCategoryWthAllServicesResponse>()
                .ReverseMap();


        CreateMap<SharEditServiceRequest, SharService>()
                .ReverseMap();

        #endregion

    }
}
