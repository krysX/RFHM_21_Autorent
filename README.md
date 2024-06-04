# RFHM_21_Autorent
A 21. csapat Rendszerfejlesztés feladata.

Ez a negyedik beadandó branch-e

Szerver elérési útvonala: AutorentServer

Kliens elérési útvonala: AutorentServer\AutorentServer\wwwroot

## Futtatás Windows-on
1. AutorentServer\AutorentServer.sln megnyitása Visual Studio-ban
2. Első futtatás előtt: Tools -> NuGet Package Manager -> Package Manager Console-ban 
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Tools 
Add-Migration InitialCreate
Update-Database
``` 
(EF Core Tools telepítése ha még nincs telepítve)
(migration és adatbázis létrehozása)

3. Futtatás Visual Studióból vagy az AutorentServer\AutorentServer\bin\Debug\net8.0\AutorentServer.exe-ből 
4. Ekkor a konzol ablakban megjelenő porton elérhető a kliens, ahova az alábbi két fiókkal tudunk belépni:

| Felhasználónév | Jelszó |
| -------------- | ------ |
| admin          | admin  |
| user           | user   |

