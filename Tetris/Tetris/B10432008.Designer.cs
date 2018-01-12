namespace Tetris
{
    partial class B10432008
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
            this.Start = new System.Windows.Forms.Button();
            this.ScoreName = new System.Windows.Forms.Label();
            this.Game = new System.Windows.Forms.Label();
            this.Over = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.FlatAppearance.BorderSize = 2;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Start.Location = new System.Drawing.Point(22, 332);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(146, 53);
            this.Start.TabIndex = 0;
            this.Start.Text = "start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.strat_Click);
            this.Start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyPress);
            // 
            // ScoreName
            // 
            this.ScoreName.AutoSize = true;
            this.ScoreName.CausesValidation = false;
            this.ScoreName.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ScoreName.Location = new System.Drawing.Point(26, 22);
            this.ScoreName.Name = "ScoreName";
            this.ScoreName.Size = new System.Drawing.Size(124, 37);
            this.ScoreName.TabIndex = 1;
            this.ScoreName.Text = "Score";
            // 
            // Game
            // 
            this.Game.AutoSize = true;
            this.Game.Font = new System.Drawing.Font("標楷體", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Game.Location = new System.Drawing.Point(30, 147);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(120, 48);
            this.Game.TabIndex = 2;
            this.Game.Text = "Game";
            this.Game.Visible = false;
            // 
            // Over
            // 
            this.Over.AutoSize = true;
            this.Over.Font = new System.Drawing.Font("標楷體", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Over.Location = new System.Drawing.Point(48, 232);
            this.Over.Name = "Over";
            this.Over.Size = new System.Drawing.Size(120, 48);
            this.Over.TabIndex = 3;
            this.Over.Text = "Over";
            this.Over.Visible = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Score.Location = new System.Drawing.Point(49, 72);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(43, 37);
            this.Score.TabIndex = 4;
            this.Score.Text = "0";
            // 
            // B10432008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 428);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Over);
            this.Controls.Add(this.Game);
            this.Controls.Add(this.ScoreName);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "B10432008";
            this.Text = "B10432008";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        protected internal System.Windows.Forms.Label ScoreName;
        private System.Windows.Forms.Label Game;
        private System.Windows.Forms.Label Over;
        private System.Windows.Forms.Label Score;
    }
}

