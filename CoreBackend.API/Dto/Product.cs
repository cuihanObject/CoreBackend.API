using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBackend.API.Dto
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public float Price { get; set; }
        //public List<T> Materials { get; internal set; }

        public string Description { get; set; }

        public ICollection<Material> Materials { get; set; }
    }

    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
