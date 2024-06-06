# RFHM_21_Autorent
A 21. csapat Rendszerfejlesztés feladata.

Ez a végső változat branch-e

Szerver elérési útvonala: AutorentServer

Kliens elérési útvonala: AutorentServer\AutorentServer\wwwroot

## Előkészületek első futtatás előtt (Windows alatt)
1. Visual Studio 2022 telepítése (ha nincs meg)
2. Visual Studióhoz ASP.NET támogatás telepítése
3. EF Core és hozzá kapcsolódó eszközök telepítése
   (Tools -> NuGet Package Manager -> Package Manager Console-ban)
   ```
   Install-Package Microsoft.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.Tools
   ```
4. Adatbázis legenerálása (szintén a Package Manager Console-ban)
   ```
   Add-Migration InitialCreate
   Update-Database
   ```

## Futtatás Windows-on
1. Futtatás Visual Studióból vagy az AutorentServer\AutorentServer\bin\Debug\net8.0\AutorentServer.exe-ből 
2. Ekkor a konzol ablakban megjelenő porton elérhető a kliens, ahova az alábbi két fiókkal tudunk belépni:

| Felhasználónév | Jelszó |
| -------------- | ------ |
| admin          | admin  |
| user           | user   |

