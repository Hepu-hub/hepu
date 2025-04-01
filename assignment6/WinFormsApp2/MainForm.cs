using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        private BindingSource bsOrders = new BindingSource();
        private BindingSource bsOrderDetails = new BindingSource();
        private OrderService orderService = new OrderService();

        public MainForm()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupBindings();
            LoadOrders();
        }

        private void SetupDataGridView()
        {
            // 订单列表DataGridView设置
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderId",
                HeaderText = "订单号",
                Width = 100
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CustomerName",
                HeaderText = "客户名",
                Width = 150
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderDate",
                HeaderText = "日期",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "yyyy-MM-dd" }
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "总金额",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            // 订单明细DataGridView设置
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductName",
                HeaderText = "商品名",
                Width = 150
            });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Price",
                HeaderText = "单价",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Width = 80
            });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "金额",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
        }

        private void SetupBindings()
        {
            bsOrders.DataSource = orderService.orders;
            dgvOrders.DataSource = bsOrders;
            bsOrderDetails.DataSource =orderService.Details;
            dgvOrderDetails.DataSource = bsOrderDetails;
        }

        private void LoadOrders()
        {
            bsOrders.DataSource = null;
            bsOrders.DataSource = orderService.orders;
            bsOrders.ResetBindings(false); // 强制刷新绑定
            bsOrderDetails.DataSource = null;
            bsOrderDetails.DataSource = orderService.Details;
            bsOrderDetails.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new EditOrderForm(new Order());
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(editForm.CurrentOrder);
                foreach (var VARIABLE in editForm.CurrentOrder.Details)
                {
                    orderService.Details.Add(VARIABLE);
                }
                LoadOrders();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bsOrders.Current == null) return;

            var editForm = new EditOrderForm((Order)bsOrders.Current);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(editForm.CurrentOrder);
                LoadOrders();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bsOrders.Current == null) return;

            if (MessageBox.Show("确定要删除此订单吗?", "确认", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                orderService.RemoveOrder(((Order)bsOrders.Current).OrderId);
                LoadOrders();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadOrders();
            }
            else
            {
                bsOrders.DataSource = orderService.QueryByCustomerName(txtSearch.Text);
            }
        }
    }
}