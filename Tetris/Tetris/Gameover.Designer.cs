namespace SE_Project
{
    partial class Gameover
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_restart = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_restart
            // 
            this.button_restart.BackColor = System.Drawing.Color.SteelBlue;
            this.button_restart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.button_restart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.button_restart.Font = new System.Drawing.Font("CXingHK-Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_restart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_restart.Location = new System.Drawing.Point(77, 30);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(176, 49);
            this.button_restart.TabIndex = 0;
            this.button_restart.Text = "Back";
            this.button_restart.UseVisualStyleBackColor = false;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.SteelBlue;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.button_exit.Font = new System.Drawing.Font("CXingHK-Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_exit.Location = new System.Drawing.Point(77, 102);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(175, 50);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Gameover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(334, 186);
            this.ControlBox = false;
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_restart);
            this.Font = new System.Drawing.Font("CXingHK-Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Gameover";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOver";
            this.Load += new System.EventHandler(this.Gameover_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.Button button_exit;
    }
}