namespace Provhanterare
{
    public partial class Form1 : Form
    {
        List<string> Awnsers;
        public Form1()
        {
            InitializeComponent();
            Awnsers = new List<string>();


        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            List<FlowLayoutPanel> groups = tablelayoutpanel.Controls.OfType<FlowLayoutPanel>().ToList();
            for (int i = 0; i < groups.Count; i++)
            {
                List<Control> control = groups[i].Controls.OfType<Control>().ToList();
                for (int j = 0; j < groups[i].Controls.Count; j++)
                {
                     
                    if (control[j] is RadioButton)
                    {
                        if (((RadioButton)control[j]).Checked)
                        {
                            string result = groups[i].Name + " " + control[j].Text;
                            if ((string)(control[j].Tag) == "1")
                            {
                                result += " rätt";
                            }
                            else
                            {
                                result += " fel";
                            }
                            Awnsers.Add(result);
                        }
                    }
                    else if(control[j] is TextBox && ((TextBox)control[j]).ReadOnly == false)
                    {
                        Awnsers.Add(groups[i].Name + " " + control[j].Text);
                    }  
                }
            }
            TextWriter tw = new StreamWriter("SavedList.txt");

            for(int i = 0; i < Awnsers.Count; i++)
            {
                tw.WriteLine(Awnsers[i]);
            }

            
            tw.Close();

            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.Show();
        }

        /*private void textBox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(((TextBox)sender).Text, ((TextBox)sender).Font);
            ((TextBox)sender).Width = size.Width;
            ((TextBox)sender).Height = size.Height;
        }
        */
    }
}