# RFHM_21_Autorent
A 21. csapat Rendszerfejlesztés feladata.

Ez az második beadandó branch-e
A szerver az AutorentServer mappában található
A kliens az AutorentServer\AutorentServer\wwwroot\index.html fájlban található.

## Futtatás Windows-on
1. Solution megnyitása Visual Studio-ban
2. Tools -> NuGet Package Manager -> Package Manager Console-ban ```Update-Database``` parancs (adatbázis létesítése)
3. Futtatás Visual Studióból vagy az AutorentServer\AutorentServer\bin\Debug\net8.0\AutorentServer.exe-ből 
4. Ekkor felugrik a Swagger felület, ahol ki lehet próbálni az egyes API végpontokat
+ egy minimális kliens is található a repóban, amelyet a szerver portján elérhető (localhost:<port>)

