using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum Kind
    {
        Other,
        Suede,
        Leather
    }
    public enum Sex
    {
        Unisex,
        Women,
        Men
    }
    public class Shoe
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Kind Kind { get; set; }
        public Sex Sex { get; set; }
        public int BrandId { get; set; }
        
        public string ListBoxShow
        {
            get
            {
                return Brand.Name + "" + Model;
            }
        }

        public Brand Brand { get; set; }
    }
}
