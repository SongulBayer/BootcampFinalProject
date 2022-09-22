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
