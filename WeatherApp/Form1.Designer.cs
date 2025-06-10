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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.cmbStates = new System.Windows.Forms.ComboBox();
            this.StateLabel = new System.Windows.Forms.Label();
            this.ZipcodeLabel = new System.Windows.Forms.Label();
            this.cmbCounty = new System.Windows.Forms.ComboBox();
            this.CountyLabel = new System.Windows.Forms.Label();
            this.cmbZipCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(296, 66);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(160, 21);
            this.cmbCity.TabIndex = 0;
            this.cmbCity.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangedCommitted_UpdateSelections);
            // 
            // btnGetWeather
            // 
            this.btnGetWeather.Location = new System.Drawing.Point(695, 64);
            this.btnGetWeather.Name = "btnGetWeather";
            this.btnGetWeather.Size = new System.Drawing.Size(85, 24);
            this.btnGetWeather.TabIndex = 1;
            this.btnGetWeather.Text = "Get Weather";
            this.btnGetWeather.UseVisualStyleBackColor = true;
            this.btnGetWeather.Click += new System.EventHandler(this.BtnGetWeather_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.TitleLabel.Location = new System.Drawing.Point(369, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(246, 37);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Monsieur Momo";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(437, 227);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(69, 13);
            this.lblWeather.TabIndex = 4;
            this.lblWeather.Text = "Weather Info";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(359, 51);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(28, 13);
            this.CityLabel.TabIndex = 5;
            this.CityLabel.Text = "City*";
            this.CityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStates
            // 
            this.cmbStates.FormattingEnabled = true;
            this.cmbStates.Location = new System.Drawing.Point(239, 66);
            this.cmbStates.Name = "cmbStates";
            this.cmbStates.Size = new System.Drawing.Size(51, 21);
            this.cmbStates.TabIndex = 6;
            this.cmbStates.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangedCommitted_UpdateSelections);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(248, 51);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(32, 13);
            this.StateLabel.TabIndex = 7;
            this.StateLabel.Text = "State";
            // 
            // ZipcodeLabel
            // 
            this.ZipcodeLabel.AutoSize = true;
            this.ZipcodeLabel.Location = new System.Drawing.Point(615, 51);
            this.ZipcodeLabel.Name = "ZipcodeLabel";
            this.ZipcodeLabel.Size = new System.Drawing.Size(50, 13);
            this.ZipcodeLabel.TabIndex = 9;
            this.ZipcodeLabel.Text = "Zipcode*";
            // 
            // cmbCounty
            // 
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Location = new System.Drawing.Point(462, 66);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(121, 21);
            this.cmbCounty.TabIndex = 10;
            this.cmbCounty.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangedCommitted_UpdateSelections);
            // 
            // CountyLabel
            // 
            this.CountyLabel.AutoSize = true;
            this.CountyLabel.Location = new System.Drawing.Point(502, 50);
            this.CountyLabel.Name = "CountyLabel";
            this.CountyLabel.Size = new System.Drawing.Size(40, 13);
            this.CountyLabel.TabIndex = 11;
            this.CountyLabel.Text = "County";
            // 
            // cmbZipCode
            // 
            this.cmbZipCode.FormattingEnabled = true;
            this.cmbZipCode.Location = new System.Drawing.Point(589, 66);
            this.cmbZipCode.Name = "cmbZipCode";
            this.cmbZipCode.Size = new System.Drawing.Size(100, 21);
            this.cmbZipCode.TabIndex = 12;
            this.cmbZipCode.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangedCommitted_UpdateSelections);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.cmbZipCode);
            this.Controls.Add(this.CountyLabel);
            this.Controls.Add(this.cmbCounty);
            this.Controls.Add(this.ZipcodeLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.cmbStates);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.lblWeather);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.btnGetWeather);
            this.Controls.Add(this.cmbCity);
            this.Name = "HomePage";
            this.Padding = new System.Windows.Forms.Padding(100);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Button btnGetWeather;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.ComboBox cmbStates;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label ZipcodeLabel;
        private System.Windows.Forms.ComboBox cmbCounty;
        private System.Windows.Forms.Label CountyLabel;
        private System.Windows.Forms.ComboBox cmbZipCode;
    }
}

