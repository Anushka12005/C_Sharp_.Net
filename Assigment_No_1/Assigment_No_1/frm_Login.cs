using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment_No_1
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            tb_Username.Focus();
        }

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            tb_Password.Enabled = true;
           
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (tb_Username.Text == "Admin" && tb_Password.Text == "a1234")  
            {
                MessageBox.Show("WELCOME", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm_Add_Student_Details Obj = new frm_Add_Student_Details();
                Obj.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect Username or Password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tb_Username.Clear();
            tb_Password.Clear();
            tb_Password.Enabled = false;
            btn_Submit.Enabled = false;


        }
    }
}
