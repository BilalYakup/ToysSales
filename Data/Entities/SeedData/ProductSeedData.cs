using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                new Product { Id = 1, Name = "Fabulous Lightning Mcqueen", Description = "Cars 3 filminin en sevdiğiniz karakterleri şimdi tekli paketlerde sizlerle!\r\n\r\n \r\n\r\n1:55 ölçeğindeki heyecan verici film detayları olan bu koleksiyona çocuklar bayılacak! Şimşek McQueen, Cruz Ramirez ve Jackson Storm ve daha birçok karakterin bulunduğu bu büyük koleksiyon ile çocuklar araba koleksiyonuna başlayabilir ya da araba koleksiyonunu genişletebilirler.\r\n\r\n \r\n\r\nKarakterlerin hepsini toplayın ve Cars koleksiyonunuzu tamamlayın!\r\n\r\n \r\n\r\nPaket içerisinde; 1 adet Cars araç yer almaktadır.\r\n\r\n \r\n\r\nPaket ölçüsü: 14 x 4,5 x 17 cm", UnitPrice = 179, UnitStock = 15, Image = "Arabalar3TekliKarakter.jpg", CategoryId = 1 },

                new Product { Id = 2, Name = "LEGO Minecraft Creeper Pususu 21177", Description = "Minecraft oyuncuları için küçük bir sette büyük eğlence!\r\n\r\n \r\n\r\nBu kompakt, klasik Minecraft macerasında çocukları meşgul edecek çok şey var. Oyunun kahraman karakterlerinden biri olan Steve’e bir yavru domuz, bir civciv ve bir Patlayan Creeper katılıyor. Çocuklar önce çalışma masasında demir cevheriyle yaratıcılıklarını gösterir. Daha sonra hayvanlarla ilgilenir, ektikleri şeker kamışına bakar ve sahneyi gelinciklerle süslerler. Daha sonra korkunç Patlayan Creeper ile savaşmak için kılıcı kullanırlar. Çocukların özel patlayıcı bloğu itmesiyle savaş zirveye ulaşır ve Patlayıcı Creeper havaya uçar. O günün aksiyonu bittiğinde bu eğlenceli set, çocuk odasında sergilendiğinde harika görünür.", UnitPrice = 199, UnitStock = 32, Image = "MinecraftCreeperjpg.jpg", CategoryId = 2 },

                new Product { Id = 3, Name = "LEGO Star Wars Luke Skywalker'ın X-Wing Fighter'ı 75301", Description = "Luke Skywalker’ın simgeleşmiş X-wing Fighter’ı ile heyecan verici bir hendek akınına hazırlan!\r\n\r\n \r\n\r\nSadık droid R2-D2’nin gemide olduğundan emin ol, sonra kokpite atla. Motorları çalıştır ve uzaya fırla. Kanatları saldırı moduna geçir ve yaylı atıcıları İmparatorluk starship'lerine ateşle! Savaşı kazandıktan sonra Asilerin üssüne dönerek kutlama yap!\r\n\r\n \r\n\r\nÇocuklar, klasik Star Wars üçlemesinden Luke Skywalker’ın X-wing Fighter'ının bu havalı LEGO versiyonuyla kendi epik hikayelerinin kahramanı olabilir. Arkasında R2-D2 için yeri olan açılan bir LEGO mini figür kokpiti, bir düğmeye basarak saldırı pozisyonuna geçen kanatlar, kapanan iniş takımı ve 2 yaylı atıcı gibi hayranlarının çok beğeneceği orijinal detaylarla doludur. Oynayın ve Sergileyin Çocuklara yönelik bu muhteşem yapım oyuncağında Luke Skywalker, Prenses Leia ve General Dodonna LEGO mini figürleri, Luke'un ışın kılıcı dahil silahlar, ayrıca bir R2-D2 LEGO droid figürü bulunur. Çocuklar için en iyi parçalı modeller LEGO Group, 1999'dan beri Star Wars evreninden simgeleşmiş starship'leri, araçları, yerleri ve karakterleri canlandırıyor. LEGO Star Wars, şu anda yaratıcı çocuklar ve yetişkinler için eğlenceli hediye fikirleriyle LEGO'nun en başarılı temasıdır.", UnitPrice = 1199, UnitStock = 12, Image = "StarWarsSkywalkerin.jpg", CategoryId = 3 }
                );
        }
    }
}
