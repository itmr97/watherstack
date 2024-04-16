using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watherstack
{
    public partial class main : Form
    {
        WeatherData weather;
        string fullname;
        public main()
        {
            InitializeComponent();
        }

        private async void main_Load(object sender, EventArgs e)
        {
            fullname=Properties.Settings.Default.fullname;
            await Task.Run(() => load_data());
            set_data();
        }
        private void load_data()
        {
            var url = "http://api.weatherstack.com/current?access_key=40b78a90574fe5a50bcff1d850aa457e& query="+fullname;
            HttpHelper helper = new HttpHelper();
            var data = helper.json_conv(url);
            weather = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(data);
        }
        private void set_data()
        {
            city_name.Text=weather.request.query;
            lb_dec.Text=string.Join("",weather.current.weather_descriptions);
            vac_state.ImageLocation=string.Join("",weather.current.weather_icons);
            temp.Text = weather.current.temperature.ToString();
            wind.Text = weather.current.wind_speed.ToString();
            humidity.Text = weather.current.humidity.ToString();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loction fml= new loction();
            fml.Show();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            fullname = Properties.Settings.Default.fullname;
            await Task.Run(() => load_data());
            set_data();

        }
    }
}
