using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudA.Data.Data
{
    public class Images
    {
        [Key]
        public int IdImages { get; set; }
        public string PathUrl { get; set; }

        public int IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}
