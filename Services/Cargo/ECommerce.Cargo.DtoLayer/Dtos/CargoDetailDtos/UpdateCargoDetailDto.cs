﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string RecieverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCamponyId { get; set; }
        
    }
}
