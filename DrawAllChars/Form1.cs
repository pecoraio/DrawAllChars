using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        LinkedList<Bitmap> bmps = new LinkedList<Bitmap>();
        LinkedListNode<Bitmap> CurNode;
        byte[] Tofu;
        List<byte[]> TofuTR = new List<byte[]>();
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(768, 1024);
            EnableCtrl();

            #region "比較用トーフ準備"
            var tbmp = new Bitmap(21, 21);
            using (var g = Graphics.FromImage(tbmp))
            using (var font = new Font(this.Font.Name, 16))
            using (var fmt = new StringFormat(StringFormat.GenericTypographic))
            {
                g.Clear(Color.White);
                g.DrawString(Char.ConvertFromUtf32(0x1F000), font, Brushes.Black, 0, 0, fmt);
                Tofu = ImageToByteArray(tbmp);
                foreach (var c in new[] {   Char.ConvertFromUtf32(0x10) , Char.ConvertFromUtf32(0x80),
                                            Char.ConvertFromUtf32(0x1F8C0) , Char.ConvertFromUtf32(0x1B170) ,Char.ConvertFromUtf32(0x2A6E0) })
                {
                    g.Clear(Color.White);
                    TextRenderer.DrawText(g, c, font, new Point(0, 0), Color.Black);
                    TofuTR.Add(ImageToByteArray(tbmp));
                }
            }
            #endregion
        }

        bool stop = false;
        /// <summary>
        /// 検査開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStart_Click(object sender, EventArgs e)
        {
            stop = false;
            pictureBox1.Image = bmp;
            foreach (var b in bmps)
                b.Dispose();
            bmps.Clear();

            var tbmp = new Bitmap(21, 21);
            using (var g = Graphics.FromImage(bmp))
            using (var tg = Graphics.FromImage(tbmp))
            using (var font = new Font(this.Font.Name , 16))
            using (var font2 = new Font(this.Font.Name, 16,FontStyle.Regular))
            using (var fmt = new StringFormat(StringFormat.GenericTypographic))
            {

                g.Clear(Color.White);
                int top = 5;
                int start = (int)nuStart.Value;
                var mes = g.MeasureString("□", font,0,fmt);
                var wid = (int)mes.Width;
                var hig = (int)mes.Height;
                var mes2 = g.MeasureString("XXXXX", font, 0, fmt);
                var wid2 = (int)mes2.Width;
                bool Err = false;
                for (int Ldigit = start; Ldigit < (int)nuEnd.Value; Ldigit+=0x10)
                {
                    int left = 5;
                    g.DrawString($"{Ldigit:X5}", font, Brushes.Black, left, top, fmt);
                    left += wid2 + 5;
                    Application.DoEvents();
                    pictureBox1.Invalidate();
                    int ichar= Ldigit;
                    //１ライン 16文字ずつ描画
                    for (int Rdigit = 0; Rdigit < 0x10; Rdigit++)
                    {
                        ichar = Ldigit + Rdigit;
                        string str;
                        try
                        {
                            str = Char.ConvertFromUtf32(ichar);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        if (false == IsTofu(tbmp, tg, str, font, fmt))
                            g.DrawString(str, font, Brushes.Black, left, top, fmt);
                        else
                        {
                            TextRenderer.DrawText(g, str, font, new Point(left, top), Color.Green);
                            if (false == IsTofuTR(tbmp, tg, str, font, fmt))
                            {
                                g.DrawString(str, font2, Brushes.Red, left, top, fmt);
                                Err = true;

                            }
                            else
                                g.DrawString(str, font, Brushes.Black, left, top, fmt);
                        }
                        left += wid + 5;

                    }
                    if (top + hig *2+2> bmp.Height || ichar == nuEnd.Value)
                    {
                        //改ページと保存
                        var suf = $"{(int)nuStart.Value:X}-{(int)nuEnd.Value:X}";
                        Directory.CreateDirectory($"All-{suf}");
                        bmp.Save($"All-{suf}\\{start:X5}-{ichar:X5}.png", ImageFormat.Png);
                        nuSStart.Value = start;
                        nuSEnd.Value = ichar;
                        bmps.AddLast(bmp.Clone()as Bitmap);
                        CurNode = bmps.Last;
                        btPrv.Enabled = true;
                        if (Err)
                        {
                            Directory.CreateDirectory($"Err-{suf}");
                            bmp.Save($"Err-{suf}\\{start:X5}-{ichar:X5}.png",ImageFormat.Png);
                        }
                        start = ichar + 1;
                        top = 5;
                        if(ichar != nuEnd.Value)
                            g.Clear(Color.White);
                        Err = false;
                    }
                    else
                        top += hig + 5;

                    if (stop)
                        break;
                }
            }
        }

        private void btPrv_Click(object sender, EventArgs e)
        {
            CurNode = CurNode.Previous;
            pictureBox1.Image = CurNode.Value;
            pictureBox1.Invalidate();
            EnableCtrl();

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
        bool IsTofu(Bitmap bmp,Graphics g ,string str,Font font,StringFormat fmt)
        {
            g.Clear(Color.White);
            g.DrawString(str, font, Brushes.Black, 0, 0, fmt);
            var b =ImageToByteArray(bmp);
            return b.SequenceEqual(Tofu);
        }
        bool IsTofuTR(Bitmap bmp, Graphics g, string str, Font font, StringFormat fmt)
        {
            g.Clear(Color.White);
            TextRenderer.DrawText(g, str, font, new Point(0, 0), Color.Black);
            var b = ImageToByteArray(bmp);

            foreach (var t in TofuTR)
            {
                if (b.SequenceEqual(t))
                    return true;
            }
            return false;
        }
        public byte[] ImageToByteArray(Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void nuStart_ValueChanged(object sender, EventArgs e)
        {
            if(nuEnd.Value < nuStart.Value)
                nuEnd.Value = nuStart.Value + 0x200;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
