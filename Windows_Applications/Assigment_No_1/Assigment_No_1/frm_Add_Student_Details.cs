using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace Assigment_No_1
{
    public partial class frm_Add_Student_Details : Form
    {
        public frm_Add_Student_Details()
        {
            InitializeComponent();
        }


        SqlConnection ACon = new SqlConnection(@"Data Source=LAPTOP-C60FO0NM;Initial Catalog=Fork_Admission_Assignment_System.db;Integrated Security=True");
        void ACon_Start()
        {
            if(ACon.State != ConnectionState.Open)
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

            Auto_Incr_RollNo();

            tb_Name.Clear();
            tb_Mob_No.Clear();
            cb_Course.SelectedIndex = -1;
            dtp_Date_Of_Birth.Text = "01-01-2000";
        }
        void Auto_Incr_RollNo()
        {
            ACon_Start();

            int No = 0;

            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = ACon;
            Cmd.CommandText = "Select Count(*) From Student_Details";

            No = Convert.ToInt32(Cmd.ExecuteScalar());
            Cmd.Dispose();

            if (No > 0)
            {
                Cmd.Connection = ACon;
                Cmd.CommandText = "Select Max(Roll_No) From Student_Details";

                No = Convert.ToInt32(Cmd.ExecuteScalar()) + 1;
            }
            else
            {
                No = 101;
            }
            tb_Roll_No.Text = Convert.ToString(No);
            ACon_Stop();
        }
       
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            frm_Login Obj = new frm_Login();
            Obj.Show();
            this.Hide();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ACon_Start();
            if (tb_Roll_No.Text != "" && tb_Name.Text != "" && tb_Mob_No.Text != "" && cb_Course.SelectedIndex >= 0)
            {
                SqlCommand Cmd = new SqlCommand();

                Cmd.CommandText = "Insert Into Student_Details(Roll _No, Name, Mobile_No, Date_Of_Birth, Course) Values(@RN0, @NM, @MNo, @Db, @Course)";
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
       
        private void btn_Student_List_Click(object sender, EventArgs e)
        {
            frm_Student_List Obj = new frm_Student_List();
            Obj.Show();
            this.Hide();

        }
        private void frm_Add_Student_Details_Load(object sender, EventArgs e)
        {
            Auto_Incr_RollNo();

        }
            private void F_Only_Text(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }

        }

        private void F_Only_Numeric(object sender, KeyPressEventArgs e)
        {
                if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                {
                    e.Handled = true;

                }
            

        }

        private void btn_Logout_Click_1(object sender, EventArgs e)
        {

        }
    }
}