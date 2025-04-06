using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        private readonly OrderService _orderService = new OrderService();
        private BindingSource _ordersBinding = new BindingSource();
        private BindingSource _detailsBinding = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGrids();
            LoadData();
        }

        private void InitializeDataGrids()
        {
            // 配置订单DataGridView
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "OrderId", HeaderText = "订单号", Width = 80 },
                new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "客户名", Width = 150 },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderDate",
                    HeaderText = "日期",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    HeaderText = "总金额",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                }
            );

            // 配置明细DataGridView
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "商品名", Width = 150 },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "UnitPrice",
                    HeaderText = "单价",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "数量", Width = 60 },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Amount",
                    HeaderText = "金额",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                }
            );

            // 设置数据绑定
            _ordersBinding.DataSource = new List<Order>();
            dgvOrders.DataSource = _ordersBinding;

            _detailsBinding.DataSource = _ordersBinding;
            _detailsBinding.DataMember = "Details";
            dgvOrderDetails.DataSource = _detailsBinding;
        }

        private void LoadData()
        {
            _ordersBinding.DataSource = _orderService.GetAllOrders();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new EditOrderForm(new Order());
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _orderService.AddOrder(editForm.CurrentOrder);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_ordersBinding.Current is Order selectedOrder)
            {
                // 从数据库重新加载订单以避免并发问题
                var orderToEdit = _orderService.GetOrderById(selectedOrder.OrderId);
                var editForm = new EditOrderForm(orderToEdit);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _orderService.UpdateOrder(editForm.CurrentOrder);
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ordersBinding.Current is Order selectedOrder &&
                MessageBox.Show("确认删除此订单及其所有明细？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _orderService.DeleteOrder(selectedOrder.OrderId);
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                _ordersBinding.DataSource = _orderService.SearchOrders(keyword);
            }
            else
            {
                LoadData();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _orderService.Dispose();
            base.OnFormClosing(e);
        }
    }
}
