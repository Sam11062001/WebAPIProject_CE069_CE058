using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel;
using Voyage_Guide_Client.Model;
using System.Net.Http;

namespace Voyage_Guide_Client
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        [Obsolete]
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            guna2Button1.Enabled = false;
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            AuthenticateUser user = new AuthenticateUser();

            try
            {
               user.username = username;
                user.password = password;
                Boolean VoyageisAuthenticated = false;
                
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44302/api/Auth/");

                    var result =  await client.PostAsJsonAsync("VoyageLogin", user);

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<int>();
                        readTask.Wait();

                        int UserID = readTask.Result;


                        if (UserID == 0)
                        {
                            label3.Visible = true;
                            guna2Button1.Enabled = true;
                        }
                        else
                        {
                            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            config.AppSettings.Settings.Add("UVID100", UserID.ToString());
                            config.Save(ConfigurationSaveMode.Minimal);
                            ConfigurationManager.RefreshSection("appSettings");
                            int UseridReterived = Int32.Parse(ConfigurationSettings.AppSettings["UVID100"]);
                            dashboard d = new dashboard();
                            d.Show();
                            this.Hide();
                        }
                    }

                    

                }


                

            }
            catch(TimeoutException execption)
            {
                MessageBox.Show("Error Occured :" + execption.Message);
            }





        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r1 = new Register();
            r1.Show();
            this.Hide();
        }
    }
}
