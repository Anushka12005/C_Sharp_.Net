using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assigment_No2
{
    public partial class frm_Search_Student : Form
    {
        public frm_Search_Student()
        {
            InitializeComponent();
        }
        SqlConnection ACon = new SqlConnection(@"Data Source=LAPTOP-C60FO0NM;Initial Catalog=Fork_Admission_Assignment_System.db;Integrated Security=True");

        void ACon_Start()
        {
            if (ACon.State != ConnectionState.Open)
            {
                ACon.Open();
            }
        }
        void ACon_Stop()
        {
            if (ACon.State != ConnectionState.Closed)
            {
                ACon.Close();
            }
        }
        void Clear_Controls()
        {
            tb_Roll_No.Clear();
            tb_Name.Clear();
            tb_Mob_No.Clear();
            cb_Course.SelectedIndex = -1;

            dtp_DOB.Text = "01-02-2001";
        }
        void Enable_Controls()
        {
            tb_Name.Enabled = true;
            tb_Mob_No.Enabled = true;
            dtp_DOB.Enabled = true;
            cb_Course.Enabled = true;

            tb_Roll_No.Enabled = false;
        }
        void Disable_Controls()
        {
            tb_Name.Enabled = false;
            tb_Mob_No.Enabled = false;
            dtp_DOB.Enabled = false;
            cb_Course.Enabled = false;

            tb_Roll_No.Enabled = true;
        }

        private void frm_Search_Student_Load(object sender, EventArgs e)
        {
            lbl_LoginUser.Text = "Welcome" + A_Shared_Content.LoginUsername;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
            Disable_Controls();
            tb_Roll_No.Focus();
        }
    }
}
