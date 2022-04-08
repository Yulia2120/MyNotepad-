using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Collections.Generic;

namespace MyNotepad__
{

    public partial class MainForm : Form
    {

        Image CloseImage, AddImage;
        Point _imageLocation = new Point(20, 4);
        Point imageHitArea = new Point(20, 4);
        MyTextBox notebox = new MyTextBox();
        bool tbChange = false;
        string docPath = "";

        public object myTextBox { get; internal set; }

        public void CreatePages()
        {
            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                TabPage tab = new TabPage();
                tab.Text = "Page";
                tabControl1.Controls.Add(tab);
                tabControl1.TabPages[tabControl1.TabCount - 1].Text = "Page" + tabControl1.TabCount.ToString();
                tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(notebox);
              
            }
        }

        private void noteBox_TextChanged(object sender, EventArgs e)
        {
            tbChange = true;
            TextWork.StatusAnalize(ref notebox, ref statusLinesCount, ref statusWordsCount, ref statusCharSpaceCount, ref statusCharCount);
            TextWork.mEditEnableds(ref notebox, ref mEditCopy, ref mEditCut, ref mEditDel, ref mEditFind, ref mEditGo);
            TextWork.mEditEnableds(ref notebox, ref mEditCopy, ref mEditCut, ref mEditDel, ref mEditFind, ref mEditGo);
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            this.Width = Properties.Settings.Default.formWidth;
            this.Height = Properties.Settings.Default.formHeight;
            notebox.Font = Properties.Settings.Default.textFont;
            if (Properties.Settings.Default.statusStripVisible == true)
            { mViewStatusStrip.CheckState = CheckState.Checked; }
            else
            { mViewStatusStrip.CheckState = CheckState.Unchecked; }
            if (Properties.Settings.Default.textTransfer == true)
            { mFormatTransfer.CheckState = CheckState.Checked; }
            else
            { mFormatTransfer.CheckState = CheckState.Unchecked; }
            fastColoredTextBox1.Visible = false;
        }

