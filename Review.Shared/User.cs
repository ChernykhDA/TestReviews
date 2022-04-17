﻿namespace Review.Shared
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; } 

        public Role? Role { get; set; }

        public virtual ICollection<ReviewModel> ReviewModels { get; set; }

        public virtual ICollection<UToken> UTokens { get; set; }
    }
}