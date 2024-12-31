using System;
using System.Windows.Forms;

namespace CountdownToNewYear
{
    public partial class Form1 : Form
    {
        DateTime newYear;

        public Form1()
        {
            InitializeComponent();
            InitializeCountdown();
            UpdateLabel();
            Timer timer = new Timer();
            timer.Interval = 1000; // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeCountdown()
        {
            // Устанавливаем дату Нового года
            newYear = new DateTime(DateTime.Now.Year + 1, 1, 1);
        }

        private void UpdateLabel()
        {
            // Получаем текущую дату и время
            DateTime now = DateTime.Now;

            // Вычисляем разницу в времени
            TimeSpan timeUntilNewYear = newYear - now;

            // Формируем строку для вывода
            string countdownString = $"{timeUntilNewYear.Days} д {timeUntilNewYear.Hours} ч " +
                                      $"{timeUntilNewYear.Minutes} м {timeUntilNewYear.Seconds} с";

            // Обновляем текст label2
            label2.Text = countdownString;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateLabel();
        }
    }
}
