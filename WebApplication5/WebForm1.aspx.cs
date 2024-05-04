using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication5.BAL;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllRecords();
                ShowButtons();
                HideButtons();
                ResetForm();
            }
        }

        private void ShowButtons()
        {
            updateBtn.Enabled = true;
            deleteBtn.Enabled = true;
            insertBtn.Enabled = false;
        }
        private void HideButtons()
        {
            insertBtn.Enabled = true;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
        }

        private void ResetForm()
        {
            txtCustAdd.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtCustPhone.Text = string.Empty;
            txtCustEmail.Text = string.Empty;
            HideButtons();
            txtCustName.Focus();
        }
        protected void GetAllRecords()
        {
            BalCust obj = new BalCust();
            GridView1.DataSource = obj.GetCustomers();
            GridView1.DataBind();
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            BalCust obj = new BalCust();
            if (obj.CheckDuplicate(txtCustEmail.Text) > 0)
            {
                lblMsg.Text = "Email Already Exist !";
                return;
            }
            Customer cust = new Customer();
            cust.custEmail = txtCustEmail.Text;
            cust.custName = txtCustName.Text;
            cust.custAdd = txtCustAdd.Text;
            cust.custPhone = txtCustPhone.Text;
            obj.InsertCust(cust);
            lblMsg.Text = "Record Inserted";
            GetAllRecords();
            ResetForm();
            HideButtons();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.custId = Convert.ToInt32(txtCustId.Text);
            cust.custName = txtCustName.Text;
            cust.custAdd = txtCustAdd.Text;
            cust.custPhone = txtCustPhone.Text;
            cust.custEmail = txtCustEmail.Text;
            BalCust obj = new BalCust();
            obj.UpdateCust(cust);
            lblMsg.Text = "Record Updated";
            GetAllRecords();
            ResetForm();
            HideButtons();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            BalCust obj = new BalCust();
            obj.DeleteCust(Convert.ToInt32(txtCustId.Text));
            lblMsg.Text = "Record Deleted";
            GetAllRecords();
            ResetForm();
            HideButtons();
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowButtons();
            GridViewRow SelectedRow = GridView1.Rows[e.NewSelectedIndex];
            txtCustId.Text = SelectedRow.Cells[0].Text;
            txtCustName.Text = SelectedRow.Cells[1].Text;
            txtCustEmail.Text = SelectedRow.Cells[2].Text;
            txtCustPhone.Text = SelectedRow.Cells[3].Text;
            txtCustAdd.Text = SelectedRow.Cells[4].Text;
        }
    }
}