namespace HelpDesk
{
    partial class userSelectForm
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
            this.btnFileTicket = new System.Windows.Forms.Button();
            this.btnIT = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileTicket
            // 
            this.btnFileTicket.ForeColor = System.Drawing.Color.Black;
            this.btnFileTicket.Location = new System.Drawing.Point(67, 107);
            this.btnFileTicket.Name = "btnFileTicket";
            this.btnFileTicket.Size = new System.Drawing.Size(146, 35);
            this.btnFileTicket.TabIndex = 1;
            this.btnFileTicket.Text = "File a ticket";
            this.btnFileTicket.UseVisualStyleBackColor = true;
            this.btnFileTicket.Click += new System.EventHandler(this.btnFileTicket_Click);
            // 
            // btnIT
            // 
            this.btnIT.ForeColor = System.Drawing.Color.Black;
            this.btnIT.Location = new System.Drawing.Point(67, 165);
            this.btnIT.Name = "btnIT";
            this.btnIT.Size = new System.Drawing.Size(146, 35);
            this.btnIT.TabIndex = 2;
            this.btnIT.Text = "Technitians";
            this.btnIT.UseVisualStyleBackColor = true;
            this.btnIT.Click += new System.EventHandler(this.btnIT_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnCustomer.Location = new System.Drawing.Point(67, 49);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(146, 35);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Users";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // userSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(270, 244);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnIT);
            this.Controls.Add(this.btnFileTicket);
            this.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "userSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "userSelectForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.userSelectForm_FormClosing);
            this.Load += new System.EventHandler(this.userSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileTicket;
        private System.Windows.Forms.Button btnIT;
        private System.Windows.Forms.Button btnCustomer;
    }
}