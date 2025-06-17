namespace WeatherApp
{
    partial class WeatherInfo
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
            this.lblCurrentWeather = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentWeather
            // 
            this.lblCurrentWeather.AutoSize = true;
            this.lblCurrentWeather.Location = new System.Drawing.Point(375, 155);
            this.lblCurrentWeather.Name = "lblCurrentWeather";
            this.lblCurrentWeather.Size = new System.Drawing.Size(66, 13);
            this.lblCurrentWeather.TabIndex = 0;
            this.lblCurrentWeather.Text = "WeatherInfo";
            // 
            // WeatherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.lblCurrentWeather);
            this.Name = "WeatherInfo";
            this.Text = "WeatherInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentWeather;
    }
}