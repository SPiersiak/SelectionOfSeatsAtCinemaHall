Algorytm do znajdowania dwóch miejsc na sali kinowej

1. Problem

Należy stworzyć algorytm, który dla zadanego układu sali znajdzie parę siedzeń obok siebie które znajdują się w możliwie najlepszym miejscu. Najlepsze miejsce określamy, miejsca zlokalizowane na środku sali kinowej. Dla sprecyzowania zakładamy, że są to miejsca na przecięciu środkowego rzędu i środkowej kolumny.
Algorytm przypisuje kolumnom i rzędom wagi. Waga 0 to najlepsza waga. Każda kolumna lub rząd znajdujący się dalej od rzędu, lub kolumny środkowej jest inkrementowany o 1. Na sali kinowej mogą występować dwa rzędy lub kolumny środkowe. Dzieje się, tak gdy liczba np. kolumn jest liczbą parzystą, gdzie nie jesteśmy w stanie
wyznaczyć dokładnie jednej kolumny środkowej, są nimi 2 kolumny przyległe do tego punktu. Jeżeli liczba kolumn lub rzędów jest liczbą nieparzystą, to istnieje dokładnie jedna kolumna, lub rząd środkowy. Opisany proces przedstawiono na zdjęciu poniżej.

![image](https://github.com/SPiersiak/SelectionOfSeatsAtCinemaHall/assets/50294425/40d9e3e4-42ae-47b5-8c00-6c355e43139e)

Dzięki wyznaczeniu wag dla każdej kolumny i rzędu możemy przypisać finalną wagę dla każdego z siedzeń. Będzie ona suma wagi kolumny i rzędu. Im suma wag jest mniejsza (bliższa zeru), to miejsce jest uznawane za najlepsze. W idealnym przypadku (gdy dane miejsce nie będzie zarezerwowane) to najlepsze miejsce będzie posiadało wagę 0.
W zależności od układu sali może występować więcej niż jedno takie miejsce.

2. Algorytm

W poniższych punktach przedstawiono sposób działania algorytmu.

2.1. Model danych

Modelem, który odwzorowuje pojedyncze siedzenie wykorzystywanym przez algorytm, jest klasa Seat przedstawiona poniżej. Przyjmuje takie właściwości jak numer rzędu, numer kolumny, numer siedzenia, wagi (rzędu, kolumny, ogólną wagę siedzenia), informację czy miejsce jest zarezerwowane, typ siedzenia (fotel lub kanapa) wraz ze skorelowanym siedzeniem obok, jeżeli typ to kanapa.
```c#
public class Seat
{
    public int Row { get; set; }

    public int SeatNumber { get; set; }

    public int ColumnNumber { get; set; }

    public int RowWeight { get; set; }

    public int ColumnWeight { get; set; }

    public int TotalWeight => RowWeight + ColumnWeight;

    public bool IsReservated { get; set; } = false;

    public TypeOfSeat TypeOfSeat { get; set; } = TypeOfSeat.Armchair;

    public int? CorelatedRightSeatNumber { get; set; }
}
```

2.2. Struktura danych reprezentująca sale kinową

Sala kinowa reprezentowana jest w programie za pomocą słownika, w którym kluczem jest numer rzędu, a wartością jest lista siedzeń w danym rzędzie reprezentowana przez klasę Seat zaprezentowana powyżej.

```c#
Dictionary<int, List<Seat>> CinemaHall
```

2.3. Metoda wyznaczająca wagi rzędów

Metoda SetRowWeight wyznacza wagi rzędów dla całej sali kinowej. Jako argument przyjmuje kompletny słownik przedstawiający całą salę kinową (struktura zaprezentowana w PTK 2.2.).
Na początku metoda wyznacz ilość rzędów środkowych w zależności czy ich liczba jest parzysta, czy nie. Po wyznaczeniu rzędów środkowych następuje iteracja po każdym rzędzie w celu przypisania dla niego wag.
Wartość ta jest wynikiem obliczenia wartości bezwzględnej z różnicy numeru rzędu z numerem rzędu środkowego.
Jeżeli istnieją dwa rzędy środkowe, to wartość ta wyznaczana jest w ten sam sposób, lecz numer rzędu ośrodkowego jest brany w zależności czy wartość liczonego rzędu jest mniejsza/równa lub większa/równa numerowi rzędu środkowego.

```c#
public void SetRowWeight(Dictionary<int, List<Seat>> data)
{
    var rowCount = data.Keys.Count;

    var isExaclyOneBestRow = rowCount % 2 != 0;

    var secondBestRow = default(int);
    var firstBestRow = (int)Math.Round(rowCount / 2.0, 0, MidpointRounding.AwayFromZero);
    if (!isExaclyOneBestRow)
    {
        secondBestRow = firstBestRow + 1;
    }

    foreach (var row in data)
    {
        var rowWeight = default(int);

        if (isExaclyOneBestRow)
        {
            rowWeight = Math.Abs(row.Key - firstBestRow);
        }
        else
        {
            rowWeight = row.Key <= firstBestRow ? Math.Abs(row.Key - firstBestRow) : Math.Abs(row.Key - secondBestRow);
        }

        row.Value.ForEach(column =>
        {
            column.RowWeight = rowWeight;
        });
    }
}
```

2.4. Metoda wyznaczająca wagi kolumn

Metoda SetColumnWeight wyznacza wagi dla wszystkich kolumn sali kinowej. Jako argument przyjmuje kompletny słownik przedstawiający całą salę kinową (struktura zaprezentowana w PTK 2.2.).
Na początku metoda wyznacz ilość kolumn środkowych w zależności czy ich liczba jest parzysta, czy nie. Po wyznaczeniu kolumn środkowych następuje iteracja po każdym rzędzie, a następnie wszystkich kolumnach tego rzędu w celu przypisania dla niego wag.
Wartość ta jest wynikiem obliczenia wartości bezwzględnej z różnicy numeru kolumny z numerem kolumny środkowej.
Jeżeli istnieją dwie kolumny środkowe, to wartość ta wyznaczana jest w ten sam sposób, lecz numer kolumny środkowego jest brany w zależności czy wartość liczonej kolumny jest mniejsza/równa lub większa/równa numerowi kolumny środkowej.

```c#
public void SetColumnWeight(Dictionary<int, List<Seat>> data)
{
    var rowWithMostSeats = data.OrderByDescending(x => x.Value.Count).First().Value.Count;

    var isExaclyOneBestColumn = rowWithMostSeats % 2 != 0;
    var secondBestColumn = default(int);

    var firstBestColumn = (int)Math.Round(rowWithMostSeats / 2.0, 0, MidpointRounding.AwayFromZero);

    if (!isExaclyOneBestColumn)
    {
        secondBestColumn = firstBestColumn + 1;
    }

    foreach (var row in data)
    {
        row.Value.ForEach(column =>
        {
            if (isExaclyOneBestColumn)
            {
                column.ColumnWeight = Math.Abs(column.ColumnNumber - firstBestColumn);
            }
            else
            {
                column.ColumnWeight = column.ColumnNumber <= firstBestColumn ? Math.Abs(column.ColumnNumber - firstBestColumn) : Math.Abs(column.ColumnNumber - secondBestColumn);
            }
        });
    }
}
```

2.5. Metoda wyznaczająca wszystkie dostępne pary siedzeń w danym rzędzie

Metoda FindBestPlaceAlongsideInRow wyznacza wszystkie możliwe pary siedzeń w danym rzędzie i zwraca tę parę, której suma wag jest najmniejsza. Jeżeli nie jest możliwe wyzanczenie jakielkowliek pary siedzeń metoda zwraca null.
Jako argument metoda przyjmuje listę siedzeń w danym rzędzie. W pierwszej kolejności następuje iteracja po wszystkich siedzenia, które nie są zarezerwowane i są typu fotel. Zostaje zapamiętywany stan poprzedniego iterowanego fotela.
Jeżeli numer kolumny następnego iterowanego fotela równy jest wartości sumy numeru kolumny poprzedniego siedzenia + 1 to znaczy, że dane fotele występują obok siebie. Taka para zostaje dodana, to listy par foteli gdzie zostają zapisane numery foteli oraz suma ich wag (dzięki tej wartości rozpoznajemy które pary foteli są najlepsze).
W kolejnym etapie zostaje wykonane połączeniu siedzeń, które są kanapami. Możliwe jest zarezerwowanie tylko całej kanapy, a więc dwóch siedzeń. Jeżeli istnieją wolne kanapy, również zostaną dodane do dostępnych par siedzeń.

```c#
public BestSeats? FindBestPlaceAlongsideInRow(List<Seat> row)
{
    Seat? previousSeat = null;
    var listOfSeatsAlongsideInRowWithTotalWeight = new List<BestSeats>();

    foreach (var seat in row.Where(x => x.IsReservated == false && x.TypeOfSeat == TypeOfSeat.Armchair))
    {
        if (previousSeat == null)
        {
            previousSeat = seat;
            continue;
        }

        if (previousSeat.ColumnNumber + 1 == seat.ColumnNumber)
        {
            listOfSeatsAlongsideInRowWithTotalWeight.Add(new BestSeats() { SeatNumber1 = previousSeat.SeatNumber, SeatNumber2 = seat.SeatNumber, RowNumber = seat.Row, TotalWeight = previousSeat.TotalWeight + seat.TotalWeight });
        }

        previousSeat = seat;
    }

    listOfSeatsAlongsideInRowWithTotalWeight.AddRange(from first in row.Where(x => x.IsReservated == false && x.TypeOfSeat == TypeOfSeat.Couch)
                                                      join second in row on first.SeatNumber equals second.CorelatedRightSeatNumber
                                                      select new BestSeats() { SeatNumber1 = first.SeatNumber, SeatNumber2 = second.SeatNumber, RowNumber = second.Row, TotalWeight = first.TotalWeight + second.TotalWeight });

    return listOfSeatsAlongsideInRowWithTotalWeight.Any() ? listOfSeatsAlongsideInRowWithTotalWeight.OrderBy(o => o.TotalWeight).First() : null;
}
```
