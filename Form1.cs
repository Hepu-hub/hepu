namespace WinFormsApp1;

public partial class Form1 : Form
{
    public string str1;
    public string str2;
    public string strop;
    public Form1()
    {
        InitializeComponent();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        str1 = textBox1.Text.Trim();
    }
    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        strop = textBox3.Text.Trim();
    }
    private void textBox4_TextChanged(object sender, EventArgs e)
    {
        
    }
    /*
    private void button1_Click(object sender, EventArgs e)
    {
        double num1=double.Parse(str1);
        double num2=double.Parse(str2);
        double result = 0.0;
        switch (strop[0])
        {
            case '+': result = num1 + num2;
                break;
            case '-': result = num1 - num2;
                break;
            case '*': result = num1 * num2;
                break;
            case '/': result = num1 / num2;
                break;
        }
        textBox4.Text = result.ToString();
    }
    */
    private void button1_Click(object sender, EventArgs e)
    {
        //MessageBox.Show($"str1: '{str1}' str2: '{str2}'");
        // 使用 TryParse 安全地尝试将字符串转换为数字
        if (double.TryParse(str1, out double num1) && double.TryParse(str2, out double num2))
        {
            double result = 0.0;
            // 根据操作符进行计算
            switch (strop[0])
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        MessageBox.Show("除数不能为零！");
                        return;  // 如果除数为零，停止执行
                    }
                    break;
                default:
                    MessageBox.Show("无效的操作符！");
                    return;
            }
            // 显示结果
            textBox4.Text = result.ToString();
        }
        else
        {
            MessageBox.Show("请输入有效的数字！");
        }
    }

    private void textBox2_TextChanged_1(object sender, EventArgs e)
    {
        str2 = textBox2.Text;
    }
}