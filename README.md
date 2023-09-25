<!-- Proje Başlığı -->
<h1 align="center">Eczane Otomasyonu 🌡️💊</h1>

<!-- Proje Açıklaması -->
<p align="center">
  <img src="https://github.com/Mertalkann/C-form-Eczasist-automation/blob/main/image.gif" alt="Eczasist Ekran Görüntüsü">
</p>
<p align="center">
  Birinci sınıf bir eczane deneyimi için geliştirilen, modern bir otomasyon sistemi.
</p>

<!-- Gereksinimler -->
## 🚀 Gereksinimler

Projeyi çalıştırmadan önce aşağıdaki gereksinimlere ihtiyaç vardır:

- **MSSQL Veritabanı Sunucusu**
- **Web Sunucusu** (örneğin, Apache veya Nginx)
- **config.json** dosyasında gerekli bağlantı bilgileri

<!-- Kurulum Kılavuzu -->
## 🛠️ Kurulum

Projenin yerel bir geliştirme ortamında çalıştırılması için aşağıdaki adımları takip edebilirsiniz:

1. **Veritabanı Kurulumu**: MSSQL veritabanınızı oluşturun ve bağlantı bilgilerini **config.json** dosyasında güncelleyin.

2. **Veritabanı Tablolarının Oluşturulması**: Projeyi ilk çalıştırdığınızda, veritabanı tablolarını oluşturmak için bir veritabanı kurulum betiği kullanabilirsiniz. Betik projenin kök dizininde bulunmalıdır.

3. **Projeyi Çalıştırma**: Web sunucusunu başlatın ve projeyi tarayıcınızda açın.

<!-- Kullanım Kılavuzu -->
## 📋 Kullanım

Eczane otomasyon sistemi, kullanıcı dostu bir arayüzle aşağıdaki işlemleri gerçekleştirmenize olanak tanır:

- **İlaç Ekleme**: Yeni ilaçlar ekleyin ve stokları takip edin.
- **Müşteri Yönetimi**: Müşteri bilgilerini güncelleyin ve geçmiş satışları görüntüleyin.
- **Reçete Oluşturma**: Doktorlar için reçeteler oluşturun ve reçete detaylarını takip edin.
- **Doktor Yönetimi**: Doktor bilgilerini düzenleyin ve yeni doktorlar ekleyin.
- **Satış İşlemleri**: Müşterilere ilaç satışı yapın ve satış geçmişini görüntüleyin.

<!-- Veritabanı Tabloları ve İlişkileri -->
## 🗃️ Veritabanı Tabloları ve İlişkileri

<p align="center">
  <img src="https://github.com/Mertalkann/C-form-Eczasist-automation/blob/main/Eczasist/20%20703.048%20Mertcan%20Alkan.png" alt="Tablolar Arası İlişkiler">
</p>

Proje de  kullanılan MSSQL veritabanı, çeşitli tablolar arasındaki ilişkilerle tasarlanmıştır. İşte bu tabloların ve ilişkilerin ayrıntılı açıklamaları:

### İlaçlar (drugs)

Bu tablo, eczanenizdeki mevcut ilaçları saklar. Her ilaç için benzersiz bir kimlik (ID), ilaç adı, stok miktarı ve diğer ilaç özellikleri içerir.

### Müşteriler (customers)

Müşterilerin bilgilerini saklayan bu tablo, her müşteri için bir kimlik (ID), ad, soyad, iletişim bilgileri ve diğer müşteri bilgilerini içerir.

<!-- Diğer tablolar ve ilişkiler buraya eklenmelidir -->

### İlişkiler

Veritabanı, aşağıdaki ilişkileri içerir:

- İlaçlar (drugs) tablosu, reçete detayları (prescription_details) tablosuyla birincil anahtar ile ilişkilidir. Bu ilişki, bir reçetede hangi ilaçların verildiğini kaydetmek için kullanılır.

- Reçeteler (prescriptions) tablosu, doktorlar (doctors) ve müşteriler (customers) tablolarıyla ilişkilidir. Bir reçetenin hangi doktor tarafından yazıldığını ve hangi müşteriye verildiğini izlemek için kullanılır.

- Satışlar (sales) tablosu, müşteriler (customers) tablosuyla ilişkilidir. Bu ilişki, bir satışın hangi müşteriye yapıldığını belirtir.

Bu ilişkiler sayesinde projeniz, ilaçlar, reçeteler, müşteriler, doktorlar ve satışlar arasındaki bağlantıları doğru bir şekilde takip edebilir ve çeşitli işlemleri gerçekleştirebilir. Bu sayede eczane otomasyonu sistemi daha verimli ve doğru hale gelir.

<!-- Katkıda Bulunma -->
## 🤝 Katkıda Bulunma

Eğer projeye katkıda bulunmak isterseniz, lütfen bir çekme isteği (pull request) açın. Herhangi bir hata bildirimi veya öneri için GitHub'ta bir sorun (issue) oluşturabilirsiniz.

<!-- Lisans -->
## 📜 Lisans

Bu proje [Lisans Adı] altında lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasını inceleyebilirsiniz.
