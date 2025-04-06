using System;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class EditOrderForm : Form
    {
        public Order CurrentOrder { get; private set; }
        private BindingSource _detailsBinding = new BindingSource();

        public EditOrderForm(Order order)
        {
            InitializeComponent();
            CurrentOrder = order ?? new Order();
            InitializeBindings();
            InitializeDataGrid();
        }

        private void InitializeBindings()
        {
            txtOrderId.DataBindings.Add("Text", CurrentOrder, "OrderId");
            txtCustomerName.DataBindings.Add("Text", CurrentOrder, "CustomerName");
            dtpOrderDate.DataBindings.Add("Value", CurrentOrder, "OrderDate");

            _detailsBinding.DataSource = CurrentOrder.Details;
            dgvEditDetails.DataSource = _detailsBinding;
        }

        private void InitializeDataGrid()
        {
            dgvEditDetails.AutoGenerateColumns = false;
            dgvEditDetails.Columns.Clear();
            dgvEditDetails.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductName",
                    HeaderText = "商品名称",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "UnitPrice",
                    HeaderText = "单价",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "数量",
                    Width = 60
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Amount",
                    HeaderText = "金额",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                    Width = 80,
                    ReadOnly = true
                },
                new DataGridViewButtonColumn
                {
                    HeaderText = "操作",
                    Text = "删除",
                    UseColumnTextForButtonValue = true,
                    Width = 60
                }
            );
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            CurrentOrder.Details.Add(new OrderDetail
            {
                ProductName = "新商品",
                UnitPrice = 0,
                Quantity = 1
            });
            _detailsBinding.ResetBindings(false);
        }

        private void dgvEditDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 自动计算金额
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2) // UnitPrice 或 Quantity 列
            {
                var row = dgvEditDetails.Rows[e.RowIndex];
                if (row.DataBoundItem is OrderDetail detail)
                {
                    // 触发属性变更通知
                    if (e.ColumnIndex == 1) detail.UnitPrice = Convert.ToDecimal(row.Cells[1].Value);
                    else if (e.ColumnIndex == 2) detail.Quantity = Convert.ToInt32(row.Cells[2].Value);

                    row.Cells[3].Value = detail.Amount; // 更新金额显示
                }
            }
        }

        private void dgvEditDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 处理删除按钮点击
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // 删除按钮列
            {
                if (dgvEditDetails.Rows[e.RowIndex].DataBoundItem is OrderDetail detail)
                {
                    if (MessageBox.Show("确定删除此明细项？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CurrentOrder.Details.Remove(detail);
                        _detailsBinding.ResetBindings(false);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("客户名不能为空！");
                return;
            }

            if (CurrentOrder.Details.Count == 0)
            {
                MessageBox.Show("至少需要一个订单明细！");
                return;
            }

            // 检查明细项有效性
            foreach (var detail in CurrentOrder.Details)
            {
                if (string.IsNullOrWhiteSpace(detail.ProductName))
                {
                    MessageBox.Show("商品名称不能为空！");
                    return;
                }

                if (detail.UnitPrice <= 0)
                {
                    MessageBox.Show("单价必须大于零！");
                    return;
                }

                if (detail.Quantity <= 0)
                {
                    MessageBox.Show("数量必须大于零！");
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvEditDetails.CellEndEdit += dgvEditDetails_CellEndEdit;
            dgvEditDetails.CellContentClick += dgvEditDetails_CellContentClick;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dgvEditDetails.CellEndEdit -= dgvEditDetails_CellEndEdit;
            dgvEditDetails.CellContentClick -= dgvEditDetails_CellContentClick;
            base.OnFormClosing(e);
        }
    }
}