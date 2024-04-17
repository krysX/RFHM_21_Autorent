# RFHM_21_Autorent
A 21. csapat Rendszerfejlesztés feladata.

Ez az második beadandó branch-e

A szerver az AutorentServer mappában található.

Egy minimális kliens is található a repóban az AutorentServer\AutorentServer\wwwroot\index.html fájlban.

## Futtatás Windows-on
1. Solution megnyitása Visual Studio-ban
2. Tools -> NuGet Package Manager -> Package Manager Console-ban
```
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database
```
3. Futtatás Visual Studióból vagy az AutorentServer\AutorentServer\bin\Debug\net8.0\AutorentServer.exe-ből 
4. Ekkor felugrik a Swagger felület, ahol ki lehet próbálni az egyes API végpontokat
+ a klienst a szerver címén elérjük

