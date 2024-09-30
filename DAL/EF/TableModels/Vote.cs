using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Poll Poll { get; set; }
      
        [ForeignKey("Poll")]
        public int PollId { get; set; }
       
        public virtual Option Option { get; set; }
        
        [ForeignKey("Option")]
        public int OptionId { get; set; }
       

        
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
       
    }
}
