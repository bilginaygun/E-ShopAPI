using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.DTO.Login
{
    public class LoginRequestDTO
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
