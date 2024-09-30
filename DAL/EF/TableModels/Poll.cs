using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Poll
    {

        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        public DateTime EndDateTime { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public Poll()
        {
            Options = new List<Option>();
        }
    }
}
