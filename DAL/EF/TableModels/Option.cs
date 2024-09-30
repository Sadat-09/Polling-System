using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        public string OptionText { get; set; }
        public virtual Poll Poll { get; set; }
        
        [ForeignKey("Poll")]
        public int PollId { get; set; }
       

        

        public virtual ICollection<Vote> Votes { get; set; }

        public Option()
        {
            Votes = new List<Vote>();
        }
    }
}
