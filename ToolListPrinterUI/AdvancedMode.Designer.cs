
namespace ToolListPrinterUI
{
    partial class AdvancedMode
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
            this.programLabel = new System.Windows.Forms.Label();
            this.enterPartNumberLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.returnButton = new System.Windows.Forms.Button();
            this.createAndOpenFileButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.loadToolListsButton = new System.Windows.Forms.Button();
            this.partNumberTextBox = new System.Windows.Forms.TextBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.toolListsListBox = new System.Windows.Forms.CheckedListBox();
            this.selectToolListsLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.ignoreMissingCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // programLabel
            // 
            this.programLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.programLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.programLabel.Location = new System.Drawing.Point(0, 0);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(684, 57);
            this.programLabel.TabIndex = 2;
            this.programLabel.Text = "Tool List Printer Application by PetoMPP";
            this.programLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enterPartNumberLabel
            // 
            this.enterPartNumberLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.enterPartNumberLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.enterPartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.enterPartNumberLabel.Location = new System.Drawing.Point(0, 5);
            this.enterPartNumberLabel.Name = "enterPartNumberLabel";
            this.enterPartNumberLabel.Size = new System.Drawing.Size(217, 32);
            this.enterPartNumberLabel.TabIndex = 8;
            this.enterPartNumberLabel.Text = "Wpisz numer detalu:";
            this.enterPartNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.returnButton);
            this.bottomPanel.Controls.Add(this.createAndOpenFileButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 358);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(10);
            this.bottomPanel.Size = new System.Drawing.Size(684, 103);
            this.bottomPanel.TabIndex = 11;
            // 
            // returnButton
            // 
            this.returnButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.returnButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.returnButton.FlatAppearance.BorderSize = 2;
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.returnButton.Location = new System.Drawing.Point(576, 10);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(98, 83);
            this.returnButton.TabIndex = 10;
            this.returnButton.Text = "Powrót";
            this.returnButton.UseVisualStyleBackColor = true;
            // 
            // createAndOpenFileButton
            // 
            this.createAndOpenFileButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.createAndOpenFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.createAndOpenFileButton.FlatAppearance.BorderSize = 2;
            this.createAndOpenFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createAndOpenFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createAndOpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAndOpenFileButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createAndOpenFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.createAndOpenFileButton.Location = new System.Drawing.Point(10, 10);
            this.createAndOpenFileButton.Name = "createAndOpenFileButton";
            this.createAndOpenFileButton.Size = new System.Drawing.Size(306, 83);
            this.createAndOpenFileButton.TabIndex = 9;
            this.createAndOpenFileButton.Text = "Stwórz i otwórz listę narzędzi z wybranych pozycji";
            this.createAndOpenFileButton.UseVisualStyleBackColor = true;
            this.createAndOpenFileButton.Click += new System.EventHandler(this.CreateAndOpenFileButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.loadToolListsButton);
            this.topPanel.Controls.Add(this.partNumberTextBox);
            this.topPanel.Controls.Add(this.enterPartNumberLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 57);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.topPanel.Size = new System.Drawing.Size(684, 42);
            this.topPanel.TabIndex = 12;
            // 
            // loadToolListsButton
            // 
            this.loadToolListsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.loadToolListsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.loadToolListsButton.FlatAppearance.BorderSize = 2;
            this.loadToolListsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.loadToolListsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadToolListsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadToolListsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadToolListsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.loadToolListsButton.Location = new System.Drawing.Point(491, 5);
            this.loadToolListsButton.Name = "loadToolListsButton";
            this.loadToolListsButton.Size = new System.Drawing.Size(188, 32);
            this.loadToolListsButton.TabIndex = 11;
            this.loadToolListsButton.Text = "Załaduj listy narzędziowe";
            this.loadToolListsButton.UseVisualStyleBackColor = true;
            this.loadToolListsButton.Click += new System.EventHandler(this.LoadToolListsButton_Click);
            // 
            // partNumberTextBox
            // 
            this.partNumberTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.partNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.partNumberTextBox.Location = new System.Drawing.Point(217, 5);
            this.partNumberTextBox.Name = "partNumberTextBox";
            this.partNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.partNumberTextBox.Size = new System.Drawing.Size(247, 32);
            this.partNumberTextBox.TabIndex = 10;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.toolListsListBox);
            this.leftPanel.Controls.Add(this.selectToolListsLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 99);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(342, 259);
            this.leftPanel.TabIndex = 13;
            // 
            // toolListsListBox
            // 
            this.toolListsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolListsListBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListsListBox.FormattingEnabled = true;
            this.toolListsListBox.HorizontalScrollbar = true;
            this.toolListsListBox.Location = new System.Drawing.Point(0, 35);
            this.toolListsListBox.Name = "toolListsListBox";
            this.toolListsListBox.Size = new System.Drawing.Size(342, 224);
            this.toolListsListBox.TabIndex = 16;
            // 
            // selectToolListsLabel
            // 
            this.selectToolListsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectToolListsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectToolListsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.selectToolListsLabel.Location = new System.Drawing.Point(0, 0);
            this.selectToolListsLabel.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.selectToolListsLabel.Name = "selectToolListsLabel";
            this.selectToolListsLabel.Size = new System.Drawing.Size(342, 35);
            this.selectToolListsLabel.TabIndex = 15;
            this.selectToolListsLabel.Text = "Wybierz tool listy do druku:";
            this.selectToolListsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.ignoreMissingCheckBox);
            this.rightPanel.Controls.Add(this.optionsLabel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(342, 99);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(342, 259);
            this.rightPanel.TabIndex = 14;
            // 
            // ignoreMissingCheckBox
            // 
            this.ignoreMissingCheckBox.AutoSize = true;
            this.ignoreMissingCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ignoreMissingCheckBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ignoreMissingCheckBox.Location = new System.Drawing.Point(0, 35);
            this.ignoreMissingCheckBox.Name = "ignoreMissingCheckBox";
            this.ignoreMissingCheckBox.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ignoreMissingCheckBox.Size = new System.Drawing.Size(342, 29);
            this.ignoreMissingCheckBox.TabIndex = 17;
            this.ignoreMissingCheckBox.Text = "Ignoruj brakujące narzędzia";
            this.ignoreMissingCheckBox.UseVisualStyleBackColor = true;
            // 
            // optionsLabel
            // 
            this.optionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.optionsLabel.Location = new System.Drawing.Point(0, 0);
            this.optionsLabel.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(342, 35);
            this.optionsLabel.TabIndex = 16;
            this.optionsLabel.Text = "Opcje:";
            this.optionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdvancedMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.programLabel);
            this.Name = "AdvancedMode";
            this.Text = "AdvancedMode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdvancedMode_FormClosed);
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.Label enterPartNumberLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.TextBox partNumberTextBox;
        private System.Windows.Forms.Button loadToolListsButton;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.CheckedListBox toolListsListBox;
        private System.Windows.Forms.Label selectToolListsLabel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.CheckBox ignoreMissingCheckBox;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Button createAndOpenFileButton;
        private System.Windows.Forms.Button returnButton;
    }
}