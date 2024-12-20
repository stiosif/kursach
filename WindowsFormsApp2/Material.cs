using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Material
    {
        public Material(int id, string name, int instock)
        {
            this.id = id;
            this.name = name;
            this.instock = instock;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int instock { get; set; }
    }
}
