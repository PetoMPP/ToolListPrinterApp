
namespace ToolListPrinterUI
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.programLabel = new System.Windows.Forms.Label();
            this.partNumberTextBox = new System.Windows.Forms.TextBox();
            this.enterPartNumberLabel = new System.Windows.Forms.Label();
            this.createAndOpenFileButton = new System.Windows.Forms.Button();
            this.ignoreMissingCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedModeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // programLabel
            // 
            this.programLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.programLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.programLabel.Location = new System.Drawing.Point(0, 0);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(384, 93);
            this.programLabel.TabIndex = 1;
            this.programLabel.Text = "Tool List Printer Application by PetoMPP";
            this.programLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // partNumberTextBox
            // 
            this.partNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.partNumberTextBox.Location = new System.Drawing.Point(69, 132);
            this.partNumberTextBox.Name = "partNumberTextBox";
            this.partNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.partNumberTextBox.Size = new System.Drawing.Size(247, 32);
            this.partNumberTextBox.TabIndex = 6;
            // 
            // enterPartNumberLabel
            // 
            this.enterPartNumberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.enterPartNumberLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.enterPartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.enterPartNumberLabel.Location = new System.Drawing.Point(0, 93);
            this.enterPartNumberLabel.Name = "enterPartNumberLabel";
            this.enterPartNumberLabel.Size = new System.Drawing.Size(384, 36);
            this.enterPartNumberLabel.TabIndex = 7;
            this.enterPartNumberLabel.Text = "Wpisz numer detalu:";
            this.enterPartNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createAndOpenFileButton
            // 
            this.createAndOpenFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.createAndOpenFileButton.FlatAppearance.BorderSize = 2;
            this.createAndOpenFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createAndOpenFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createAndOpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAndOpenFileButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createAndOpenFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.createAndOpenFileButton.Location = new System.Drawing.Point(98, 201);
            this.createAndOpenFileButton.Name = "createAndOpenFileButton";
            this.createAndOpenFileButton.Size = new System.Drawing.Size(188, 93);
            this.createAndOpenFileButton.TabIndex = 8;
            this.createAndOpenFileButton.Text = "Stwórz i otwórz listę narzędzi";
            this.createAndOpenFileButton.UseVisualStyleBackColor = true;
            this.createAndOpenFileButton.Click += new System.EventHandler(this.CreateAndOpenFileButton_Click);
            // 
            // ignoreMissingCheckBox
            // 
            this.ignoreMissingCheckBox.AutoSize = true;
            this.ignoreMissingCheckBox.Location = new System.Drawing.Point(69, 173);
            this.ignoreMissingCheckBox.Name = "ignoreMissingCheckBox";
            this.ignoreMissingCheckBox.Size = new System.Drawing.Size(170, 19);
            this.ignoreMissingCheckBox.TabIndex = 9;
            this.ignoreMissingCheckBox.Text = "Ignoruj brakujące narzędzia";
            this.ignoreMissingCheckBox.UseVisualStyleBackColor = true;
            // 
            // advancedModeLinkLabel
            // 
            this.advancedModeLinkLabel.AutoSize = true;
            this.advancedModeLinkLabel.Location = new System.Drawing.Point(200, 337);
            this.advancedModeLinkLabel.Name = "advancedModeLinkLabel";
            this.advancedModeLinkLabel.Size = new System.Drawing.Size(172, 15);
            this.advancedModeLinkLabel.TabIndex = 10;
            this.advancedModeLinkLabel.TabStop = true;
            this.advancedModeLinkLabel.Text = "Idź do trybu zaawansowanego..";
            this.advancedModeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AdvancedModeLinkLabel_LinkClicked);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.advancedModeLinkLabel);
            this.Controls.Add(this.ignoreMissingCheckBox);
            this.Controls.Add(this.createAndOpenFileButton);
            this.Controls.Add(this.enterPartNumberLabel);
            this.Controls.Add(this.partNumberTextBox);
            this.Controls.Add(this.programLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "Tool List Printer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.TextBox partNumberTextBox;
        private System.Windows.Forms.Label enterPartNumberLabel;
        private System.Windows.Forms.Button createAndOpenFileButton;
        private System.Windows.Forms.CheckBox ignoreMissingCheckBox;
        private System.Windows.Forms.LinkLabel advancedModeLinkLabel;
    }
}

