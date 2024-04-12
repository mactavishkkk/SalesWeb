using SalesWeb.Models;
using SalesWeb.Models.Enums;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // Database has been seeded
            }

            Department department = new Department(1, "Computers");
            Department departmentOne = new Department(2, "Eletronics");
            Department departmentTwo = new Department(3, "Books");

            Seller seller = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1998, 4, 21), 1000, department);
            Seller sellerOne = new Seller(2, "Paul", "paul@gmail.com", new DateTime(1999, 5, 22), 1500, departmentOne);
            Seller sellerTwo = new Seller(3, "Alex", "alex@gmail.com", new DateTime(2000, 6, 24), 2000, departmentTwo);
            Seller sellerThree = new Seller(4, "Maria", "maria@gmail.com", new DateTime(2001, 7, 25), 2500, department);
            Seller sellerFour = new Seller(5, "Tifany", "Tifany@gmail.com", new DateTime(2002, 8, 26), 3000, departmentOne);
            Seller sellerFive = new Seller(6, "Chirty", "chirty@gmail.com", new DateTime(2003, 9, 27), 3500, departmentTwo);
            Seller sellerSix = new Seller(7, "Ana", "ana@gmail.com", new DateTime(2004, 10, 28), 4000, departmentOne);
            Seller sellerSeven = new Seller(8, "Moises", "moises@gmail.com", new DateTime(2005, 11, 29), 1000, department);
            Seller sellerEight = new Seller(9, "Paulo", "paulo@gmail.com", new DateTime(2006, 12, 30), 1200, department);
            Seller sellerNine = new Seller(10, "Gabriela", "gabriela@gmail.com", new DateTime(2007, 1, 01), 1300, departmentTwo);

            SalesRecord sale = new SalesRecord(1, new DateTime(2013, 4, 22), 765.4, SaleStatus.Pending, seller);
            SalesRecord saleOne = new SalesRecord(2, new DateTime(2014, 5, 23), 765.4, SaleStatus.Billed, sellerOne);
            SalesRecord saleTwo = new SalesRecord(3, new DateTime(2015, 6, 24), 765.4, SaleStatus.Canceled, sellerTwo);
            SalesRecord saleThree = new SalesRecord(4, new DateTime(2016, 7, 25), 765.4, SaleStatus.Pending, sellerThree);
            SalesRecord saleFour = new SalesRecord(5, new DateTime(2017, 8, 26), 765.4, SaleStatus.Pending, sellerFour);
            SalesRecord saleFive = new SalesRecord(6, new DateTime(2018, 9, 27), 765.4, SaleStatus.Billed, seller);
            SalesRecord saleSix = new SalesRecord(7, new DateTime(2013, 10, 12), 765.4, SaleStatus.Billed, sellerFive);
            SalesRecord saleSeven = new SalesRecord(8, new DateTime(2014, 4, 13), 765.4, SaleStatus.Canceled, sellerSix);
            SalesRecord saleEight = new SalesRecord(9, new DateTime(2015, 5, 14), 765.4, SaleStatus.Canceled, sellerSeven);
            SalesRecord saleNine = new SalesRecord(10, new DateTime(2016, 6, 15), 765.4, SaleStatus.Canceled, sellerEight);
            SalesRecord saleTen = new SalesRecord(11, new DateTime(2017, 7, 16), 765.4, SaleStatus.Billed, sellerNine);
            SalesRecord saleEleven = new SalesRecord(12, new DateTime(2018, 8, 22), 765.4, SaleStatus.Billed, sellerTwo);
            SalesRecord saleTwelve = new SalesRecord(13, new DateTime(2013, 9, 21), 765.4, SaleStatus.Billed, sellerThree);
            SalesRecord saleThirteen = new SalesRecord(14, new DateTime(2014, 10, 20), 765.4, SaleStatus.Pending, sellerFour);
            SalesRecord saleFourteen = new SalesRecord(15, new DateTime(2015, 4, 19), 765.4, SaleStatus.Pending, sellerFive);
            SalesRecord saleFiveteen = new SalesRecord(16, new DateTime(2016, 5, 18), 765.4, SaleStatus.Canceled, sellerSix);
            SalesRecord saleSixteen = new SalesRecord(17, new DateTime(2017, 6, 21), 765.4, SaleStatus.Canceled, sellerSeven);
            SalesRecord saleSeventeen = new SalesRecord(18, new DateTime(2018, 7, 24), 765.4, SaleStatus.Canceled, sellerEight);
            SalesRecord saleEighteen = new SalesRecord(19, new DateTime(2013, 8, 23), 765.4, SaleStatus.Pending, sellerNine);
            SalesRecord saleNineteen = new SalesRecord(20, new DateTime(2014, 9, 26), 765.4, SaleStatus.Billed, sellerNine);

            _context.Department.AddRange(department, departmentOne, departmentTwo);
            _context.Seller.AddRange(seller, sellerTwo, sellerThree, sellerFour, sellerFive, sellerSix, sellerEight, sellerNine);
            _context.SalesRecord.AddRange(sale, saleOne, saleTwo,
                saleThree, saleFour, saleFive,
                saleSix, saleSeven, saleEight,
                saleNine, saleTen, saleEleven,
                saleTwelve, saleThirteen, saleFourteen,
                saleFiveteen, saleSixteen, saleSeventeen,
                saleEighteen, saleNineteen);

            _context.SaveChanges();
        }
    }
}
