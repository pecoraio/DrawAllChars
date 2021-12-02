
namespace DrawAllChars
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btStart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.status_disp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL_TEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nuStart = new System.Windows.Forms.NumericUpDown();
            this.nuEnd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrv = new System.Windows.Forms.Button();
            this.btNxt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStart.Location = new System.Drawing.Point(402, 21);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(161, 66);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "検査開始";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // status_disp
            // 
            this.status_disp.DataPropertyName = "status_disp";
            this.status_disp.FillWeight = 40F;
            this.status_disp.HeaderText = "ステータス";
            this.status_disp.MinimumWidth = 6;
            this.status_disp.Name = "status_disp";
            this.status_disp.Width = 108;
            // 
            // PL_TEXT
            // 
            this.PL_TEXT.DataPropertyName = "PL_TEXT";
            this.PL_TEXT.HeaderText = "プラン";
            this.PL_TEXT.MinimumWidth = 6;
            this.PL_TEXT.Name = "PL_TEXT";
            this.PL_TEXT.Width = 60;
            // 
            // ORDER_DATE
            // 
            this.ORDER_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORDER_DATE.DataPropertyName = "ORDER_DATE";
            dataGridViewCellStyle1.Format = "yyyy/MM/dd HH:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.ORDER_DATE.DefaultCellStyle = dataGridViewCellStyle1;
            this.ORDER_DATE.HeaderText = "注文日時";
            this.ORDER_DATE.MinimumWidth = 6;
            this.ORDER_DATE.Name = "ORDER_DATE";
            this.ORDER_DATE.Width = 125;
            // 
            // ORDER_NUM
            // 
            this.ORDER_NUM.DataPropertyName = "ORDER_NUM";
            this.ORDER_NUM.HeaderText = "注文数";
            this.ORDER_NUM.MinimumWidth = 6;
            this.ORDER_NUM.Name = "ORDER_NUM";
            this.ORDER_NUM.Width = 60;
            // 
            // CardName
            // 
            this.CardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CardName.DataPropertyName = "CardName";
            this.CardName.HeaderText = "券種名";
            this.CardName.MinimumWidth = 6;
            this.CardName.Name = "CardName";
            this.CardName.ReadOnly = true;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "案件名";
            this.ITEM_NAME.MinimumWidth = 6;
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            // 
            // ORDER_CD
            // 
            this.ORDER_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORDER_CD.DataPropertyName = "ORDER_CD";
            this.ORDER_CD.HeaderText = "注文番号";
            this.ORDER_CD.MinimumWidth = 6;
            this.ORDER_CD.Name = "ORDER_CD";
            this.ORDER_CD.ReadOnly = true;
            this.ORDER_CD.Width = 125;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "☑";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.Width = 45;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btNxt);
            this.splitContainer1.Panel1.Controls.Add(this.btPrv);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.nuEnd);
            this.splitContainer1.Panel1.Controls.Add(this.nuStart);
            this.splitContainer1.Panel1.Controls.Add(this.btStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1687, 1065);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1687, 955);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nuStart
            // 
            this.nuStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nuStart.Hexadecimal = true;
            this.nuStart.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nuStart.Location = new System.Drawing.Point(53, 40);
            this.nuStart.Maximum = new decimal(new int[] {
            983039,
            0,
            0,
            0});
            this.nuStart.Name = "nuStart";
            this.nuStart.Size = new System.Drawing.Size(120, 30);
            this.nuStart.TabIndex = 0;
            this.nuStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuStart.Value = new decimal(new int[] {
            128512,
            0,
            0,
            0});
            // 
            // nuEnd
            // 
            this.nuEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nuEnd.Hexadecimal = true;
            this.nuEnd.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nuEnd.Location = new System.Drawing.Point(233, 40);
            this.nuEnd.Maximum = new decimal(new int[] {
            983039,
            0,
            0,
            0});
            this.nuEnd.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nuEnd.Name = "nuEnd";
            this.nuEnd.Size = new System.Drawing.Size(120, 30);
            this.nuEnd.TabIndex = 1;
            this.nuEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuEnd.Value = new decimal(new int[] {
            128767,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(193, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "-";
            // 
            // btPrv
            // 
            this.btPrv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrv.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btPrv.Location = new System.Drawing.Point(1415, 21);
            this.btPrv.Margin = new System.Windows.Forms.Padding(4);
            this.btPrv.Name = "btPrv";
            this.btPrv.Size = new System.Drawing.Size(90, 60);
            this.btPrv.TabIndex = 3;
            this.btPrv.Text = "◁";
            this.btPrv.UseVisualStyleBackColor = true;
            // 
            // btNxt
            // 
            this.btNxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNxt.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNxt.Location = new System.Drawing.Point(1556, 21);
            this.btNxt.Margin = new System.Windows.Forms.Padding(4);
            this.btNxt.Name = "btNxt";
            this.btNxt.Size = new System.Drawing.Size(90, 60);
            this.btNxt.TabIndex = 4;
            this.btNxt.Text = "▷";
            this.btNxt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 1065);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_disp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PL_TEXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_CD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Button btNxt;
        protected System.Windows.Forms.Button btPrv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuEnd;
        private System.Windows.Forms.NumericUpDown nuStart;
    }
}

