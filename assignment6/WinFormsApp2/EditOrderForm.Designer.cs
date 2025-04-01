namespace WinFormsApp2
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            txtCustomerName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtOrderId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            dgvEditDetails = new System.Windows.Forms.DataGridView();
            panel2 = new System.Windows.Forms.Panel();
            btnOK = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEditDetails).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpOrderDate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtCustomerName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtOrderId);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(917, 200);
            panel1.TabIndex = 0;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new System.Drawing.Point(642, 30);
            dtpOrderDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new System.Drawing.Size(217, 30);
            dtpOrderDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(550, 40);
            label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 24);
            label3.TabIndex = 4;
            label3.Text = "日期：";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new System.Drawing.Point(183, 100);
            txtCustomerName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new System.Drawing.Size(272, 30);
            txtCustomerName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(55, 110);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 24);
            label2.TabIndex = 2;
            label2.Text = "客户名：";
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new System.Drawing.Point(183, 30);
            txtOrderId.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new System.Drawing.Size(272, 30);
            txtOrderId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(55, 40);
            label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 24);
            label1.TabIndex = 0;
            label1.Text = "订单号：";
            // 
            // dgvEditDetails
            // 
            dgvEditDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvEditDetails.Location = new System.Drawing.Point(0, 200);
            dgvEditDetails.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            dgvEditDetails.Name = "dgvEditDetails";
            dgvEditDetails.RowHeadersWidth = 62;
            dgvEditDetails.Size = new System.Drawing.Size(917, 500);
            dgvEditDetails.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnOK);
            panel2.Controls.Add(btnCancel);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 700);
            panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(917, 100);
            panel2.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Location = new System.Drawing.Point(550, 20);
            btnOK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(147, 60);
            btnOK.TabIndex = 0;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(733, 20);
            btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(147, 60);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditOrderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(917, 800);
            Controls.Add(dgvEditDetails);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            Text = "编辑订单";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEditDetails).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEditDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}