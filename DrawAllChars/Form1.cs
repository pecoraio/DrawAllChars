﻿using System;
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
        Bitmap bmp;
        //Dictionary<(int,int),Bitmap> dic = new Dictionary<(int,int), Bitmap>();
        LinkedList<Bitmap> bmps = new LinkedList<Bitmap>();
        LinkedListNode<Bitmap> CurNode;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(768, 1024);
            EnableCtrl();
        }
       
        private void btStart_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bmp;
            //dic.Clear();
            foreach (var b in bmps)
                b.Dispose();

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
                var mes2 = g.MeasureString("XXXXX", font, 0, fmt);
                var wid2 = (int)mes2.Width;
                //var page = 1;
                bool Err = false;
                for (int Ldigit = start; Ldigit < (int)nuEnd.Value; Ldigit+=0x10)
                {
                    int left = 5;
                    g.DrawString($"{Ldigit:X5}", font, Brushes.Black, left, top, fmt);
                    left += wid2 + 5;
                    Application.DoEvents();
                    pictureBox1.Invalidate();
                    int ichar= Ldigit;
                    for (int Rdigit = 0; Rdigit < 0x10; Rdigit++)
                    {
                        ichar = Ldigit + Rdigit;
                        var str = Char.ConvertFromUtf32(ichar);
                        //var str = Convert.ToChar(ichar).ToString();
                        if (g.MeasureString(str, font, 0, fmt).Width != 0F)
                            g.DrawString(str, font, Brushes.Black, left, top, fmt);
                        else
                        {
                            g.DrawString(str, font2, Brushes.Red, left, top, fmt);
                            Err = true;
                        }
                        TextRenderer.DrawText(g, str, font, new Point(left, top), Color.Black);
                        left += wid + 5;
                        //if(left + wid > bmp.Width)
                        //{
                        //    left = 0;
                        //    top += hig + 5;
                        //    Application.DoEvents();
                        //}

                    }
                    if (top + hig *2+2> bmp.Height || ichar == nuEnd.Value)
                    {
                        Directory.CreateDirectory("bmp");
                        bmp.Save($"bmp\\{start:X5}-{ichar:X5}.bmp");
                        nuSStart.Value = start;
                        nuSEnd.Value = ichar;
                        bmps.AddLast(bmp.Clone()as Bitmap);
                        CurNode = bmps.Last;
                        btPrv.Enabled = true;
                        //dic[(start, ichar)] = bmp.Clone() as Bitmap;
                        if (Err)
                        {
                            Directory.CreateDirectory("Err");
                            bmp.Save($"Err\\{start:X5}-{ichar:X5}.bmp");
                        }
                        start = ichar + 1;
                        top = 5;
                        if(ichar != nuEnd.Value)
                            g.Clear(Color.White);
                        Err = false;
                    }
                    else
                        top += hig + 5;
                }
            }
        }

        private void btPrv_Click(object sender, EventArgs e)
        {
            CurNode = CurNode.Previous;
            pictureBox1.Image = CurNode.Value;
            pictureBox1.Invalidate();
            EnableCtrl();
            //btPrv.Enabled = CurNode.Previous != null;
            //btNxt.Enabled = CurNode.Next != null;

        }

        private void btNxt_Click(object sender, EventArgs e)
        {
            CurNode = CurNode.Next;
            pictureBox1.Image = CurNode.Value;
            pictureBox1.Invalidate();
            EnableCtrl();
        }
        void EnableCtrl()
        {
            btPrv.Enabled = CurNode?.Previous != null;
            btNxt.Enabled = CurNode?.Next != null;

        }
    }
}
