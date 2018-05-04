using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelLayer
{
    public class Hotel : BaseModel
    {
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual int StarRating { get; set; }
    }
}
