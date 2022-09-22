# 	:rocket: PayCore .Net/.Net Core Bootcamp Bitirme Projesi

## Bitirme projesi bir WepApi projesinden oluşmaktadır Generic Repository ve N-Tier Architecture Dwsign kullanılmıştır. Yapılan işlemler sırasıyla aşağıda açıklanmıştır.En son kısımda ise tüm görevler bir liste halinde bulunmaktadır.
 
### Yetkilendirme
### Üye olma ve authorize fonksiyonu eklendi. Üyelik olma işlemleri için kullanıcı adı, e-posta ve bir parola gerekmektedir.Kullanıcının şifresi şifrelenmiş bir formatta veri tabanına kaydedildi. Gerekli validasyonlar sağlanılıp üye olma işlemi gerçekleştiğinde kullanıcının mail adresine başarılı bir şekilde kayıt olduğunu ileten mail gönderildi.Bu işlem için MailKit aracından yararlanıldı. Bu işlem için appsettings.json dosyasına gerekli eklememler yapıldı.

```
    "EmailUsername": "E-posta adresiniz",
    "EmailPassword": "Çok güvenli parola",
    "EmailHost": "smtp.gmail.com"
```
### Kullanıcının sisteme giriş yaptığı bilgiler veri tabanındaki bilgiler ile karşılaştırıldı, eşleşme olması durumunda kullanıcıya özel token üretildi bu sayede sisteme erişim sağlayabilecek duruma getirildi.

### Ürün Ekleme Detayları
### Ürün eklenirken istenilen bilgiler şunlardır: ürün adı, açıklama, kategori, renk, marka, kullanım durumu, fiyat ve teklif opsiyonu.

### Kullanılar Teknolojiler
* Automapper
* Nhibernate
* JWT Bearer 
* PostgreSql
* SOLID Principles
* SMTP EMail Services

#### Right: Programı ayağa kaldırmak için appsetting.json dosyasındaki connection string kodunu kendinize göre düzenlemeniz yeterli.
```
 "ConnectionStrings": {
    "PostgreSqlConnection": "User ID=postgres;Password=PgAdmin şifreniz;Server=localhost;Port=port numaranız;Database=veri tabanı adı;Integrated Security=true;Pooling=true;"
  }
  
```
### Ekran Görüntüleri

![Ekran Görüntüsü (619)](https://user-images.githubusercontent.com/63016233/191680189-c0defeda-e576-419e-865f-41f2954b673f.png)

![Ekran Görüntüsü (620)](https://user-images.githubusercontent.com/63016233/191680259-726deed0-251b-42b6-b878-ff9f6bbba956.png)

![Ekran Görüntüsü (621)](https://user-images.githubusercontent.com/63016233/191680314-659620d5-13b9-4376-a40b-dd9fda26e684.png)

![Ekran Görüntüsü (622)](https://user-images.githubusercontent.com/63016233/191680393-448a4c67-dc91-4099-a241-18497ec133d0.png)
