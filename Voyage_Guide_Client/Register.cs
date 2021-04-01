using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voyage_Guide_Client.Models;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;

namespace Voyage_Guide_Client
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/api/Register/");
                registerBtn.Enabled = false;
                UserRegister userRegister = new UserRegister()
                {
                    email = emailtextbox.Text,
                    firstName = fnametextbox.Text,
                    lastName = lnametextbox.Text,
                    password = passwordtextbpx.Text,
                    username = usernametextbox.Text,
                };



                //var result = client.PostAsync("newVoyageUser", new StringContent(
                //    new JavaScriptSerializer().Serialize(userRegister), Encoding.UTF8, "application/json")).Result;

                var result = await client.PostAsJsonAsync("newVoyageUser", userRegister);
                
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();

                    bool registrationResult = readTask.Result;

                    if (registrationResult)
                    {
                        login l = new login();
                        l.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Sorry User Cannot be registered,please try again later");
                    }
                }

            }
        }
    }
}
