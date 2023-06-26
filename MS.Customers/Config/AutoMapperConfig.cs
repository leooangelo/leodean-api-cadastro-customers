using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MS.Customer.Domain;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.DTO.Customer;
using MS.Customer.Domain.Entities;
using MS.Customer.Domain.ViewModel;
using System;

namespace MS.Customer.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {

                //cfg.CreateMap<User, UserDTO>().ReverseMap();
                //cfg.CreateMap<User, ResponseUserDTO>().ReverseMap();
                //cfg.CreateMap<UserDTO, ResponseUserDTO>().ReverseMap();
                //cfg.CreateMap<PageResult<User>, PageResult<ResponseUserDTO>>().ReverseMap();
                //cfg.CreateMap<UserViewModel, UserDTO>().ReverseMap();
                //cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();


                cfg.CreateMap<CustomerDTO, ResponseCustomerDTO>().ReverseMap();
                cfg.CreateMap<CustomerDTO, Customers>().ReverseMap();
                cfg.CreateMap<Customers, ResponseCustomerDTO>().ReverseMap();

                //cfg.CreateMap<PageResult<Customer>, PageResult<ResponseCustomerDTO>>().ReverseMap();
                cfg.CreateMap<CustomerViewModel, CustomerDTO>().ReverseMap();
                cfg.CreateMap<CustomerUpdateViewModel, CustomerUpdateDTO>().ReverseMap();
                cfg.CreateMap<CustomerUpdateDTO, Customers>().ReverseMap();


                //cfg.CreateMap<ExpedientViewModel, ExpedientDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }
    }
}