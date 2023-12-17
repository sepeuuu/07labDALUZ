using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07labDALUZ
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frmUpdateMember = new FrmUpdateMember();
            frmUpdateMember.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfMembers();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            RefreshListOfMembers();
        }

        private long StudentId;

        public FrmClubRegistration()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
            this.Load += FrmClubRegistration_Load;
        }
        public void RefreshListOfMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        private int RegistrationID()
        {
            count++;
            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            FirstName = txtFname.Text;
            MiddleName = txtMname.Text;
            LastName = txtLname.Text;
            Gender = cbGender.SelectedItem.ToString();
            Program = cbProgram.Text;

            Age = int.Parse(txtAge.Text);
            StudentId = long.Parse(txtStudID.Text);

            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);

            RefreshListOfMembers();
            Clear();
        }

        public void Clear()
        {
            txtStudID.Clear();
            txtLname.Clear();
            txtFname.Clear();
            txtMname.Clear();
            txtAge.Clear();
            cbGender.SelectedIndex = -1;
            cbProgram.SelectedIndex = -1;
        }
    }
}
