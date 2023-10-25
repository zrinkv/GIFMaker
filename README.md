# GIFMaker

Angular aplikacije za generiranje GIF-ova na temelju odabranih slika.

Za pokretanje pojekta unutar Visual Studio 2022 potrebno je na postavkama solution-a postaviti Multiple startup projects (GIFMakerAngular i GIFMakerAPI -> Action-> Start) ili Single startup project da se pokrene samo GIFMakerAPI, a Angular projekt pokrenuti zasebno preko CLI-a ("npm start" u direktoriju GIFMakerAngular).

Prije pokretanja projekta potrebno je u DeveloperPowerShell-u promijeniti direktorij u GIFMakerAngular (cd GIFMakerAngular) i pokrenuti naredbu "npm update".

U slučaju da vam CLI javlja da ne može pronaći module potrebno je izbrisati node_modules direktorij and package-lock.json datoteku ručno ili pomoću sljedećih naredbi:

"rm -rf node_modules" i "rm -f package-lock.json"

Zatim pobrisati cache: "npm cache clean --force" i pokrenuti "npm install" za instalaciju potrebnih modula.

# Napomena
Web API je razvijan u .NetCore 7 verziji, Agular projekt u Angular CLI: 16.2.7, Node: 20.9.0 i Package Manager: npm 10.2.1
