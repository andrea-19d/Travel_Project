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


namespace BusinessLogic.Core
{
    public class AdminApi
    {
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
                var users = dbContext.Users.Select(u => new UserMinimal
                {
                    Username = u.Username,
                    Email = u.Email,
                    Id = u.UserId,
                    LastLogin = u.LastLogin,
                    UserPhoto = u.UserPhoto,
                    Level = u.Level
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

                using (var db = new DestinationContext())
                {
                    db.Destination.Add(newDestination);
                    db.SaveChanges();
                }
                return new ActionStatus { Status = true, StatusMessage = "Destination added successfully" };
            }
            catch (DbUpdateException ex)
            {
                // Retrieve the inner exception for more details
                var innerException = ex.InnerException;
                // Log or handle the inner exception appropriately
                return new ActionStatus { Status = false, StatusMessage = "Database update error: " + innerException.Message };
            }
            catch (Exception ex)
            {
                return new ActionStatus { Status = false, StatusMessage = "An error occurred: " + ex.Message };
            }
        }

    }
}
