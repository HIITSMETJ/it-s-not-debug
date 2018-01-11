namespace Tetris
{
    partial class B10432006
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
            this.start_button = new System.Windows.Forms.Button();
            this.scoreBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.start_button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.start_button.FlatAppearance.BorderSize = 5;
            this.start_button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Info;
            this.start_button.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_button.ForeColor = System.Drawing.Color.SlateBlue;
            this.start_button.Location = new System.Drawing.Point(386, 405);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(257, 93);
            this.start_button.TabIndex = 1;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            this.start_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.B10432006_KeyPress);
            // 
            // scoreBox
            // 
            this.scoreBox.BackColor = System.Drawing.Color.SkyBlue;
            this.scoreBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.scoreBox.ForeColor = System.Drawing.SystemColors.Window;
            this.scoreBox.Location = new System.Drawing.Point(532, 74);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.scoreBox.Size = new System.Drawing.Size(138, 46);
            this.scoreBox.TabIndex = 2;
            this.scoreBox.Text = "0";
            this.scoreBox.TextChanged += new System.EventHandler(this.scoreBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(347, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score";
            // 
            // B10432006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(743, 539);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.start_button);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Name = "B10432006";
            this.Text = "Tetris-THIS IS NOT DEBUG";
            this.Load += new System.EventHandler(this.B10432006_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.TextBox scoreBox;
        private System.Windows.Forms.Label label1;
    }
}

