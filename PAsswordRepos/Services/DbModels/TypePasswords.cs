using System;
using System.Collections.Generic;
using PAsswordRepos.Services.DbModels;

namespace PAsswordRepos
{
    public partial class TypePassword
    {
        public TypePassword()
        {
            Passwords = new HashSet<Password>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Password> Passwords { get; set; }
    }
}
