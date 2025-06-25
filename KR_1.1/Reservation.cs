using System;

namespace KR_1._1
{
    [Serializable]
    public class Reservation
    {
        public string SeatNumber { get; set; } // e.g., "5-3"
        public string Surname { get; set; }
        public string Status { get; set; } // "Reserved" or "Purchased"
        public string Session { get; set; } // e.g., "Ранковий сеанс"
        public string Movie { get; set; } // e.g., "М/ф Кунг-Фу Панда"
        public DateTime Timestamp { get; set; } // When reservation was made
    }
}