using DigitalPhotoPrinting.Models;

namespace DigitalPhotoPrinting.Services
{
    public interface AdminService
    {

        public dynamic FindAllOrder();

        public dynamic FindOrderDetails(int orderId);

        public bool UpdateMaterial(Material material);
    }
}
