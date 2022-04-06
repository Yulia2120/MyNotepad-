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
        public static void OpenFile(ref TextBox notebox, ref bool tbChange, ref string docPath) // Метод "Открыть документ"
        {
            string programmName = Properties.Settings.Default.programmName;
            OpenFileDialog openDocument = new OpenFileDialog();
            openDocument.Title = "Открыть текстовый документ";
            openDocument.Filter = "Текстовые файлы (*.txt) |*.txt| Все файлы (*.*)|*.*";
            if (openDocument.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(openDocument.FileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file, Encoding.Default);
                notebox.Text = reader.ReadToEnd();
                reader.Close();
                docPath = openDocument.FileName;
                tbChange = false;
                MainForm.ActiveForm.Text = openDocument.SafeFileName + " — " + programmName;
            }
        }



    }
}
