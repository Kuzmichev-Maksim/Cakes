using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Cake
    {
        internal class PartCake
        {
            public string Name;
            public List<PodpunktOfPart> Podpunkts;
        }
        internal class PodpunktOfPart
        {
            public string Name;
            public int Price;

            public PodpunktOfPart(string name, int price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}
