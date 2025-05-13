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

                        },
                        new ProductNode
                        {
                            Id = 102,
                            Name = "Gurme Umami",
                            Price = 199.90m,
                            Description = "Trüflü aioli, kızarmış mantar ve özel soslarla",

                        },
                        new ProductNode
                        {
                            Id = 103,
                            Name = "Double Cheeseburger",
                            Price = 179.90m,
                            Description = "İki kat dana eti, çift cheddar peyniri, özel sos",

                        },
                        new ProductNode
                        {
                            Id = 104,
                            Name = "Mega Burger",
                            Price = 229.90m,
                            Description = "Üç kat dana eti, bacon, cheddar, özel sos",

                        },
                        new ProductNode
                        {
                            Id = 105,
                            Name = "Klasik Tavuk Burger",
                            Price = 169.90m,
                            Description = "Çıtır tavuk fileto, marul, mayonez",

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

                        },
                        new ProductNode
                        {
                            Id = 202,
                            Name = "Soğan Halkası",
                            Price = 59.90m,
                            Description = "Çıtır çıtır, baharatlı soğan halkası",

                        },
                        new ProductNode
                        {
                            Id = 203,
                            Name = "Nugget (6'lı)",
                            Price = 69.90m,
                            Description = "Çıtır tavuk nugget, özel sos ile",

                        },
                        new ProductNode
                        {
                            Id = 204,
                            Name = "Mozzarella Çubukları",
                            Price = 79.90m,
                            Description = "Çıtır kaplamalı, erimiş mozzarella",

                        },
                        new ProductNode
                        {
                            Id = 205,
                            Name = "Sweet Potato Fries",
                            Price = 54.90m,
                            Description = "Tatlı patates kızartması, özel sos ile",

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
                            Name = "Kola",
                            Price = 29.90m,
                            Description = "Soğuk içecek, 330ml",

                        },
                        new ProductNode
                        {
                            Id = 302,
                            Name = "Ayran",
                            Price = 24.90m,
                            Description = "Ev yapımı ayran,330ml",

                        },
                        new ProductNode
                        {
                            Id = 303,
                            Name = "Meyve Kokteyli",
                            Price = 59.90m,
                            Description = "Taze meyvelerle hazırlanmış özel kokteyl",

                        },
                        new ProductNode
                        {
                            Id = 304,
                            Name = "Milkshake",
                            Price = 49.90m,
                            Description = " Çikolatalı/Vanilyalı/Çilekli",

                        },
                        new ProductNode
                        {
                            Id = 305,
                            Name = "Ev Yapımı Limonata",
                            Price = 39.90m,
                            Description = "Taze sıkılmış limon, nane yaprakları",

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

                        },
                        new ProductNode
                        {
                            Id = 402,
                            Name = "Dondurma",
                            Price = 39.90m,
                            Description = "Çikolatalı/Vanilyalı/Çilekli",

                        },
                        new ProductNode
                        {
                            Id = 403,
                            Name = "New York Cheesecake",
                            Price = 79.90m,
                            Description = "Krem peynirli, frambuaz soslu",

                        },
                        new ProductNode
                        {
                            Id = 404,
                            Name = "Tiramisu",
                            Price = 74.90m,
                            Description = "İtalyan usulü, kahve ve mascarpone",

                        },
                        new ProductNode
                        {
                            Id = 405,
                            Name = "Browni",
                            Price = 64.90m,
                            Description = "Çikolatalı, fındıklı browni",


                        }
                    }
                }
            };
        }
    }
}
