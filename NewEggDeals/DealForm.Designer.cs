﻿namespace NewEggDeals
{
  partial class DealForm
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
      this.optionsPanel = new System.Windows.Forms.Panel();
      this.newCheckBox = new System.Windows.Forms.CheckBox();
      this.dealPanel = new System.Windows.Forms.Panel();
      this.optionsPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // optionsPanel
      // 
      this.optionsPanel.Controls.Add(this.newCheckBox);
      this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.optionsPanel.Location = new System.Drawing.Point(0, 0);
      this.optionsPanel.Name = "optionsPanel";
      this.optionsPanel.Size = new System.Drawing.Size(692, 30);
      this.optionsPanel.TabIndex = 1;
      // 
      // newCheckBox
      // 
      this.newCheckBox.AutoSize = true;
      this.newCheckBox.Location = new System.Drawing.Point(12, 7);
      this.newCheckBox.Name = "newCheckBox";
      this.newCheckBox.Size = new System.Drawing.Size(126, 17);
      this.newCheckBox.TabIndex = 0;
      this.newCheckBox.Text = "Only show new deals";
      this.newCheckBox.UseVisualStyleBackColor = true;
      this.newCheckBox.CheckedChanged += new System.EventHandler(this.newCheckBox_CheckedChanged);
      // 
      // dealPanel
      // 
      this.dealPanel.AutoScroll = true;
      this.dealPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dealPanel.Location = new System.Drawing.Point(0, 30);
      this.dealPanel.Name = "dealPanel";
      this.dealPanel.Size = new System.Drawing.Size(692, 86);
      this.dealPanel.TabIndex = 2;
      // 
      // DealForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(692, 116);
      this.Controls.Add(this.dealPanel);
      this.Controls.Add(this.optionsPanel);
      this.Name = "DealForm";
      this.Text = "Deals";
      this.Load += new System.EventHandler(this.FillDeals);
      this.optionsPanel.ResumeLayout(false);
      this.optionsPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel optionsPanel;
    private System.Windows.Forms.CheckBox newCheckBox;
    private System.Windows.Forms.Panel dealPanel;

  }
}

