using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotepad__
{
    public class MyTabPage: TabPage
    {

        public MyTabPage(string title, string text = "", Color tab_color = new Color())
        {
            this.Text = title;
            this.Controls.Add(new TextBox() { Multiline = true, Size = new Size(400, 400), BackColor = tab_color, Text = text });
        }

    }
}
