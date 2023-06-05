using System;
using System.Windows.Forms;

namespace RatioMaster {
  public partial class Prompt : Form {
    internal string Result = string.Empty;

    internal bool OK = false;

    public Prompt(string text, string labletext, string defvalue) {
      InitializeComponent();
      Text = text;
      label1.Text = labletext;
      textBox1.Text = defvalue;
    }

    private void button2_Click(object sender, EventArgs e) {
      Result = string.Empty;
    }

    private void button1_Click(object sender, EventArgs e) {
      Result = textBox1.Text;
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
      if (e.KeyChar == 13) {
        button1_Click(null, null);
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}