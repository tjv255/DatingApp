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
              .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
              .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres == null ? null: src.Genres
                    .Replace(" ", "")
                    .Split(',', System.StringSplitOptions.None)
                    .ToList()))
              .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills == null ? null: src.Skills
                    .Replace(" ", "")
                    .Split(',', System.StringSplitOptions.None)
                    .ToList()));
            CreateMap<Photo, PhotoDto>();
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
        }
    }
}