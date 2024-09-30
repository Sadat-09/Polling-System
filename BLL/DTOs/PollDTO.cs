using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PollDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public DateTime EndDateTime { get; set; }

        
        public List<OptionDTO> Options { get; set; }

        public PollDTO()
        {
            Options = new List<OptionDTO>();
        }
    }
}
