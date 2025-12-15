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
    public partial class frm_Update_Student : Form
    {
        public frm_Update_Student()
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

        private void frm_Update_Student_Load(object sender, EventArgs e)
        {
            lbl_LoginUser.Text = "Welcome" + A_Shared_Content.LoginUsername;

        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;

            }

        }

        private void Only_Text(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
            Disable_Controls();
            tb_Roll_No.Focus();

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            ACon_Start();

            if (tb_Roll_No.Text != "")
            {
                SqlCommand Cmd = new SqlCommand();

                Cmd.CommandText = "Select * From Student_Details Where Roll_No = @RNo";

                Cmd.Connection = ACon;

                Cmd.Parameters.Add("RNo", SqlDbType.Int).Value = tb_Roll_No.Text;

                SqlDataReader DR = Cmd.ExecuteReader();
                if (DR.Read())
                {
                    tb_Name.Text = DR.GetString(DR.GetOrdinal("Name"));
                    dtp_DOB.Text = DR["DOB"].ToString();
                    tb_Mob_No.Text = (DR["Mobile_No"].ToString());
                    cb_Course.Text = DR.GetString(DR.GetOrdinal("Course"));

                    Enable_Controls();
                }
                else
                {
                    MessageBox.Show("Invalid Roll No.", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Roll_No.Clear();
                }
            }

            ACon_Stop();
         }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            ACon_Start();

            if (tb_Roll_No.Text != "" && tb_Name.Text != "" && tb_Mob_No.Text != "" && cb_Course.SelectedIndex >= 0)
            {
                SqlCommand Cmd = new SqlCommand();

                Cmd.CommandText = "Update Into Student_Details(Roll _No, Name, Mobile_No, Date_Of_Birth, Course) Where (@RN0, @NM, @MNo, @Db, @Course)";
                Cmd.Connection = ACon;


                Cmd.Parameters.Add("RNO", System.Data.SqlDbType.Int).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("NM", System.Data.SqlDbType.VarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("MNo", System.Data.SqlDbType.Decimal).Value = tb_Mob_No.Text;
                Cmd.Parameters.Add("Db", System.Data.SqlDbType.Date).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("Course", System.Data.SqlDbType.NVarChar).Value = cb_Course.Text;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Student Details Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear_Controls();

            }
            else
            {
                MessageBox.Show("1st Fill all fields", "INCOMPLTE");

            }
            ACon_Stop();

        }

        private void btn_Add_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student Obj = new frm_Add_New_Student();
            Obj.Show();
            this.Hide();

        }

        private void btn_Search_Student_Click(object sender, EventArgs e)
        {
            frm_Search_Student Obj = new frm_Search_Student();
            Obj.Show();
            this.Hide();

        }

        private void btn_Student_List_Click(object sender, EventArgs e)
        {
            frm_Student_List Obj = new frm_Student_List();
            Obj.Show();
            this.Hide();

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            frm_Login Obj = new frm_Login();
            Obj.Show();
            this.Hide();

        }
    }
    
}
