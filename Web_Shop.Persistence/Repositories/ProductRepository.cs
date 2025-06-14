using Microsoft.EntityFrameworkCore;
using Web_Shop.Persistence.Repositories.Interfaces;
using WWSI_Shop.Persistence.MySQL.Context;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WwsishopContext context) : base(context) { }

        //public async Task<bool> IsNameEditAllowedAsync(string name, ulong id)
        //{
        //    return !await Entities.AnyAsync(e => e.Name == name && e.IdProduct != id);
        //}

        //public async Task<bool> NameExistAsync(string name)
        //{
        //    return await Entities.AnyAsync(e => e.Name == name);
        //}

        //public async Task<bool> EmailExistsAsync(string email)
        //{
        //    return await Entities.AnyAsync(e => e.Email == email);
        //}

        //public async Task<bool> IsEmailEditAllowedAsync(string email, ulong id)
        //{
        //    return !await Entities.AnyAsync(e => e.Email == email && e.IdCustomer != id);
        //}

        //public async Task<Customer?> GetByEmailAsync(string email)
        //{
        //    return await Entities.FirstOrDefaultAsync(e => e.Email == email);
        //}
    }
}
