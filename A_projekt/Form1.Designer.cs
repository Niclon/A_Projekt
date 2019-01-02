namespace A_projekt
{
    partial class Form1
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
            this.pluginSelector = new System.Windows.Forms.ComboBox();
            this.cityNameLabel = new System.Windows.Forms.Label();
            this.cityName = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.temperatureData = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityNameData = new System.Windows.Forms.Label();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.humidityData = new System.Windows.Forms.Label();
            this.windSpeedLabel = new System.Windows.Forms.Label();
            this.windSpeedData = new System.Windows.Forms.Label();
            this.globalizaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csCzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pluginSelector
            // 
            this.pluginSelector.FormattingEnabled = true;
            this.pluginSelector.Location = new System.Drawing.Point(863, 2);
            this.pluginSelector.Name = "pluginSelector";
            this.pluginSelector.Size = new System.Drawing.Size(196, 21);
            this.pluginSelector.TabIndex = 1;
            this.pluginSelector.SelectedIndexChanged += new System.EventHandler(this.pluginSelector_SelectedIndexChanged);
            // 
            // cityNameLabel
            // 
            this.cityNameLabel.AutoSize = true;
            this.cityNameLabel.Location = new System.Drawing.Point(19, 63);
            this.cityNameLabel.Name = "cityNameLabel";
            this.cityNameLabel.Size = new System.Drawing.Size(35, 13);
            this.cityNameLabel.TabIndex = 2;
            this.cityNameLabel.Text = "Name";
            // 
            // cityName
            // 
            this.cityName.Location = new System.Drawing.Point(268, 63);
            this.cityName.Name = "cityName";
            this.cityName.Size = new System.Drawing.Size(380, 20);
            this.cityName.TabIndex = 3;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(707, 63);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(161, 23);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(905, 63);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(154, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(905, 92);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(154, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Location = new System.Drawing.Point(19, 207);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(67, 13);
            this.temperatureLabel.TabIndex = 7;
            this.temperatureLabel.Text = "Temperature";
            // 
            // temperatureData
            // 
            this.temperatureData.AutoSize = true;
            this.temperatureData.Location = new System.Drawing.Point(265, 207);
            this.temperatureData.Name = "temperatureData";
            this.temperatureData.Size = new System.Drawing.Size(0, 13);
            this.temperatureData.TabIndex = 8;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(19, 169);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(53, 13);
            this.cityLabel.TabIndex = 9;
            this.cityLabel.Text = "City name";
            // 
            // cityNameData
            // 
            this.cityNameData.AutoSize = true;
            this.cityNameData.Location = new System.Drawing.Point(265, 169);
            this.cityNameData.Name = "cityNameData";
            this.cityNameData.Size = new System.Drawing.Size(0, 13);
            this.cityNameData.TabIndex = 10;
            // 
            // humidityLabel
            // 
            this.humidityLabel.AutoSize = true;
            this.humidityLabel.Location = new System.Drawing.Point(19, 244);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(47, 13);
            this.humidityLabel.TabIndex = 11;
            this.humidityLabel.Text = "Humidity";
            // 
            // humidityData
            // 
            this.humidityData.AutoSize = true;
            this.humidityData.Location = new System.Drawing.Point(265, 244);
            this.humidityData.Name = "humidityData";
            this.humidityData.Size = new System.Drawing.Size(0, 13);
            this.humidityData.TabIndex = 12;
            // 
            // windSpeedLabel
            // 
            this.windSpeedLabel.AutoSize = true;
            this.windSpeedLabel.Location = new System.Drawing.Point(19, 281);
            this.windSpeedLabel.Name = "windSpeedLabel";
            this.windSpeedLabel.Size = new System.Drawing.Size(64, 13);
            this.windSpeedLabel.TabIndex = 13;
            this.windSpeedLabel.Text = "Wind speed";
            // 
            // windSpeedData
            // 
            this.windSpeedData.AutoSize = true;
            this.windSpeedData.Location = new System.Drawing.Point(265, 281);
            this.windSpeedData.Name = "windSpeedData";
            this.windSpeedData.Size = new System.Drawing.Size(0, 13);
            this.windSpeedData.TabIndex = 14;
            // 
            // globalizaceToolStripMenuItem
            // 
            this.globalizaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csCzToolStripMenuItem,
            this.enToolStripMenuItem});
            this.globalizaceToolStripMenuItem.Name = "globalizaceToolStripMenuItem";
            this.globalizaceToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.globalizaceToolStripMenuItem.Text = "Globalizace";
            // 
            // csCzToolStripMenuItem
            // 
            this.csCzToolStripMenuItem.Name = "csCzToolStripMenuItem";
            this.csCzToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.csCzToolStripMenuItem.Text = "cs-CZ";
            this.csCzToolStripMenuItem.Click += new System.EventHandler(this.csCzToolStripMenuItem_Click);
            // 
            // enToolStripMenuItem
            // 
            this.enToolStripMenuItem.Name = "enToolStripMenuItem";
            this.enToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enToolStripMenuItem.Text = "en-US";
            this.enToolStripMenuItem.Click += new System.EventHandler(this.enToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalizaceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 598);
            this.Controls.Add(this.windSpeedData);
            this.Controls.Add(this.windSpeedLabel);
            this.Controls.Add(this.humidityData);
            this.Controls.Add(this.humidityLabel);
            this.Controls.Add(this.cityNameData);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.temperatureData);
            this.Controls.Add(this.temperatureLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.cityName);
            this.Controls.Add(this.cityNameLabel);
            this.Controls.Add(this.pluginSelector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox pluginSelector;
        private System.Windows.Forms.Label cityNameLabel;
        private System.Windows.Forms.TextBox cityName;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Label temperatureData;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label cityNameData;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label humidityData;
        private System.Windows.Forms.Label windSpeedLabel;
        private System.Windows.Forms.Label windSpeedData;
        private System.Windows.Forms.ToolStripMenuItem globalizaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csCzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