        public void tabControl1_DrawItem(object sender, DrawItemEventArgs e) // создаем пользовательский TabPage
        {
            AddImage = Properties.Resources.Add;
            CloseImage = Properties.Resources.Close;
            Image img;
            if (e.Index == tabControl1.TabCount - 1)
            {
                img = new Bitmap(AddImage);
                tabControl1.Padding = new Point(20, 4);
            }
            else
            {
                img = new Bitmap(CloseImage);
            }
            Rectangle r = e.Bounds;
            r = tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (
                this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X),
                _imageLocation.Y));
        }

        public void tabControl1_MouseClick(object sender, MouseEventArgs e) // добавляем вкладки по клику мыши
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tabControl.SelectedIndex).Width - imageHitArea.X;
            Rectangle r = this.tabControl1.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, imageHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                TabPage tab = new TabPage();
                tab.Text = "Page";
                tabControl1.Controls.Add(tab);
                tabControl1.TabPages[tabControl1.TabCount - 1].Text = "Page" + tabControl1.TabCount.ToString();
                tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(new MyTextBox() { BorderStyle = BorderStyle.None, Top = 26, Dock = DockStyle.Fill });


            }
            else
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
                }
            }
        }

        public void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.formWidth = this.Width;
            Properties.Settings.Default.formHeight = this.Height;
            Properties.Settings.Default.textTransfer = notebox.WordWrap;
            Properties.Settings.Default.textFont = notebox.Font;
            Properties.Settings.Default.statusStripVisible = statusStrip.Visible;
            Properties.Settings.Default.Save();

            if (tbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед выходом?", "Выход из программы", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {
                    if (docPath != "")
                    {
                        FileWork.SaveFile(ref notebox, ref tbChange, ref docPath);
                        Application.Exit();
                    }
                    else if (docPath == "")
                    {
                        FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
                        Application.Exit();
                    }
                }
                else if (message == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

        }

        private void mFileNew_Click(object sender, EventArgs e)   // создать документ
        {
            fastColoredTextBox1.Visible = false;
            fastColoredTextBox1.Enabled = false;

            CreatePages();

            if (tbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед созданием нового?", "Создание документа", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {


                    if (docPath != "")
                    {
                        FileWork.SaveFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                    }
                    else if (docPath == "")
                    {
                        FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                    }
                }
                else if (message == DialogResult.No)
                {
                    FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                }
            }
            else
            {
                FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
            }
        }

       

        private void mFileOpen_Click(object sender, EventArgs e) // открыть документ
        {
            fastColoredTextBox1.Visible = false;
            fastColoredTextBox1.Enabled = false;

            if (tbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед открытием нового?", "Открытие документа", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {
                    if (docPath != "")
                    {
                        FileWork.SaveFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.OpenFile(ref notebox, ref tbChange, ref docPath);
                    }
                    else if (docPath == "")
                    {
                        FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.OpenFile(ref notebox, ref tbChange, ref docPath);
                    }
                }
                else if (message == DialogResult.No)
                {
                    FileWork.OpenFile(ref notebox, ref tbChange, ref docPath);
                }
                else
                {
                    return;
                }
            }
            else
            {
                FileWork.OpenFile(ref notebox, ref tbChange, ref docPath);
            }
        }

        private void mFileSave_Click(object sender, EventArgs e) // сохранить документ
        {
            if (docPath != "")
            {
                FileWork.SaveFile(ref notebox, ref tbChange, ref docPath);
            }
            else
            {
                FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
            }
        }

        private void mfileSaveAs_Click(object sender, EventArgs e) // сохранить документ как...
        {
            FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
        }

        private void mFilePageParam_Click(object sender, EventArgs e) // параметры страницы печати
        {
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
            }
        }

        private void mFilePrint_Click(object sender, EventArgs e) // печать документа
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка параметров печати.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void mFileExit_Click(object sender, EventArgs e) // выход из программы
        {
            Application.Exit();
        }
        public MainForm(string fileName) // Открытие программы документом
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                try
                {
                    string programmName = Properties.Settings.Default.programmName;
                    FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(file, Encoding.Default);
                    notebox.Text = reader.ReadToEnd();
                    reader.Close();
                    docPath = fileName;
                    tbChange = false;
                    this.Text = Path.GetFileName(fileName) + " — " + programmName;
                    notebox.Select(0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mEditCancel_Click(object sender, EventArgs e)
        {
            notebox.Undo();
        }

        private void mEditCut_Click(object sender, EventArgs e)
        {
            if (notebox.SelectionLength > 0)
            {
                notebox.Cut();
            }
        }

        private void mEditCopy_Click(object sender, EventArgs e)
        {
            if (notebox.SelectionLength > 0)
            {
                notebox.Copy();
            }
        }

        private void mEditPaste_Click(object sender, EventArgs e)
        {
            notebox.Paste();
        }

        private void mEditDel_Click(object sender, EventArgs e)
        {
            if (notebox.SelectionLength > 0)
            {
                notebox.SelectedText = "";
            }

        }

        public void mEditFind_Click(object sender, EventArgs e)
        {
            SearchForm findText = new SearchForm();
            findText.Owner = this;
            findText.Show();
        }

        public void mEditGiveAll_Click(object sender, EventArgs e)
        {
            notebox.SelectAll();
        }

        private void mEditTime_Click(object sender, EventArgs e)
        {
            notebox.AppendText(Environment.NewLine + Convert.ToString(System.DateTime.Now));
        }

        private void mEditGo_Click(object sender, EventArgs e)
        {

            GoToForm gotoform = new GoToForm();
            gotoform.Owner = this;
            gotoform.tbLineNum.Minimum = 0;
            gotoform.tbLineNum.Maximum = notebox.Lines.Count();
            gotoform.ShowDialog();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Visible = false;
            fastColoredTextBox1.Enabled = false;
            CreatePages();
            if (tbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед созданием нового?", "Создание документа", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {


                    if (docPath != "")
                    {
                        FileWork.SaveFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                    }
                    else if (docPath == "")
                    {
                        FileWork.SaveAsFile(ref notebox, ref tbChange, ref docPath);
                        FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                    }
                }
                else if (message == DialogResult.No)
                {
                    FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
                }
            }
            else
            {
                FileWork.CreateFile(ref notebox, ref tbChange, ref docPath);
            }
        }

        private void mFormatFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = notebox.Font;
            DialogResult = fontDialog.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                notebox.Font = fontDialog.Font;
            }
        }

        private void mFormatTransfer_CheckStateChanged(object sender, EventArgs e)
        {
            if (mFormatTransfer.CheckState == CheckState.Checked)
            {
                notebox.WordWrap = true;
                notebox.ScrollBars = ScrollBars.Vertical;
                mEditGo.Enabled = false;
                statusLab1.Visible = false;
                statusLinesCount.Visible = false;
            }
            else
            {
                notebox.WordWrap = false;
                notebox.ScrollBars = ScrollBars.Both;
                mEditGo.Enabled = true;
                statusLab1.Visible = true;
                statusLinesCount.Visible = true;
            }
        }

        private void mViewStatusStrip_CheckStateChanged(object sender, EventArgs e)
        {
            if (mViewStatusStrip.CheckState == CheckState.Checked)
            {
                statusStrip.Visible = true;
            }
            else
            {
                statusStrip.Visible = false;
            }
        }

        private void mHelpAboutProgram_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void mRun_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Visible = true;
            fastColoredTextBox1.Enabled = true;
            labFile.Visible = true;
            txtBoxFile.Visible = true;  
            labFramework.Visible = true;
            txtBoxFramework.Visible = true;
            txtBoxStatus.Visible = true;    
        }

        private void mRunCSharp_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void mRunHTML_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void mRunPHP_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            string text = fastColoredTextBox1.Text;
            statusLinesCount.Text = fastColoredTextBox1.Lines.Count().ToString();
            statusWordsCount.Text = text.Split(new Char[] { ' ', '\t', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-',
                '_', '+', '=', '[', '{', ']', '}', '/', '\\', '|', '"', ':', ';', '.', ',', '>', '<' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
            statusCharCount.Text = text.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "").ToCharArray().Length.ToString();
            statusCharSpaceCount.Text = text.ToCharArray().Length.ToString();

        }

        private void mRunCompile_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion ", txtBoxFramework.Text } });
            CompilerParameters parameters = new CompilerParameters(new string[] { "mscorlib.dll","System.Core.dll" }, txtBoxFile.Text, true );
            parameters.GenerateExecutable = true;
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, fastColoredTextBox1.Text);
            if (results.Errors.HasErrors)
            {
                foreach (CompilerError error in results.Errors.Cast<CompilerError>())
                    txtBoxStatus.Text += $"Line{error.Line}:{error.ErrorText}";
            }
            else
            {
                txtBoxStatus.Text = "--- Assembly completed ---";
                Process.Start($"{Application.StartupPath}/{txtBoxFile}");
            }
        }
       

        public MainForm()
        {
            InitializeComponent();
            this.notebox.TextChanged += new System.EventHandler(this.noteBox_TextChanged);

            this.Text = Properties.Settings.Default.newDocName + " - " + Properties.Settings.Default.programmName;
            autocompleteMenu.Items = File.ReadAllLines("cs-reserv-list.dicr");
        }

    }
}
