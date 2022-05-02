namespace CSharpStudyNetCore.Forms;

partial class Form_Data
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
        if (disposing && (components != null)) {
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
            this.Button_UpdateData = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Button_UpdateData
            // 
            this.Button_UpdateData.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_UpdateData.Highlight = false;
            this.Button_UpdateData.Location = new System.Drawing.Point(20, 60);
            this.Button_UpdateData.Name = "Button_UpdateData";
            this.Button_UpdateData.Size = new System.Drawing.Size(760, 39);
            this.Button_UpdateData.Style = MetroFramework.MetroColorStyle.Blue;
            this.Button_UpdateData.StyleManager = null;
            this.Button_UpdateData.TabIndex = 0;
            this.Button_UpdateData.Text = "Обновить данные";
            this.Button_UpdateData.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Form_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_UpdateData);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Form_Data";
            this.Text = "Данные";
            this.ResumeLayout(false);

    }

    #endregion

    private MetroFramework.Controls.MetroButton Button_UpdateData;
}
