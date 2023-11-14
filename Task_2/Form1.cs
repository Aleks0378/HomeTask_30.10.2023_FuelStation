//1.ƒано приложение, в первой строке мы пишем любое слово, приложение,
//а во второй строке мы пишем какие-нибудь буквы и на выводе получаетс€ подсчЄт сколько этих букв встретилось в первой строке.
//Ќа форму добавить: 2 textBox, 1 button, 1 dataGridView.


using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        TextBox textBox1;
        TextBox textBox2;
        DataGridView dataGrid;

        public Form1()
        {
            InitializeComponent();
            Width = 760;
            Height = 500;
            FormBorderStyle= FormBorderStyle.Fixed3D;
            textBox1 = new TextBox()
            {
                Location = new Point(10, 10),
                Size = new Size(300, 100),
                Multiline = true,
                Text="Enter the words"
            };
            textBox2 = new TextBox()
            {
                Location = new Point(textBox1.Location.X+textBox1.Width+10, 10),
                Size = new Size(300, 50),
                Multiline = true,
                Text= "Enter the symbol or symbols"  
            };
            Button checkedButton = new Button()
            {
                Location = new Point(textBox2.Location.X+textBox2.Width+10, 10),
                Size = new Size(100, 50),
                Text= "Check"
            };
            dataGrid = new DataGridView()
            {
                ColumnCount = 3,
                Dock = DockStyle.Bottom,
                Size = new Size(ClientSize.Width, ClientSize.Height - textBox1.Height - 20)
                
        };
            
            dataGrid.Columns[0].HeaderText = "—трока 1";
            dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[1].HeaderText = "—трока 2";
            dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[2].HeaderText = "¬ывод";
            dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            this.Controls.AddRange(new Control[] { textBox1, textBox2, checkedButton, dataGrid } );
            checkedButton.Click += CheckedButton_Click;
        }

        private void CheckedButton_Click(object? sender, EventArgs e)
        {
            int quant = 0,i=0;
            string text = textBox1.Text;
            while ((i=text.IndexOf(textBox2.Text)) >= 0)
            {
                quant++;
                text = text.Substring(0, text.Length - i);
            }
            dataGrid.Rows.Add(textBox1.Text, textBox2.Text, quant.ToString());
        }
    }
}