using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace MyNotepad__
{
    public class FileWorks
    {
        public static void CreateFile(ref TextBox notebox, ref bool tbChange, ref string docPath) // Метод "Создать новый документ"
        {
            string newDocName = Properties.Settings.Default.newDocName;
            string programmName = Properties.Settings.Default.programmName;
            notebox.Clear();
            docPath = "";
            tbChange = false;
            MainForm.ActiveForm.Text = newDocName + " — " + programmName;
        }
    }
}
