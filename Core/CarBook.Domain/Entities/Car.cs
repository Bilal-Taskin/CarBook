using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }

        // 1. İlişkinin tutulacağı Yabancı Anahtar (FK) alanı
        public int BrandID { get; set; } // <-- int tipinde ekledik

        // 2. Navigasyon Özelliği (Modeli temsil eder)
        public Brand Brand { get; set; } // <-- İsmini Brand olarak değiştirdik

        public string Model { get; set; }
        // ... diğer özellikler ...
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars{ get; set; }
        public List<RentACarProcess> RentACarProcesses{ get; set; }
        public List<Reservation> Reservations{ get; set; }
    }
}
