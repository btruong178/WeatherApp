namespace WeatherApp
{
    partial class HomePage
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
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.btnGetWeather = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.cmbStates = new System.Windows.Forms.ComboBox();
            this.StateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(376, 55);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(160, 21);
            this.cmbCity.TabIndex = 0;
            this.cmbCity.SelectionChangeCommitted += new System.EventHandler(this.CmdCity_SelectionChangeCommitted);
            // 
            // btnGetWeather
            // 
            this.btnGetWeather.Location = new System.Drawing.Point(542, 55);
            this.btnGetWeather.Name = "btnGetWeather";
            this.btnGetWeather.Size = new System.Drawing.Size(85, 22);
            this.btnGetWeather.TabIndex = 1;
            this.btnGetWeather.Text = "Get Weather";
            this.btnGetWeather.UseVisualStyleBackColor = true;
            this.btnGetWeather.Click += new System.EventHandler(this.BtnGetWeather_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.TitleLabel.Location = new System.Drawing.Point(338, 1);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(246, 37);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Monsieur Momo";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(420, 226);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(69, 13);
            this.lblWeather.TabIndex = 4;
            this.lblWeather.Text = "Weather Info";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(436, 40);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(32, 13);
            this.CityLabel.TabIndex = 5;
            this.CityLabel.Text = "Cities";
            this.CityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStates
            // 
            this.cmbStates.FormattingEnabled = true;
            this.cmbStates.Location = new System.Drawing.Point(319, 55);
            this.cmbStates.Name = "cmbStates";
            this.cmbStates.Size = new System.Drawing.Size(51, 21);
            this.cmbStates.TabIndex = 6;
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(328, 40);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(32, 13);
            this.StateLabel.TabIndex = 7;
            this.StateLabel.Text = "State";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.cmbStates);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.lblWeather);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetWeather);
            this.Controls.Add(this.cmbCity);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(100);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Button btnGetWeather;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.ComboBox cmbStates;
        private System.Windows.Forms.Label StateLabel;
    }
}

