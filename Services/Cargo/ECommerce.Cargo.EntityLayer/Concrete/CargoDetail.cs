using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string RecieverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCamponyId { get; set; }
        public CargoCompany CargoCampony { get; set; }
    }
}
