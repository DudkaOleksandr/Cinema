using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace KR_1._1
{
    public class ReservationService
    {
        private readonly string _filePath;
        private List<Reservation> _reservations;
        private readonly object _lock = new object();

        public ReservationService()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reservations.json");
            _reservations = LoadReservations();
        }

        private List<Reservation> LoadReservations()
        {
            lock (_lock)
            {
                try
                {
                    if (File.Exists(_filePath))
                    {
                        string json = File.ReadAllText(_filePath);
                        return JsonConvert.DeserializeObject<List<Reservation>>(json) ?? new List<Reservation>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження резервувань: {ex.Message}", "Помилка");
                }
                return new List<Reservation>();
            }
        }

        private void SaveReservations()
        {
            lock (_lock)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(_reservations, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(_filePath, json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка збереження резервувань: {ex.Message}", "Помилка");
                }
            }
        }

        public List<Reservation> GetReservationsForSessionAndMovie(string session, string movie)
        {
            return _reservations
                .Where(r => r.Session == session && r.Movie == movie)
                .ToList();
        }

        public Reservation GetReservationBySeat(string seatNumber, string session, string movie)
        {
            return _reservations
                .FirstOrDefault(r => r.SeatNumber == seatNumber && r.Session == session && r.Movie == movie);
        }

        public void AddOrUpdateReservation(Reservation reservation)
        {
            lock (_lock)
            {
                var existing = _reservations
                    .FirstOrDefault(r => r.SeatNumber == reservation.SeatNumber &&
                                         r.Session == reservation.Session &&
                                         r.Movie == reservation.Movie);
                if (existing != null)
                {
                    _reservations.Remove(existing);
                }
                _reservations.Add(reservation);
                SaveReservations();
            }
        }

        public void DeleteReservation(string seatNumber, string session, string movie)
        {
            lock (_lock)
            {
                var existing = _reservations
                    .FirstOrDefault(r => r.SeatNumber == seatNumber && r.Session == session && r.Movie == movie);
                if (existing != null)
                {
                    _reservations.Remove(existing);
                    SaveReservations();
                }
            }
        }

        public bool IsSeatFree(string seatNumber, string session, string movie)
        {
            return GetReservationBySeat(seatNumber, session, movie) == null;
        }

        public List<string> GetFreeSeats(string session, string movie, int rows = 15, int columns = 10)
        {
            var reservedSeats = GetReservationsForSessionAndMovie(session, movie)
                .Select(r => r.SeatNumber)
                .ToHashSet();
            var freeSeats = new List<string>();
            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= columns; col++)
                {
                    string seat = string.Format("{0}-{1}", row, col);
                    if (!reservedSeats.Contains(seat))
                    {
                        freeSeats.Add(seat);
                    }
                }
            }
            return freeSeats
                .OrderBy(s => int.Parse(s.Split('-')[0]))
                .ThenBy(s => int.Parse(s.Split('-')[1]))
                .Select(s => string.Format("Ряд {0}, Місце {1}", s.Split('-')[0], s.Split('-')[1]))
                .ToList();
        }

        public List<string> GetSoldSeats(string session, string movie)
        {
            return GetReservationsForSessionAndMovie(session, movie)
                .Where(r => r.Status == "Purchased")
                .OrderBy(r => int.Parse(r.SeatNumber.Split('-')[0]))
                .ThenBy(r => int.Parse(r.SeatNumber.Split('-')[1]))
                .Select(r => string.Format("Ряд {0}, Місце {1}", r.SeatNumber.Split('-')[0], r.SeatNumber.Split('-')[1]))
                .ToList();
        }
    }
}