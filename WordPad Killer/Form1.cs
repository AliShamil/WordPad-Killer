using System.Drawing.Text;

namespace WordPad_Killer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<FontFamily> fonts = new List<FontFamily>();
            List<string> fontstyles = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font);
            }

            

            combo_Font.Items.AddRange(fonts.ToArray());
            combo_Font.DisplayMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_Font.SelectedItem is not null)
            //    richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(combo_Font.SelectedItem), richTextBox1.Font.Style);
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
            }

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files|*.*|Text Files|*.txt";
            openFileDialog1.FilterIndex = 2;

            // openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
            }
        }

        //private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    textBox1.Font = new Font(textBox1.Font.FontFamily, Convert.ToInt32(comboBox1.SelectedItem), textBox1.Font.Style);
        //}
    }
}