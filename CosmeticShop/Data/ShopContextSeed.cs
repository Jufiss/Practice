using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using CosmeticShop.DAL.Models;

namespace CosmeticShop.Data
{
    public class ShopContextSeed
    {
        public static async Task SeedAsync(ShopContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Category.Any())
                {
                    return;
                }
                var categories = new Category[]
                {
                        new Category{Name="Тушь"},
                        new Category{Name="Помада"},
                        new Category{Name="Парфюмерия"}
                };
                foreach (Category b in categories)
                {
                    context.Category.Add(b);
                }
                await context.SaveChangesAsync();

                var firms = new Firm[]
{
                        new Firm{Name="Vivienne Sabo"},
                        new Firm{Name="Tom Ford"},
};
                foreach (Firm b in firms)
                {
                    context.Firm.Add(b);
                }
                await context.SaveChangesAsync();

                var products = new Product[]
                {
                        new Product{Name="Nude Createur", CategoryId=2, Color="Красный", Count=15, Price=400, FirmId=1, Description="Новая помада Nude Créateur вдохновит тебя на творчество в ежедневном макияже!"},
                        new Product{Name="Lost Cherry", CategoryId=3, Smell="Горький миндаль, Ликер, Вишня", Count=5, Price=10400, FirmId=2, Description="Насыщенный и изысканный восточный аромат Lost Cherry пронизан контрастами. "}
                };
                foreach (Product b in products)
                {
                    context.Product.Add(b);
                }
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
