using Application.Interfaces.Repositories;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            IGenericRepository<Cart, int> _cartRepository = new GenericRepository<Cart, int>(
                _context
            );
            CartServices cartService = new CartServices(_cartRepository);

            //var all = cartService.GetCartByUserId(2);
            //var all = cartService.GetAllEntitys();
            //foreach (var item in all)
            //{
            //    Console.WriteLine($"Cart ID: {item.ID}, User ID: {item.UserID}");
            //    foreach (var cartItem in item.CartItems)
            //    {
            //        Console.WriteLine(
            //            $"  Product ID: {cartItem.ProductId}, Quantity: {cartItem.Quantity}, Price: {cartItem.ProductPrice}, Image: {cartItem.ProductImage}"
            //        );
            //    }
            //}
            //cartService.ClearCart(new Cart { ID = 1 });
        }
    }
}
