using FluentAssertions;
using SelectionOfSeatsAtCinemaHall;
using SelectionOfSeatsAtCinemaHall.Models;

namespace SelectionOfSeatsAtCinemaAlgorithm;

public class AlgorithmTest
{
    [Fact]
    public void SetUpRowWeight_WhenEvenNumberOfElements_TwoRowHasBestWeight()
    {
        var data = SetUpData();
        var sut = new SelectSeatsAlgorithm();

        sut.SetRowWeight(data);

        Assert.All(data.Where(x => x.Key == 1).First().Value, a => Assert.Equal(1, a.RowWeight));
        Assert.All(data.Where(x => x.Key == 2).First().Value, a => Assert.Equal(0, a.RowWeight));
        Assert.All(data.Where(x => x.Key == 3).First().Value, a => Assert.Equal(0, a.RowWeight));
        Assert.All(data.Where(x => x.Key == 4).First().Value, a => Assert.Equal(1, a.RowWeight));
    }

    [Fact]
    public void SetUpRowWeight_WhenOddNumberOfElements_OneRowHasBestWeight()
    {
        var data = SetUpData();
        data.Remove(4);
        var sut = new SelectSeatsAlgorithm();

        sut.SetRowWeight(data);

        Assert.All(data.Where(x => x.Key == 1).First().Value, a => Assert.Equal(1, a.RowWeight));
        Assert.All(data.Where(x => x.Key == 2).First().Value, a => Assert.Equal(0, a.RowWeight));
        Assert.All(data.Where(x => x.Key == 3).First().Value, a => Assert.Equal(1, a.RowWeight));
    }

    [Fact]
    public void SetUpColumnWeight_WhenEvenNumberOfElements_TwoColumnsHasBestWeight()
    {
        var data = SetUpData();
        var sut = new SelectSeatsAlgorithm();

        sut.SetColumnWeight(data);
        var rowColumns = data.Where(x => x.Key == 1).First().Value;

        Assert.Equal(2, rowColumns.Count(c => c.ColumnWeight == 0));
    }

    [Fact]
    public void SetUpColumnWeight_WhenOddNumberOfElements_OneColumnHasBestWeight()
    {
        var data = SetUpData();
        data.Remove(1);
        data.Remove(3);
        var sut = new SelectSeatsAlgorithm();

        sut.SetColumnWeight(data);
        var rowColumns = data.Where(x => x.Key == 2).First().Value;

        Assert.Equal(1, rowColumns.Count(c => c.ColumnWeight == 0));
    }

    [Fact]
    public void FindBestPlaceAlongside_WhenSucces_FindPlace()
    {
        var data = SetUpData();
        var sut = new SelectSeatsAlgorithm();

        var result = sut.FindBestPlaceAlongsideInRow(data.Where(x => x.Key == 1).First().Value);

        result.Should().BeOfType<BestSeats>();
        result.Should().NotBeNull();
        Assert.Equal(3, result.SeatNumber1);
        Assert.Equal(4, result.SeatNumber2);
        Assert.Equal(0, result.TotalWeight);
    }

    [Fact]
    public void FindBestPlaceAlongside_WhenFailed_DoNotFindPlace()
    {
        var data = SetUpData();
        var sut = new SelectSeatsAlgorithm();

        var result = sut.FindBestPlaceAlongsideInRow(data.Where(x => x.Key == 2).First().Value);

        result.Should().BeNull();
    }

    [Fact]
    public void FindBestPlaceAlongside_WhenSucces_FindPlaceOnCouch()
    {
        var data = SetUpData();
        var sut = new SelectSeatsAlgorithm();

        var result = sut.FindBestPlaceAlongsideInRow(data.Where(x => x.Key == 4).First().Value);

        result.Should().NotBeNull();
        result.Should().BeOfType<BestSeats>();
        Assert.Equal(3, result.SeatNumber1);
        Assert.Equal(2, result.SeatNumber2);
    }

    private Dictionary<int, List<Seat>> SetUpData()
    {
        var data = new Dictionary<int, List<Seat>>();

        var Row1 = new List<Seat>()
        {
            new Seat(1, 1, 1, false),
            new Seat(1, 2, 2, true),
            new Seat(1, 3, 3, false),
            new Seat(1, 4, 4, false),
        };
        var Row2 = new List<Seat>()
        {
            new Seat(2, 1, 2, false),
            new Seat(2, 2, 3, true),
            new Seat(2, 3, 4, false),
            
        };
        var Row3 = new List<Seat>()
        {
            new Seat(3, 1, 1, false),
            new Seat(3, 2, 2, false),
            new Seat(3, 3, 3, false),
            new Seat(3, 4, 4, false),
        };
        var Row4 = new List<Seat>()
        {
            new Seat(4, 1, 1, false),
            new Seat(4, 2, 2, false, TypeOfSeat.Couch, 3),
            new Seat(4, 3, 3, false, TypeOfSeat.Couch),
        };

        data.Add(1, Row1);
        data.Add(2, Row2);
        data.Add(3, Row3);
        data.Add(4, Row4);

        return data;
    }
}