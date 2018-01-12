namespace Tetris
{
    partial class B10432017
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
			this.button1 = new System.Windows.Forms.Button();
			this.score = new System.Windows.Forms.Label();
			this.viewTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(252, 141);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(70, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.strat);
			this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyPress);
			// 
			// score
			// 
			this.score.AutoSize = true;
			this.score.Font = new System.Drawing.Font("新細明體", 18F);
			this.score.Location = new System.Drawing.Point(248, 98);
			this.score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.score.Name = "score";
			this.score.Size = new System.Drawing.Size(85, 24);
			this.score.TabIndex = 1;
			this.score.Text = "Score: 0";
			// 
			// viewTime
			// 
			this.viewTime.AutoSize = true;
			this.viewTime.Font = new System.Drawing.Font("新細明體", 14F);
			this.viewTime.Location = new System.Drawing.Point(250, 357);
			this.viewTime.Name = "viewTime";
			this.viewTime.Size = new System.Drawing.Size(71, 19);
			this.viewTime.TabIndex = 2;
			this.viewTime.Text = "Time : 0";
			// 
			// B10432017
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 430);
			this.Controls.Add(this.viewTime);
			this.Controls.Add(this.score);
			this.Controls.Add(this.button1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "B10432017";
			this.Text = "B10432017";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label score;
		private System.Windows.Forms.Label viewTime;
	}
}

