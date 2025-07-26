using AutoMapper;
using Chartwell.Core.DTOs.CompanyExpertise;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.CompanyINFO;
using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.DTOs.ContactUs;
using Chartwell.Core.DTOs.EXpertiseNews;
using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.DTOs.OurFirms;
using Chartwell.Core.DTOs.OverViewSections;
using Chartwell.Core.DTOs.SubIndustries;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.DTOs.TeamRoleTitles;
using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Entity.TeamMembers;

namespace Chartwell.Core.DTOs.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TeamMember, TeamMemberToReturnDTO>()
                .ForMember(T => T.DepartmentServices, O => O.MapFrom(T => T.DepartmentServices.Name))
                .ForMember(T => T.TeamRoleTitle, O => O.MapFrom(T => T.TeamRoleTitle.Name))
                .ForMember(T => T.CompanyServices, O => O.MapFrom(T => T.CompanyServices.Name))
                .ForMember(T => T.OurFirm, O => O.MapFrom(T => T.OurFirm.Title))
                 .ForMember(P => P.PictureUrl, O => O.MapFrom<TeamMemberPictureUrlResolver>());

            CreateMap<TeamMemberToReturnDTO, TeamMemberToReturnDTOForUsers>();

            CreateMap<TeamMemberDTO, TeamMember>();

            CreateMap<CompanyServicesDTO, CompanyService>();

            CreateMap<CompanyService, CompanyServiceToReturnDTO>()
               .ForMember(P => P.PictureUrl, O => O.MapFrom<CompanyServicesPictureUrlResolver>()); ;

            CreateMap<OurFirmDTO, OurFirm>();

            CreateMap<OurFirm, OurFirmToReturnDTO>()
                .ForMember(P => P.PictureUrl, O => O.MapFrom<OurFirmPictureUrlResolver>());

            CreateMap<TeamRoleTitle, TeamRoleTitleDTO>().ReverseMap();

            CreateMap<TeamRoleTitle, TeamRoleTitleToReturnDTO>()
                  .ForMember(T => T.OurFirm, O => O.MapFrom(T => T.OurFirm.Title));

            CreateMap<Entity.ExpertisesNews.CompanyExpertise, CompanyExpertiseDTO>();

            CreateMap<Entity.ExpertisesNews.CompanyExpertise, CompanyExpertiseToReturnDTO>()
                .ForMember(P => P.pictureUrl, O => O.MapFrom<CompanyExpertisePictureUrlResolver>());

            CreateMap<OverViewSection, overViewSectionDTO>().ReverseMap();

            CreateMap<OverViewSection, OverViewToReturnDTO>()
                .ForMember(O => O.CompanyExpertise, O => O.MapFrom(O => O.CompanyExpertise.Name))
                .ForMember(O => O.CompanyServices, O => O.MapFrom(O => O.CompanyServices.Name));

            CreateMap<CompanyInfo, CompanyInfoToReturnDTO>()
                .ForMember(O => O.SocialLinks, O => O.MapFrom(O => O.SocialLinks.LinkedInUrl))
                .ForMember(P => P.LogoUrl, O => O.MapFrom<CompanyInfoLogoResolver>());

            CreateMap<CompanyInfo, CompanyInfoDTO>().ReverseMap();

            CreateMap<Industry, IndustryToReturnDTO>()
                 .ForMember(O => O.CompanyServices, O => O.MapFrom(O => O.CompanyServices.Name))
                  .ForMember(P => P.IconUrl, O => O.MapFrom<IndustryIconResolver>());
            ;

            CreateMap<IndustryDTO, Industry>();

            CreateMap<SubIndustry, SubIndustryToReturnDTO>()
                 .ForMember(O => O.Industries, O => O.MapFrom(O => O.Industries.Name));

            CreateMap<SubIndustry, SubIndustryDTO>().ReverseMap();

            CreateMap<ContactUsDTO, Entity.ContactsUs.ContactUs>().ReverseMap();

            CreateMap<Entity.ContactsUs.ContactUs, ContactUsToReturnDTO>()
               .ForMember(O => O.CompanyExpertise, O => O.MapFrom(O => O.CompanyExpertise.Name))
               .ForMember(O => O.Address, O => O.MapFrom(O => O.Address.City));

            CreateMap< ExpertiseNewsDTO, ExpertiseNews>();

            CreateMap<ExpertiseNews, ExpertiseNewsToReturnDTO>()
               .ForMember(O => O.TeamMembers, O => O.MapFrom(O => O.TeamMembers.FirstName))
               .ForMember(O => O.CompanyExpertise, O => O.MapFrom(O => O.CompanyExpertise.Name));
        }
        
    }
}
