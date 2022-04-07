using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepad__
{
    public class MyTextBox: TextBox
    {
        public MyTextBox()
        {
            BorderStyle = BorderStyle.None;
            Top = 26;
            Dock = DockStyle.Fill;
            Multiline = true;
            ScrollBars = ScrollBars.Both;

        }

}
}
