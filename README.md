# LaptopsApp

Aplikacja stworzona na potrzeby zaliczenia przedmiotu "Programowanie Wizualne".

## 1 WYMAGANIA OGÓLNE

### 1.1 Projekty
Projekty dotyczą implementacji katalogu produktów. Każdy wybiera sobie produkty. Nie można wybierać samochodów jako tematu projektu zaliczeniowego.

### 1.2 Grupy
Projekty realizuje się w dwuosobowych grupach.

### 1.3 Standard kodowania
Należy stosować się do wymagań standardu kodowania w języku C#.

### 1.4 Ocena
Ocena z projektów wystawiana jest na podstawie zgodności z wymaganiami.

### 1.5 Oddawanie projektów
Przy oddawaniu projektów należy je wcześniej wyczyścić z elementów wynikających z kompilacji.

### 1.6 Interfejs aplikacji
Należy wykonać w technologii WPF, UWP, WINUI 3.0 lub .NET MAUI. Następnie utworzyć aplikację webową z wykorzystaniem technologii ASP.Net Core, MVC lub Blazor.

### 1.7 Katalog
Muszą być minimum dwie powiązane relacje Producent-Produkt.

### 1.8 Typ wyliczeniowy
Wymagane jest wykorzystanie typu wyliczeniowego jako typu jednego z atrybutów.

## 2 ARCHITEKTURA APLIKACJI

### 2.1 Wzorzec projektowy
Aplikacja wielowarstwowa z wydzielonymi warstwami: UI, BL, DAO.

### 2.2 Biblioteki dll
Każdy element architektury stanowi osobną bibliotekę dll.

### 2.3 Wykorzystanie bibliotek
Dozwolone jest wykorzystanie biblioteki z warstwy wyższej przez bibliotekę warstwy niższej.

### 2.4 Warstwa DAO
W warstwie DAO umieszczone są obiekty danych DO.

### 2.5 Plik konfiguracyjny
Nazwa biblioteki z danymi znajduje się w pliku konfiguracyjnym aplikacji.

### 2.6 Nazwa przestrzeni nazw
Format: Nazwisko.NazwaAplikacji.NazwaSkładowej.

### 2.7 Struktura plików
Każda klasa, typ wyliczeniowy i interfejs mają znajdować się w osobnym pliku.

### 2.8 UI okienkowe
Realizowane z wykorzystaniem technologii WPF/.NET MAUI zgodnie z architekturą MVVM.

### 2.9 ModelView
ModelView może zostać umieszczony w osobnej warstwie/bibliotece.

## 3 STANDARD KODOWANIA

Kodowanie w standardzie dostępnym [tutaj](https://aspblogs.blob.core.windows.net/media/lhunt/Publications/CSharp%20Coding%20Standards.pdf) z uproszczeniami.

## 4 WYMAGANIA

### 4.1 Operacje na danych z UI
- Przeglądanie katalogu
- Dodawanie Produktów/Producentów
- Modyfikowanie danych
- Usuwanie rekordów
- Wyszukiwanie danych
- Filtrowanie danych

### 4.2 Bazy danych
Wykorzystanie biblioteki EF. Dostępne opcje to DAOMock, DAOFile, DAOSQL.

