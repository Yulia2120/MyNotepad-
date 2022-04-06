using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotepad__
{

    public partial class MainForm : Form
    {

        Image CloseImage, AddImage;
        Point _imageLocation = new Point(20, 4);
        Point imageHitArea = new Point(20, 4);
        TextBox notebox = new TextBox();
        bool tbChange = false;
        string docPath = "";

     

        public void MainForm_Load(object sender, EventArgs e)
        {
            AddImage = Properties.Resources.Add;
            CloseImage = Properties.Resources.Close;
            tabControl1.Padding = new Point(20, 4);
            tabControl1.TabPages[tabControl1.TabCount - 1].Text = "Page";
            tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(new TextBox() { BorderStyle = BorderStyle.None, Top = 26,
            Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both});

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



        }

        public void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
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

        public void tabControl1_MouseClick(object sender, MouseEventArgs e)
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
                tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(new TextBox() { BorderStyle = BorderStyle.None, Top = 26, Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both });



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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.formWidth = this.Width;
            Properties.Settings.Default.formHeight = this.Height;
            Properties.Settings.Default.textTransfer = notebox.WordWrap;
            Properties.Settings.Default.textFont = notebox.Font;
            Properties.Settings.Default.statusStripVisible = statusStrip.Visible;
            Properties.Settings.Default.Save();

        }

        public MainForm()
        {
            InitializeComponent();

        }
    }
}
