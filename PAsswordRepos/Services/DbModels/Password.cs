using System;
using System.Collections.Generic;

namespace PAsswordRepos.Services.DbModels
{
    public partial class Password
    {
        public int Id { get; set; }
        public int TypePassword { get; set; }
        public string Name { get; set; } = null!;
        public string Password1 { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual TypePassword TypePasswordNavigation { get; set; } = null!;
    }
}
