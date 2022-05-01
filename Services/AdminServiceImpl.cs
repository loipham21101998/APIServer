using DigitalPhotoPrinting.Models;

namespace DigitalPhotoPrinting.Services
{
    public class AdminServiceImpl : AdminService
    {
        DatabaseContext db;

        public AdminServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }


        public dynamic FindAllOrder()
        {
            return db.Orders.Select(o => new {
                id = o.Id,
                account = o.Account.UserName,
                date = o.Date,
                total = o.Total
            }).ToList();
        }

        public dynamic FindOrderDetails(int orderId)
        {
            return db.OrderDetails.Where(o=> o.OrderId == orderId).Select( o=> new
            {
                image = "http://localhost:5242/Uploads/"+o.Image.FolderName+"/"+o.Image.Name,
                sizename = o.Size.Name,
                materialname = o.Material.Name,
                quantity = o.Quantity
            }).ToList();
        }

        public bool UpdateMaterial(Material material)
        {
            var m = db.Materials.FirstOrDefault(m => m.Id == material.Id);
            m.Name = material.Name;
            m.Price = material.Price;
            db.Entry(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
