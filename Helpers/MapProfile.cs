using AutoMapper;
using TreainBookingApi.Entities;
using TreainBookingApi.Models;

namespace TreainBookingApi.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TrainSchedule, TrainScheduleVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Train, TrainVM>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Booking, BookingVM>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}