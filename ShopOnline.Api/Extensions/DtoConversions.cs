using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;
using System.Linq;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();

        }

        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name

            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartitems, IEnumerable<Product> products) 
        {
            return (from cartitem in cartitems
                    join product in products
                    on  cartitem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartitem.Id,
                        ProductId = cartitem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartitem.CartId,
                        Qty = cartitem.Qty,
                        TotalPrice = product.Price * cartitem.Qty   
                    }).ToList();
        }


        public static CartItemDto ConvertToDto(this CartItem cartitem, Product product)
        {
            return new CartItemDto
            {
                Id = cartitem.Id,
                ProductId = cartitem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                CartId = cartitem.CartId,
                Qty = cartitem.Qty,
                TotalPrice = product.Price * cartitem.Qty
            };
        }
    }
}
