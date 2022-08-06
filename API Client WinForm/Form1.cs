using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Client_WinForm
{
    public partial class Form1 : Form
    {
        APIServes _restClient;
        public Form1()
        {
            
            InitializeComponent();
            _restClient = new APIServes("N6pqf6rGsbEUNP2ZzQMSauT98K0rDJQX");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void  button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string json = await _restClient.GetArticlsLastDayAsync(PeriodType.oneday);
                textBox1.Text = json;
            }
            catch
            {
                textBox1.Text = "Error request";
            }


        }
    }
}
