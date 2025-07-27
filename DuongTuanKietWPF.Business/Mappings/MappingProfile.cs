using AutoMapper;
using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.DataAccess.Models;

namespace DuongTuanKietWPF.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer mappings
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerStatus, opt => opt.MapFrom(src => (byte)1));
            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            // Room mappings
            CreateMap<RoomInformation, RoomDto>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.RoomTypeName : null))
                .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.TypeDescription : null));
            CreateMap<RoomCreateDto, RoomInformation>()
                .ForMember(dest => dest.RoomId, opt => opt.Ignore())
                .ForMember(dest => dest.RoomStatus, opt => opt.MapFrom(src => (byte)1))
                .ForMember(dest => dest.RoomType, opt => opt.Ignore());
            CreateMap<RoomUpdateDto, RoomInformation>()
                .ForMember(dest => dest.RoomType, opt => opt.Ignore());

            // RoomType mappings
            CreateMap<RoomType, RoomTypeDto>();

            // Booking mappings
            CreateMap<BookingReservation, BookingDto>()
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.CustomerFullName : null))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.EmailAddress : null))
                .ForMember(dest => dest.BookingDetails, opt => opt.MapFrom(src => src.BookingDetails));
            CreateMap<BookingCreateDto, BookingReservation>()
                .ForMember(dest => dest.BookingReservationId, opt => opt.Ignore())
                .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => (byte)1))
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.BookingDetails, opt => opt.Ignore());
            CreateMap<BookingUpdateDto, BookingReservation>()
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.BookingDetails, opt => opt.Ignore());

            // BookingDetail mappings
            CreateMap<BookingDetail, BookingDetailDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomNumber : null))
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.Room != null && src.Room.RoomType != null ? src.Room.RoomType.RoomTypeName : null))
                .ForMember(dest => dest.RoomPricePerDay, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomPricePerDay : null));
            CreateMap<BookingDetailCreateDto, BookingDetail>()
                .ForMember(dest => dest.Room, opt => opt.Ignore())
                .ForMember(dest => dest.BookingReservation, opt => opt.Ignore());

            // Report mappings
            CreateMap<BookingReservation, BookingReportDto>()
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.CustomerFullName : string.Empty))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.EmailAddress : string.Empty))
                .ForMember(dest => dest.TotalRooms, opt => opt.MapFrom(src => src.BookingDetails.Count))
                .ForMember(dest => dest.BookingDetails, opt => opt.MapFrom(src => src.BookingDetails));
        }
    }
}
