using FastFoodMenuAPI.Models;
namespace FastFoodMenuAPI.Services
{
    public class MenuService
    {
        public List<CategoryNode> GetMenu()
        {
            return new List<CategoryNode>
            {
                new CategoryNode
                {
                    Id = 1,
                    Name = "Burgerler",
                    Children = new List<ProductNode>
                    {
                        new ProductNode
                        {
                            Id = 101,
                            Name = "Inferno Burger",
                            Price = 189.90m,
                            Description = "Alevde pişirilmiş dana eti, erimiş peynirler, jalapeno ve özel soslar",
                            ImageUrl = "images/burgers/inferno.jpg"
                        },
                        new ProductNode
                        {
                            Id = 102,
                            Name = "Gurme Umami Burger",
                            Price = 199.90m,
                            Description = "Trüflü aioli, kızarmış mantar ve özel soslarla",
                            ImageUrl = "images/burgers/gurme.jpg"
                        },
                        new ProductNode
                        {
                            Id = 103,
                            Name = "Bedezin Burgeri",
                            Price = 999.99m,
                            Description = "Meşhur",
                            ImageUrl = "images/burgers/tavuk.jpg"
                        },
                        new ProductNode
                        {
                            Id = 104,
                            Name = "Double Cheeseburger",
                            Price = 179.90m,
                            Description = "İki kat dana eti, çift cheddar peyniri, özel sos",
                            ImageUrl = "images/burgers/klasik.jpg"
                        },
                        new ProductNode
                        {
                            Id = 105,
                            Name = "Mega Burger",
                            Price = 229.90m,
                            Description = "Üç kat dana eti, bacon, cheddar, özel sos",
                            ImageUrl = "images/burgers/klasik.jpg"
                        }
                    }
                },
                new CategoryNode
                {
                    Id = 2,
                    Name = "Yan Ürünler",
                    Children = new List<ProductNode>
                    {
                        new ProductNode
                        {
                            Id = 201,
                            Name = "Patates Kızartması",
                            Price = 49.90m,
                            Description = "Çıtır çıtır, baharatlı patates kızartması",
                            ImageUrl = "images/sides/patates.jpg"
                        },
                        new ProductNode
                        {
                            Id = 202,
                            Name = "Soğan Halkası",
                            Price = 59.90m,
                            Description = "Çıtır çıtır, baharatlı soğan halkası",
                            ImageUrl = "images/sides/sogan.jpg"
                        },
                        new ProductNode
                        {
                            Id = 203,
                            Name = "Nugget (6'lı)",
                            Price = 69.90m,
                            Description = "Çıtır tavuk nugget, özel sos ile",
                            ImageUrl = "images/sides/nugget.jpg"
                        },
                        new ProductNode
                        {
                            Id = 204,
                            Name = "Mozzarella Çubukları",
                            Price = 79.90m,
                            Description = "Çıtır kaplamalı, erimiş mozzarella",
                            ImageUrl = "images/sides/mozzarella.jpg"
                        }
                    }
                },
                new CategoryNode
                {
                    Id = 3,
                    Name = "İçecekler",
                    Children = new List<ProductNode>
                    {
                        new ProductNode
                        {
                            Id = 301,
                            Name = "Meyve Kokteyli",
                            Price = 59.90m,
                            Description = "Taze meyvelerle hazırlanmış özel kokteyl",
                            ImageUrl = "images/drinks/kokteyl.jpg"
                        },
                        new ProductNode
                        {
                            Id = 302,
                            Name = "Milkshake",
                            Price = 49.90m,
                            Description = "Çikolatalı/Vanilyalı/Çilekli",
                            ImageUrl = "images/drinks/milkshake.jpg"
                        },
                        new ProductNode
                        {
                            Id = 303,
                            Name = "Ev Yapımı Limonata",
                            Price = 39.90m,
                            Description = "Taze sıkılmış limon, nane yaprakları",
                            ImageUrl = "images/drinks/limonata.jpg"
                        },
                        new ProductNode
                        {
                            Id = 304,
                            Name = "Meyve Smoothie",
                            Price = 54.90m,
                            Description = "Karışık meyve, yoğurt ve bal",
                            ImageUrl = "images/drinks/smoothie.jpg"
                        }
                    }
                },
                new CategoryNode
                {
                    Id = 4,
                    Name = "Tatlılar",
                    Children = new List<ProductNode>
                    {
                        new ProductNode
                        {
                            Id = 401,
                            Name = "Çikolatalı Sufle",
                            Price = 69.90m,
                            Description = "Sıcak servis edilen, akışkan çikolatalı sufle",
                            ImageUrl = "images/desserts/sufle.jpg"
                        },
                        new ProductNode
                        {
                            Id = 402,
                            Name = "New York Cheesecake",
                            Price = 79.90m,
                            Description = "Krem peynirli, frambuaz soslu",
                            ImageUrl = "images/desserts/cheesecake.jpg"
                        },
                        new ProductNode
                        {
                            Id = 403,
                            Name = "Tiramisu",
                            Price = 74.90m,
                            Description = "İtalyan usulü, kahve ve mascarpone",
                            ImageUrl = "images/desserts/tiramisu.jpg"
                        },
                        new ProductNode
                        {
                            Id = 404,
                            Name = "Dondurma (3 Top)",
                            Price = 49.90m,
                            Description = "Çikolatalı/Vanilyalı/Çilekli",
                            ImageUrl = "images/desserts/dondurma.jpg"
                        }
                    }
                }
            };
        }
    }
}
