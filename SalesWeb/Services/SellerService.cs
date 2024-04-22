using SalesWeb.Data;
using SalesWeb.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Services.Exceptions;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not foud");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            } catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            _context.SaveChangesAsync();
        }
    }
}
