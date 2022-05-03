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
            this.Label_Data = new MetroFramework.Controls.MetroLabel();
            this.TabControl_Data = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SplitContainer_Author_Main = new System.Windows.Forms.SplitContainer();
            this.Grid_Data = new MetroFramework.Controls.MetroGrid();
            this.Label_Author_Data = new MetroFramework.Controls.MetroLabel();
            this.Label_Author_Bottom = new MetroFramework.Controls.MetroLabel();
            this.Button_Author_Create = new MetroFramework.Controls.MetroButton();
            this.Label_Author_Create = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Author_MiddleName = new MetroFramework.Controls.MetroTextBox();
            this.Label_Author_MiddleName = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Author_LastName = new MetroFramework.Controls.MetroTextBox();
            this.Label_Author_LastName = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Author_FirstName = new MetroFramework.Controls.MetroTextBox();
            this.Label_Author_FirstName = new MetroFramework.Controls.MetroLabel();
            this.Label_Author_Header = new MetroFramework.Controls.MetroLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.Button_DeleteData = new MetroFramework.Controls.MetroButton();
            this.Button_UpdateData = new MetroFramework.Controls.MetroButton();
            this.SplitContainer_Buttons = new System.Windows.Forms.SplitContainer();
            this.TabControl_Data.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Author_Main)).BeginInit();
            this.SplitContainer_Author_Main.Panel1.SuspendLayout();
            this.SplitContainer_Author_Main.Panel2.SuspendLayout();
            this.SplitContainer_Author_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons)).BeginInit();
            this.SplitContainer_Buttons.Panel1.SuspendLayout();
            this.SplitContainer_Buttons.Panel2.SuspendLayout();
            this.SplitContainer_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Data
            // 
            this.Label_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Data.Location = new System.Drawing.Point(20, 94);
            this.Label_Data.Name = "Label_Data";
            this.Label_Data.Size = new System.Drawing.Size(600, 19);
            this.Label_Data.TabIndex = 2;
            this.Label_Data.Text = " ";
            // 
            // TabControl_Data
            // 
            this.TabControl_Data.Controls.Add(this.tabPage1);
            this.TabControl_Data.Controls.Add(this.tabPage2);
            this.TabControl_Data.Controls.Add(this.tabPage3);
            this.TabControl_Data.Controls.Add(this.tabPage4);
            this.TabControl_Data.Controls.Add(this.tabPage5);
            this.TabControl_Data.Controls.Add(this.tabPage6);
            this.TabControl_Data.Controls.Add(this.tabPage7);
            this.TabControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Data.Location = new System.Drawing.Point(20, 113);
            this.TabControl_Data.Name = "TabControl_Data";
            this.TabControl_Data.SelectedIndex = 0;
            this.TabControl_Data.Size = new System.Drawing.Size(600, 287);
            this.TabControl_Data.TabIndex = 5;
            this.TabControl_Data.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SplitContainer_Author_Main);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(592, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bookmakers";
            // 
            // SplitContainer_Author_Main
            // 
            this.SplitContainer_Author_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Author_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Author_Main.Name = "SplitContainer_Author_Main";
            // 
            // SplitContainer_Author_Main.Panel1
            // 
            this.SplitContainer_Author_Main.Panel1.Controls.Add(this.Grid_Data);
            this.SplitContainer_Author_Main.Panel1.Controls.Add(this.Label_Author_Data);
            // 
            // SplitContainer_Author_Main.Panel2
            // 
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_Bottom);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Button_Author_Create);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_Create);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.TextBox_Author_MiddleName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_MiddleName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.TextBox_Author_LastName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_LastName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.TextBox_Author_FirstName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_FirstName);
            this.SplitContainer_Author_Main.Panel2.Controls.Add(this.Label_Author_Header);
            this.SplitContainer_Author_Main.Size = new System.Drawing.Size(592, 245);
            this.SplitContainer_Author_Main.SplitterDistance = 370;
            this.SplitContainer_Author_Main.TabIndex = 7;
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
            this.Grid_Data.Location = new System.Drawing.Point(0, 35);
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
            this.Grid_Data.RowHeadersVisible = false;
            this.Grid_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Data.Size = new System.Drawing.Size(370, 210);
            this.Grid_Data.TabIndex = 2;
            // 
            // Label_Author_Data
            // 
            this.Label_Author_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_Data.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Label_Author_Data.Location = new System.Drawing.Point(0, 0);
            this.Label_Author_Data.Name = "Label_Author_Data";
            this.Label_Author_Data.Size = new System.Drawing.Size(370, 35);
            this.Label_Author_Data.TabIndex = 4;
            this.Label_Author_Data.Text = "Список авторов";
            this.Label_Author_Data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Author_Bottom
            // 
            this.Label_Author_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Author_Bottom.Location = new System.Drawing.Point(0, 238);
            this.Label_Author_Bottom.Name = "Label_Author_Bottom";
            this.Label_Author_Bottom.Size = new System.Drawing.Size(218, 7);
            this.Label_Author_Bottom.TabIndex = 11;
            this.Label_Author_Bottom.Text = " ";
            // 
            // Button_Author_Create
            // 
            this.Button_Author_Create.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Author_Create.Location = new System.Drawing.Point(0, 200);
            this.Button_Author_Create.Name = "Button_Author_Create";
            this.Button_Author_Create.Size = new System.Drawing.Size(218, 38);
            this.Button_Author_Create.TabIndex = 10;
            this.Button_Author_Create.Text = "Создать новую запись";
            this.Button_Author_Create.UseSelectable = true;
            this.Button_Author_Create.Click += new System.EventHandler(this.Button_Author_Create_Click);
            // 
            // Label_Author_Create
            // 
            this.Label_Author_Create.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_Create.Location = new System.Drawing.Point(0, 176);
            this.Label_Author_Create.Name = "Label_Author_Create";
            this.Label_Author_Create.Size = new System.Drawing.Size(218, 24);
            this.Label_Author_Create.TabIndex = 12;
            this.Label_Author_Create.Text = " ";
            // 
            // TextBox_Author_MiddleName
            // 
            // 
            // 
            // 
            this.TextBox_Author_MiddleName.CustomButton.Image = null;
            this.TextBox_Author_MiddleName.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.TextBox_Author_MiddleName.CustomButton.Name = "";
            this.TextBox_Author_MiddleName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Author_MiddleName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Author_MiddleName.CustomButton.TabIndex = 1;
            this.TextBox_Author_MiddleName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Author_MiddleName.CustomButton.UseSelectable = true;
            this.TextBox_Author_MiddleName.CustomButton.Visible = false;
            this.TextBox_Author_MiddleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBox_Author_MiddleName.Lines = new string[0];
            this.TextBox_Author_MiddleName.Location = new System.Drawing.Point(0, 153);
            this.TextBox_Author_MiddleName.MaxLength = 32767;
            this.TextBox_Author_MiddleName.Name = "TextBox_Author_MiddleName";
            this.TextBox_Author_MiddleName.PasswordChar = '\0';
            this.TextBox_Author_MiddleName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Author_MiddleName.SelectedText = "";
            this.TextBox_Author_MiddleName.SelectionLength = 0;
            this.TextBox_Author_MiddleName.SelectionStart = 0;
            this.TextBox_Author_MiddleName.ShortcutsEnabled = true;
            this.TextBox_Author_MiddleName.ShowClearButton = true;
            this.TextBox_Author_MiddleName.Size = new System.Drawing.Size(218, 23);
            this.TextBox_Author_MiddleName.TabIndex = 9;
            this.TextBox_Author_MiddleName.UseSelectable = true;
            this.TextBox_Author_MiddleName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Author_MiddleName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Author_MiddleName
            // 
            this.Label_Author_MiddleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_MiddleName.Location = new System.Drawing.Point(0, 129);
            this.Label_Author_MiddleName.Name = "Label_Author_MiddleName";
            this.Label_Author_MiddleName.Size = new System.Drawing.Size(218, 24);
            this.Label_Author_MiddleName.TabIndex = 8;
            this.Label_Author_MiddleName.Text = "Отчество:";
            this.Label_Author_MiddleName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TextBox_Author_LastName
            // 
            // 
            // 
            // 
            this.TextBox_Author_LastName.CustomButton.Image = null;
            this.TextBox_Author_LastName.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.TextBox_Author_LastName.CustomButton.Name = "";
            this.TextBox_Author_LastName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Author_LastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Author_LastName.CustomButton.TabIndex = 1;
            this.TextBox_Author_LastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Author_LastName.CustomButton.UseSelectable = true;
            this.TextBox_Author_LastName.CustomButton.Visible = false;
            this.TextBox_Author_LastName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBox_Author_LastName.Lines = new string[0];
            this.TextBox_Author_LastName.Location = new System.Drawing.Point(0, 106);
            this.TextBox_Author_LastName.MaxLength = 32767;
            this.TextBox_Author_LastName.Name = "TextBox_Author_LastName";
            this.TextBox_Author_LastName.PasswordChar = '\0';
            this.TextBox_Author_LastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Author_LastName.SelectedText = "";
            this.TextBox_Author_LastName.SelectionLength = 0;
            this.TextBox_Author_LastName.SelectionStart = 0;
            this.TextBox_Author_LastName.ShortcutsEnabled = true;
            this.TextBox_Author_LastName.ShowClearButton = true;
            this.TextBox_Author_LastName.Size = new System.Drawing.Size(218, 23);
            this.TextBox_Author_LastName.TabIndex = 7;
            this.TextBox_Author_LastName.UseSelectable = true;
            this.TextBox_Author_LastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Author_LastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Author_LastName
            // 
            this.Label_Author_LastName.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_LastName.Location = new System.Drawing.Point(0, 82);
            this.Label_Author_LastName.Name = "Label_Author_LastName";
            this.Label_Author_LastName.Size = new System.Drawing.Size(218, 24);
            this.Label_Author_LastName.TabIndex = 6;
            this.Label_Author_LastName.Text = "Фамилия:";
            this.Label_Author_LastName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TextBox_Author_FirstName
            // 
            // 
            // 
            // 
            this.TextBox_Author_FirstName.CustomButton.Image = null;
            this.TextBox_Author_FirstName.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.TextBox_Author_FirstName.CustomButton.Name = "";
            this.TextBox_Author_FirstName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Author_FirstName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Author_FirstName.CustomButton.TabIndex = 1;
            this.TextBox_Author_FirstName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Author_FirstName.CustomButton.UseSelectable = true;
            this.TextBox_Author_FirstName.CustomButton.Visible = false;
            this.TextBox_Author_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBox_Author_FirstName.Lines = new string[0];
            this.TextBox_Author_FirstName.Location = new System.Drawing.Point(0, 59);
            this.TextBox_Author_FirstName.MaxLength = 32767;
            this.TextBox_Author_FirstName.Name = "TextBox_Author_FirstName";
            this.TextBox_Author_FirstName.PasswordChar = '\0';
            this.TextBox_Author_FirstName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Author_FirstName.SelectedText = "";
            this.TextBox_Author_FirstName.SelectionLength = 0;
            this.TextBox_Author_FirstName.SelectionStart = 0;
            this.TextBox_Author_FirstName.ShortcutsEnabled = true;
            this.TextBox_Author_FirstName.ShowClearButton = true;
            this.TextBox_Author_FirstName.Size = new System.Drawing.Size(218, 23);
            this.TextBox_Author_FirstName.TabIndex = 5;
            this.TextBox_Author_FirstName.UseSelectable = true;
            this.TextBox_Author_FirstName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Author_FirstName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Author_FirstName
            // 
            this.Label_Author_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_FirstName.Location = new System.Drawing.Point(0, 35);
            this.Label_Author_FirstName.Name = "Label_Author_FirstName";
            this.Label_Author_FirstName.Size = new System.Drawing.Size(218, 24);
            this.Label_Author_FirstName.TabIndex = 4;
            this.Label_Author_FirstName.Text = "Имя:";
            this.Label_Author_FirstName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Label_Author_Header
            // 
            this.Label_Author_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_Header.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Label_Author_Header.Location = new System.Drawing.Point(0, 0);
            this.Label_Author_Header.Name = "Label_Author_Header";
            this.Label_Author_Header.Size = new System.Drawing.Size(218, 35);
            this.Label_Author_Header.TabIndex = 3;
            this.Label_Author_Header.Text = "Добавить нового автора";
            this.Label_Author_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(752, 275);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Authors";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(752, 275);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Groups";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 275);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Books";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 38);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(752, 275);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "CopyBooks";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 38);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(752, 275);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Readers";
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 38);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(752, 275);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Orders";
            // 
            // Button_DeleteData
            // 
            this.Button_DeleteData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_DeleteData.Location = new System.Drawing.Point(0, 0);
            this.Button_DeleteData.Name = "Button_DeleteData";
            this.Button_DeleteData.Size = new System.Drawing.Size(308, 34);
            this.Button_DeleteData.TabIndex = 5;
            this.Button_DeleteData.Text = "Удалить выбранные записи";
            this.Button_DeleteData.UseSelectable = true;
            this.Button_DeleteData.Click += new System.EventHandler(this.Button_DeleteData_Click);
            // 
            // Button_UpdateData
            // 
            this.Button_UpdateData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_UpdateData.Location = new System.Drawing.Point(0, 0);
            this.Button_UpdateData.Name = "Button_UpdateData";
            this.Button_UpdateData.Size = new System.Drawing.Size(288, 34);
            this.Button_UpdateData.TabIndex = 1;
            this.Button_UpdateData.Text = "Обновить данные";
            this.Button_UpdateData.UseSelectable = true;
            this.Button_UpdateData.Click += new System.EventHandler(this.Button_UpdateData_Click);
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
            this.SplitContainer_Buttons.Panel2.Controls.Add(this.Button_DeleteData);
            this.SplitContainer_Buttons.Size = new System.Drawing.Size(600, 34);
            this.SplitContainer_Buttons.SplitterDistance = 288;
            this.SplitContainer_Buttons.TabIndex = 4;
            // 
            // Form_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.Controls.Add(this.TabControl_Data);
            this.Controls.Add(this.Label_Data);
            this.Controls.Add(this.SplitContainer_Buttons);
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "Form_Data";
            this.Text = "Работа с данными";
            this.Load += new System.EventHandler(this.Form_Data_Load);
            this.TabControl_Data.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.SplitContainer_Author_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Author_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Author_Main)).EndInit();
            this.SplitContainer_Author_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Data)).EndInit();
            this.SplitContainer_Buttons.Panel1.ResumeLayout(false);
            this.SplitContainer_Buttons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Buttons)).EndInit();
            this.SplitContainer_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel Label_Data;
        private MetroFramework.Controls.MetroTabControl TabControl_Data;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MetroFramework.Controls.MetroButton Button_DeleteData;
        private MetroFramework.Controls.MetroButton Button_UpdateData;
        private System.Windows.Forms.SplitContainer SplitContainer_Buttons;
        private System.Windows.Forms.SplitContainer SplitContainer_Author_Main;
        private MetroFramework.Controls.MetroGrid Grid_Data;
        private MetroFramework.Controls.MetroButton Button_Author_Create;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_MiddleName;
        private MetroFramework.Controls.MetroLabel Label_Author_MiddleName;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_LastName;
        private MetroFramework.Controls.MetroLabel Label_Author_LastName;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_FirstName;
        private MetroFramework.Controls.MetroLabel Label_Author_FirstName;
        private MetroFramework.Controls.MetroLabel Label_Author_Header;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private MetroFramework.Controls.MetroLabel Label_Author_Bottom;
        private MetroFramework.Controls.MetroLabel Label_Author_Create;
        private MetroFramework.Controls.MetroLabel Label_Author_Data;
    }
}

