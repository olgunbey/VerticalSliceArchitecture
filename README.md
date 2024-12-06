# Vertical Slice Arcitecture
Bu proje VSA yapısı kullanılarak geliştirilmektedir. Minimal Apileri daha esnek kullanabilmek için Carter Framework'u kullanıldı.
Repository yerine IApplicationDbContext yapısı kullanıldı.

- Doğrudan iş mantığına odaklanılır.
- Sık değiştirilen iş gereksinimleri.
- Az sayıda dosya ve sınıf.
- Daha hızlı geliştirme süreci
- Gevşek bağlantı
- Feature odaklı
- Her dilim kendi içerisinde bağımsız bir şekilde ele alınır. Buda bakım süreçlerini kolaylaştırır.
