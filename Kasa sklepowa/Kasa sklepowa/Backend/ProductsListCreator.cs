using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kasa_sklepowa.Backend
{
    public static class ProductsListCreator
    {
            
        public static List<Product> GetProducts()
        {
            var path = Directory.GetCurrentDirectory() + "\\products.json";
            var data = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true  };
            return JsonSerializer.Deserialize<List<Product>>(data, options);
        }

    }
}
