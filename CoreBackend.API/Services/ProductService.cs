using CoreBackend.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBackend.API.Services
{
    public class ProductService
    {
        public static ProductService Current { get; } = new ProductService();
        public List<Product> Products { get; }
        private ProductService()
        {
            Products = new List<Product>
            {
                //new Product{
                //    Id=1,
                //    Name="巧克力",
                //    Price =8
                //},
                //new Product{
                //    Id=2,
                //    Name ="方便面",
                //    Price =2.5f
                //},
                //new Product {
                //    Id=3,
                //    Name="腊肠",
                //    Price=5.8f
                //}


                new Product{
                    Id=1,
                    Name="巧克力",
                    Price =8,
                    Description="这是一个巧克力",
                    Materials=new List<Material>
                    {
                        new Material
                        {
                            Id=1,
                            Name="咖啡豆"
                        },
                        new Material
                        {
                            Id=2,
                            Name="糖"
                        }
                    }
                },
                new Product{
                    Id=2,
                    Name ="方便面",
                    Price =2.5f,
                    Description="这是方便面",
                    Materials =new  List<Material>{
                        new Material{
                            Id=1,
                            Name="淀粉"
                        },
                        new Material{
                            Id=2,
                            Name="植物油"
                        }
                    }

                },
                new Product {
                    Id=3,
                    Name="腊肠",
                    Price=5.8f,
                    Description="这是腊肠",
                    Materials=new List<Material>{
                        new Material{
                            Id=1,
                            Name="肉"
                        },
                        new Material{
                            Id=2,
                            Name="肠"
                        }
                    }
                }
            };
        }
    }
}
