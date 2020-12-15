using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFassets.Domains
{
    public class Category
    {
        public int Id { get; set;}
        public string CategoryName{ get; set;}

        public int AssetId { get; set; }

        public static implicit operator Category(string v)
        {
            throw new NotImplementedException();
        }
    }
}
