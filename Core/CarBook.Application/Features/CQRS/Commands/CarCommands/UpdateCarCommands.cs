using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommands
    {
        public int CarID { get; set; }

        // 1. İlişkinin tutulacağı Yabancı Anahtar (FK) alanı
        public int BrandID { get; set; } // <-- int tipinde ekledik

        // 2. Navigasyon Özelliği (Modeli temsil eder)
       
        public string Model { get; set; }
        // ... diğer özellikler ...
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
