﻿namespace NewEggDeals.Controls
{
  partial class DealControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.titleLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.savingsLabel = new System.Windows.Forms.Label();
      this.priceLabel = new System.Windows.Forms.Label();
      this.dateLabel = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.camelLinkLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox
      // 
      this.pictureBox.Image = global::NewEggDeals.Properties.Resources.Solution;
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(64, 64);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      // 
      // titleLabel
      // 
      this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.titleLabel.Location = new System.Drawing.Point(71, 4);
      this.titleLabel.Name = "titleLabel";
      this.titleLabel.Size = new System.Drawing.Size(439, 29);
      this.titleLabel.TabIndex = 1;
      this.titleLabel.Text = "TITLE XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXY" +
    "";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(71, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Price:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(71, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(48, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Savings:";
      // 
      // savingsLabel
      // 
      this.savingsLabel.AutoSize = true;
      this.savingsLabel.Location = new System.Drawing.Point(125, 48);
      this.savingsLabel.Name = "savingsLabel";
      this.savingsLabel.Size = new System.Drawing.Size(69, 13);
      this.savingsLabel.TabIndex = 5;
      this.savingsLabel.Text = "23% ($54.00)";
      // 
      // priceLabel
      // 
      this.priceLabel.AutoSize = true;
      this.priceLabel.Location = new System.Drawing.Point(125, 33);
      this.priceLabel.Name = "priceLabel";
      this.priceLabel.Size = new System.Drawing.Size(46, 13);
      this.priceLabel.TabIndex = 4;
      this.priceLabel.Text = "$254.44";
      // 
      // dateLabel
      // 
      this.dateLabel.AutoSize = true;
      this.dateLabel.Location = new System.Drawing.Point(262, 48);
      this.dateLabel.Name = "dateLabel";
      this.dateLabel.Size = new System.Drawing.Size(114, 13);
      this.dateLabel.TabIndex = 7;
      this.dateLabel.Text = "01/01/2001 12:00 AM";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(200, 48);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(56, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Published:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(451, 48);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(0, 13);
      this.label3.TabIndex = 9;
      // 
      // camelLinkLabel
      // 
      this.camelLinkLabel.AutoSize = true;
      this.camelLinkLabel.Location = new System.Drawing.Point(413, 48);
      this.camelLinkLabel.Name = "camelLinkLabel";
      this.camelLinkLabel.Size = new System.Drawing.Size(97, 13);
      this.camelLinkLabel.TabIndex = 8;
      this.camelLinkLabel.Text = "CamelCamelCamel:";
      this.camelLinkLabel.Click += new System.EventHandler(this.camelLinkLabel_Click);
      // 
      // DealControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.label3);
      this.Controls.Add(this.camelLinkLabel);
      this.Controls.Add(this.dateLabel);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.savingsLabel);
      this.Controls.Add(this.priceLabel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.titleLabel);
      this.Controls.Add(this.pictureBox);
      this.Name = "DealControl";
      this.Size = new System.Drawing.Size(513, 64);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label savingsLabel;
    private System.Windows.Forms.Label priceLabel;
    private System.Windows.Forms.Label dateLabel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label camelLinkLabel;
  }
}
