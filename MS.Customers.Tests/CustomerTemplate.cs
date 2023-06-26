using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.DTO.Customer;
using MS.Customer.Domain.Entities;
using MS.Customer.Domain.Enum;
using MS.Customer.Domain.Paging;
using MS.Customer.Domain.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Tests
{
    public class CustomerTemplate
    {
        public static Customers Customers()
        {
            return new Customers()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "46617438817",
                Email = "leozncontato@gmail.com",
                Phone = "11916691211",
                Password = "Leoteste@12",
                Generous = Generous.Others,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }
        public static Customers Customers2()
        {
            return new Customers()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "$2a$11$G7JH4PvHSMEipkMLrWN9Puy2mVKXfF5UXVCGrM/YNQf6kK/fyBhWC",
                Email = "leozncontato@gmail.com",
                Phone = "11916691211",
                Password = "Leoteste@12",
                Generous = Generous.Others,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }
        
        public static Customers CustomersCreate()
        {
            return new Customers()
            {
                Name = "Caetano",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "caetanoteste2@gmail.com",
                Phone = "11968953253",
                Password = "Testes@12",
                Generous = Generous.Others,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }

        public static IList<Customers> ListCustomers()
        {
            IList<Customers> customers = new List<Customers>();
            customers.Add(Customers());
            return customers;
        }

        public static IList<Customers> ListCustomers2()
        {
            IList<Customers> customers = new List<Customers>();
            customers.Add(Customers2());
            return customers;
        }

        public static ResponseCustomerDTO ResponseCustomerDTO()
        {
            return new ResponseCustomerDTO()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "leozncontato@gmail.com",
                Phone = "11916691211",
                Password = "Leoteste@12",
                Generous = Generous.Others,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }

        public static ResponseCustomerDTO ResponseCustomerDTOCreated()
        {
            return new ResponseCustomerDTO()
            {
                Name = "Caetano",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "leozncontato@gmail.com",
                Phone = "11968953253",
                Password = "Testes@12",
                Generous = Generous.Others,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }

        public static ResponseCustomerDTO ResponseCustomerDTOUpdate()
        {
            return new ResponseCustomerDTO()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "leozncontato@gmail.com",
                Phone = "1196895353",
                Password = "Leoteste@12",
                Generous = Generous.Masculine,
                IsActive = true,
                CustomerId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };
        }

        public static CustomerViewModel CustomerViewModel()
        {
            return new CustomerViewModel()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "leozncontato@gmail.com",
                Phone = "11916691211",
                Password = "Leoteste@12",
                Generous = Generous.Others
            };
        }

        public static CustomerDTO CustomerDTO()
        {
            return new CustomerDTO()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "leozncontato@gmail.com",
                Phone = "11916691211",
                Password = "Leoteste@12",
                Generous = Generous.Others,
                CustomerId = Guid.NewGuid()
            };
        }

        public static CustomerDTO CustomerDTOCreate()
        {
            return new CustomerDTO()
            {
                Name = "Caetano",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "caetanoteste2@gmail.com",
                Phone = "11968953253",
                Password = "Testes@12",
                Generous = Generous.Others,
                CustomerId = Guid.NewGuid()
            };
        }

        public static CustomerUpdateDTO CustomerUpdateDTO()
        {
            return new CustomerUpdateDTO()
            {
                Name = "Jasmime",
                LastName = "Angelo",
                Phone = "11955321211",
                Generous = Generous.Feminine,
                CustomerId = new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5")
            };
        }
        public static CustomerUpdateDTO CustomerUpdateDTOErro()
        {
            return new CustomerUpdateDTO()
            {
                Name = "Jasmime",
                LastName = "Angelo",
                Phone = "11968953253",
                Generous = Generous.Feminine,
                CustomerId = new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5")
            };
        }

        public static Customers CustomersUpdate()
        {
            return new Customers()
            {
                Name = "Jasmime",
                LastName = "Angelo",
                Cpf = "51541979095",
                Email = "caetanoteste2@gmail.com",
                Phone = "11955321211",
                Password = "Testes@12",
                Generous = Generous.Feminine,
                IsActive = true,
                CustomerId = new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5"),
                CreatedAt = DateTime.Now
            };
        }

        public static Customers CustomersUpdateMap()
        {
            return new Customers()
            {
                Name = "Jasmime",
                LastName = "Angelo",
                Phone = "11955321211",
                Generous = Generous.Feminine,
            };
        }

        public static CustomerUpdateViewModel CustomerUpdateViewModel()
        {
            return new CustomerUpdateViewModel()
            {
                Name = "Leonardo",
                LastName = "Angelo",
                Phone = "1196895353",
                Generous = Generous.Masculine
            };
        }

        public static CustomerUpdateEmailViewMoedel CustomerUpdateEmailViewMoedel()
        {
            return new CustomerUpdateEmailViewMoedel()
            {
                NewEmail = "leoteste@gmail.com",
                NewEmailConfirmed = "leoteste@gmail.com",
                Password = "Leoteste@12"
            };
        }



        public static CustomerUpdatePasswordViewModel CustomerUpdatePasswordViewModel()
        {
            return new CustomerUpdatePasswordViewModel()
            {
                NewPassword = "Leo12@Teste",
                NewPasswordConfirmed = "Leo12@Teste",
                OldPassword = "Leoteste@12"
            };
        }

        public static CustomerUpdatePasswordViewModel CustomerUpdatePasswordViewModelError()
        {
            return new CustomerUpdatePasswordViewModel()
            {
                NewPassword = "Leo1234@Teste",
                NewPasswordConfirmed = "Leo12@Teste",
                OldPassword = "Leoteste@12"

            };
        }

        public static CustomerActiveDeactiveViewModel CustomerActiveDeactiveViewModel()
        {
            return new CustomerActiveDeactiveViewModel()
            {
                IsActive = true
            };
        }

        public static ResponsePaging<ResponseCustomerDTO> PagingFiltersBaseResonseCustomDTO()
        {
            return new ResponsePaging<ResponseCustomerDTO>(){data = ListObjectResponse() };
        }

        public static List<ResponseCustomerDTO> ListObjectResponse()
        {
            List<ResponseCustomerDTO> lst = new List<ResponseCustomerDTO>();
            lst.Add(ResponseCustomerDTO());
;           return lst;
        }

        public static IList<ResponseCustomerDTO> IListObjectResponse()
        {
            IList<ResponseCustomerDTO> lst = new List<ResponseCustomerDTO>();
            lst.Add(ResponseCustomerDTO());
            ; return lst;
        }
    }
}
