using DigitalPhotoPrinting.Models;

namespace DigitalPhotoPrinting.Services
{
    public interface ImageService
    {
        public PrintOrder FindAll();

        public dynamic AllMaterial();

        public dynamic AllSize();

        public bool Order(PrintOrder[] printOrder,int accId, double total);

        public bool InsertImage(string filename , int accountId, string folderName);
    }
}
