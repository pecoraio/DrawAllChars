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
            using (var font2 = new Font(this.Font.Name, 16,FontStyle.Bold))
            using (var fmt = new StringFormat(StringFormat.GenericTypographic))
            //using (var br = Brushes.Black)
            {
                //g.PageUnit = GraphicsUnit.Pixel;
                g.Clear(Color.White);

                int top = 5;
                int start = (int)nuStart.Value;
                var mes = g.MeasureString("□", font,0,fmt);
                var wid = (int)mes.Width;
                var hig = (int)mes.Height;
                var mes2 = g.MeasureString(string.Concat(Enumerable.Repeat("X", Math.Max(nuStart.Value.ToString().Length, nuEnd.Value.ToString().Length))), font, 0, fmt);
                var wid2 = (int)mes2.Width;
                var page = 1;
                bool Err = false;
                for (int x = start; x < (int)nuEnd.Value; x+=0x10)
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
                        var str = Char.ConvertFromUtf32(ichar);
                        //var str = Convert.ToChar(ichar).ToString();
                        if (g.MeasureString(str, font, 0, fmt).Width != 0F)
                            g.DrawString(str, font, Brushes.Black, left, top, fmt);
                        else
                        {
                            g.DrawString(str, font2, Brushes.Red, left, top, fmt);
                            TextRenderer.DrawText(g, str,font, new Point(left, top), Color.Black);
                            Err = true;
                        }
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
                        if (Err)
                        {
                            Directory.CreateDirectory("Err");
                            bmp.Save($"Err\\{page++:D3}-{start:X4}-{ichar:X4}.bmp");
                        }
                        start = ichar + 1;
                        top = 5;
                        g.Clear(Color.White);
                        Err = false;
                    }
                    else
                        top += hig + 5;
                }
            }
        }

    }
}
