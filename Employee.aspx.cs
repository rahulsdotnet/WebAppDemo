using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace WebDemo
{
    public partial class Employee : System.Web.UI.Page
    {
        public EmployeeService employeeSerive = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllEmployee();
            }
        }

        private void BindEmployeeGridView(DataTable table)
        {
            gvEmployee.DataSource = table;
            gvEmployee.DataBind();
        }

        private void GetAllEmployee()
        {
            employeeSerive = new EmployeeService();
            DataTable table = employeeSerive.GetEmployees();
            BindEmployeeGridView(table);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    employeeSerive = new EmployeeService();
                    DataTable table = employeeSerive.GetByEmployeeId(Convert.ToInt32(txtSearch.Text));
                    BindEmployeeGridView(table);
                }
                else
                {
                    GetAllEmployee();
                }
            }
            catch (Exception exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + exception.Message + "\");", true);
            }

        }


    }
}