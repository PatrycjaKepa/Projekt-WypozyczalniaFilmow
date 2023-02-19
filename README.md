
# Wypożyczalnia Filmów

Projekt ten służy do, jak sama nazwa mówi, wypożyczania filmów poprzez stronę internetową w łatwy, szybki i zorganizowany sposób.


## Spis treści
* [Informacje o projekcie](#Informacje o projekcie)
* [Dane testowe](#Dane testowe)
* [Technologie użyte w projekcie](#Technologie użyte w projekcie)
* [Testowanie aplikacji](#Testowanie aplikacji)
* [Wytyczne projketu](#Wytyczne projketu)
* [Autor](#Autor)

## Informacje o projekcie
Strona ma za zadanie umożliwiać wypożyczenie filmu zainteresowanemu klientowi. 
Aby móc wypożyczyć jakikolwiek film, wymagane jest posiadanie konta na stronie. Można jednak bez niego przejrzeć filmy jakie oferuje strona i zobaczyć , czy jest ten, który nas interesuje. Aby to zrobić należy wybrać opcje Movies z menu znajdującym się po lewej stronie.
Tam można przejrzeć filmy lub wyszukać konkretny wpisując tytuł w pasku wyszukiwania.
W menu znajdziemy także "Movie rental policies". Opcja ta zawiera informacje o zasadach wypożyczania filmów.

#### Kiedy zaloguje się użytkownik
Po zalogowaniu opcje menu rozszerzają się o parę opcji oraz zmieniają się już te istniejące:
* Movies - odblokowana zostaje funkcja wypożyczenia;
* My Lends - znajdziemy tutaj informację o naszych wypożyczonych już filmach oraz opcję ich anulowania;
* Profile - Zawiera informacje na temat naszego konta;
* Log out - Wylogowuje nas;

#### Kiedy zaloguje się administrator
Po zalogowaniu opcje menu rozszerzają się o parę opcji oraz zmieniają się już te istniejące:
* Movies - odblokowana zostają funkcje tworzenia nowego filmu, edytowanie istniejącego już filmu oraz usuwanie filmu;
* Lends - tutaj administrator może potwierdzić opłatę za film lub, w razie anulowania, odrzucić wypożyczenie(płatności nie są jeszcze rozszerzone ale ceny oraz ich określenie za ilość dni już tak)
* Users - w tym miejscu administrator może zobaczyć wszystkich użytkowników strony oraz w razie problemów zwykłego użytkownika, czy chęć zmiany innych upoważnionych, edytować czy usunąć konto.



## Dane testowe:
#### Administrator:
> Aby zalogować się jako administrator należy podać:

`Imię: Mietek`

E-mail: mietek@admin.pl

Password: Mietek123
#### Zwykli użytkownicy:
> Aby zalogować się jako zwykły użytkownik należy podać jedene z danych:

`Imię: Janek`

E-mail: janek@user1.pl

Password: Janek123

`Imię: Sylwia`

E-mail: sylwia@user2.pl

Password: Sylwia123
## Testowanie aplikacji

Aplikacja znajduje się na GitHubie. Należy pobrać ją jako plik .zip i otworzyć w odpowiednim środowisku. W tym przypadku jest to Visual Studio.

Aby ujrzeć stronę należy skompilować kod. Jeśli pojawią się problemy z danymi należy w konsoli:
* sprawdzić migracje `get-migration`
* jeśli ostatnia migracja jest false `update-database`
* jeśli ostatnia migracja jest true `add-migration przykładowa Nazwa`, a następnie `update-database`


Adres do połączenia z bazą danych: `"Server=(localdb)\\mssqllocaldb;Database=WypozyczalniaFilmow;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=dbo"`

`Microsoft SQL Managment Studio`

## Wytyczne projektu
>Ocena aplikacji odbywa się na podstawie kodu źródłowego, który należy zamieścić na GitHub lub innym podobnym portalu.
Kod źródłowy do aplikacji został zamieszczony na platformie GitHub:
`https://github.com/PatrycjaKepa/Projekt-WypozyczalniaFilmow`.

>Repozytorium na GitHub musi być umieszczone co najmniej 3 tygodnie przez oddaniem projektu, i posiadać co najmniej 3 commity o różnych datach (nie wliczając pierwszego), świadczące o pracy nad projektem.
Repozytorium zostało zamiesczone na GitHub'ie 11.01.2023, a liczba commitów o różnych datach jest większ niż 3.

>Do każdego projektu należy przygotować dokumentację w postaci pliku README.md z opisem instalacji, wymagań, konfiguracji ( łańcuch połączenia z bazą, testowi użytkownicy i ich hasła, itd.) oraz opis działania aplikacji z punktu widzenia użytkownika (przykład opisu).
Jeśli możesz to przeczytać to znaczy, że README istnieje :) Jest ono ułożone tak, aby nie pominąć żadnej wżnej rzeczy.

>Punkty za projekt można uzyskać wyłącznie pod warunkiem, że aplikację projektu można uruchomić na podstawie kodu źródłowego. Projekty, których nie można uruchomić nie będą oceniane!
Uruchamianie tego projektu zostało sprawdzone na innym urządzeniu z rezultatem pozytywnym :)

>W skład każdej aplikacji powinny się znaleźć (wymagania minimalne na 35 punktów): min. 3 formularze, każdy z walidacją (5),

`Formularz do logowania` - nie można zostawić jakiegokolwiek pustego pola oraz sprawdzane jest czy dane są poprawne, w obu przypadkach w razie niepowodzenia wyskoczy błąd
`Formularz do rejestracji` - e-mail nie może sie powtarzać a hasło musi posiadać przynajmniej jedną dużą literę i znak
`Formularz do wypożyczeń` - jeśli daty się nie zgadzają wypożyczenie się nie założy, a zamiast tego pojawi się komunikat o błędzie 


>Utrwalanie danych za pomocą EF z użyciem SQLite lub SQL Server, a aplikacja powinna zawierać co najmniej 4 encje, w tym trzy encje występujące w związkach (5),
`Encje:` 6 

`Encje występujące w związkach:` 4

>Wykorzystanie DI i zastosowanie dwóch implementacji jednego interfejsu (np. implementacja repozytorium produkcyjnego i testowego) (5),


>Autoryzacja użytkowników - na poziomie podstawowym w postaci rozróżnienia zwykłych użytkowników (dostęp publiczny z logowaniem lub bez) i użytkowników uprzywilejowanych (np. administrator z dostępem po zalogowaniu) (5),
Strona ma 3 rozróżnienia: dla niezalogowanych, dla zwykłych użytkowników i dla adminów.

>WebAPI REST odnoszące się do głównej encji(GET, POST, DELETE, PUT lub UPDATE)(5),
Główna encja posiada wszystkie te rzeczy(CRUD)

>Testy jednostkowe najważniejszych funkcji i klas aplikacji (5),
Aplikacja posiada testy jednostkowe

>Wygląd i przejrzystość aplikacji zgodne z domyślnym stylem Bootstrap (5).
W mojej aplikacji wygląd i przejrzystość jest zgodna z domyślnym stylem Bootstrap.

#### Dodatkowe wytyczne:

>Projekt wyróżnia się ciekawymi funkcjami (wykraczającymi poza typowy CRUD) np. tworzenie rankingu popularności książek, wyszukiwanie książek wg kryteriów, stronicowanie, dynamiczne pobieranie danych potrzebnych do wstawienia w formularzu itd. (10).
Mój projekt posiada wiele ciekawych funkcji wykraczających poza CRUD, między innym zmieniający się status wypożyczeń czy wyszukiwanie filmów

>Projekt wyróżnia się estetycznym i oryginalnym wyglądem (10), wykraczającym poza to, co oferuje domyślnie Bootstrap.
Do ostylowania używałam także stylów css

>Jakością kodu, który powinien być czytelny z jasno wydzielonymi warstwami np. serwis, osobne klasy modeli widoków itd.(15).
Tak, projekt zrealizowano w oparciu o model MVC, klasy są oddzielone folderami, a także encje posiadają oddzielne odpowiedzialności.
## Autor
- [Patrycja Kępa](https://github.com/PatrycjaKepa/Projekt-WypozyczalniaFilmow), numer indeksu: `13937`