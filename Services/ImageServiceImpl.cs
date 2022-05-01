using DigitalPhotoPrinting.Models;

namespace DigitalPhotoPrinting.Services
{
    public class ImageServiceImpl : ImageService
    {

        DatabaseContext db;

        public ImageServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public dynamic AllMaterial()
        {
            return db.Materials.Select(m => new
            {
                id = m.Id,
                name = m.Name,
                price = m.Price,
            }).ToList();
        }

        public dynamic AllSize()
        {
            return db.Sizes.Select(s => new
            {
                id = s.Id,
                name = s.Name,
                price = s.Price
            }).ToList();
        }

        public PrintOrder FindAll()
        {
            return new PrintOrder { AccountId = 1, ImageName = "aaa", MaterialName = "bbb", Quantity = 1, SizeName = "4x4" };
        }

        public bool Order(PrintOrder[] printOrder, int accId, double total)
        {
            var order = new Order();
            order.AccountId = accId;
            order.Date = DateTime.Now;
            order.Total = total;


            db.Orders.Add(order);
            db.SaveChanges();

            int orderId = db.Orders.OrderByDescending(o => o.Id).Take(1).FirstOrDefault().Id;

            foreach (var p in printOrder)
            {
                var orderDetails = new OrderDetail();
                orderDetails.OrderId = orderId;
                orderDetails.ImageId = (db.Images.FirstOrDefault(i => i.Name == p.ImageName)).Id;
                //orderDetails.ImageId = 1;
                orderDetails.Sizeid = (db.Sizes.FirstOrDefault(i => i.Name == p.SizeName)).Id;
                orderDetails.MaterialId = (db.Materials.FirstOrDefault(i => i.Name == p.MaterialName)).Id;
                orderDetails.Quantity = p.Quantity;
                db.OrderDetails.Add(orderDetails);
                db.SaveChanges();

            }
            return true;
        }


        public bool InsertImage(string filename, int accountId, string folderName)
        {
            var image = new Image();
            image.Name = filename;
            image.Date = DateTime.Now;
            image.AccountId = accountId;
            image.FolderName = folderName;
            db.Images.Add(image);
            return db.SaveChanges() > 0;
        }

   
    }
}
