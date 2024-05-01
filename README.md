# RFHM_21_Autorent
A 21. csapat Rendszerfejlesztés feladata.

Ez a harmadik beadandó branch-e
Szerver elérési útvonala: AutorentServer
Kliens elérési útvonala: AutorentServer\AutorentServer\wwwroot

## Futtatás Windows-on
1. AutorentServer\AutorentServer.sln megnyitása Visual Studio-ban
2. Tools -> NuGet Package Manager -> Package Manager Console-ban 
```
Add-Migration InitialCreate
Update-Database
``` 
(migration és adatbázis létrehozása)
3. Futtatás Visual Studióból vagy az AutorentServer\AutorentServer\bin\Debug\net8.0\AutorentServer.exe-ből 
4. Swagger UI automatikusan megnyílik, itt lehet belépni a /users/login menüpont alatt, sikeres azonosítás után generálódik egy JWT token
5. A kliens a localhost:5000 cím alatt fut, az előbb generált JWT tokent a hosszukás beviteli mezőbe másoljuk be
6. Ezután a kliens működésését a kék gombokra kattintva tudjuk kipróbálni.
