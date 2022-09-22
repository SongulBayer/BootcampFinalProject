# 	:rocket: PayCore .Net/.Net Core Bootcamp Bitirme Projesi

## Bitirme projesi bir WepApi projesinden oluşmaktadır Generic Repository ve N-Tier Architecture Dwsign kullanılmıştır. Yapılan işlemler sırasıyla aşağıda açıklanmıştır.En son kısımda ise tüm görevler bir liste halinde bulunmaktadır.
 
### Yetkilendirme
### Üye olma ve authorize fonksiyonu eklendi. Üyelik kayır işlemleri için kullanıcı adı, e-posta ve bir parola gerekmektedir. Gerekli validasyonlar sağlanılıp üye olma işlemi gerçekleştiğinde kullanıcının mail adresine başarılı bir şekilde kayıt olduğunu ileten mail gönderildi.Bu işlem için MailKit aracından yararlanıldı. Bu işlem için appsettings.json dosyasına gerekli eklememler yapıldı.

```
    "EmailUsername": "E-posta adresiniz",
    "EmailPassword": "Çok güvenli parola",
    "EmailHost": "smtp.gmail.com"
```


