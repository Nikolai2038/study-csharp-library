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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label_Data = new MetroFramework.Controls.MetroLabel();
            this.TabControl_Data = new MetroFramework.Controls.MetroTabControl();
            this.TabPage_Catalog = new System.Windows.Forms.TabPage();
            this.Grid_Catalog = new MetroFramework.Controls.MetroGrid();
            this.Panel_Catalog_Search_1 = new MetroFramework.Controls.MetroPanel();
            this.RadioButton_Catalog_RegistrationDate = new MetroFramework.Controls.MetroRadioButton();
            this.Label_Catalog_3 = new MetroFramework.Controls.MetroLabel();
            this.RadioButton_Catalog_Bookmaker = new MetroFramework.Controls.MetroRadioButton();
            this.Label_Catalog_2 = new MetroFramework.Controls.MetroLabel();
            this.RadioButton_Catalog_Group = new MetroFramework.Controls.MetroRadioButton();
            this.Label_Catalog_1 = new MetroFramework.Controls.MetroLabel();
            this.RadioButton_Catalog_Author = new MetroFramework.Controls.MetroRadioButton();
            this.Panel_Catalog_Search_2 = new MetroFramework.Controls.MetroPanel();
            this.TextBox_Catalog_Search = new MetroFramework.Controls.MetroTextBox();
            this.Label_Catalog_4 = new MetroFramework.Controls.MetroLabel();
            this.Button_Catalog_Search = new MetroFramework.Controls.MetroButton();
            this.Label_Catalog_6 = new MetroFramework.Controls.MetroLabel();
            this.Button_Catalog_Reset = new MetroFramework.Controls.MetroButton();
            this.TabPage_Registration = new System.Windows.Forms.TabPage();
            this.SplitContainer_Registration = new System.Windows.Forms.SplitContainer();
            this.Button_Registration_CopyBook_Tab = new MetroFramework.Controls.MetroButton();
            this.Button_Registration_Book_Tab = new MetroFramework.Controls.MetroButton();
            this.Panel_Registration_Book = new MetroFramework.Controls.MetroPanel();
            this.DateTime_Registration_Book_RegistrationDate = new MetroFramework.Controls.MetroDateTime();
            this.NumericUpDown_Registration_Book_Year = new System.Windows.Forms.NumericUpDown();
            this.TextBox_Registration_Book_Name = new MetroFramework.Controls.MetroTextBox();
            this.ComboBox_Registration_Book_Bookmaker = new System.Windows.Forms.ComboBox();
            this.ComboBox_Registration_Book_Group = new System.Windows.Forms.ComboBox();
            this.ComboBox_Registration_Book_Author = new System.Windows.Forms.ComboBox();
            this.PictureBox_Registration_Book_Cover = new System.Windows.Forms.PictureBox();
            this.Button_Registration_Book_Register = new MetroFramework.Controls.MetroButton();
            this.Button_Registration_Book_Cover = new MetroFramework.Controls.MetroButton();
            this.Label_Registration_Book_RegistrationDate = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Year = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Bookmaker = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Group = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Name = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Author = new MetroFramework.Controls.MetroLabel();
            this.Label_Registration_Book_Header = new MetroFramework.Controls.MetroLabel();
            this.TabPage_References = new System.Windows.Forms.TabPage();
            this.SplitContainer_References = new System.Windows.Forms.SplitContainer();
            this.Grid_References = new MetroFramework.Controls.MetroGrid();
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
            this.TabPage_Giveaways = new System.Windows.Forms.TabPage();
            this.TabPage_Returns = new System.Windows.Forms.TabPage();
            this.TabPage_Forms = new System.Windows.Forms.TabPage();
            this.TabPage_Reports = new System.Windows.Forms.TabPage();
            this.TabControl_Data.SuspendLayout();
            this.TabPage_Catalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Catalog)).BeginInit();
            this.Panel_Catalog_Search_1.SuspendLayout();
            this.Panel_Catalog_Search_2.SuspendLayout();
            this.TabPage_Registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Registration)).BeginInit();
            this.SplitContainer_Registration.Panel1.SuspendLayout();
            this.SplitContainer_Registration.Panel2.SuspendLayout();
            this.SplitContainer_Registration.SuspendLayout();
            this.Panel_Registration_Book.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Registration_Book_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Registration_Book_Cover)).BeginInit();
            this.TabPage_References.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_References)).BeginInit();
            this.SplitContainer_References.Panel1.SuspendLayout();
            this.SplitContainer_References.Panel2.SuspendLayout();
            this.SplitContainer_References.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_References)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Data
            // 
            this.Label_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Data.Location = new System.Drawing.Point(20, 60);
            this.Label_Data.Name = "Label_Data";
            this.Label_Data.Size = new System.Drawing.Size(960, 19);
            this.Label_Data.TabIndex = 2;
            this.Label_Data.Text = " ";
            // 
            // TabControl_Data
            // 
            this.TabControl_Data.Controls.Add(this.TabPage_Catalog);
            this.TabControl_Data.Controls.Add(this.TabPage_Registration);
            this.TabControl_Data.Controls.Add(this.TabPage_References);
            this.TabControl_Data.Controls.Add(this.TabPage_Giveaways);
            this.TabControl_Data.Controls.Add(this.TabPage_Returns);
            this.TabControl_Data.Controls.Add(this.TabPage_Forms);
            this.TabControl_Data.Controls.Add(this.TabPage_Reports);
            this.TabControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Data.Location = new System.Drawing.Point(20, 79);
            this.TabControl_Data.Name = "TabControl_Data";
            this.TabControl_Data.SelectedIndex = 0;
            this.TabControl_Data.Size = new System.Drawing.Size(960, 551);
            this.TabControl_Data.TabIndex = 5;
            this.TabControl_Data.UseSelectable = true;
            this.TabControl_Data.SelectedIndexChanged += new System.EventHandler(this.TabControl_Data_SelectedIndexChanged);
            // 
            // TabPage_Catalog
            // 
            this.TabPage_Catalog.BackColor = System.Drawing.SystemColors.MenuBar;
            this.TabPage_Catalog.Controls.Add(this.Grid_Catalog);
            this.TabPage_Catalog.Controls.Add(this.Panel_Catalog_Search_1);
            this.TabPage_Catalog.Controls.Add(this.Panel_Catalog_Search_2);
            this.TabPage_Catalog.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Catalog.Name = "TabPage_Catalog";
            this.TabPage_Catalog.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Catalog.TabIndex = 3;
            this.TabPage_Catalog.Text = "Каталог книг";
            // 
            // Grid_Catalog
            // 
            this.Grid_Catalog.AllowUserToResizeRows = false;
            this.Grid_Catalog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_Catalog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_Catalog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_Catalog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grid_Catalog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Catalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Catalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Catalog.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Catalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Catalog.EnableHeadersVisualStyles = false;
            this.Grid_Catalog.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Grid_Catalog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_Catalog.Location = new System.Drawing.Point(0, 0);
            this.Grid_Catalog.Name = "Grid_Catalog";
            this.Grid_Catalog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Catalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Catalog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_Catalog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Catalog.Size = new System.Drawing.Size(952, 457);
            this.Grid_Catalog.TabIndex = 18;
            // 
            // Panel_Catalog_Search_1
            // 
            this.Panel_Catalog_Search_1.Controls.Add(this.RadioButton_Catalog_RegistrationDate);
            this.Panel_Catalog_Search_1.Controls.Add(this.Label_Catalog_3);
            this.Panel_Catalog_Search_1.Controls.Add(this.RadioButton_Catalog_Bookmaker);
            this.Panel_Catalog_Search_1.Controls.Add(this.Label_Catalog_2);
            this.Panel_Catalog_Search_1.Controls.Add(this.RadioButton_Catalog_Group);
            this.Panel_Catalog_Search_1.Controls.Add(this.Label_Catalog_1);
            this.Panel_Catalog_Search_1.Controls.Add(this.RadioButton_Catalog_Author);
            this.Panel_Catalog_Search_1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Catalog_Search_1.HorizontalScrollbarBarColor = true;
            this.Panel_Catalog_Search_1.HorizontalScrollbarHighlightOnWheel = false;
            this.Panel_Catalog_Search_1.HorizontalScrollbarSize = 10;
            this.Panel_Catalog_Search_1.Location = new System.Drawing.Point(0, 457);
            this.Panel_Catalog_Search_1.Name = "Panel_Catalog_Search_1";
            this.Panel_Catalog_Search_1.Size = new System.Drawing.Size(952, 26);
            this.Panel_Catalog_Search_1.TabIndex = 20;
            this.Panel_Catalog_Search_1.VerticalScrollbarBarColor = true;
            this.Panel_Catalog_Search_1.VerticalScrollbarHighlightOnWheel = false;
            this.Panel_Catalog_Search_1.VerticalScrollbarSize = 10;
            // 
            // RadioButton_Catalog_RegistrationDate
            // 
            this.RadioButton_Catalog_RegistrationDate.AutoSize = true;
            this.RadioButton_Catalog_RegistrationDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.RadioButton_Catalog_RegistrationDate.Location = new System.Drawing.Point(276, 0);
            this.RadioButton_Catalog_RegistrationDate.Name = "RadioButton_Catalog_RegistrationDate";
            this.RadioButton_Catalog_RegistrationDate.Size = new System.Drawing.Size(121, 26);
            this.RadioButton_Catalog_RegistrationDate.TabIndex = 16;
            this.RadioButton_Catalog_RegistrationDate.Text = "Дата регистрации";
            this.RadioButton_Catalog_RegistrationDate.UseSelectable = true;
            // 
            // Label_Catalog_3
            // 
            this.Label_Catalog_3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Catalog_3.Location = new System.Drawing.Point(253, 0);
            this.Label_Catalog_3.Name = "Label_Catalog_3";
            this.Label_Catalog_3.Size = new System.Drawing.Size(23, 26);
            this.Label_Catalog_3.TabIndex = 14;
            this.Label_Catalog_3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RadioButton_Catalog_Bookmaker
            // 
            this.RadioButton_Catalog_Bookmaker.AutoSize = true;
            this.RadioButton_Catalog_Bookmaker.Dock = System.Windows.Forms.DockStyle.Left;
            this.RadioButton_Catalog_Bookmaker.Location = new System.Drawing.Point(156, 0);
            this.RadioButton_Catalog_Bookmaker.Name = "RadioButton_Catalog_Bookmaker";
            this.RadioButton_Catalog_Bookmaker.Size = new System.Drawing.Size(97, 26);
            this.RadioButton_Catalog_Bookmaker.TabIndex = 17;
            this.RadioButton_Catalog_Bookmaker.Text = "Издательство";
            this.RadioButton_Catalog_Bookmaker.UseSelectable = true;
            // 
            // Label_Catalog_2
            // 
            this.Label_Catalog_2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Catalog_2.Location = new System.Drawing.Point(133, 0);
            this.Label_Catalog_2.Name = "Label_Catalog_2";
            this.Label_Catalog_2.Size = new System.Drawing.Size(23, 26);
            this.Label_Catalog_2.TabIndex = 15;
            this.Label_Catalog_2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RadioButton_Catalog_Group
            // 
            this.RadioButton_Catalog_Group.AutoSize = true;
            this.RadioButton_Catalog_Group.Dock = System.Windows.Forms.DockStyle.Left;
            this.RadioButton_Catalog_Group.Location = new System.Drawing.Point(79, 0);
            this.RadioButton_Catalog_Group.Name = "RadioButton_Catalog_Group";
            this.RadioButton_Catalog_Group.Size = new System.Drawing.Size(54, 26);
            this.RadioButton_Catalog_Group.TabIndex = 18;
            this.RadioButton_Catalog_Group.Text = "Жанр";
            this.RadioButton_Catalog_Group.UseSelectable = true;
            // 
            // Label_Catalog_1
            // 
            this.Label_Catalog_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Catalog_1.Location = new System.Drawing.Point(56, 0);
            this.Label_Catalog_1.Name = "Label_Catalog_1";
            this.Label_Catalog_1.Size = new System.Drawing.Size(23, 26);
            this.Label_Catalog_1.TabIndex = 13;
            this.Label_Catalog_1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RadioButton_Catalog_Author
            // 
            this.RadioButton_Catalog_Author.AutoSize = true;
            this.RadioButton_Catalog_Author.Checked = true;
            this.RadioButton_Catalog_Author.Dock = System.Windows.Forms.DockStyle.Left;
            this.RadioButton_Catalog_Author.Location = new System.Drawing.Point(0, 0);
            this.RadioButton_Catalog_Author.Name = "RadioButton_Catalog_Author";
            this.RadioButton_Catalog_Author.Size = new System.Drawing.Size(56, 26);
            this.RadioButton_Catalog_Author.TabIndex = 19;
            this.RadioButton_Catalog_Author.TabStop = true;
            this.RadioButton_Catalog_Author.Text = "Автор";
            this.RadioButton_Catalog_Author.UseSelectable = true;
            // 
            // Panel_Catalog_Search_2
            // 
            this.Panel_Catalog_Search_2.Controls.Add(this.TextBox_Catalog_Search);
            this.Panel_Catalog_Search_2.Controls.Add(this.Label_Catalog_4);
            this.Panel_Catalog_Search_2.Controls.Add(this.Button_Catalog_Search);
            this.Panel_Catalog_Search_2.Controls.Add(this.Label_Catalog_6);
            this.Panel_Catalog_Search_2.Controls.Add(this.Button_Catalog_Reset);
            this.Panel_Catalog_Search_2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Catalog_Search_2.HorizontalScrollbarBarColor = true;
            this.Panel_Catalog_Search_2.HorizontalScrollbarHighlightOnWheel = false;
            this.Panel_Catalog_Search_2.HorizontalScrollbarSize = 10;
            this.Panel_Catalog_Search_2.Location = new System.Drawing.Point(0, 483);
            this.Panel_Catalog_Search_2.Name = "Panel_Catalog_Search_2";
            this.Panel_Catalog_Search_2.Size = new System.Drawing.Size(952, 26);
            this.Panel_Catalog_Search_2.TabIndex = 19;
            this.Panel_Catalog_Search_2.VerticalScrollbarBarColor = true;
            this.Panel_Catalog_Search_2.VerticalScrollbarHighlightOnWheel = false;
            this.Panel_Catalog_Search_2.VerticalScrollbarSize = 10;
            // 
            // TextBox_Catalog_Search
            // 
            // 
            // 
            // 
            this.TextBox_Catalog_Search.CustomButton.Image = null;
            this.TextBox_Catalog_Search.CustomButton.Location = new System.Drawing.Point(599, 2);
            this.TextBox_Catalog_Search.CustomButton.Name = "";
            this.TextBox_Catalog_Search.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Catalog_Search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Catalog_Search.CustomButton.TabIndex = 1;
            this.TextBox_Catalog_Search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Catalog_Search.CustomButton.UseSelectable = true;
            this.TextBox_Catalog_Search.CustomButton.Visible = false;
            this.TextBox_Catalog_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Catalog_Search.Lines = new string[0];
            this.TextBox_Catalog_Search.Location = new System.Drawing.Point(0, 0);
            this.TextBox_Catalog_Search.MaxLength = 32767;
            this.TextBox_Catalog_Search.Name = "TextBox_Catalog_Search";
            this.TextBox_Catalog_Search.PasswordChar = '\0';
            this.TextBox_Catalog_Search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Catalog_Search.SelectedText = "";
            this.TextBox_Catalog_Search.SelectionLength = 0;
            this.TextBox_Catalog_Search.SelectionStart = 0;
            this.TextBox_Catalog_Search.ShortcutsEnabled = true;
            this.TextBox_Catalog_Search.Size = new System.Drawing.Size(623, 26);
            this.TextBox_Catalog_Search.TabIndex = 1;
            this.TextBox_Catalog_Search.UseSelectable = true;
            this.TextBox_Catalog_Search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Catalog_Search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_Catalog_4
            // 
            this.Label_Catalog_4.Dock = System.Windows.Forms.DockStyle.Right;
            this.Label_Catalog_4.Location = new System.Drawing.Point(623, 0);
            this.Label_Catalog_4.Name = "Label_Catalog_4";
            this.Label_Catalog_4.Size = new System.Drawing.Size(23, 26);
            this.Label_Catalog_4.TabIndex = 13;
            this.Label_Catalog_4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Button_Catalog_Search
            // 
            this.Button_Catalog_Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Catalog_Search.Location = new System.Drawing.Point(646, 0);
            this.Button_Catalog_Search.Name = "Button_Catalog_Search";
            this.Button_Catalog_Search.Size = new System.Drawing.Size(142, 26);
            this.Button_Catalog_Search.TabIndex = 2;
            this.Button_Catalog_Search.Text = "Поиск";
            this.Button_Catalog_Search.UseSelectable = true;
            this.Button_Catalog_Search.Click += new System.EventHandler(this.Button_Catalog_Search_Click);
            // 
            // Label_Catalog_6
            // 
            this.Label_Catalog_6.Dock = System.Windows.Forms.DockStyle.Right;
            this.Label_Catalog_6.Location = new System.Drawing.Point(788, 0);
            this.Label_Catalog_6.Name = "Label_Catalog_6";
            this.Label_Catalog_6.Size = new System.Drawing.Size(23, 26);
            this.Label_Catalog_6.TabIndex = 12;
            this.Label_Catalog_6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Button_Catalog_Reset
            // 
            this.Button_Catalog_Reset.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Catalog_Reset.Location = new System.Drawing.Point(811, 0);
            this.Button_Catalog_Reset.Name = "Button_Catalog_Reset";
            this.Button_Catalog_Reset.Size = new System.Drawing.Size(141, 26);
            this.Button_Catalog_Reset.TabIndex = 2;
            this.Button_Catalog_Reset.Text = "Сбросить фильтр";
            this.Button_Catalog_Reset.UseSelectable = true;
            this.Button_Catalog_Reset.Click += new System.EventHandler(this.Button_Catalog_Reset_Click);
            // 
            // TabPage_Registration
            // 
            this.TabPage_Registration.Controls.Add(this.SplitContainer_Registration);
            this.TabPage_Registration.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Registration.Name = "TabPage_Registration";
            this.TabPage_Registration.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Registration.TabIndex = 6;
            this.TabPage_Registration.Text = "Регистрация книг";
            // 
            // SplitContainer_Registration
            // 
            this.SplitContainer_Registration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Registration.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Registration.Name = "SplitContainer_Registration";
            // 
            // SplitContainer_Registration.Panel1
            // 
            this.SplitContainer_Registration.Panel1.Controls.Add(this.Button_Registration_CopyBook_Tab);
            this.SplitContainer_Registration.Panel1.Controls.Add(this.Button_Registration_Book_Tab);
            // 
            // SplitContainer_Registration.Panel2
            // 
            this.SplitContainer_Registration.Panel2.Controls.Add(this.Panel_Registration_Book);
            this.SplitContainer_Registration.Size = new System.Drawing.Size(952, 509);
            this.SplitContainer_Registration.SplitterDistance = 234;
            this.SplitContainer_Registration.TabIndex = 7;
            // 
            // Button_Registration_CopyBook_Tab
            // 
            this.Button_Registration_CopyBook_Tab.Location = new System.Drawing.Point(46, 132);
            this.Button_Registration_CopyBook_Tab.Name = "Button_Registration_CopyBook_Tab";
            this.Button_Registration_CopyBook_Tab.Size = new System.Drawing.Size(148, 47);
            this.Button_Registration_CopyBook_Tab.TabIndex = 1;
            this.Button_Registration_CopyBook_Tab.Text = "Регистрация\r\nэкземпляров книг";
            this.Button_Registration_CopyBook_Tab.UseSelectable = true;
            this.Button_Registration_CopyBook_Tab.Click += new System.EventHandler(this.Button_Registration_CopyBook_Tab_Click);
            // 
            // Button_Registration_Book_Tab
            // 
            this.Button_Registration_Book_Tab.Location = new System.Drawing.Point(46, 66);
            this.Button_Registration_Book_Tab.Name = "Button_Registration_Book_Tab";
            this.Button_Registration_Book_Tab.Size = new System.Drawing.Size(148, 48);
            this.Button_Registration_Book_Tab.TabIndex = 0;
            this.Button_Registration_Book_Tab.Text = "Регистрация\r\nкниги";
            this.Button_Registration_Book_Tab.UseSelectable = true;
            this.Button_Registration_Book_Tab.Click += new System.EventHandler(this.Button_Registration_Book_Tab_Click);
            // 
            // Panel_Registration_Book
            // 
            this.Panel_Registration_Book.Controls.Add(this.DateTime_Registration_Book_RegistrationDate);
            this.Panel_Registration_Book.Controls.Add(this.NumericUpDown_Registration_Book_Year);
            this.Panel_Registration_Book.Controls.Add(this.TextBox_Registration_Book_Name);
            this.Panel_Registration_Book.Controls.Add(this.ComboBox_Registration_Book_Bookmaker);
            this.Panel_Registration_Book.Controls.Add(this.ComboBox_Registration_Book_Group);
            this.Panel_Registration_Book.Controls.Add(this.ComboBox_Registration_Book_Author);
            this.Panel_Registration_Book.Controls.Add(this.PictureBox_Registration_Book_Cover);
            this.Panel_Registration_Book.Controls.Add(this.Button_Registration_Book_Register);
            this.Panel_Registration_Book.Controls.Add(this.Button_Registration_Book_Cover);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_RegistrationDate);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Year);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Bookmaker);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Group);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Name);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Author);
            this.Panel_Registration_Book.Controls.Add(this.Label_Registration_Book_Header);
            this.Panel_Registration_Book.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Registration_Book.HorizontalScrollbarBarColor = true;
            this.Panel_Registration_Book.HorizontalScrollbarHighlightOnWheel = false;
            this.Panel_Registration_Book.HorizontalScrollbarSize = 10;
            this.Panel_Registration_Book.Location = new System.Drawing.Point(0, 0);
            this.Panel_Registration_Book.Name = "Panel_Registration_Book";
            this.Panel_Registration_Book.Size = new System.Drawing.Size(714, 509);
            this.Panel_Registration_Book.TabIndex = 8;
            this.Panel_Registration_Book.VerticalScrollbarBarColor = true;
            this.Panel_Registration_Book.VerticalScrollbarHighlightOnWheel = false;
            this.Panel_Registration_Book.VerticalScrollbarSize = 10;
            // 
            // DateTime_Registration_Book_RegistrationDate
            // 
            this.DateTime_Registration_Book_RegistrationDate.Location = new System.Drawing.Point(162, 230);
            this.DateTime_Registration_Book_RegistrationDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DateTime_Registration_Book_RegistrationDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTime_Registration_Book_RegistrationDate.Name = "DateTime_Registration_Book_RegistrationDate";
            this.DateTime_Registration_Book_RegistrationDate.Size = new System.Drawing.Size(173, 29);
            this.DateTime_Registration_Book_RegistrationDate.TabIndex = 23;
            // 
            // NumericUpDown_Registration_Book_Year
            // 
            this.NumericUpDown_Registration_Book_Year.Location = new System.Drawing.Point(162, 204);
            this.NumericUpDown_Registration_Book_Year.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.NumericUpDown_Registration_Book_Year.Name = "NumericUpDown_Registration_Book_Year";
            this.NumericUpDown_Registration_Book_Year.Size = new System.Drawing.Size(173, 20);
            this.NumericUpDown_Registration_Book_Year.TabIndex = 22;
            this.NumericUpDown_Registration_Book_Year.Value = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            // 
            // TextBox_Registration_Book_Name
            // 
            // 
            // 
            // 
            this.TextBox_Registration_Book_Name.CustomButton.Image = null;
            this.TextBox_Registration_Book_Name.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.TextBox_Registration_Book_Name.CustomButton.Name = "";
            this.TextBox_Registration_Book_Name.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Registration_Book_Name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Registration_Book_Name.CustomButton.TabIndex = 1;
            this.TextBox_Registration_Book_Name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Registration_Book_Name.CustomButton.UseSelectable = true;
            this.TextBox_Registration_Book_Name.CustomButton.Visible = false;
            this.TextBox_Registration_Book_Name.Lines = new string[0];
            this.TextBox_Registration_Book_Name.Location = new System.Drawing.Point(162, 106);
            this.TextBox_Registration_Book_Name.MaxLength = 32767;
            this.TextBox_Registration_Book_Name.Name = "TextBox_Registration_Book_Name";
            this.TextBox_Registration_Book_Name.PasswordChar = '\0';
            this.TextBox_Registration_Book_Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Registration_Book_Name.SelectedText = "";
            this.TextBox_Registration_Book_Name.SelectionLength = 0;
            this.TextBox_Registration_Book_Name.SelectionStart = 0;
            this.TextBox_Registration_Book_Name.ShortcutsEnabled = true;
            this.TextBox_Registration_Book_Name.Size = new System.Drawing.Size(174, 23);
            this.TextBox_Registration_Book_Name.TabIndex = 21;
            this.TextBox_Registration_Book_Name.UseSelectable = true;
            this.TextBox_Registration_Book_Name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Registration_Book_Name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ComboBox_Registration_Book_Bookmaker
            // 
            this.ComboBox_Registration_Book_Bookmaker.FormattingEnabled = true;
            this.ComboBox_Registration_Book_Bookmaker.Location = new System.Drawing.Point(161, 177);
            this.ComboBox_Registration_Book_Bookmaker.Name = "ComboBox_Registration_Book_Bookmaker";
            this.ComboBox_Registration_Book_Bookmaker.Size = new System.Drawing.Size(174, 21);
            this.ComboBox_Registration_Book_Bookmaker.TabIndex = 18;
            // 
            // ComboBox_Registration_Book_Group
            // 
            this.ComboBox_Registration_Book_Group.FormattingEnabled = true;
            this.ComboBox_Registration_Book_Group.Location = new System.Drawing.Point(161, 140);
            this.ComboBox_Registration_Book_Group.Name = "ComboBox_Registration_Book_Group";
            this.ComboBox_Registration_Book_Group.Size = new System.Drawing.Size(173, 21);
            this.ComboBox_Registration_Book_Group.TabIndex = 19;
            // 
            // ComboBox_Registration_Book_Author
            // 
            this.ComboBox_Registration_Book_Author.FormattingEnabled = true;
            this.ComboBox_Registration_Book_Author.Location = new System.Drawing.Point(161, 72);
            this.ComboBox_Registration_Book_Author.Name = "ComboBox_Registration_Book_Author";
            this.ComboBox_Registration_Book_Author.Size = new System.Drawing.Size(174, 21);
            this.ComboBox_Registration_Book_Author.TabIndex = 20;
            // 
            // PictureBox_Registration_Book_Cover
            // 
            this.PictureBox_Registration_Book_Cover.Location = new System.Drawing.Point(383, 147);
            this.PictureBox_Registration_Book_Cover.Name = "PictureBox_Registration_Book_Cover";
            this.PictureBox_Registration_Book_Cover.Size = new System.Drawing.Size(148, 198);
            this.PictureBox_Registration_Book_Cover.TabIndex = 17;
            this.PictureBox_Registration_Book_Cover.TabStop = false;
            // 
            // Button_Registration_Book_Register
            // 
            this.Button_Registration_Book_Register.Location = new System.Drawing.Point(98, 298);
            this.Button_Registration_Book_Register.Name = "Button_Registration_Book_Register";
            this.Button_Registration_Book_Register.Size = new System.Drawing.Size(148, 47);
            this.Button_Registration_Book_Register.TabIndex = 9;
            this.Button_Registration_Book_Register.Text = "Зарегистрировать";
            this.Button_Registration_Book_Register.UseSelectable = true;
            this.Button_Registration_Book_Register.Click += new System.EventHandler(this.Button_Registration_Book_Register_Click);
            // 
            // Button_Registration_Book_Cover
            // 
            this.Button_Registration_Book_Cover.Location = new System.Drawing.Point(383, 71);
            this.Button_Registration_Book_Cover.Name = "Button_Registration_Book_Cover";
            this.Button_Registration_Book_Cover.Size = new System.Drawing.Size(148, 47);
            this.Button_Registration_Book_Cover.TabIndex = 10;
            this.Button_Registration_Book_Cover.Text = "Загрузить\r\nизображение обложки";
            this.Button_Registration_Book_Cover.UseSelectable = true;
            this.Button_Registration_Book_Cover.Click += new System.EventHandler(this.Button_Registration_Book_Cover_Click);
            // 
            // Label_Registration_Book_RegistrationDate
            // 
            this.Label_Registration_Book_RegistrationDate.AutoSize = true;
            this.Label_Registration_Book_RegistrationDate.Location = new System.Drawing.Point(36, 240);
            this.Label_Registration_Book_RegistrationDate.Name = "Label_Registration_Book_RegistrationDate";
            this.Label_Registration_Book_RegistrationDate.Size = new System.Drawing.Size(119, 19);
            this.Label_Registration_Book_RegistrationDate.TabIndex = 12;
            this.Label_Registration_Book_RegistrationDate.Text = "Дата регистрации";
            // 
            // Label_Registration_Book_Year
            // 
            this.Label_Registration_Book_Year.AutoSize = true;
            this.Label_Registration_Book_Year.Location = new System.Drawing.Point(36, 203);
            this.Label_Registration_Book_Year.Name = "Label_Registration_Book_Year";
            this.Label_Registration_Book_Year.Size = new System.Drawing.Size(85, 19);
            this.Label_Registration_Book_Year.TabIndex = 13;
            this.Label_Registration_Book_Year.Text = "Год издания";
            // 
            // Label_Registration_Book_Bookmaker
            // 
            this.Label_Registration_Book_Bookmaker.AutoSize = true;
            this.Label_Registration_Book_Bookmaker.Location = new System.Drawing.Point(36, 166);
            this.Label_Registration_Book_Bookmaker.Name = "Label_Registration_Book_Bookmaker";
            this.Label_Registration_Book_Bookmaker.Size = new System.Drawing.Size(64, 19);
            this.Label_Registration_Book_Bookmaker.TabIndex = 14;
            this.Label_Registration_Book_Bookmaker.Text = "Издатель";
            // 
            // Label_Registration_Book_Group
            // 
            this.Label_Registration_Book_Group.AutoSize = true;
            this.Label_Registration_Book_Group.Location = new System.Drawing.Point(38, 140);
            this.Label_Registration_Book_Group.Name = "Label_Registration_Book_Group";
            this.Label_Registration_Book_Group.Size = new System.Drawing.Size(44, 19);
            this.Label_Registration_Book_Group.TabIndex = 15;
            this.Label_Registration_Book_Group.Text = "Жанр";
            // 
            // Label_Registration_Book_Name
            // 
            this.Label_Registration_Book_Name.AutoSize = true;
            this.Label_Registration_Book_Name.Location = new System.Drawing.Point(36, 112);
            this.Label_Registration_Book_Name.Name = "Label_Registration_Book_Name";
            this.Label_Registration_Book_Name.Size = new System.Drawing.Size(68, 19);
            this.Label_Registration_Book_Name.TabIndex = 16;
            this.Label_Registration_Book_Name.Text = "Название";
            // 
            // Label_Registration_Book_Author
            // 
            this.Label_Registration_Book_Author.AutoSize = true;
            this.Label_Registration_Book_Author.Location = new System.Drawing.Point(36, 81);
            this.Label_Registration_Book_Author.Name = "Label_Registration_Book_Author";
            this.Label_Registration_Book_Author.Size = new System.Drawing.Size(46, 19);
            this.Label_Registration_Book_Author.TabIndex = 11;
            this.Label_Registration_Book_Author.Text = "Автор";
            // 
            // Label_Registration_Book_Header
            // 
            this.Label_Registration_Book_Header.AutoSize = true;
            this.Label_Registration_Book_Header.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Label_Registration_Book_Header.Location = new System.Drawing.Point(34, 25);
            this.Label_Registration_Book_Header.Name = "Label_Registration_Book_Header";
            this.Label_Registration_Book_Header.Size = new System.Drawing.Size(159, 25);
            this.Label_Registration_Book_Header.TabIndex = 8;
            this.Label_Registration_Book_Header.Text = "Регистрация книги";
            // 
            // TabPage_References
            // 
            this.TabPage_References.Controls.Add(this.SplitContainer_References);
            this.TabPage_References.Location = new System.Drawing.Point(4, 38);
            this.TabPage_References.Name = "TabPage_References";
            this.TabPage_References.Size = new System.Drawing.Size(952, 509);
            this.TabPage_References.TabIndex = 0;
            this.TabPage_References.Text = "Справочники";
            // 
            // SplitContainer_References
            // 
            this.SplitContainer_References.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_References.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_References.Name = "SplitContainer_References";
            // 
            // SplitContainer_References.Panel1
            // 
            this.SplitContainer_References.Panel1.Controls.Add(this.Grid_References);
            this.SplitContainer_References.Panel1.Controls.Add(this.Label_Author_Data);
            // 
            // SplitContainer_References.Panel2
            // 
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_Bottom);
            this.SplitContainer_References.Panel2.Controls.Add(this.Button_Author_Create);
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_Create);
            this.SplitContainer_References.Panel2.Controls.Add(this.TextBox_Author_MiddleName);
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_MiddleName);
            this.SplitContainer_References.Panel2.Controls.Add(this.TextBox_Author_LastName);
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_LastName);
            this.SplitContainer_References.Panel2.Controls.Add(this.TextBox_Author_FirstName);
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_FirstName);
            this.SplitContainer_References.Panel2.Controls.Add(this.Label_Author_Header);
            this.SplitContainer_References.Size = new System.Drawing.Size(952, 509);
            this.SplitContainer_References.SplitterDistance = 611;
            this.SplitContainer_References.TabIndex = 7;
            // 
            // Grid_References
            // 
            this.Grid_References.AllowUserToResizeRows = false;
            this.Grid_References.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_References.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_References.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_References.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grid_References.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_References.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_References.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_References.DefaultCellStyle = dataGridViewCellStyle5;
            this.Grid_References.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_References.EnableHeadersVisualStyles = false;
            this.Grid_References.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Grid_References.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_References.Location = new System.Drawing.Point(0, 35);
            this.Grid_References.Name = "Grid_References";
            this.Grid_References.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_References.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Grid_References.RowHeadersVisible = false;
            this.Grid_References.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_References.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_References.Size = new System.Drawing.Size(611, 474);
            this.Grid_References.TabIndex = 2;
            // 
            // Label_Author_Data
            // 
            this.Label_Author_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Author_Data.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Label_Author_Data.Location = new System.Drawing.Point(0, 0);
            this.Label_Author_Data.Name = "Label_Author_Data";
            this.Label_Author_Data.Size = new System.Drawing.Size(611, 35);
            this.Label_Author_Data.TabIndex = 4;
            this.Label_Author_Data.Text = "Список авторов";
            this.Label_Author_Data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Author_Bottom
            // 
            this.Label_Author_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Author_Bottom.Location = new System.Drawing.Point(0, 238);
            this.Label_Author_Bottom.Name = "Label_Author_Bottom";
            this.Label_Author_Bottom.Size = new System.Drawing.Size(337, 271);
            this.Label_Author_Bottom.TabIndex = 11;
            this.Label_Author_Bottom.Text = " ";
            // 
            // Button_Author_Create
            // 
            this.Button_Author_Create.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Author_Create.Location = new System.Drawing.Point(0, 200);
            this.Button_Author_Create.Name = "Button_Author_Create";
            this.Button_Author_Create.Size = new System.Drawing.Size(337, 38);
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
            this.Label_Author_Create.Size = new System.Drawing.Size(337, 24);
            this.Label_Author_Create.TabIndex = 12;
            this.Label_Author_Create.Text = " ";
            // 
            // TextBox_Author_MiddleName
            // 
            // 
            // 
            // 
            this.TextBox_Author_MiddleName.CustomButton.Image = null;
            this.TextBox_Author_MiddleName.CustomButton.Location = new System.Drawing.Point(315, 1);
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
            this.TextBox_Author_MiddleName.Size = new System.Drawing.Size(337, 23);
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
            this.Label_Author_MiddleName.Size = new System.Drawing.Size(337, 24);
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
            this.TextBox_Author_LastName.CustomButton.Location = new System.Drawing.Point(315, 1);
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
            this.TextBox_Author_LastName.Size = new System.Drawing.Size(337, 23);
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
            this.Label_Author_LastName.Size = new System.Drawing.Size(337, 24);
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
            this.TextBox_Author_FirstName.CustomButton.Location = new System.Drawing.Point(315, 1);
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
            this.TextBox_Author_FirstName.Size = new System.Drawing.Size(337, 23);
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
            this.Label_Author_FirstName.Size = new System.Drawing.Size(337, 24);
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
            this.Label_Author_Header.Size = new System.Drawing.Size(337, 35);
            this.Label_Author_Header.TabIndex = 3;
            this.Label_Author_Header.Text = "Добавить нового автора";
            this.Label_Author_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabPage_Giveaways
            // 
            this.TabPage_Giveaways.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Giveaways.Name = "TabPage_Giveaways";
            this.TabPage_Giveaways.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Giveaways.TabIndex = 1;
            this.TabPage_Giveaways.Text = "Выдача книг";
            // 
            // TabPage_Returns
            // 
            this.TabPage_Returns.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Returns.Name = "TabPage_Returns";
            this.TabPage_Returns.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Returns.TabIndex = 2;
            this.TabPage_Returns.Text = "Возврат книг";
            // 
            // TabPage_Forms
            // 
            this.TabPage_Forms.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Forms.Name = "TabPage_Forms";
            this.TabPage_Forms.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Forms.TabIndex = 4;
            this.TabPage_Forms.Text = "Формуляры";
            // 
            // TabPage_Reports
            // 
            this.TabPage_Reports.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Reports.Name = "TabPage_Reports";
            this.TabPage_Reports.Size = new System.Drawing.Size(952, 509);
            this.TabPage_Reports.TabIndex = 5;
            this.TabPage_Reports.Text = "Отчёты";
            // 
            // Form_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.TabControl_Data);
            this.Controls.Add(this.Label_Data);
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "Form_Data";
            this.Load += new System.EventHandler(this.Form_Data_Load);
            this.TabControl_Data.ResumeLayout(false);
            this.TabPage_Catalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Catalog)).EndInit();
            this.Panel_Catalog_Search_1.ResumeLayout(false);
            this.Panel_Catalog_Search_1.PerformLayout();
            this.Panel_Catalog_Search_2.ResumeLayout(false);
            this.TabPage_Registration.ResumeLayout(false);
            this.SplitContainer_Registration.Panel1.ResumeLayout(false);
            this.SplitContainer_Registration.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Registration)).EndInit();
            this.SplitContainer_Registration.ResumeLayout(false);
            this.Panel_Registration_Book.ResumeLayout(false);
            this.Panel_Registration_Book.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Registration_Book_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Registration_Book_Cover)).EndInit();
            this.TabPage_References.ResumeLayout(false);
            this.SplitContainer_References.Panel1.ResumeLayout(false);
            this.SplitContainer_References.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_References)).EndInit();
            this.SplitContainer_References.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_References)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel Label_Data;
        private MetroFramework.Controls.MetroTabControl TabControl_Data;
        private System.Windows.Forms.TabPage TabPage_References;
        private System.Windows.Forms.TabPage TabPage_Giveaways;
        private System.Windows.Forms.SplitContainer SplitContainer_References;
        private MetroFramework.Controls.MetroGrid Grid_References;
        private MetroFramework.Controls.MetroButton Button_Author_Create;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_MiddleName;
        private MetroFramework.Controls.MetroLabel Label_Author_MiddleName;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_LastName;
        private MetroFramework.Controls.MetroLabel Label_Author_LastName;
        private MetroFramework.Controls.MetroTextBox TextBox_Author_FirstName;
        private MetroFramework.Controls.MetroLabel Label_Author_FirstName;
        private MetroFramework.Controls.MetroLabel Label_Author_Header;
        private System.Windows.Forms.TabPage TabPage_Returns;
        private System.Windows.Forms.TabPage TabPage_Catalog;
        private System.Windows.Forms.TabPage TabPage_Forms;
        private System.Windows.Forms.TabPage TabPage_Reports;
        private System.Windows.Forms.TabPage TabPage_Registration;
        private MetroFramework.Controls.MetroLabel Label_Author_Bottom;
        private MetroFramework.Controls.MetroLabel Label_Author_Create;
        private MetroFramework.Controls.MetroLabel Label_Author_Data;
        private System.Windows.Forms.SplitContainer SplitContainer_Registration;
        private MetroFramework.Controls.MetroButton Button_Registration_CopyBook_Tab;
        private MetroFramework.Controls.MetroButton Button_Registration_Book_Tab;
        private MetroFramework.Controls.MetroPanel Panel_Registration_Book;
        private MetroFramework.Controls.MetroDateTime DateTime_Registration_Book_RegistrationDate;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Registration_Book_Year;
        private MetroFramework.Controls.MetroTextBox TextBox_Registration_Book_Name;
        private System.Windows.Forms.ComboBox ComboBox_Registration_Book_Bookmaker;
        private System.Windows.Forms.ComboBox ComboBox_Registration_Book_Group;
        private System.Windows.Forms.ComboBox ComboBox_Registration_Book_Author;
        private System.Windows.Forms.PictureBox PictureBox_Registration_Book_Cover;
        private MetroFramework.Controls.MetroButton Button_Registration_Book_Register;
        private MetroFramework.Controls.MetroButton Button_Registration_Book_Cover;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_RegistrationDate;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Year;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Bookmaker;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Group;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Name;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Author;
        private MetroFramework.Controls.MetroLabel Label_Registration_Book_Header;
        private MetroFramework.Controls.MetroGrid Grid_Catalog;
        private MetroFramework.Controls.MetroPanel Panel_Catalog_Search_1;
        private MetroFramework.Controls.MetroRadioButton RadioButton_Catalog_RegistrationDate;
        private MetroFramework.Controls.MetroLabel Label_Catalog_3;
        private MetroFramework.Controls.MetroRadioButton RadioButton_Catalog_Bookmaker;
        private MetroFramework.Controls.MetroLabel Label_Catalog_2;
        private MetroFramework.Controls.MetroRadioButton RadioButton_Catalog_Group;
        private MetroFramework.Controls.MetroLabel Label_Catalog_1;
        private MetroFramework.Controls.MetroRadioButton RadioButton_Catalog_Author;
        private MetroFramework.Controls.MetroPanel Panel_Catalog_Search_2;
        private MetroFramework.Controls.MetroTextBox TextBox_Catalog_Search;
        private MetroFramework.Controls.MetroLabel Label_Catalog_4;
        private MetroFramework.Controls.MetroButton Button_Catalog_Search;
        private MetroFramework.Controls.MetroLabel Label_Catalog_6;
        private MetroFramework.Controls.MetroButton Button_Catalog_Reset;
    }
}

