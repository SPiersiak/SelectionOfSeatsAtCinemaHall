using SelectionOfSeatsAtCinemaHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionOfSeatsAtCinemaHall.DataMockHelper;
public static class CinemaHallData
{
    private static Dictionary<int, List<Seat>> CinemaHall = new Dictionary<int, List<Seat>>();
    private static List<Seat> Row1 = new List<Seat>()
    {
        new Seat(1, 1, 7, false),
        new Seat(1, 2, 8, true),
        new Seat(1, 3, 9, false),
        new Seat(1, 4, 10, false),
        new Seat(1, 5, 11, false),
        new Seat(1, 6, 12, false),
        new Seat(1, 7, 13, false),
        new Seat(1, 8, 14, false),
        new Seat(1, 9, 15, false),
        new Seat(1, 10, 16, false),
        new Seat(1, 11, 17, false),
        new Seat(1, 12, 18, false),
    };
    private static List<Seat> Row2 = new List<Seat>()
    {
        new Seat(2, 1, 6, false),
        new Seat(2, 2, 7, false),
        new Seat(2, 3, 8, false),
        new Seat(2, 4, 9, false),
        new Seat(2, 5, 10, false),
        new Seat(2, 6, 11, false),
        new Seat(2, 7, 12, false),
        new Seat(2, 8, 13, false),
        new Seat(2, 9, 14, false),
        new Seat(2, 10, 15, false),
        new Seat(2, 11, 16, false),
        new Seat(2, 12, 17, false),
        new Seat(2, 13, 18, false),
    };
    private static List<Seat> Row3 = new List<Seat>()
    {
        new Seat(3, 1, 6, false),
        new Seat(3, 2, 7, false),
        new Seat(3, 3, 8, false),
        new Seat(3, 4, 9, false),
        new Seat(3, 5, 10, false),
        new Seat(3, 6, 11, false),
        new Seat(3, 7, 12, false),
        new Seat(3, 8, 13, false),
        new Seat(3, 9, 14, false),
        new Seat(3, 10, 15, false),
        new Seat(3, 11, 16, false),
        new Seat(3, 12, 17, false),
        new Seat(3, 13, 18, false),
    };
    private static List<Seat> Row4 = new List<Seat>()
    {
        new Seat(4, 1, 6, false),
        new Seat(4, 2, 7, false),
        new Seat(4, 3, 8, false),
        new Seat(4, 4, 9, false),
        new Seat(4, 5, 10, false),
        new Seat(4, 6, 11, false),
        new Seat(4, 7, 12, false),
        new Seat(4, 8, 13, false),
        new Seat(4, 9, 14, false),
        new Seat(4, 10, 15, false),
        new Seat(4, 11, 16, false),
        new Seat(4, 12, 17, false),
        new Seat(4, 13, 18, false),

    };
    private static List<Seat> Row5 = new List<Seat>()
    {
        new Seat(5, 1, 6, false),
        new Seat(5, 2, 7, false),
        new Seat(5, 3, 8, true),
        new Seat(5, 4, 9, true),
        new Seat(5, 5, 10, false),
        new Seat(5, 6, 11, false),
        new Seat(5, 7, 12, false),
        new Seat(5, 8, 13, false),
        new Seat(5, 9, 14, false),
        new Seat(5, 10, 15, false),
        new Seat(5, 11, 16, false),
        new Seat(5, 12, 17, false),
        new Seat(5, 13, 18, false),

    };
    private static List<Seat> Row6 = new List<Seat>()
    {
        new Seat(6, 1, 1, true),
        new Seat(6, 2, 2, true),
        new Seat(6, 3, 3, true),
        new Seat(6, 4, 6, true),
        new Seat(6, 5, 7, true),
        new Seat(6, 6, 8, true),
        new Seat(6, 7, 9, true),
        new Seat(6, 8, 10, true),
        new Seat(6, 9, 11, true),
        new Seat(6, 10, 12, true),
        new Seat(6, 11, 13, true),
        new Seat(6, 12, 14, true),
        new Seat(6, 13, 15, false),
        new Seat(6, 14, 16, false),
        new Seat(6, 15, 17, false),
        new Seat(6, 16, 18, false),

    };
    private static List<Seat> Row7 = new List<Seat>()
    {
        new Seat(7, 1, 1, false),
        new Seat(7, 2, 2, false),
        new Seat(7, 3, 3, false),
        new Seat(7, 4, 6, false),
        new Seat(7, 5, 7, false),
        new Seat(7, 6, 8, false),
        new Seat(7, 7, 9, false),
        new Seat(7, 8, 10, false),
        new Seat(7, 9, 11, false),
        new Seat(7, 10, 12, false),
        new Seat(7, 11, 13, false),
        new Seat(7, 12, 14, false),
        new Seat(7, 13, 15, false),
        new Seat(7, 14, 16, false),
        new Seat(7, 15, 17, false),
        new Seat(7, 16, 18, false),

    };
    private static List<Seat> Row8 = new List<Seat>()
    {
        new Seat(8, 1, 1, false),
        new Seat(8, 2, 2, false),
        new Seat(8, 3, 3, false),
        new Seat(8, 4, 6, false),
        new Seat(8, 5, 7, false),
        new Seat(8, 6, 8, false),
        new Seat(8, 7, 9, false),
        new Seat(8, 8, 10, false),
        new Seat(8, 9, 11, false),
        new Seat(8, 10, 12, false),
        new Seat(8, 11, 13, false),
        new Seat(8, 12, 14, false),
        new Seat(8, 13, 15, false),
        new Seat(8, 14, 16, false),
        new Seat(8, 15, 17, false),
        new Seat(8, 16, 18, false),

    };
    private static List<Seat> Row9 = new List<Seat>()
    {
        new Seat(9, 1, 1, false),
        new Seat(9, 2, 2, false, TypeOfSeat.Couch, 3),
        new Seat(9, 3, 3, false, TypeOfSeat.Couch),
        new Seat(9, 4, 6, false),
        new Seat(9, 5, 7, false, TypeOfSeat.Couch, 6),
        new Seat(9, 6, 8, false, TypeOfSeat.Couch),
        new Seat(9, 7, 9, false, TypeOfSeat.Couch, 8),
        new Seat(9, 8, 10, false, TypeOfSeat.Couch),
        new Seat(9, 9, 11, false, TypeOfSeat.Couch, 10),
        new Seat(9, 10, 12, false, TypeOfSeat.Couch),
        new Seat(9, 11, 13, false, TypeOfSeat.Couch, 12),
        new Seat(9, 12, 14, false, TypeOfSeat.Couch),
        new Seat(9, 13, 15, false, TypeOfSeat.Couch, 14),
        new Seat(9, 14, 16, false, TypeOfSeat.Couch),
        new Seat(9, 15, 17, false, TypeOfSeat.Couch, 16),
        new Seat(9, 16, 18, false, TypeOfSeat.Couch),
    };
    private static List<Seat> Row10 = new List<Seat>()
    {
        new Seat(10, 1, 1, false),
        new Seat(10, 2, 2, false, TypeOfSeat.Couch, 3),
        new Seat(10, 3, 3, false, TypeOfSeat.Couch),
        new Seat(10, 4, 6, false),
        new Seat(10, 5, 7, false, TypeOfSeat.Couch, 6),
        new Seat(10, 6, 8, false, TypeOfSeat.Couch),
        new Seat(10, 7, 9, false, TypeOfSeat.Couch, 8),
        new Seat(10, 8, 10, false, TypeOfSeat.Couch),
        new Seat(10, 9, 11, false, TypeOfSeat.Couch, 10),
        new Seat(10, 10, 12, false, TypeOfSeat.Couch),
        new Seat(10, 11, 13, false, TypeOfSeat.Couch, 12),
        new Seat(10, 12, 14, false, TypeOfSeat.Couch),
        new Seat(10, 13, 15, false, TypeOfSeat.Couch, 14),
        new Seat(10, 14, 16, false, TypeOfSeat.Couch),
        new Seat(10, 15, 17, false, TypeOfSeat.Couch, 16),
        new Seat(10, 16, 18, false, TypeOfSeat.Couch),

    };
    private static List<Seat> Row11 = new List<Seat>()
    {
        new Seat(11, 1, 1, false, TypeOfSeat.Couch, 2),
        new Seat(11, 2, 2, false, TypeOfSeat.Couch),
        new Seat(11, 3, 3, false, TypeOfSeat.Couch, 4),
        new Seat(11, 4, 4, false, TypeOfSeat.Couch),
        new Seat(11, 5, 5, false, TypeOfSeat.Couch, 6),
        new Seat(11, 6, 6, false, TypeOfSeat.Couch),
        new Seat(11, 7, 7, false, TypeOfSeat.Couch, 8),
        new Seat(11, 8, 8, false, TypeOfSeat.Couch),
        new Seat(11, 9, 9, false, TypeOfSeat.Couch, 10),
        new Seat(11, 10, 10, false, TypeOfSeat.Couch),
        new Seat(11, 11, 11, false, TypeOfSeat.Couch, 12),
        new Seat(11, 12, 12, false, TypeOfSeat.Couch),
        new Seat(11, 13, 13, false, TypeOfSeat.Couch, 14),
        new Seat(11, 14, 14, false, TypeOfSeat.Couch),
        new Seat(11, 15, 15, false, TypeOfSeat.Couch, 16),
        new Seat(11, 16, 16, false, TypeOfSeat.Couch),
        new Seat(11, 17, 17, false, TypeOfSeat.Couch, 18),
        new Seat(11, 18, 18, false, TypeOfSeat.Couch),

    };

    public static Dictionary<int, List<Seat>> InitialCinemaHallData()
    {
        CinemaHall.Add(1, Row1);
        CinemaHall.Add(2, Row2);
        CinemaHall.Add(3, Row3);
        CinemaHall.Add(4, Row4);
        CinemaHall.Add(5, Row5);
        CinemaHall.Add(6, Row6);
        CinemaHall.Add(7, Row7);
        CinemaHall.Add(8, Row8);
        CinemaHall.Add(9, Row9);
        CinemaHall.Add(10, Row10);
        CinemaHall.Add(11, Row11);

        return CinemaHall;
    }
}
