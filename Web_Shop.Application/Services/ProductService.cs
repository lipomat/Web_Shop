using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Extensions;
using Web_Shop.Application.Helpers.PagedList;
using Web_Shop.Application.Mappings;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.UOW.Interfaces;
using WWSI_Shop.Persistence.MySQL.Model;
using BC = BCrypt.Net.BCrypt;

namespace Web_Shop.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(ILogger<Product> logger,
                                  ISieveProcessor sieveProcessor,
                                  IOptions<SieveOptions> sieveOptions,
                                  IUnitOfWork unitOfWork)
            : base(logger, sieveProcessor, sieveOptions, unitOfWork)
        {

        }

        public async Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> CreateNewProductAsync(AddUpdateProductDTO dto)
        {
            try
            {

                var newEntity = dto.MapProduct();
                //newEntity.CreatedAt = DateTime.UtcNow;
                //newEntity.UpdatedAt = newEntity.CreatedAt;

                var result = await AddAndSaveAsync(newEntity);
                return (true, result.entity, HttpStatusCode.OK, string.Empty);
            }
            catch (Exception ex)
            {
                return LogError(ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> UpdateExistingProductAsync(AddUpdateProductDTO dto, ulong id)
        {
            try
            {
                var existingEntityResult = await WithoutTracking().GetByIdAsync(id);

                if (!existingEntityResult.IsSuccess)
                {
                    return existingEntityResult;
                }

                var domainEntity = dto.MapProduct();

                domainEntity.IdProduct = id;

                //domainEntity.CreatedAt = existingEntity.CreatedAt;
                //domainEntity.UpdatedAt = DateTime.UtcNow;
                //domainProduct.UpdatedAt = DateTime.UtcNow.ConvertFromUtc(TimeZones.CentralEuropeanTimeZone);
                return await UpdateAndSaveAsync(domainEntity, id);
            }
            catch (Exception ex)
            {
                return LogError(ex.Message);
            }
        }

        /*
        public async Task<(bool IsSuccess, IPagedList<Product, GetSingleProductDTO>? entityList, HttpStatusCode StatusCode, string ErrorMessage)> SearchProductsAsync(SieveModel paginationParams)
        {
            try
            {
                var query = _unitOfWork.ProductRepository.Entities.AsNoTracking();

                var result = await query.ToPagedListAsync(_sieveProcessor,
                                                          _sieveOptions,
                                                          paginationParams,
                                                          formatterCallback => DomainToDtoMapper.MapGetSingleProductDTO(formatterCallback));

                return (true, result, HttpStatusCode.OK, String.Empty);
            }
            catch (Exception ex)
            {
                var error = LogError(ex.Message);

                return (false, default, error.StatusCode, error.ErrorMessage);
            }
        }
        */
    }
}
