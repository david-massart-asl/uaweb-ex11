using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api.Models
{
    public partial class Artists
    {
        public Artists()
        {
            ScheduleItems = new HashSet<ScheduleItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string WebSite { get; set; }

        public virtual ICollection<ScheduleItems> ScheduleItems { get; set; }
    }
}
