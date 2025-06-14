using Sieve.Models;
using System.Net;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Helpers.PagedList;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Application.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> CreateNewProductAsync(AddUpdateProductDTO dto);
        Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> UpdateExistingProductAsync(AddUpdateProductDTO dto, ulong id);
        //Task<(bool IsSuccess, Customer? entity, HttpStatusCode StatusCode, string ErrorMessage)> UpdateExistingCustomerAsync(AddUpdateCustomerDTO dto, ulong id);
        //Task<(bool IsSuccess, Customer? entity, HttpStatusCode StatusCode, string ErrorMessage)> VerifyPasswordByEmail(string email, string password);
        //Task<(bool IsSuccess, IPagedList<Customer, GetSingleCustomerDTO>? entityList, HttpStatusCode StatusCode, string ErrorMessage)> SearchCustomersAsync(SieveModel paginationParams);
    }
}
