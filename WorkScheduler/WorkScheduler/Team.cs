using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduler
{
    public class Team
    {
        public string name;
        public List<string> dates;
        public int shift;

        public Team(string text, List<string> dates,int shift)
        {
            this.name = text;
            this.dates = dates;
            this.shift = shift;
        }
    }
}
