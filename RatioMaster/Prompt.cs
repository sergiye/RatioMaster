using System;
using System.Windows.Forms;

namespace RatioMaster {
  public partial class Prompt : Form {
    internal string Result = string.Empty;

    internal bool OK = false;

    public Prompt(string text, string labelText, string defValue) {
      InitializeComponent();
      Text = text;
      label1.Text = labelText;
      textBox1.Text = defValue;
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      Result = string.Empty;
    }

    private void btnOk_Click(object sender, EventArgs e) {
      Result = textBox1.Text;
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
      if (e.KeyChar == 13) {
        btnOk_Click(null, null);
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}