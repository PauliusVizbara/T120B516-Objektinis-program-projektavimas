# T120B516 Projektas

## Žaidimo aprašymas

Žaidimo tipas yra kelių žaidėjų Tower Defense, kuriame žaidėjai bendromis pastangomis statydamas gynybinius bokštus stengsnis apsiginti nuo vis didėjančių priešų atakų. 

Žaidimo formato pavyzdys:

![](https://steamcdn-a.akamaihd.net/steam/apps/989650/ss_2b864a2aed7527850fa6aa690e8e995c8f376122.1920x1080.jpg?t=1546777522)

## Technologija

Žaidimui sukurti bus naudojama:

- **C#** kalba
- **ASP.NET** karkasas
- **SignalR** biblioteka asinchroniškai komunikacijai

## Architektūra

- Pats žaidimas bus iškeltas į **Singleton**'ą, kuris bus atsakingas už žaidimo eigą (lygio paleidimas ir pakeitimas, laimėjimo ir pralaimėjimo sužiūrėjimas)
- Pagrindinė bazinė abstrakti klasė bus **Unit**, kuri turės tik savo poziciją. Norint sukurti specifinius objektus kaip pastatus ar kareivius bus naudojami **BuildingFactory** ir **SoldierFactory**, kurie implementuos sąsąją **UnitFactory**, kuris bus abstraktus fabrikas (*angl. abstract factory*)

## Paleidimas

- Step 1
- Step 2

## Testavimas

[Lab1](https://docs.google.com/document/d/1Em8HIq5uxUOxEhGf9ucYCZOt1zf3D3Df8gE96an67_s/edit#heading=h.3vcmjd1st9vo)
