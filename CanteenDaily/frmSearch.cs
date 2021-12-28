using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanteenDaily
{
    public partial class frmSearch : Form
    {
        public event SearchContextChangedHandler TextChanged;

        private void BuildControls(List<field> fields)
        {
            int top = 10;
            bool focused = false;

            #region loop for each field
            foreach (field f in fields)
            {
                Label label = new Label();
                label.Text = f.FrielndlyName + ":";
                label.Top = top;
                label.Left = 5;
                label.AutoSize = true;
                this.Controls.Add(label);

                TextBox textbox = new TextBox();
                textbox.TextChanged += new EventHandler(textBox_TextChanged);
                textbox.Tag = f.Field;
                textbox.Top = top;
                textbox.Left = 120;
                textbox.Width = this.Width - 100;

                if (!focused)
                {
                    textbox.Focus();
                    focused = true;
                }

                top += 35;
                this.Controls.Add(textbox);
            }
            #endregion

            this.Height = top + 30;
        }

        public frmSearch(List<field> fields)
        {
            InitializeComponent();
            BuildControls(fields);
        }

        private List<field> GetFilterValues()
        {
            List<field> fields = new List<field>();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    field f = new field();
                    f.Field = ctrl.Tag.ToString();
                    f.Value = ctrl.Text;
                    fields.Add(f);
                }
            }
            return fields;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(GetFilterValues());
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Enter))
                Close();
        }
    }
}
