# MeteoFetcher

**MeteoFetcher** je .NET 9 konzolová aplikace, která každou hodinu stahuje XML data z meteostanice, převede je do JSON formátu a uloží do SQL databáze spolu s časem stažení. Pokud meteostanice není dostupná, uloží se záznam s informací o chybě.

## Použité technologie

- .NET 9 Console App  
- Entity Framework Core 9  
- SQL Server (LocalDB)  
- Newtonsoft.Json  

## Konfigurace

Konfigurace je definována v souboru `appsettings.json`:

```json
{
  "Weather": {
    "Url": "https://pastebin.com/raw/PMQueqDV"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MeteoDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
```
## Spuštění aplikace

1. Otevři projekt v IDE (např. Visual Studio nebo VS Code).
2. Ujisti se, že máš nainstalovaný SQL Server Express (LocalDB).
3. V konzoli spusť:

    ```bash
    dotnet run
    ```

4. Při prvním spuštění dojde automaticky k vytvoření databáze a migraci schématu.
5. Aplikace každou hodinu stáhne nová data a uloží je do databáze.

## Časová implementace
6-7 hodin
