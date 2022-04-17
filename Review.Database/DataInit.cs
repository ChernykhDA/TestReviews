using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Database
{
    public class DataInit
    {
        public class UserDataInit : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasData(
                    new User[]
                    {
                        new User{ Id = 1, Name = "Иван", Login = "User1", Password = "ed9929ed5586ec34074ab5230da09e59a58de6d3771eea5d623fa37cf6462179", RoleId = 1},

                        new User{ Id = 2, Name = "Петр", Login = "User2", Password = "ed9929ed5586ec34074ab5230da09e59a58de6d3771eea5d623fa37cf6462179", RoleId = 1},

                        new User{ Id = 3, Name = "Петр", Login = "Admin", Password = "ed9929ed5586ec34074ab5230da09e59a58de6d3771eea5d623fa37cf6462179", RoleId = 2}
                    });
            }
        }

        public class ReviewDataInit : IEntityTypeConfiguration<ReviewModel>
        {
            public void Configure(EntityTypeBuilder<ReviewModel> builder)
            {
                builder.HasData(
                    new ReviewModel[]
                    {
                        new ReviewModel{ Id = 2, Name = "Иван Иванов", OrgName = "KFC", 
                            Like = "все", CreateTime = new DateTime(2022, 1, 12, 11, 11, 11), Rating = 5, UserId = 1},
                        new ReviewModel{ Id = 1, Name = "Петр Иванов", OrgName = "KFC", OrgAddress = "Ленина 4",
                            Like = "все", NotLike = "ничего", Comment = "ewewe", CreateTime = new DateTime(2022, 1, 14, 11, 11, 11), Rating = 4, UserId = 1},
                        new ReviewModel{ Id = 3, Name = "Иван Иванов", OrgName = "Макдональдс", OrgAddress = "Ленина 4",
                            Like = "все", NotLike = "ничего", Comment = "ewewe", CreateTime = new DateTime(2022, 1, 15, 11, 11, 11), Rating = 5, UserId = 1},
                        new ReviewModel{ Id = 4, Name = "Петр Иванов", OrgName = "ДНС", OrgAddress = "Ленина 3",
                            Like = "все", NotLike = "ничего", Comment = "ewewe", CreateTime = new DateTime(2022, 1, 16, 11, 11, 11), Rating = 4, UserId = 1},
                        new ReviewModel{ Id = 5, Name = "Иван Иванов", OrgName = "Мвидео", OrgAddress = "Ленина 2",
                            Like = "все", NotLike = "ничего", Comment = "ewewe", CreateTime = new DateTime(2022, 1, 17, 11, 11, 11), Rating = 5, UserId = 1},
                        new ReviewModel{ Id = 6, Name = "Анна Иванова", OrgName = "Пятерочка", OrgAddress = "Ленина 1",
                            Like = "ничего", NotLike = "все", Comment = "Ну и **лупа.", CreateTime = new DateTime(2022, 4, 17, 11, 11, 11), Rating = 1}
                    });
            }
        }

        public class RoleDataInit : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasData(
                    new Role[]
                    {
                        new Role{ Id = 1, Description = "User" },
                        new Role{ Id = 2, Description = "Admin" }
                    });
            }
        }
    }
}
