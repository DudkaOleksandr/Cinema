namespace KR_1._1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonCinema;
        private System.Windows.Forms.Button buttonMorning;
        private System.Windows.Forms.Button buttonDay;
        private System.Windows.Forms.Button buttonEvening;
        private System.Windows.Forms.Button buttonKungFuPanda;
        private System.Windows.Forms.Button buttonKlaus;
        private System.Windows.Forms.Button buttonDune;
        private System.Windows.Forms.Button buttonParasite;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonFindSeat;
        private System.Windows.Forms.Button buttonFreeSeats;
        private System.Windows.Forms.Button buttonSoldSeats;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxSeatInput;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelSeatInput;
        private System.Windows.Forms.ListBox seatListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonCinema = new System.Windows.Forms.Button();
            this.buttonMorning = new System.Windows.Forms.Button();
            this.buttonDay = new System.Windows.Forms.Button();
            this.buttonEvening = new System.Windows.Forms.Button();
            this.buttonKungFuPanda = new System.Windows.Forms.Button();
            this.buttonKlaus = new System.Windows.Forms.Button();
            this.buttonDune = new System.Windows.Forms.Button();
            this.buttonParasite = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.buttonReserve = new System.Windows.Forms.Button();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonFindSeat = new System.Windows.Forms.Button();
            this.buttonFreeSeats = new System.Windows.Forms.Button();
            this.buttonSoldSeats = new System.Windows.Forms.Button();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxSeatInput = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelSeatInput = new System.Windows.Forms.Label();
            this.seatListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // buttonCinema
            this.buttonCinema.Location = new System.Drawing.Point(350, 20);
            this.buttonCinema.Name = "buttonCinema";
            this.buttonCinema.Size = new System.Drawing.Size(100, 30);
            this.buttonCinema.TabIndex = 0;
            this.buttonCinema.Text = "Кінотеатр";
            this.buttonCinema.UseVisualStyleBackColor = true;
            this.buttonCinema.Click += new System.EventHandler(this.buttonCinema_Click);

            // buttonMorning
            this.buttonMorning.Location = new System.Drawing.Point(200, 20);
            this.buttonMorning.Name = "buttonMorning";
            this.buttonMorning.Size = new System.Drawing.Size(100, 30);
            this.buttonMorning.Text = "Ранковий сеанс";
            this.buttonMorning.UseVisualStyleBackColor = true;
            this.buttonMorning.Visible = false;
            this.buttonMorning.Click += new System.EventHandler(this.buttonMorning_Click);

            // buttonDay
            this.buttonDay.Location = new System.Drawing.Point(350, 20);
            this.buttonDay.Name = "buttonDay";
            this.buttonDay.Size = new System.Drawing.Size(100, 30);
            this.buttonDay.Text = "Денний сеанс";
            this.buttonDay.UseVisualStyleBackColor = true;
            this.buttonDay.Visible = false;
            this.buttonDay.Click += new System.EventHandler(this.buttonDay_Click);

            // buttonEvening
            this.buttonEvening.Location = new System.Drawing.Point(500, 20);
            this.buttonEvening.Name = "buttonEvening";
            this.buttonEvening.Size = new System.Drawing.Size(100, 30);
            this.buttonEvening.Text = "Вечірній сеанс";
            this.buttonEvening.UseVisualStyleBackColor = true;
            this.buttonEvening.Visible = false;
            this.buttonEvening.Click += new System.EventHandler(this.buttonEvening_Click);

            // buttonKungFuPanda
            this.buttonKungFuPanda.Location = new System.Drawing.Point(350, 20);
            this.buttonKungFuPanda.Name = "buttonKungFuPanda";
            this.buttonKungFuPanda.Size = new System.Drawing.Size(140, 30);
            this.buttonKungFuPanda.Text = "М/ф Кунг-Фу Панда";
            this.buttonKungFuPanda.UseVisualStyleBackColor = true;
            this.buttonKungFuPanda.Visible = false;
            this.buttonKungFuPanda.Click += new System.EventHandler(this.buttonKungFuPanda_Click);

            // buttonKlaus
            this.buttonKlaus.Location = new System.Drawing.Point(300, 20);
            this.buttonKlaus.Name = "buttonKlaus";
            this.buttonKlaus.Size = new System.Drawing.Size(100, 30);
            this.buttonKlaus.Text = "М/ф Клаус";
            this.buttonKlaus.UseVisualStyleBackColor = true;
            this.buttonKlaus.Visible = false;
            this.buttonKlaus.Click += new System.EventHandler(this.buttonKlaus_Click);

            // buttonDune
            this.buttonDune.Location = new System.Drawing.Point(420, 20);
            this.buttonDune.Name = "buttonDune";
            this.buttonDune.Size = new System.Drawing.Size(100, 30);
            this.buttonDune.Text = "Х/ф Дюна";
            this.buttonDune.UseVisualStyleBackColor = true;
            this.buttonDune.Visible = false;
            this.buttonDune.Click += new System.EventHandler(this.buttonDune_Click);

            // buttonParasite
            this.buttonParasite.Location = new System.Drawing.Point(350, 20);
            this.buttonParasite.Name = "buttonParasite";
            this.buttonParasite.Size = new System.Drawing.Size(100, 30);
            this.buttonParasite.Text = "Х/ф Паразити";
            this.buttonParasite.UseVisualStyleBackColor = true;
            this.buttonParasite.Visible = false;
            this.buttonParasite.Click += new System.EventHandler(this.buttonParasite_Click);

            // btnBack
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(775, 500);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);

            // btnExit
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(725, 540);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 30);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Завершити Перегляд";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // buttonReserve
            this.buttonReserve.Location = new System.Drawing.Point(30, 540);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(120, 30);
            this.buttonReserve.TabIndex = 11;
            this.buttonReserve.Text = "Забронювати місце";
            this.buttonReserve.UseVisualStyleBackColor = true;
            this.buttonReserve.Visible = false;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);

            // buttonBuy
            this.buttonBuy.Location = new System.Drawing.Point(160, 540);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(120, 30);
            this.buttonBuy.TabIndex = 12;
            this.buttonBuy.Text = "Купити квиток";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Visible = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(290, 540);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 30);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Відмінити бронювання";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // buttonInfo
            this.buttonInfo.Location = new System.Drawing.Point(450, 540);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(80, 30);
            this.buttonInfo.TabIndex = 14;
            this.buttonInfo.Text = "Інформація про сеанс";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Visible = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);

            // buttonFindSeat
            this.buttonFindSeat.Location = new System.Drawing.Point(540, 540);
            this.buttonFindSeat.Name = "buttonFindSeat";
            this.buttonFindSeat.Size = new System.Drawing.Size(120, 30);
            this.buttonFindSeat.TabIndex = 15;
            this.buttonFindSeat.Text = "Знайти місце";
            this.buttonFindSeat.UseVisualStyleBackColor = true;
            this.buttonFindSeat.Visible = false;
            this.buttonFindSeat.Click += new System.EventHandler(this.buttonFindSeat_Click);

            // buttonFreeSeats
            this.buttonFreeSeats.Location = new System.Drawing.Point(290, 510);
            this.buttonFreeSeats.Name = "buttonFreeSeats";
            this.buttonFreeSeats.Size = new System.Drawing.Size(100, 30);
            this.buttonFreeSeats.TabIndex = 16;
            this.buttonFreeSeats.Text = "Вільні місця";
            this.buttonFreeSeats.UseVisualStyleBackColor = true;
            this.buttonFreeSeats.Visible = false;
            this.buttonFreeSeats.Click += new System.EventHandler(this.buttonFreeSeats_Click);

            // buttonSoldSeats
            this.buttonSoldSeats.Location = new System.Drawing.Point(430, 510);
            this.buttonSoldSeats.Name = "buttonSoldSeats";
            this.buttonSoldSeats.Size = new System.Drawing.Size(100, 30);
            this.buttonSoldSeats.TabIndex = 17;
            this.buttonSoldSeats.Text = "Продані місця";
            this.buttonSoldSeats.UseVisualStyleBackColor = true;
            this.buttonSoldSeats.Visible = false;
            this.buttonSoldSeats.Click += new System.EventHandler(this.buttonSoldSeats_Click);

            // textBoxSurname
            this.textBoxSurname.Location = new System.Drawing.Point(30, 515);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(250, 20);
            this.textBoxSurname.TabIndex = 18;
            this.textBoxSurname.Visible = false;

            // textBoxSeatInput
            this.textBoxSeatInput.Location = new System.Drawing.Point(540, 515);
            this.textBoxSeatInput.Name = "textBoxSeatInput";
            this.textBoxSeatInput.Size = new System.Drawing.Size(120, 20);
            this.textBoxSeatInput.TabIndex = 19;
            this.textBoxSeatInput.Visible = false;

            // labelSurname
            this.labelSurname.Location = new System.Drawing.Point(30, 495);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(120, 20);
            this.labelSurname.TabIndex = 20;
            this.labelSurname.Text = "Введіть прізвище";
            this.labelSurname.Visible = false;

            // labelSeatInput
            this.labelSeatInput.Location = new System.Drawing.Point(540, 495);
            this.labelSeatInput.Name = "labelSeatInput";
            this.labelSeatInput.Size = new System.Drawing.Size(120, 20);
            this.labelSeatInput.TabIndex = 21;
            this.labelSeatInput.Text = "Введіть ряд та місце:";
            this.labelSeatInput.Visible = false;

            // seatListBox
            this.seatListBox.Location = new System.Drawing.Point(290, 350);
            this.seatListBox.Name = "seatListBox";
            this.seatListBox.Size = new System.Drawing.Size(310, 150);
            this.seatListBox.TabIndex = 22;
            this.seatListBox.Visible = false;
            this.seatListBox.ScrollAlwaysVisible = true;

            // Form1
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.buttonCinema);
            this.Controls.Add(this.buttonMorning);
            this.Controls.Add(this.buttonDay);
            this.Controls.Add(this.buttonEvening);
            this.Controls.Add(this.buttonKungFuPanda);
            this.Controls.Add(this.buttonKlaus);
            this.Controls.Add(this.buttonDune);
            this.Controls.Add(this.buttonParasite);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.buttonReserve);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonFindSeat);
            this.Controls.Add(this.buttonFreeSeats);
            this.Controls.Add(this.buttonSoldSeats);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxSeatInput);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelSeatInput);
            this.Controls.Add(this.seatListBox);
            this.Name = "Form1";
            this.Text = "Бронювання місць у кінотеатрі";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}