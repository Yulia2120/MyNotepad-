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


        private void MainForm_Load(object sender, EventArgs e)
        {
            AddImage = Properties.Resources.Add;
            CloseImage = Properties.Resources.Close;
            tabControl1.Padding = new Point(20, 4);
            tabControl1.TabPages[tabControl1.TabCount - 1].Text = "Page";
            tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(new RichTextBox() { BorderStyle = BorderStyle.None, Top = 26, Dock = DockStyle.Fill });


        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
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

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
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
                tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(new RichTextBox() { BorderStyle = BorderStyle.None, Top = 26, Dock = DockStyle.Fill });



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


        public MainForm()
        {
            InitializeComponent();

        }
    }
}
