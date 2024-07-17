using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            List<EntityEmployee> EmpList = LogicEmployee.LLEmployeeList();
            dataGridView1.DataSource = EmpList;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            EntityEmployee emp = new EntityEmployee();
            emp.Ad = TxtName.Text;
            emp.Soyad = TxtSurname.Text;
            emp.Sehir = TxtCity.Text;
            emp.Gorev = TxtDuty.Text;
            emp.Maas = Convert.ToInt32(TxtSalary.Text);
            LogicEmployee.LLEmployeeAdd(emp);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            EntityEmployee emp = new EntityEmployee();
            emp.Id = Convert.ToInt32(TxtId.Text);
            LogicEmployee.LLEmployeeDelete(emp.Id);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurname.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtDuty.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EntityEmployee emp = new EntityEmployee();
            emp.Id = Convert.ToInt32(TxtId.Text);
            emp.Ad = TxtName.Text;
            emp.Soyad = TxtSurname.Text;
            emp.Sehir = TxtCity.Text;
            emp.Gorev = TxtDuty.Text;
            emp.Maas = Convert.ToInt32(TxtSalary.Text);
            LogicEmployee.LLEmployeUpdate(emp);
        }
    }
}
