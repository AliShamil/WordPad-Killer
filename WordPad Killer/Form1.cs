using System.Drawing.Text;

namespace WordPad_Killer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string currentFont = "Segoe UI";
        float currentFontSize = 9F;
        FontStyle currentFontStyle = default;

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> fonts = new List<string>();

            foreach (var font in System.Drawing.FontFamily.Families)
            {
                combo_Font.Items.Add(font);
            }

            foreach (var fontstyle in Enum.GetValues<FontStyle>())
            {
                combo_Font_Style.Items.Add(fontstyle);
            }

            foreach (var align in Enum.GetValues<System.Windows.Forms.HorizontalAlignment>())
            {
                comboBox4.Items.Add(align);
            }

            combo_Font.Items.AddRange(fonts.ToArray());
            combo_Font.DisplayMember = "Name";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(saveFileDialog1.FileName);
                sw.Write(textBox1.Text);
            }

        }

        private void btn_load_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "All files|*.*|Text Files|*.txt";
            openFileDialog1.FilterIndex = 2;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    textBox1.Clear();
                StreamReader sr = new(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();
            }
        }



        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            switch (combo.SelectedItem.GetType().ToString())
            {
                case "System.String":
                    float.TryParse(combo.SelectedItem.ToString(), out currentFontSize);
                    break;
                case "System.Drawing.FontFamily":
                    currentFont = (combo.SelectedItem as FontFamily).Name;
                    break;
                case "System.Drawing.FontStyle":
                    currentFontStyle = (FontStyle)combo.SelectedItem;
                    break;

            }
            textBox1.Font = new System.Drawing.Font(currentFont, currentFontSize, currentFontStyle, System.Drawing.GraphicsUnit.Point);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign =  (HorizontalAlignment)comboBox4.SelectedItem;
        }
    }
}