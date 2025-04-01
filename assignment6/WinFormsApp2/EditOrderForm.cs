using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class EditOrderForm : Form
    {
        public Order CurrentOrder;
        private BindingSource bsDetails = new BindingSource();

        public EditOrderForm(Order order)
        {
            InitializeComponent();
            CurrentOrder = order;
            SetupDataBindings();
        }
        private void SetupDataBindings()
        {
            txtOrderId.DataBindings.Add("Text", CurrentOrder, "OrderId");
            txtCustomerName.DataBindings.Add("Text", CurrentOrder, "CustomerName");
            dtpOrderDate.DataBindings.Add("Value", CurrentOrder, "OrderDate");

            bsDetails.DataSource = CurrentOrder.Details;
            dgvEditDetails.DataSource = bsDetails;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("请输入客户名!");
                return;
            }

            if (CurrentOrder.Details.Count == 0)
            {
                MessageBox.Show("请添加至少一个订单明细!");
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}