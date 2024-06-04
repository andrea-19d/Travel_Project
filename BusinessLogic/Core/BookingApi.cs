using AutoMapper;
using BusinessLogic.DBModel.Seed;
using Domain.Entities;
using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.Core
{
    public class BookingApi
    {
        public async Task<List<ADestinations>> GetAllDestinations()
        {
            using (var dbContext = new DestinationContext())
            {
                var dest = await dbContext.Destination.ToListAsync();
                var destination = Mapper.Map<List<ADestinations>>(dest);

                return destination;
            }
        }

        public ADestinations GetDestinationDetails(int id)
        {
            using (var dbContext = new DestinationContext())
            {
                var dest = dbContext.Destination.FirstOrDefault(d => d.DestinationID == id);
                var destiantion = Mapper.Map<ADestinations>(dest);

                return destiantion;
            }
        }

        public int GetDestinationCount()
        {
            using (var dbContext = new DestinationContext())
            {
                var usersCount = dbContext.Destination.Count();

                return usersCount;
            }
        }

        public ActionStatus UpdateDestinationPackages(ADestinations dest, HttpPostedFileBase file)
        {
            try
            {
                using(var dbContext = new DestinationContext())
                {
                    var destination = dbContext.Destination.FirstOrDefault(d => d.DestinationID == dest.DestinationID);
                    if (file != null && file.ContentLength > 0)
                    {
                        // Handle file upload
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Destination"), filename);
                        file.SaveAs(filepath);

                        // Convert the uploaded image to byte array
                        byte[] imageBytes = File.ReadAllBytes(filepath);

                        dest.Img = imageBytes;
                    }
                    else
                    {
                        dest.Img = destination.Img;
                    }

                    Mapper.Map(dest, destination);

                    var entry = dbContext.Entry(destination);
                    if (entry.State == EntityState.Unchanged)
                    {
                        return new ActionStatus { Status = true, StatusMessage = "No Change" };
                    }

                    entry.State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return new ActionStatus { Status = true, StatusMessage = "Destination Updated" };

                }
            }
            catch (Exception ex) 
            {
                return new ActionStatus { Status = false, StatusMessage = ex.Message };
            }
        }

        public ActionStatus CreateTheBooking(UBooking model)
        {
            BookingDB booking;

            using (var context = new BookingContext()) {

    /*            var existingBooking = context.Bookings.FirstOrDefault(b =>
                       b.DestinationID == model.DestinationID &&
                       b.UserId == model.UserId &&
                       b.StartDate == model.StartDate &&
                       b.EndDate == model.EndDate &&
                       b.TotalPeople == model.TotalPeople);
                if (existingBooking != null)
                {
                    return new ActionStatus { Status = false, StatusMessage = "A similar booking already exists." };
                }*/

                booking = Mapper.Map<BookingDB>(model);
                booking.Status = "PENDING";

                context.Entry(booking);
                context.SaveChanges();

                return new ActionStatus { Status = true, StatusMessage = "Destination saved succesfully" };
            }
        }
    }
}
