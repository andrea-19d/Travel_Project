using AutoMapper;
using BusinessLogic.DBModel.Seed;
using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Domain.Entities.User.Global;

namespace BusinessLogic.Core
{
    public class AdminApi
    {

        /* --- MANAGE USERS --- */
        public ActionStatus DeleteSelectedDestination(int destId)
        {
            try
            {
                using (var db = new DestinationContext())
                {
                    var destinationToDelete = db.Destination.FirstOrDefault(d => d.DestinationID == destId);
                    if (destinationToDelete == null)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "Destination not found" };
                    }
                    db.Destination.Remove(destinationToDelete);
                    db.SaveChanges();
                    return new ActionStatus { Status = true, StatusMessage = "Destination deleted successfully." };
                }
            }
            catch ( Exception ex) 
            {
                return new ActionStatus { Status = false, StatusMessage = ex.Message };
            }
        }

        public ActionStatus DeleteAUser(int userId)
        {
            try
            {
                using (var dbContext = new UserContext())
                {
                    var userToDelete = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
                    if (userToDelete == null)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "User not found." };
                    }

                    dbContext.Users.Remove(userToDelete);
                    dbContext.SaveChanges();

                    return new ActionStatus { Status = true, StatusMessage = "User deleted successfully." };
                }
            }
            catch (Exception ex)
            {
                return new ActionStatus { Status = false, StatusMessage = ex.Message };
            }
        }

        public LevelAcces ChangeAUserRole(int userId, string newUserRole)
        {
            try
            {
                using (var dbContext = new UserContext())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
                    if (user != null)
                    {
                        if (Enum.TryParse(newUserRole, out LevelAcces newRole))
                        {
                            user.Level = newRole;
                            dbContext.SaveChanges();
                            return newRole;
                        }
                        else
                        {
                            // Returnăm nivelul de acces curent dacă nu se poate face conversia
                            return user.Level;
                        }
                    }
                    else
                    {
                        // Returnăm nivelul de acces curent dacă utilizatorul nu este găsit
                        return LevelAcces.User;
                    }
                }
            }
            catch (Exception ex)
            {
                // În caz de eroare, returnăm nivelul de acces curent și afișăm un mesaj de eroare
                Console.WriteLine($"Error: {ex.Message}");
                return LevelAcces.User;
            }
        }



        public List<UserMinimal> GetAllUsers()
        {
            using (var dbContext = new UserContext())
            {
                var userMinimals = dbContext.Users
                    .Select(user => new UserMinimal
                    {
                        Id = user.UserId,
                        Username = user.Username,
                        Email = user.Email,
                        LastLogin = user.LastLogin,
                        LasIp = user.UserIP,
                        Level = user.Level,
                        UserPhoto = user.UserPhoto
                    })
                    .ToList();

                return userMinimals;
            }
        }


        /* --- GET THE STATISTICS --- */
        public int ManageNrOfUsers()
        {
            using (var dbContext = new UserContext())
            {
                var usersCount = dbContext.Users.Count(u => u.Level == LevelAcces.User);

                return usersCount;
            }

        }

        public int ManageTodaysUsers()
        {
            DateTime currentDate = DateTime.Today;
            using (var dbContext = new UserContext())
            {
                var usersCount = dbContext.Users
                    .Where(s => DbFunctions.TruncateTime(s.RegisterDate) == currentDate.Date && s.Level == LevelAcces.User)
                    .Count();

                return usersCount;
            }
        }

        private int GetYesterdayUsers()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            using (var dbContext = new UserContext())
            {
                var usersCount = dbContext.Users
                    .Where(s => DbFunctions.TruncateTime(s.RegisterDate) == yesterday.Date && s.Level == LevelAcces.User)
                    .Count();

                return usersCount;
            }

        }

        public int GetUsersPercentageChange()
        {
            var todayUsers = ManageTodaysUsers();
            var yesterdayUsers = GetYesterdayUsers();

            var todayPercentage = (todayUsers * 100)/yesterdayUsers;
            var performanceIndicator = (todayPercentage < 100) ? todayPercentage - 100 : todayPercentage - 100;

            return performanceIndicator;
        }


        public int GetTotalSalesAdmin()
        {
            using (var dbContext = new BookingContext())
            {
                
                var todaysSales = dbContext.Bookings.Sum(s => (decimal?)s.TotalPrice); 
                int todaysSalesInt = todaysSales.HasValue ? (int)todaysSales.Value : 0;

                return todaysSalesInt;
            }
        }


        public int GetTodaysSalesAdmin()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            using (var dbContext = new BookingContext())
            {
                var todaysSales = dbContext.Bookings
                                            .Where(s => s.CreationDate >= today && s.CreationDate < tomorrow)
                                            .Sum(s => (decimal?)s.TotalPrice);

                int todaysSalesInt = todaysSales.HasValue ? (int)todaysSales.Value : 0;

                return todaysSalesInt;
            }
        }

        private int GetYersterdaySales()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime today = DateTime.Today;
            using (var dbContext = new BookingContext())
            {
                var yesterdaysSales = dbContext.Bookings
                                                .Where(s => s.CreationDate >= yesterday && s.CreationDate < today)
                                                .Sum(s => (decimal?)s.TotalPrice);

                int yesterdaysSalesInt = yesterdaysSales.HasValue ? (int)yesterdaysSales.Value : 0;

                return yesterdaysSalesInt;
            }
        }

        public decimal GetSalesPercentageChange()
        {
            var todaySales = GetTodaysSalesAdmin();
            var yesterdaySales = GetYersterdaySales();

            if (yesterdaySales == 0)
            {
                return todaySales == 0 ? 0 : 100; 
            }

            var todayPercentage = (todaySales * 100) / yesterdaySales;
            var performanceIndicator = (todayPercentage < 100) ? todayPercentage - 100 : todayPercentage - 100;

            return performanceIndicator;
        }



        /* --- MANAGE DESTINATIONS --- */
        public ActionStatus AddNewDestination(ADestinations destination, HttpPostedFileBase file)
        {
            try
            {
                using (var db = new DestinationContext())
                {
                    bool destinationExists = db.Destination.Any(u => u.DestinationName == destination.DestinationName);
                    if (destinationExists)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "Destination already exists" };
                    }
                }

                if (file != null && file.ContentLength > 0)
                {
                    // Handle file upload
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Destination"), filename);
                    file.SaveAs(filepath);

                    // Convert the uploaded image to byte array
                    byte[] imageBytes = File.ReadAllBytes(filepath);

                    destination.Img = imageBytes;
                }
                else
                {
                    destination.Img = null;
                }

                var newDestination = Mapper.Map<DestDbTable>(destination);
                newDestination.Status = DestinationStatus.Public;

                using (var db = new DestinationContext())
                {
                    db.Destination.Add(newDestination);
                    db.SaveChanges();
                }
                return new ActionStatus { Status = true, StatusMessage = "Destination added successfully" };
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                return new ActionStatus { Status = false, StatusMessage = "Database update error: " + innerException.Message };
            }
            catch (Exception ex)
            {
                return new ActionStatus { Status = false, StatusMessage = "An error occurred: " + ex.Message };
            }
        }

    }
}
