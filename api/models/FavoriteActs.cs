﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api.Models
{
    public partial class FavoriteActs
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ScheduleItemId { get; set; }

        public virtual ScheduleItems ScheduleItem { get; set; }
    }
}
