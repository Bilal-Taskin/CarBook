🚗 CarBook - Enterprise Car Rental System
CarBook, modern yazılım mimarileri ve tasarım desenleri kullanılarak geliştirilmiş, ölçeklenebilir ve yüksek performanslı bir araç kiralama yönetim sistemidir. Bu proje, ASP.NET Core 8.0 ekosisteminde kurumsal düzeyde bir uygulamanın uçtan uca nasıl inşa edildiğini göstermektedir.

🛠 Kullanılan Teknolojiler & Araçlar
Framework: ASP.NET Core 8.0 (Web API & MVC)

- Architecture: N-Tier (Clean) Architecture
- Data Access: Entity Framework Core
- Database: MS SQL Server
- Real-Time: SignalR (Anlık veri takibi ve bildirimler)

Design Patterns:
- CQRS (Command Query Responsibility Segregation)
- MediatR (Mediator Pattern)
- Repository Pattern

Security: JWT (JSON Web Token) Authentication & Authorization
Tools: Automapper, Fluent Validation, Swagger, HttpClient

🚀 Öne Çıkan Özellikler
Katmanlı Mimari: Proje; Entity, DataAccess, Business ve WebUI olmak üzere mantıksal katmanlara ayrılarak sürdürülebilirlik sağlandı.
CQRS & MediatR: Okuma ve yazma operasyonları birbirinden ayrılarak karmaşıklık minimize edildi ve kodun test edilebilirliği artırıldı.
SignalR Entegrasyonu: Admin panelinde ve ana sayfada verilerin sayfa yenilenmeden anlık olarak güncellenmesi sağlandı.
API Consumption: Backend tarafında hazırlanan RESTful API'lar, Frontend tarafında IHttpClientFactory kullanılarak profesyonelce tüketildi.
Dinamik UI: ViewComponents ve Partial Views yapıları ile modüler bir arayüz geliştirildi.


📁 Proje Yapısı:

CarBook

├── CarBook.Application      # MediatR Handlers, CQRS, DTOs, Interfaces

├── CarBook.Domain           # Entities

├── CarBook.Persistence      # DbContext, Repository Implementations, Migrations

├── CarBook.WebApi           # API Controllers, JWT Configuration

└── CarBook.WebUI            # Frontend (MVC), API Consumption, SignalR Hubs

Adım Adım Kurulum:

Veritabanı: appsettings.json içindeki ConnectionStrings kısmını kendi SQL Server adresinize göre güncelleyin.
Migration: Update-Database komutu ile tabloları oluşturun.
Çalıştır: Önce WebApi projesini, ardından WebUI projesini ayağa kaldırın.

👨‍🏫 Teşekkür
Bu projenin geliştirilme sürecinde sunduğu eşsiz müfredat ve katkıları için @Murat Yücedağ hocama teşekkürlerimi sunarım.
