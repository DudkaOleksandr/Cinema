using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KR_1._1
{
    public partial class Form1 : Form
    {
        private List<Button> seatButtons = new List<Button>();
        private int phase = 1; // 1 - Cinema, 2 - Sessions, 3 - Movies, 4 - Seats
        private string selectedSession = ""; // Для збереження вибраного сеансу
        private string selectedMovie = ""; // Для збереження вибраного фільму
        private Button selectedSeat = null; // Для відстеження вибраного місця
        private bool isFreeSeatsListVisible = false; // Для відстеження стану списку вільних місць
        private bool isSoldSeatsListVisible = false; // Для відстеження стану списку проданих місць
        private ReservationService reservationService; // Сервіс для роботи з базою даних

        public Form1()
        {
            InitializeComponent();
            reservationService = new ReservationService();
            // Загрузка встроенного фона из Resources
            this.BackgroundImage = Properties.Resources.MyBackground;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void buttonCinema_Click(object sender, EventArgs e)
        {
            phase = 2;
            buttonCinema.Visible = false;

            buttonMorning.Visible = true;
            buttonDay.Visible = true;
            buttonEvening.Visible = true;
        }

        private void buttonMorning_Click(object sender, EventArgs e)
        {
            phase = 3;
            selectedSession = "Ранковий сеанс";

            HideSessionButtons();
            buttonKungFuPanda.Visible = true;
        }

        private void buttonDay_Click(object sender, EventArgs e)
        {
            phase = 3;
            selectedSession = "Денний сеанс";

            HideSessionButtons();
            buttonKlaus.Visible = true;
            buttonDune.Visible = true;
        }

        private void buttonEvening_Click(object sender, EventArgs e)
        {
            phase = 3;
            selectedSession = "Вечірній сеанс";

            HideSessionButtons();
            buttonParasite.Visible = true;
        }

        private void buttonKungFuPanda_Click(object sender, EventArgs e)
        {
            phase = 4;
            selectedMovie = "М/ф Кунг-Фу Панда";
            HideMovieButtons();
            GenerateSeats();
            ShowReservationControls();
        }

        private void buttonKlaus_Click(object sender, EventArgs e)
        {
            phase = 4;
            selectedMovie = "М/ф Клаус";
            HideMovieButtons();
            GenerateSeats();
            ShowReservationControls();
        }

        private void buttonDune_Click(object sender, EventArgs e)
        {
            phase = 4;
            selectedMovie = "Х/ф Дюна";
            HideMovieButtons();
            GenerateSeats();
            ShowReservationControls();
        }

        private void buttonParasite_Click(object sender, EventArgs e)
        {
            phase = 4;
            selectedMovie = "Х/ф Паразити";
            HideMovieButtons();
            GenerateSeats();
            ShowReservationControls();
        }

        private void HideSessionButtons()
        {
            buttonMorning.Visible = false;
            buttonDay.Visible = false;
            buttonEvening.Visible = false;
        }

        private void HideMovieButtons()
        {
            buttonKungFuPanda.Visible = false;
            buttonKlaus.Visible = false;
            buttonDune.Visible = false;
            buttonParasite.Visible = false;
        }

        private void ShowReservationControls()
        {
            buttonReserve.Visible = true;
            buttonBuy.Visible = true;
            buttonCancel.Visible = true;
            buttonInfo.Visible = true;
            buttonFindSeat.Visible = true;
            buttonFreeSeats.Visible = true;
            buttonSoldSeats.Visible = true;
            textBoxSurname.Visible = true;
            textBoxSeatInput.Visible = true;
            labelSurname.Visible = true;
            labelSeatInput.Visible = true;
        }

        private void HideReservationControls()
        {
            buttonReserve.Visible = false;
            buttonBuy.Visible = false;
            buttonCancel.Visible = false;
            buttonInfo.Visible = false;
            buttonFindSeat.Visible = false;
            buttonFreeSeats.Visible = false;
            buttonSoldSeats.Visible = false;
            seatListBox.Visible = false;
            isFreeSeatsListVisible = false;
            isSoldSeatsListVisible = false;
            textBoxSurname.Visible = false;
            textBoxSeatInput.Visible = false;
            labelSurname.Visible = false;
            labelSeatInput.Visible = false;
            textBoxSurname.Text = "";
            textBoxSeatInput.Text = "";
            selectedSeat = null;
        }

        private void GenerateSeats()
        {
            int rows = 15;
            int columns = 10;
            int startX = 30;
            int startY = 70;
            int buttonWidth = 70;
            int buttonHeight = 25;
            int spacing = 3;

            foreach (var btn in seatButtons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            seatButtons.Clear();

            var reservations = reservationService.GetReservationsForSessionAndMovie(selectedSession, selectedMovie);

            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= columns; col++)
                {
                    Button seat = new Button();
                    seat.Size = new Size(buttonWidth, buttonHeight);
                    seat.Location = new Point(startX + (col - 1) * (buttonWidth + spacing),
                                              startY + (row - 1) * (buttonHeight + spacing));
                    seat.Text = string.Format("{0}-{1}", row, col);
                    var reservation = reservations.FirstOrDefault(r => r.SeatNumber == seat.Text);
                    seat.BackColor = reservation == null ? Color.LightGreen :
                                     reservation.Status == "Reserved" ? Color.Yellow : Color.Red;
                    seat.Click += Seat_Click;
                    this.Controls.Add(seat);
                    seatButtons.Add(seat);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button clickedSeat = sender as Button;
            if (clickedSeat != selectedSeat)
            {
                if (selectedSeat != null)
                {
                    selectedSeat.FlatStyle = FlatStyle.Standard;
                }
                clickedSeat.FlatStyle = FlatStyle.Popup;
                selectedSeat = clickedSeat;
            }
            else
            {
                clickedSeat.FlatStyle = FlatStyle.Standard;
                selectedSeat = null;
            }
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            if (selectedSeat == null)
            {
                MessageBox.Show("Будь ласка, виберіть місце.", "Помилка");
                return;
            }

            if (!reservationService.IsSeatFree(selectedSeat.Text, selectedSession, selectedMovie))
            {
                MessageBox.Show("Це місце вже заброньовано або куплено.", "Помилка");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Будь ласка, введіть прізвище.", "Помилка");
                return;
            }

            var reservation = new Reservation
            {
                SeatNumber = selectedSeat.Text,
                Surname = textBoxSurname.Text,
                Status = "Reserved",
                Session = selectedSession,
                Movie = selectedMovie,
                Timestamp = DateTime.UtcNow
            };

            reservationService.AddOrUpdateReservation(reservation);
            selectedSeat.BackColor = Color.Yellow;
            selectedSeat.FlatStyle = FlatStyle.Standard;
            MessageBox.Show(string.Format("Місце {0} успішно заброньовано для {1}!", selectedSeat.Text, textBoxSurname.Text), "Успіх");
            selectedSeat = null;
            textBoxSurname.Text = "";
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (selectedSeat == null)
            {
                MessageBox.Show("Будь ласка, виберіть місце.", "Помилка");
                return;
            }

            var existingReservation = reservationService.GetReservationBySeat(selectedSeat.Text, selectedSession, selectedMovie);
            if (existingReservation != null && existingReservation.Status == "Purchased")
            {
                MessageBox.Show("Це місце вже куплено.", "Помилка");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Будь ласка, введіть прізвище.", "Помилка");
                return;
            }

            var reservation = new Reservation
            {
                SeatNumber = selectedSeat.Text,
                Surname = textBoxSurname.Text,
                Status = "Purchased",
                Session = selectedSession,
                Movie = selectedMovie,
                Timestamp = DateTime.UtcNow
            };

            reservationService.AddOrUpdateReservation(reservation);
            selectedSeat.BackColor = Color.Red;
            selectedSeat.FlatStyle = FlatStyle.Standard;
            MessageBox.Show(string.Format("Місце {0} успішно куплено для {1}!", selectedSeat.Text, textBoxSurname.Text), "Успіх");
            selectedSeat = null;
            textBoxSurname.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (selectedSeat == null)
            {
                MessageBox.Show("Будь ласка, виберіть місце.", "Помилка");
                return;
            }

            var reservation = reservationService.GetReservationBySeat(selectedSeat.Text, selectedSession, selectedMovie);
            if (reservation == null)
            {
                MessageBox.Show("Це місце не є заброньованим або купленим.", "Помилка");
                return;
            }

            reservationService.DeleteReservation(selectedSeat.Text, selectedSession, selectedMovie);
            selectedSeat.BackColor = Color.LightGreen;
            selectedSeat.FlatStyle = FlatStyle.Standard;
            MessageBox.Show(string.Format("Бронювання або покупку місця {0} відмінено!", selectedSeat.Text), "Успіх");
            selectedSeat = null;
            textBoxSurname.Text = "";
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (phase != 4)
            {
                MessageBox.Show("Інформація доступна лише на етапі вибору місць.", "Помилка");
                return;
            }

            var reservations = reservationService.GetReservationsForSessionAndMovie(selectedSession, selectedMovie);
            int freeSeats = 150 - reservations.Count; // 15 rows * 10 columns
            int reservedSeats = reservations.Count(r => r.Status == "Reserved");
            int purchasedSeats = reservations.Count(r => r.Status == "Purchased");

            string message = string.Format(
                "Сеанс: {0}\nФільм: {1}\nВільні місця: {2}\nЗаброньовані місця: {3}\nКуплені квитки: {4}",
                selectedSession, selectedMovie, freeSeats, reservedSeats, purchasedSeats);

            MessageBox.Show(message, "Інформація про сеанс");
        }

        private void buttonFindSeat_Click(object sender, EventArgs e)
        {
            if (phase != 4)
            {
                MessageBox.Show("Пошук місць доступний лише на етапі вибору місць.", "Помилка");
                return;
            }

            string input = textBoxSeatInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Будь ласка, введіть місце у форматі 'ряд-місце' (наприклад, 15-2).", "Помилка");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d+-\d+$"))
            {
                MessageBox.Show("Неправильний формат. Введіть місце у форматі 'ряд-місце' (наприклад, 15-2).", "Помилка");
                return;
            }

            string[] parts = input.Split('-');
            int row;
            int col;
            if (!int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out col))
            {
                MessageBox.Show("Ряд і місце мають бути числами.", "Помилка");
                return;
            }

            if (row < 1 || row > 15 || col < 1 || col > 10)
            {
                MessageBox.Show(string.Format("Місце {0} не існує. Ряд має бути від 1 до 15, місце від 1 до 10.", input), "Помилка");
                return;
            }

            var reservation = reservationService.GetReservationBySeat(input, selectedSession, selectedMovie);
            string status = reservation == null ? "вільне" :
                            reservation.Status == "Reserved" ? "заброньоване" : "куплене";

            MessageBox.Show(string.Format("Місце {0}: {1}", input, status), "Статус місця");
        }

        private void buttonFreeSeats_Click(object sender, EventArgs e)
        {
            if (phase != 4)
            {
                MessageBox.Show("Перегляд вільних місць доступний лише на етапі вибору місць.", "Помилка");
                return;
            }

            if (isFreeSeatsListVisible)
            {
                seatListBox.Visible = false;
                isFreeSeatsListVisible = false;
                return;
            }

            seatListBox.Visible = false;
            seatListBox.Items.Clear();
            var freeSeats = reservationService.GetFreeSeats(selectedSession, selectedMovie);

            foreach (var seat in freeSeats)
            {
                seatListBox.Items.Add(seat);
            }

            seatListBox.Visible = true;
            isFreeSeatsListVisible = true;
            isSoldSeatsListVisible = false;
            if (seatListBox.Items.Count == 0)
            {
                seatListBox.Items.Add("Немає вільних місць.");
            }
        }

        private void buttonSoldSeats_Click(object sender, EventArgs e)
        {
            if (phase != 4)
            {
                MessageBox.Show("Перегляд проданих місць доступний лише на етапі вибору місць.", "Помилка");
                return;
            }

            if (isSoldSeatsListVisible)
            {
                seatListBox.Visible = false;
                isSoldSeatsListVisible = false;
                return;
            }

            seatListBox.Visible = false;
            seatListBox.Items.Clear();
            var soldSeats = reservationService.GetSoldSeats(selectedSession, selectedMovie);

            foreach (var seat in soldSeats)
            {
                seatListBox.Items.Add(seat);
            }

            seatListBox.Visible = true;
            isSoldSeatsListVisible = true;
            isFreeSeatsListVisible = false;
            if (seatListBox.Items.Count == 0)
            {
                seatListBox.Items.Add("Немає проданих місць.");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            HideReservationControls();

            foreach (var btn in seatButtons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            seatButtons.Clear();

            HideSessionButtons(); // Скидаємо видимість усіх кнопок сеансів
            HideMovieButtons();  // Скидаємо видимість усіх кнопок фільмів

            if (phase == 4)
            {
                phase = 3;
                selectedMovie = null;
                ShowMoviesForSession();
            }
            else if (phase == 3)
            {
                phase = 2;
                selectedSession = null;
                buttonMorning.Visible = true;
                buttonDay.Visible = true;
                buttonEvening.Visible = true;
            }
            else if (phase == 2)
            {
                phase = 1;
                buttonCinema.Visible = true;
            }
        }

        private void ShowMoviesForSession()
        {
            if (string.IsNullOrEmpty(selectedSession)) return;

            switch (selectedSession)
            {
                case "Ранковий сеанс":
                    buttonKungFuPanda.Visible = true;
                    break;
                case "Денний сеанс":
                    buttonKlaus.Visible = true;
                    buttonDune.Visible = true;
                    break;
                case "Вечірній сеанс":
                    buttonParasite.Visible = true;
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}