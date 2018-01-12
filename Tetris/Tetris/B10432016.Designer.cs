using System;

namespace Tetris
{
    partial class B10432016
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
            this.start = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.gg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Azure;
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.CadetBlue;
            this.start.Location = new System.Drawing.Point(206, 295);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(89, 82);
            this.start.TabIndex = 1;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            this.start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisView_KeyDown);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label.Location = new System.Drawing.Point(211, 39);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(79, 24);
            this.Label.TabIndex = 2;
            this.Label.Text = "SCORE:";
            this.Label.Click += new System.EventHandler(this.SCORE_Click);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.score.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(214, 83);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(59, 59);
            this.score.TabIndex = 3;
            this.score.Text = "0";
            // 
            // gg
            // 
            this.gg.AutoSize = true;
            this.gg.BackColor = System.Drawing.SystemColors.ControlText;
            this.gg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gg.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gg.ForeColor = System.Drawing.Color.Red;
            this.gg.Location = new System.Drawing.Point(204, 185);
            this.gg.Name = "gg";
            this.gg.Size = new System.Drawing.Size(90, 20);
            this.gg.TabIndex = 5;
            this.gg.Text = "GAME OVER!";
            this.gg.Visible = false;
            // 
            // B10432016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(314, 394);
            this.Controls.Add(this.gg);
            this.Controls.Add(this.score);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.start);
            this.MaximizeBox = false;
            this.Name = "B10432016";
            this.Text = "Tetris_TJ";
            this.Load += new System.EventHandler(this.TetrisView_Load);
            this.Shown += new System.EventHandler(this.TetrisView_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SCORE_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label gg;
    }
}

