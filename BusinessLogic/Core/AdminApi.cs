using AutoMapper;
using BusinessLogic.DBModel.Seed;
using Domain.Entities.Enums;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public class AdminApi
    {
        public List<UserMinimal> GetAllUsers()
        {
            using (var dbContext = new UserContext())
            {
                var users = dbContext.Users.Select(u => new UserMinimal
                {
                    Username = u.Username,
                    Email = u.Email,
                    Id = u.UserId,
                    LastLogin = u.LastLogin,
                    Level = u.Level,
                }).ToList();

                return users;
            }
        }

        public int ManageNrOfUsers()
        {
            using (var dbContext = new UserContext())
            {
                var usersCount = dbContext.Users.Count(u => u.Level == LevelAcces.User);

                return usersCount;
            }

        }

        /* RETURNS ERRORS  TO DO  */
        public int ManageNewUsersCount()
        {
           /* UDbTable data;
            DateTime currentDate = DateTime.Now;
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1); // Start of the current month
            DateTime endDate = startDate.AddMonths(1).AddDays(-1); // End of the current month
*/
            using (var dbContext = new UserContext())
            {
                /*var user =  dbContext.Users.FirstOrDefaultAsync(u => u.Level == LevelAcces.User);
                Mapper.Map(user, data);
                if (user != null)
                {
                    var newClientsCount =  dbContext.Users
                        .Count(c => c.RegisterDate >= startDate && c.RegisterDate <= endDate);

                    return newClientsCount;
                }*/

                var usersCount = dbContext.Users.Count(u => u.Level == LevelAcces.User);
                return usersCount;
            }
            
        }




    }
}
