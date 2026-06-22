# 🏢 Kurumsal Yönetim ve Teknik Servis API

Kurum içi operasyonların ve müşteri teknik destek süreçlerinin tek bir merkezden, rol bazlı bir mimariyle yönetilmesini sağlayan kapsamlı bir ASP.NET Core Web API projesidir. Sistem; personel, demirbaş, müşteri ve servis süreçleri için tam kapsamlı CRUD operasyonları sunar.

## 🎯 Projenin Amacı
Şirket içi donanım (demirbaş) atamalarını dijitalleştirmek ve müşterilerden gelen teknik servis taleplerini kayıt altına alarak uçtan uca şeffaf bir takip sistemi oluşturmak.

## 🛠️ Kullanılan Teknolojiler
*   **Backend:** ASP.NET Core Web API (C#)
*   **ORM:** Entity Framework Core (Code-First)
*   **Güvenlik:** JWT (JSON Web Token) tabanlı kimlik doğrulama
*   **Mimari:** Çok Katmanlı Mimari ve RESTful API

## ✨ Temel Özellikler
*   **Rol Bazlı Yetkilendirme (Auth):** Admin ve Personel olmak üzere farklı yetki seviyelerine sahip güvenli giriş mekanizması.
*   **Demirbaş ve Zimmet Modülü:** Şirkete ait demirbaşların sisteme kaydedilmesi ve çalışanlara (personel) zimmetlenmesi/atanması.
*   **Müşteri ve Cihaz Yönetimi:** Müşteri profillerinin oluşturulması ve teknik servise bırakılan cihazların sisteme tanımlanması.
*   **Uçtan Uca Teknik Servis Takibi:** 
    *   **Servis Kayıt:** Arızalı cihazlar için servis taleplerinin açılması.
    *   **Servis İşlem:** Cihaza uygulanan onarım ve bakım işlemlerinin girilmesi.
    *   **Servis Durum Geçmişi:** Cihazın hangi aşamalardan geçtiğinin adım adım loglanarak takip edilmesi.
*   **Dinamik Veri Yönetimi:** Tüm modüller için (Personel, Demirbaş, Cihaz, Servis) Entity Framework Core üzerinden sağlanan performanslı CRUD operasyonları.
