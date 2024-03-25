using SelectionOfSeatsAtCinemaHall.DataMockHelper;
using SelectionOfSeatsAtCinemaHall.Models;

namespace SelectionOfSeatsAtCinemaHall;

public class SelectSeatsAlgorithm
{
    public void FindBestPlace()
    {
        var data = CinemaHallData.InitialCinemaHallData();

        SetRowWeight(data);
        SetColumnWeight(data);

        var bestInRows = new List<BestSeats>();

        foreach (var row in data)
        {
            var result = FindBestPlaceAlongsideInRow(row.Value);

            if (result != null)
            {
                bestInRows.Add(result);
            }
        }
        var best = bestInRows.OrderBy(o => o.TotalWeight).First();
    }

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
}
