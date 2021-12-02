
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
            this.ckAll = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStart.Location = new System.Drawing.Point(1509, 4);
            this.btStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(161, 66);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "検査開始";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // ckAll
            // 
            this.ckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ckAll.Location = new System.Drawing.Point(13, 4);
            this.ckAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(27, 25);
            this.ckAll.TabIndex = 6;
            this.toolTip1.SetToolTip(this.ckAll, "すべて選択／すべて解除");
            this.ckAll.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ckAll);
            this.splitContainer1.Panel1.Controls.Add(this.btStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1687, 1065);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1687, 955);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 1065);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btStart;
        private System.Windows.Forms.CheckBox ckAll;
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
    }
}

