using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VoteDTO
    {
        public int Id { get; set; }

       
        public int PollId { get; set; }

        public int OptionId { get; set; }

       
        public int? UserId { get; set; }
    }
}
