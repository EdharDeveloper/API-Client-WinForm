using API_Client_WinForm.ModelApi;
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
                
                ModelNews model = await _restClient.GetArticlsLastDayAsync(PeriodType.oneday);
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < model.results.Length; i++)
                {
                        str.Append(model.results[i].section+ 
                            Environment.NewLine+"<<"+model.results[i].title+">>"+
                            "  :"+ model.results[i].source+Environment.NewLine
                                    +"Date: " + model.results[i].published_date+"\n");
                    
                         //textBox1.Paste(Environment.NewLine);
                    
                    
                }
                textBox1.Text = str.ToString();
                //textBox1.Paste(
            }
            catch
            {
                textBox1.Text = "Error request";
            }


        }
    }
}
