namespace WinFormsApp1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBox4 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(63, 138);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(213, 30);
        textBox1.TabIndex = 0;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(460, 138);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(234, 30);
        textBox2.TabIndex = 1;
        textBox2.TextChanged += textBox2_TextChanged_1;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(247, 263);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(217, 30);
        textBox3.TabIndex = 2;
        textBox3.TextChanged += textBox3_TextChanged;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(461, 111);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(232, 27);
        label2.TabIndex = 4;
        label2.Text = "Please enter a num2";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(65, 104);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(210, 34);
        label1.TabIndex = 5;
        label1.Text = "Please enter a num1";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(241, 226);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(222, 37);
        label3.TabIndex = 6;
        label3.Text = "Please enter a op";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(247, 340);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(368, 42);
        label4.TabIndex = 7;
        label4.Text = "        result";
        // 
        // textBox4
        // 
        textBox4.Location = new System.Drawing.Point(257, 391);
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(193, 30);
        textBox4.TabIndex = 8;
        textBox4.TextChanged += textBox4_TextChanged;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(358, 322);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(104, 50);
        button1.TabIndex = 9;
        button1.Text = "click";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button1);
        Controls.Add(textBox4);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox4;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox textBox3;

    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.TextBox textBox1;

    #endregion
}