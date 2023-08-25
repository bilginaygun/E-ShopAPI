using AutoMapper;
using E_Shop.Business.Abstract;
using E_Shop.Helper.CustomException;
using E_ShopAPI.Apı.Validation.FluentValidation;
using E_ShopAPI.Entity.DTO.Customer;
using E_ShopAPI.Entity.Poco;
using E_ShopAPI.Entity.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace E_ShopAPI.Apı.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("/AddCustomer")]
        [ProducesResponseType(typeof(Sonuc<CustomerDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCustomer(CustomerDTORequest CustomerDTORequest)
        {

            CustomerRegisterValidator customerValidator = new();

            if (customerValidator.Validate(CustomerDTORequest).IsValid)
            {
                Customer customer = _mapper.Map<Customer>(CustomerDTORequest);

                await _customerService.AddAsync(customer);

                CustomerDTOResponse CustomerDTOResponse = _mapper.Map<CustomerDTOResponse>(customer);
                return Ok(Sonuc<CustomerDTOResponse>.SuccessWithData(CustomerDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < customerValidator.Validate(CustomerDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(customerValidator.Validate(CustomerDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }




        }

        [HttpGet("/Customer/{guid}")]
        [ProducesResponseType(typeof(Sonuc<CustomerDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomer(Guid guid)
        {
            var customer = await _customerService.GetAsync(q => q.GUID == guid);
            if (customer != null)
            {
                CustomerDTOResponse CustomerDTOResponse = _mapper.Map<CustomerDTOResponse>(customer);


                return Ok(Sonuc<CustomerDTOResponse>.SuccessWithData(CustomerDTOResponse));

            }
            else
            {
                return NotFound(Sonuc<CustomerDTOResponse>.SuccessNoDataFound());

            }

        }

        [HttpGet("/Customers")]
        [ProducesResponseType(typeof(Sonuc<List<CustomerDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();

            List<CustomerDTOResponse> customersDTOResponseList = new List<CustomerDTOResponse>();

            foreach (var customer in customers)
            {
                var customerDTO = _mapper.Map<CustomerDTOResponse>(customer);
                customersDTOResponseList.Add(customerDTO);
            }
            return Ok(Sonuc<List<CustomerDTOResponse>>.SuccessWithData(customersDTOResponseList));
        }

    }
}
