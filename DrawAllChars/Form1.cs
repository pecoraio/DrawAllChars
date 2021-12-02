using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawAllChars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            var bmp= new Bitmap(768, 1024);
            pictureBox1.Image = bmp;

            using (var g = Graphics.FromImage(bmp))
            using (var font = new Font(this.Font.Name , 16))
            using (var fmt = new StringFormat(StringFormat.GenericTypographic))
            //using (var br = Brushes.Black)
            {
                //g.PageUnit = GraphicsUnit.Pixel;
                g.Clear(Color.White);

                int top = 5;
                int start = 0x020;
                var mes = g.MeasureString("□", font,0,fmt);
                var wid = (int)mes.Width;
                var hig = (int)mes.Height;
                var mes2 = g.MeasureString("XXXX", font, 0, fmt);
                var wid2 = (int)mes2.Width;
                var page = 1;
                for (int x = start; x < 0xFFF0; x+=0x10)
                {
                    int left = 5;
                    g.DrawString($"{x:X4}", font, Brushes.Black, left, top, fmt);
                    left += wid2 + 5;
                    Application.DoEvents();
                    pictureBox1.Invalidate();
                    int ichar= x;
                    for (int y = 0; y < 0x10; y++)
                    {
                        ichar = x + y;
                        var str = Convert.ToChar(ichar).ToString();
                        g.DrawString(str, font, Brushes.Black, left, top, fmt);
                        left += wid + 5;
                        //if(left + wid > bmp.Width)
                        //{
                        //    left = 0;
                        //    top += hig + 5;
                        //    Application.DoEvents();
                        //}

                    }
                    if (top + hig > bmp.Height)
                    {
                        Directory.CreateDirectory("bmp");
                        bmp.Save($"bmp\\{page++:D3}-{start:X4}-{ichar:X4}.bmp");
                        start = ichar + 1;
                        top = 5;
                        g.Clear(Color.White);
                    }
                    else
                        top += hig + 5;
                }
            }
        }
    }
}
