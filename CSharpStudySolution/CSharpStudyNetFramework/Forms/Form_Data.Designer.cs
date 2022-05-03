namespace CSharpStudyNetFramework.Forms
{
    partial class Form_Data : Form_Base
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grid_Data = new MetroFramework.Controls.MetroGrid();
            this.Label_Data = new MetroFramework.Controls.MetroLabel();
            this.SplitContainer_Buttons = new System.Windows.Forms.SplitContainer();
            this.Button_UpdateData = new MetroFramework.Controls.MetroButton();
            this.Button_Create = new MetroFramework.Controls.MetroButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Button_Delete = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons)).BeginInit();
            this.SplitContainer_Buttons.Panel1.SuspendLayout();
            this.SplitContainer_Buttons.Panel2.SuspendLayout();
            this.SplitContainer_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_Data
            // 
            this.Grid_Data.AllowUserToResizeRows = false;
            this.Grid_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_Data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grid_Data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Data.EnableHeadersVisualStyles = false;
            this.Grid_Data.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Grid_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_Data.Location = new System.Drawing.Point(20, 113);
            this.Grid_Data.Name = "Grid_Data";
            this.Grid_Data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Data.Size = new System.Drawing.Size(760, 317);
            this.Grid_Data.TabIndex = 1;
            // 
            // Label_Data
            // 
            this.Label_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Data.Location = new System.Drawing.Point(20, 94);
            this.Label_Data.Name = "Label_Data";
            this.Label_Data.Size = new System.Drawing.Size(760, 19);
            this.Label_Data.TabIndex = 2;
            this.Label_Data.Text = " ";
            // 
            // SplitContainer_Buttons
            // 
            this.SplitContainer_Buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.SplitContainer_Buttons.Location = new System.Drawing.Point(20, 60);
            this.SplitContainer_Buttons.Name = "SplitContainer_Buttons";
            // 
            // SplitContainer_Buttons.Panel1
            // 
            this.SplitContainer_Buttons.Panel1.Controls.Add(this.Button_UpdateData);
            // 
            // SplitContainer_Buttons.Panel2
            // 
            this.SplitContainer_Buttons.Panel2.Controls.Add(this.splitContainer1);
            this.SplitContainer_Buttons.Size = new System.Drawing.Size(760, 34);
            this.SplitContainer_Buttons.SplitterDistance = 266;
            this.SplitContainer_Buttons.TabIndex = 4;
            // 
            // Button_UpdateData
            // 
            this.Button_UpdateData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_UpdateData.Location = new System.Drawing.Point(0, 0);
            this.Button_UpdateData.Name = "Button_UpdateData";
            this.Button_UpdateData.Size = new System.Drawing.Size(266, 34);
            this.Button_UpdateData.TabIndex = 1;
            this.Button_UpdateData.Text = "Обновить данные";
            this.Button_UpdateData.UseSelectable = true;
            this.Button_UpdateData.Click += new System.EventHandler(this.Button_UpdateData_Click);
            // 
            // Button_Create
            // 
            this.Button_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Create.Location = new System.Drawing.Point(0, 0);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(240, 34);
            this.Button_Create.TabIndex = 4;
            this.Button_Create.Text = "Создать новую запись";
            this.Button_Create.UseSelectable = true;
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Button_Create);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Button_Delete);
            this.splitContainer1.Size = new System.Drawing.Size(490, 34);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 0;
            // 
            // Button_Delete
            // 
            this.Button_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Delete.Location = new System.Drawing.Point(0, 0);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(246, 34);
            this.Button_Delete.TabIndex = 5;
            this.Button_Delete.Text = "Удалить выбранную запись";
            this.Button_Delete.UseSelectable = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Form_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Grid_Data);
            this.Controls.Add(this.Label_Data);
            this.Controls.Add(this.SplitContainer_Buttons);
            this.Name = "Form_Data";
            this.Text = "Данные";
            this.Load += new System.EventHandler(this.Form_Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Data)).EndInit();
            this.SplitContainer_Buttons.Panel1.ResumeLayout(false);
            this.SplitContainer_Buttons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons)).EndInit();
            this.SplitContainer_Buttons.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroGrid Grid_Data;
        private MetroFramework.Controls.MetroLabel Label_Data;
        private System.Windows.Forms.SplitContainer SplitContainer_Buttons;
        private MetroFramework.Controls.MetroButton Button_UpdateData;
        private MetroFramework.Controls.MetroButton Button_Create;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroButton Button_Delete;
    }
}

