namespace HelpDesk
{
    partial class TechnitianForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtRoomNum = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.grpUrgency = new System.Windows.Forms.GroupBox();
            this.radHigh = new System.Windows.Forms.RadioButton();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.radLow = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTechnitian = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.listTickets = new System.Windows.Forms.ListBox();
            this.btnITUserTickets = new System.Windows.Forms.Button();
            this.btnOpenTickets = new System.Windows.Forms.Button();
            this.btnIT = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.grpUrgency.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(663, 917);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 45);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtRoomNum
            // 
            this.txtRoomNum.Enabled = false;
            this.txtRoomNum.Location = new System.Drawing.Point(13, 494);
            this.txtRoomNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoomNum.Name = "txtRoomNum";
            this.txtRoomNum.Size = new System.Drawing.Size(132, 27);
            this.txtRoomNum.TabIndex = 17;
            // 
            // rtbDescription
            // 
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Enabled = false;
            this.rtbDescription.Location = new System.Drawing.Point(13, 588);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(740, 304);
            this.rtbDescription.TabIndex = 16;
            this.rtbDescription.Text = "";
            // 
            // grpUrgency
            // 
            this.grpUrgency.Controls.Add(this.radHigh);
            this.grpUrgency.Controls.Add(this.radMedium);
            this.grpUrgency.Controls.Add(this.radLow);
            this.grpUrgency.Enabled = false;
            this.grpUrgency.ForeColor = System.Drawing.Color.White;
            this.grpUrgency.Location = new System.Drawing.Point(273, 179);
            this.grpUrgency.Margin = new System.Windows.Forms.Padding(4);
            this.grpUrgency.Name = "grpUrgency";
            this.grpUrgency.Padding = new System.Windows.Forms.Padding(4);
            this.grpUrgency.Size = new System.Drawing.Size(129, 168);
            this.grpUrgency.TabIndex = 15;
            this.grpUrgency.TabStop = false;
            this.grpUrgency.Text = "Urgency";
            // 
            // radHigh
            // 
            this.radHigh.AutoSize = true;
            this.radHigh.Location = new System.Drawing.Point(8, 123);
            this.radHigh.Margin = new System.Windows.Forms.Padding(4);
            this.radHigh.Name = "radHigh";
            this.radHigh.Size = new System.Drawing.Size(59, 23);
            this.radHigh.TabIndex = 2;
            this.radHigh.TabStop = true;
            this.radHigh.Text = "High";
            this.radHigh.UseVisualStyleBackColor = true;
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Location = new System.Drawing.Point(8, 80);
            this.radMedium.Margin = new System.Windows.Forms.Padding(4);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(82, 23);
            this.radMedium.TabIndex = 1;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "Medium";
            this.radMedium.UseVisualStyleBackColor = true;
            // 
            // radLow
            // 
            this.radLow.AutoSize = true;
            this.radLow.Location = new System.Drawing.Point(8, 38);
            this.radLow.Margin = new System.Windows.Forms.Padding(4);
            this.radLow.Name = "radLow";
            this.radLow.Size = new System.Drawing.Size(54, 23);
            this.radLow.TabIndex = 0;
            this.radLow.TabStop = true;
            this.radLow.Text = "Low";
            this.radLow.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 404);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Building";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 471);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Room Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ticket Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 556);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ticket Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ticket Area";
            // 
            // cmbTechnitian
            // 
            this.cmbTechnitian.FormattingEnabled = true;
            this.cmbTechnitian.Location = new System.Drawing.Point(12, 55);
            this.cmbTechnitian.Name = "cmbTechnitian";
            this.cmbTechnitian.Size = new System.Drawing.Size(328, 27);
            this.cmbTechnitian.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "Technitians";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Open",
            "In Progress",
            "Closed"});
            this.cmbStatus.Location = new System.Drawing.Point(12, 126);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 27);
            this.cmbStatus.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(635, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tickets";
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(12, 374);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(272, 27);
            this.txtTitle.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Title";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(286, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(467, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Please select a technitian or Please select a ticket";
            // 
            // txtBuilding
            // 
            this.txtBuilding.Enabled = false;
            this.txtBuilding.Location = new System.Drawing.Point(12, 426);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(272, 27);
            this.txtBuilding.TabIndex = 25;
            // 
            // txtArea
            // 
            this.txtArea.Enabled = false;
            this.txtArea.Location = new System.Drawing.Point(12, 206);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(238, 27);
            this.txtArea.TabIndex = 25;
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(12, 282);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(188, 27);
            this.txtType.TabIndex = 25;
            // 
            // listTickets
            // 
            this.listTickets.FormattingEnabled = true;
            this.listTickets.HorizontalScrollbar = true;
            this.listTickets.ItemHeight = 19;
            this.listTickets.Location = new System.Drawing.Point(621, 59);
            this.listTickets.Name = "listTickets";
            this.listTickets.Size = new System.Drawing.Size(502, 517);
            this.listTickets.TabIndex = 27;
            this.listTickets.SelectedIndexChanged += new System.EventHandler(this.listTickets_SelectedIndexChanged_1);
            // 
            // btnITUserTickets
            // 
            this.btnITUserTickets.Location = new System.Drawing.Point(357, 51);
            this.btnITUserTickets.Name = "btnITUserTickets";
            this.btnITUserTickets.Size = new System.Drawing.Size(114, 33);
            this.btnITUserTickets.TabIndex = 28;
            this.btnITUserTickets.Text = "My Tickets";
            this.btnITUserTickets.UseVisualStyleBackColor = true;
            this.btnITUserTickets.Click += new System.EventHandler(this.btnITUserTickets_Click);
            // 
            // btnOpenTickets
            // 
            this.btnOpenTickets.Location = new System.Drawing.Point(477, 51);
            this.btnOpenTickets.Name = "btnOpenTickets";
            this.btnOpenTickets.Size = new System.Drawing.Size(114, 33);
            this.btnOpenTickets.TabIndex = 29;
            this.btnOpenTickets.Text = "Open Tickets";
            this.btnOpenTickets.UseVisualStyleBackColor = true;
            this.btnOpenTickets.Click += new System.EventHandler(this.btnOpenTickets_Click);
            // 
            // btnIT
            // 
            this.btnIT.Location = new System.Drawing.Point(150, 122);
            this.btnIT.Name = "btnIT";
            this.btnIT.Size = new System.Drawing.Size(114, 33);
            this.btnIT.TabIndex = 30;
            this.btnIT.Text = "IT Amin";
            this.btnIT.UseVisualStyleBackColor = true;
            this.btnIT.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Location = new System.Drawing.Point(277, 129);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(205, 19);
            this.lblAdmin.TabIndex = 31;
            this.lblAdmin.Text = "Use to search tickets by status";
            this.lblAdmin.Visible = false;
            // 
            // TechnitianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1135, 974);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnIT);
            this.Controls.Add(this.btnOpenTickets);
            this.Controls.Add(this.btnITUserTickets);
            this.Controls.Add(this.listTickets);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTechnitian);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtRoomNum);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.grpUrgency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TechnitianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechnitianForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TechnitianForm_FormClosing);
            this.Load += new System.EventHandler(this.TechnitianForm_Load);
            this.grpUrgency.ResumeLayout(false);
            this.grpUrgency.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtRoomNum;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.GroupBox grpUrgency;
        private System.Windows.Forms.RadioButton radHigh;
        private System.Windows.Forms.RadioButton radMedium;
        private System.Windows.Forms.RadioButton radLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTechnitian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.ListBox listTickets;
        private System.Windows.Forms.Button btnITUserTickets;
        private System.Windows.Forms.Button btnOpenTickets;
        private System.Windows.Forms.Button btnIT;
        private System.Windows.Forms.Label lblAdmin;
    }
}