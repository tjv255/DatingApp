using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberDto, AppUser>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<Job, JobDto>()
            .ForMember(dest => dest.JobPosterId, opt => opt.MapFrom(src =>
            src.JobPoster.Id))
            .ForMember(dest => dest.JobPosterName, opt => opt.MapFrom( src =>
            src.JobPoster.KnownAs));
            CreateMap<JobUpdateDto, Job>();
            CreateMap<JobDto, Job>();

            CreateMap<Organization, OrganizationDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<AppUser, OrgMemberDto>();
            CreateMap<OrgPhoto, OrgPhotoDto>();
            CreateMap<OrganizationUpdateDto, Organization>();
            CreateMap<OrgPhotoDto, Organization>();
            

            
        }
    }
}