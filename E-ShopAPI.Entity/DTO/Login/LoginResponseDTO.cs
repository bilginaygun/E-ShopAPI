using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.DTO.Login
{
    public class LoginResponseDTO
    {
        public string AdSoyad { get; set; }
        public int CustomerID { get; set; }
        public string Token { get; set; }

        public string EPosta { get; set; }

        public string Adres { get; set; }
    }
}
