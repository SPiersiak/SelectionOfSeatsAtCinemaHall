namespace SelectionOfSeatsAtCinemaHall.Models;
public class Seat
{
    public Seat(int row, int seatNumber, int columnNumber, bool isReserved, TypeOfSeat? typeOfSeat = null, int? corelatesRightSeatNumber = null, int? rowWeight = null, int? columnWeight = null)
    {
        Row = row;
        SeatNumber = seatNumber;
        ColumnNumber = columnNumber;
        IsReservated = isReserved;

        if (rowWeight.HasValue)
        {
            RowWeight = rowWeight.Value;
        }

        if (columnWeight.HasValue)
        {
            ColumnWeight = columnWeight.Value;
        }

        if (typeOfSeat.HasValue)
        {
            TypeOfSeat = typeOfSeat.Value;
        }

        if (corelatesRightSeatNumber.HasValue)
        {
            CorelatedRightSeatNumber = corelatesRightSeatNumber.Value;
        }
    }

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
