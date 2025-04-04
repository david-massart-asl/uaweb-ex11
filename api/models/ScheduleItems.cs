using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api.Models
{
    public partial class ScheduleItems
    {
        public ScheduleItems()
        {
            FavoriteActs = new HashSet<FavoriteActs>();
        }

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int? ArtistId { get; set; }
        public int? StageId { get; set; }

        public virtual Artists Artist { get; set; }
        public virtual Stages Stage { get; set; }
        public virtual ICollection<FavoriteActs> FavoriteActs { get; set; }
    }
}
