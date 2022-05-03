namespace CSharpStudyNetFramework.Forms
{
    partial class Form_Exception
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
            if (disposing && (components != null)) {
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
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.TextBox_Exception = new MetroFramework.Controls.MetroTextBox();
            this.Label_Exception = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Stack = new MetroFramework.Controls.MetroTextBox();
            this.Label_Buttons = new MetroFramework.Controls.MetroLabel();
            this.SplitContainer_Buttons_1 = new System.Windows.Forms.SplitContainer();
            this.Button_Retry = new MetroFramework.Controls.MetroButton();
            this.SplitContainer_Buttons_2 = new System.Windows.Forms.SplitContainer();
            this.Button_Abort = new MetroFramework.Controls.MetroButton();
            this.Button_Ignore = new MetroFramework.Controls.MetroButton();
            this.Label_Stack = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons_1)).BeginInit();
            this.SplitContainer_Buttons_1.Panel1.SuspendLayout();
            this.SplitContainer_Buttons_1.Panel2.SuspendLayout();
            this.SplitContainer_Buttons_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons_2)).BeginInit();
            this.SplitContainer_Buttons_2.Panel1.SuspendLayout();
            this.SplitContainer_Buttons_2.Panel2.SuspendLayout();
            this.SplitContainer_Buttons_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.Location = new System.Drawing.Point(20, 60);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            this.SplitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.TextBox_Exception);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Label_Exception);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.TextBox_Stack);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Label_Buttons);
            this.SplitContainer_Main.Panel2.Controls.Add(this.SplitContainer_Buttons_1);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Label_Stack);
            this.SplitContainer_Main.Size = new System.Drawing.Size(600, 240);
            this.SplitContainer_Main.SplitterDistance = 83;
            this.SplitContainer_Main.TabIndex = 3;
            // 
            // TextBox_Exception
            // 
            // 
            // 
            // 
            this.TextBox_Exception.CustomButton.Image = null;
            this.TextBox_Exception.CustomButton.Location = new System.Drawing.Point(542, 1);
            this.TextBox_Exception.CustomButton.Name = "";
            this.TextBox_Exception.CustomButton.Size = new System.Drawing.Size(57, 57);
            this.TextBox_Exception.CustomButton.TabIndex = 1;
            this.TextBox_Exception.CustomButton.UseSelectable = true;
            this.TextBox_Exception.CustomButton.Visible = false;
            this.TextBox_Exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Exception.Lines = new string[0];
            this.TextBox_Exception.Location = new System.Drawing.Point(0, 24);
            this.TextBox_Exception.MaxLength = 32767;
            this.TextBox_Exception.Multiline = true;
            this.TextBox_Exception.Name = "TextBox_Exception";
            this.TextBox_Exception.PasswordChar = '\0';
            this.TextBox_Exception.ReadOnly = true;
            this.TextBox_Exception.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox_Exception.SelectedText = "";
            this.TextBox_Exception.SelectionLength = 0;
            this.TextBox_Exception.SelectionStart = 0;
            this.TextBox_Exception.ShortcutsEnabled = true;
            this.TextBox_Exception.Size = new System.Drawing.Size(600, 59);
            this.TextBox_Exception.TabIndex = 5;
            this.TextBox_Exception.UseSelectable = true;
            this.TextBox_Exception.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Exception.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Exception
            // 
            this.Label_Exception.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Exception.Location = new System.Drawing.Point(0, 0);
            this.Label_Exception.Name = "Label_Exception";
            this.Label_Exception.Size = new System.Drawing.Size(600, 24);
            this.Label_Exception.TabIndex = 4;
            this.Label_Exception.Text = "Исключение:";
            this.Label_Exception.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TextBox_Stack
            // 
            // 
            // 
            // 
            this.TextBox_Stack.CustomButton.Image = null;
            this.TextBox_Stack.CustomButton.Location = new System.Drawing.Point(526, 1);
            this.TextBox_Stack.CustomButton.Name = "";
            this.TextBox_Stack.CustomButton.Size = new System.Drawing.Size(73, 73);
            this.TextBox_Stack.CustomButton.TabIndex = 1;
            this.TextBox_Stack.CustomButton.UseSelectable = true;
            this.TextBox_Stack.CustomButton.Visible = false;
            this.TextBox_Stack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Stack.Lines = new string[0];
            this.TextBox_Stack.Location = new System.Drawing.Point(0, 24);
            this.TextBox_Stack.MaxLength = 32767;
            this.TextBox_Stack.Multiline = true;
            this.TextBox_Stack.Name = "TextBox_Stack";
            this.TextBox_Stack.PasswordChar = '\0';
            this.TextBox_Stack.ReadOnly = true;
            this.TextBox_Stack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox_Stack.SelectedText = "";
            this.TextBox_Stack.SelectionLength = 0;
            this.TextBox_Stack.SelectionStart = 0;
            this.TextBox_Stack.ShortcutsEnabled = true;
            this.TextBox_Stack.Size = new System.Drawing.Size(600, 75);
            this.TextBox_Stack.TabIndex = 7;
            this.TextBox_Stack.UseSelectable = true;
            this.TextBox_Stack.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Stack.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Buttons
            // 
            this.Label_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label_Buttons.Location = new System.Drawing.Point(0, 99);
            this.Label_Buttons.Name = "Label_Buttons";
            this.Label_Buttons.Size = new System.Drawing.Size(600, 24);
            this.Label_Buttons.TabIndex = 10;
            this.Label_Buttons.Text = " ";
            this.Label_Buttons.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SplitContainer_Buttons_1
            // 
            this.SplitContainer_Buttons_1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SplitContainer_Buttons_1.Location = new System.Drawing.Point(0, 123);
            this.SplitContainer_Buttons_1.Name = "SplitContainer_Buttons_1";
            // 
            // SplitContainer_Buttons_1.Panel1
            // 
            this.SplitContainer_Buttons_1.Panel1.Controls.Add(this.Button_Retry);
            // 
            // SplitContainer_Buttons_1.Panel2
            // 
            this.SplitContainer_Buttons_1.Panel2.Controls.Add(this.SplitContainer_Buttons_2);
            this.SplitContainer_Buttons_1.Size = new System.Drawing.Size(600, 30);
            this.SplitContainer_Buttons_1.SplitterDistance = 201;
            this.SplitContainer_Buttons_1.TabIndex = 1;
            // 
            // Button_Retry
            // 
            this.Button_Retry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Retry.Location = new System.Drawing.Point(0, 0);
            this.Button_Retry.Name = "Button_Retry";
            this.Button_Retry.Size = new System.Drawing.Size(201, 30);
            this.Button_Retry.TabIndex = 1;
            this.Button_Retry.Text = "Попробовать ещё раз";
            this.Button_Retry.UseSelectable = true;
            this.Button_Retry.Click += new System.EventHandler(this.Button_Retry_Click);
            // 
            // SplitContainer_Buttons_2
            // 
            this.SplitContainer_Buttons_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Buttons_2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Buttons_2.Name = "SplitContainer_Buttons_2";
            // 
            // SplitContainer_Buttons_2.Panel1
            // 
            this.SplitContainer_Buttons_2.Panel1.Controls.Add(this.Button_Abort);
            // 
            // SplitContainer_Buttons_2.Panel2
            // 
            this.SplitContainer_Buttons_2.Panel2.Controls.Add(this.Button_Ignore);
            this.SplitContainer_Buttons_2.Size = new System.Drawing.Size(395, 30);
            this.SplitContainer_Buttons_2.SplitterDistance = 197;
            this.SplitContainer_Buttons_2.TabIndex = 2;
            // 
            // Button_Abort
            // 
            this.Button_Abort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Abort.Location = new System.Drawing.Point(0, 0);
            this.Button_Abort.Name = "Button_Abort";
            this.Button_Abort.Size = new System.Drawing.Size(197, 30);
            this.Button_Abort.TabIndex = 2;
            this.Button_Abort.Text = "Остановить программу";
            this.Button_Abort.UseSelectable = true;
            this.Button_Abort.Click += new System.EventHandler(this.Button_Abort_Click);
            // 
            // Button_Ignore
            // 
            this.Button_Ignore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Ignore.Location = new System.Drawing.Point(0, 0);
            this.Button_Ignore.Name = "Button_Ignore";
            this.Button_Ignore.Size = new System.Drawing.Size(194, 30);
            this.Button_Ignore.TabIndex = 3;
            this.Button_Ignore.Text = "Игнорировать ошибку";
            this.Button_Ignore.UseSelectable = true;
            this.Button_Ignore.Click += new System.EventHandler(this.Button_Ignore_Click);
            // 
            // Label_Stack
            // 
            this.Label_Stack.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Stack.Location = new System.Drawing.Point(0, 0);
            this.Label_Stack.Name = "Label_Stack";
            this.Label_Stack.Size = new System.Drawing.Size(600, 24);
            this.Label_Stack.TabIndex = 6;
            this.Label_Stack.Text = "Стек вызовов:";
            this.Label_Stack.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form_Exception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.SplitContainer_Main);
            this.MinimumSize = new System.Drawing.Size(640, 320);
            this.Name = "Form_Exception";
            this.Text = "Возникло исключение!";
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.SplitContainer_Buttons_1.Panel1.ResumeLayout(false);
            this.SplitContainer_Buttons_1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons_1)).EndInit();
            this.SplitContainer_Buttons_1.ResumeLayout(false);
            this.SplitContainer_Buttons_2.Panel1.ResumeLayout(false);
            this.SplitContainer_Buttons_2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons_2)).EndInit();
            this.SplitContainer_Buttons_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private MetroFramework.Controls.MetroTextBox TextBox_Exception;
        private MetroFramework.Controls.MetroLabel Label_Exception;
        private MetroFramework.Controls.MetroTextBox TextBox_Stack;
        private MetroFramework.Controls.MetroLabel Label_Buttons;
        private System.Windows.Forms.SplitContainer SplitContainer_Buttons_1;
        private MetroFramework.Controls.MetroButton Button_Retry;
        private System.Windows.Forms.SplitContainer SplitContainer_Buttons_2;
        private MetroFramework.Controls.MetroButton Button_Abort;
        private MetroFramework.Controls.MetroButton Button_Ignore;
        private MetroFramework.Controls.MetroLabel Label_Stack;
    }
}