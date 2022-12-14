# GIFMaker

Angular aplikacije za generiranje GIF-ova na temelju odabranih slika

Za pokretanje pojekta unutar Visual Studio 2022 potrebno je na postavkama solution postaviti Multiple startup projects (GIFMakerAngular i GIFMakerAPI -> Action-> Start) ili Single startup project da se pokrene samo GIFMakerAPI, a Angular projekt pokrenuti zasebno preko CLI-a ("npm start" u direktoriju GIFMakerAngular).

Prije pokretanja projekta potrebno je u DeveloperPoweShell-u promijeniti direktorij u GIFMakerAngular (cd GIFMakerAngular) i pokrenuti komandu "npm update".

U slučaju da vam CLI javlja da ne može pronaći module potrebno je izbrisati node_modules direktorij and package-lock.json datoteku ručno ili pomoću sljdećih komandi:

"rm -rf node_modules"

"rm -f package-lock.json"

Zatim pobrisati cache:

"npm cache clean --force"

i pokrenuti "npm install"

# Napomena
Web API je razvijan u .NetCore 7 verziji, Agular projekt u Angular CLI: 15.0.3, Node: 16.15.0 i Package Manager: npm 8.19.2

