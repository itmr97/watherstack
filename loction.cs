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
    public partial class loction : Form
    {
        country country;
        string city_name;
        string country_name;
        string full_name;
        List<string> listcountry=new List<string>();
        public loction()
        {
            InitializeComponent();
        }

        private async void loction_Load(object sender, EventArgs e)
        {
            await Task.Run(()=>load_data());
            await Task.Run(() => set_data());
            comboBox1.DataSource = listcountry;
        }
        private void load_data()
        {
            HttpHelper helper = new HttpHelper();
            var data = helper.json_conv("https://countriesnow.space/api/v0.1/countries/");
            country=Newtonsoft.Json.JsonConvert.DeserializeObject<country>(data);
        }
        private void set_data()
        {
                for (int i = 0; i < country.data.Length; i++) 
                {
                country_name = country.data[i].country;

                for (int j = 0; j < country.data[i].cities.Length; j++)
                {
                    city_name = country.data[i].cities[j];
                    full_name = city_name + ", " + country_name;
                    listcountry.Add(full_name);
                }

              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.fullname = comboBox1.Text;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.fullname != null)
            {

                MessageBox.Show("Loction saved,  "+Properties.Settings.Default.fullname);
                this.Close();


            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
