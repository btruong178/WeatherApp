using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using System.IO;
using WeatherApp.OpenWeather_API;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        // Replace TextBox with ComboBox for city selection
        private ComboBox cmbCity;
        private Button btnGetWeather;
        private Label lblWeather;

        // Define the API key as a private field
        private readonly string OPENWEATHER_API_KEY;
        string workingDirectory = Directory.GetCurrentDirectory();
        string envPath = Path.Combine(Directory.GetCurrentDirectory(), "../../.env");


        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Env.Load();

            // Load the API key from environment variables
            OPENWEATHER_API_KEY = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");

            if (string.IsNullOrEmpty(OPENWEATHER_API_KEY))
            {
                MessageBox.Show("API key is missing. Please set the OPENWEATHER_API_KEY environment variable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void InitializeCustomComponents()
        {
            // ComboBox for selecting the city
            cmbCity = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList // Prevents user from typing
            };

            // Add some example cities to the ComboBox
            cmbCity.Items.Add("New York");
            cmbCity.Items.Add("London");
            cmbCity.Items.Add("Philadelphia");
            cmbCity.Items.Add("Lancaster");
            cmbCity.SelectedIndex = 0; // Select the first city by default

            // Button to get the weather information
            btnGetWeather = new Button
            {
                Text = "Get Weather",
                Location = new System.Drawing.Point(230, 20)
            };
            btnGetWeather.Click += async (s, e) => await BtnGetWeather_Click(s, e);
            Console.WriteLine(btnGetWeather.ToString());

            // Label to display weather info
            lblWeather = new Label
            {
                Text = "Weather info will display here",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            // Add the controls to the form
            Controls.Add(cmbCity);
            Controls.Add(btnGetWeather);
            Controls.Add(lblWeather);
        }

        private async Task BtnGetWeather_Click(object sender, EventArgs e)
        {
            // Get selected city from the ComboBox
            string city = cmbCity.SelectedItem.ToString();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={OPENWEATHER_API_KEY}&units=metric";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    // For simplicity, display raw JSON. You can later parse this into objects.
                    lblWeather.Text = result;
                }
                catch (Exception ex)
                {
                    lblWeather.Text = $"Error: {ex.Message}";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterControl(lblWeather);
        }

        private void CenterControl(Control ctrl)
        {
            int x = (this.ClientSize.Width - ctrl.Width) / 2;
            int y = (this.ClientSize.Height - ctrl.Height) / 2;
            ctrl.Location = new System.Drawing.Point(x, y);
        }
    }
}
