
namespace laba_2
{
    partial class Form1
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.InvetarniNumber_textBox = new System.Windows.Forms.TextBox();
            this.DataPostyplenia_picker = new System.Windows.Forms.DateTimePicker();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.Name_label = new System.Windows.Forms.Label();
            this.Invent_label = new System.Windows.Forms.Label();
            this.Size_label = new System.Windows.Forms.Label();
            this.Weight_label = new System.Windows.Forms.Label();
            this.Date_of_recive_label = new System.Windows.Forms.Label();
            this.Type_label = new System.Windows.Forms.Label();
            this.Count_label = new System.Windows.Forms.Label();
            this.Price_label = new System.Windows.Forms.Label();
            this.Producer_label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Quantity_trackBar = new System.Windows.Forms.TrackBar();
            this.Resume_richbox = new System.Windows.Forms.RichTextBox();
            this.Country_textBox = new System.Windows.Forms.TextBox();
            this.Org_textBox = new System.Windows.Forms.TextBox();
            this.Adres_textBox = new System.Windows.Forms.TextBox();
            this.Phone_textBox = new System.Windows.Forms.MaskedTextBox();
            this.Country_label = new System.Windows.Forms.Label();
            this.Organization_label = new System.Windows.Forms.Label();
            this.Adres_label = new System.Windows.Forms.Label();
            this.Phone_label = new System.Windows.Forms.Label();
            this.radioSred = new System.Windows.Forms.RadioButton();
            this.radioSmall = new System.Windows.Forms.RadioButton();
            this.radioBig = new System.Windows.Forms.RadioButton();
            this.Clear_bt = new System.Windows.Forms.Button();
            this.Clear_rch = new System.Windows.Forms.Button();
            this.Price_textBox = new System.Windows.Forms.MaskedTextBox();
            this.Weight_textBox = new System.Windows.Forms.MaskedTextBox();
            this.Save_in_file = new System.Windows.Forms.Button();
            this.Read_from_file = new System.Windows.Forms.Button();
            this.button_find = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаПоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаПоСтранеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_stat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ivent_label = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer_label = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_trackBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name_textBox
            // 
            this.Name_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name_textBox.Location = new System.Drawing.Point(201, 25);
            this.Name_textBox.MaxLength = 36;
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(374, 27);
            this.Name_textBox.TabIndex = 0;
            this.Name_textBox.TextChanged += new System.EventHandler(this.Name_textBox_TextChanged);
            // 
            // InvetarniNumber_textBox
            // 
            this.InvetarniNumber_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InvetarniNumber_textBox.Location = new System.Drawing.Point(201, 75);
            this.InvetarniNumber_textBox.Name = "InvetarniNumber_textBox";
            this.InvetarniNumber_textBox.Size = new System.Drawing.Size(374, 27);
            this.InvetarniNumber_textBox.TabIndex = 1;
            this.InvetarniNumber_textBox.TextChanged += new System.EventHandler(this.InvetarniNumber_textBox_TextChanged);
            this.InvetarniNumber_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTB_ONLY_NUMBER_KeyPress);
            // 
            // DataPostyplenia_picker
            // 
            this.DataPostyplenia_picker.Location = new System.Drawing.Point(267, 250);
            this.DataPostyplenia_picker.MaxDate = new System.DateTime(3002, 8, 2, 0, 0, 0, 0);
            this.DataPostyplenia_picker.MinDate = new System.DateTime(2002, 8, 2, 0, 0, 0, 0);
            this.DataPostyplenia_picker.Name = "DataPostyplenia_picker";
            this.DataPostyplenia_picker.Size = new System.Drawing.Size(206, 27);
            this.DataPostyplenia_picker.TabIndex = 2;
            this.DataPostyplenia_picker.ValueChanged += new System.EventHandler(this.DataPostyplenia_picker_ValueChanged);
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.BackColor = System.Drawing.Color.White;
            this.buttonAddToList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddToList.Location = new System.Drawing.Point(675, 38);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(182, 44);
            this.buttonAddToList.TabIndex = 3;
            this.buttonAddToList.Text = "Добавить значение";
            this.buttonAddToList.UseVisualStyleBackColor = false;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonSaveInFile_Click);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_label.Location = new System.Drawing.Point(33, 32);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(59, 15);
            this.Name_label.TabIndex = 5;
            this.Name_label.Text = "Название";
            // 
            // Invent_label
            // 
            this.Invent_label.AutoSize = true;
            this.Invent_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Invent_label.Location = new System.Drawing.Point(33, 82);
            this.Invent_label.Name = "Invent_label";
            this.Invent_label.Size = new System.Drawing.Size(122, 15);
            this.Invent_label.TabIndex = 6;
            this.Invent_label.Text = "Инвентарный номер";
            this.Invent_label.Click += new System.EventHandler(this.Invent_label_Click);
            // 
            // Size_label
            // 
            this.Size_label.AutoSize = true;
            this.Size_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Size_label.Location = new System.Drawing.Point(33, 126);
            this.Size_label.Name = "Size_label";
            this.Size_label.Size = new System.Drawing.Size(47, 15);
            this.Size_label.TabIndex = 8;
            this.Size_label.Text = "Размер";
            this.Size_label.Click += new System.EventHandler(this.Size_label_Click);
            // 
            // Weight_label
            // 
            this.Weight_label.AutoSize = true;
            this.Weight_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Weight_label.Location = new System.Drawing.Point(280, 177);
            this.Weight_label.Name = "Weight_label";
            this.Weight_label.Size = new System.Drawing.Size(48, 15);
            this.Weight_label.TabIndex = 13;
            this.Weight_label.Text = "Вес (кг)";
            this.Weight_label.Click += new System.EventHandler(this.Weight_label_Click);
            // 
            // Date_of_recive_label
            // 
            this.Date_of_recive_label.AutoSize = true;
            this.Date_of_recive_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Date_of_recive_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Date_of_recive_label.Location = new System.Drawing.Point(267, 230);
            this.Date_of_recive_label.Name = "Date_of_recive_label";
            this.Date_of_recive_label.Size = new System.Drawing.Size(110, 15);
            this.Date_of_recive_label.TabIndex = 14;
            this.Date_of_recive_label.Text = "Дата поступления";
            // 
            // Type_label
            // 
            this.Type_label.AutoSize = true;
            this.Type_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Type_label.Location = new System.Drawing.Point(41, 226);
            this.Type_label.Name = "Type_label";
            this.Type_label.Size = new System.Drawing.Size(38, 19);
            this.Type_label.TabIndex = 15;
            this.Type_label.Text = "Тип:";
            this.Type_label.Click += new System.EventHandler(this.Type_label_Click);
            // 
            // Count_label
            // 
            this.Count_label.AutoSize = true;
            this.Count_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Count_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Count_label.Location = new System.Drawing.Point(36, 565);
            this.Count_label.Name = "Count_label";
            this.Count_label.Size = new System.Drawing.Size(72, 15);
            this.Count_label.TabIndex = 16;
            this.Count_label.Text = "Количество";
            this.Count_label.Click += new System.EventHandler(this.Count_label_Click);
            // 
            // Price_label
            // 
            this.Price_label.AutoSize = true;
            this.Price_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Price_label.Location = new System.Drawing.Point(33, 177);
            this.Price_label.Name = "Price_label";
            this.Price_label.Size = new System.Drawing.Size(66, 15);
            this.Price_label.TabIndex = 17;
            this.Price_label.Text = "Цена (руб)";
            // 
            // Producer_label
            // 
            this.Producer_label.AutoSize = true;
            this.Producer_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Producer_label.Location = new System.Drawing.Point(32, 338);
            this.Producer_label.Name = "Producer_label";
            this.Producer_label.Size = new System.Drawing.Size(123, 19);
            this.Producer_label.TabIndex = 18;
            this.Producer_label.Text = "Производитель:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(75, 250);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(153, 19);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Непродовольственные";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox2.Location = new System.Drawing.Point(75, 275);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(140, 19);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "Продовольственные";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Quantity_trackBar
            // 
            this.Quantity_trackBar.LargeChange = 100;
            this.Quantity_trackBar.Location = new System.Drawing.Point(36, 594);
            this.Quantity_trackBar.Maximum = 1000;
            this.Quantity_trackBar.Name = "Quantity_trackBar";
            this.Quantity_trackBar.Size = new System.Drawing.Size(261, 45);
            this.Quantity_trackBar.SmallChange = 100;
            this.Quantity_trackBar.TabIndex = 24;
            this.Quantity_trackBar.TickFrequency = 100;
            this.Quantity_trackBar.Scroll += new System.EventHandler(this.trackBarColichestvo_Scroll);
            // 
            // Resume_richbox
            // 
            this.Resume_richbox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Resume_richbox.Location = new System.Drawing.Point(675, 103);
            this.Resume_richbox.Name = "Resume_richbox";
            this.Resume_richbox.Size = new System.Drawing.Size(548, 521);
            this.Resume_richbox.TabIndex = 26;
            this.Resume_richbox.Text = "";
            this.Resume_richbox.TextChanged += new System.EventHandler(this.Resume_richbox_TextChanged);
            // 
            // Country_textBox
            // 
            this.Country_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Country_textBox.Location = new System.Drawing.Point(201, 379);
            this.Country_textBox.Name = "Country_textBox";
            this.Country_textBox.Size = new System.Drawing.Size(284, 27);
            this.Country_textBox.TabIndex = 28;
            this.Country_textBox.TextChanged += new System.EventHandler(this.Country_textBox_TextChanged);
            this.Country_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTB_ONLY_CHAR_KeyPress);
            // 
            // Org_textBox
            // 
            this.Org_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Org_textBox.Location = new System.Drawing.Point(201, 451);
            this.Org_textBox.Name = "Org_textBox";
            this.Org_textBox.Size = new System.Drawing.Size(284, 27);
            this.Org_textBox.TabIndex = 29;
            // 
            // Adres_textBox
            // 
            this.Adres_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Adres_textBox.Location = new System.Drawing.Point(201, 415);
            this.Adres_textBox.Name = "Adres_textBox";
            this.Adres_textBox.Size = new System.Drawing.Size(284, 27);
            this.Adres_textBox.TabIndex = 30;
            // 
            // Phone_textBox
            // 
            this.Phone_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Phone_textBox.Location = new System.Drawing.Point(201, 492);
            this.Phone_textBox.Mask = "(999) 000-0000";
            this.Phone_textBox.Name = "Phone_textBox";
            this.Phone_textBox.Size = new System.Drawing.Size(284, 27);
            this.Phone_textBox.TabIndex = 32;
            this.Phone_textBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.Phone_textBox_MaskInputRejected);
            // 
            // Country_label
            // 
            this.Country_label.AutoSize = true;
            this.Country_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Country_label.Location = new System.Drawing.Point(67, 386);
            this.Country_label.Name = "Country_label";
            this.Country_label.Size = new System.Drawing.Size(46, 15);
            this.Country_label.TabIndex = 33;
            this.Country_label.Text = "Страна";
            // 
            // Organization_label
            // 
            this.Organization_label.AutoSize = true;
            this.Organization_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Organization_label.Location = new System.Drawing.Point(67, 458);
            this.Organization_label.Name = "Organization_label";
            this.Organization_label.Size = new System.Drawing.Size(79, 15);
            this.Organization_label.TabIndex = 34;
            this.Organization_label.Text = "Организация";
            // 
            // Adres_label
            // 
            this.Adres_label.AutoSize = true;
            this.Adres_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Adres_label.Location = new System.Drawing.Point(67, 422);
            this.Adres_label.Name = "Adres_label";
            this.Adres_label.Size = new System.Drawing.Size(40, 15);
            this.Adres_label.TabIndex = 35;
            this.Adres_label.Text = "Адрес";
            // 
            // Phone_label
            // 
            this.Phone_label.AutoSize = true;
            this.Phone_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Phone_label.Location = new System.Drawing.Point(67, 499);
            this.Phone_label.Name = "Phone_label";
            this.Phone_label.Size = new System.Drawing.Size(55, 15);
            this.Phone_label.TabIndex = 36;
            this.Phone_label.Text = "Телефон";
            // 
            // radioSred
            // 
            this.radioSred.AutoSize = true;
            this.radioSred.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSred.Location = new System.Drawing.Point(324, 121);
            this.radioSred.Name = "radioSred";
            this.radioSred.Size = new System.Drawing.Size(73, 19);
            this.radioSred.TabIndex = 10;
            this.radioSred.TabStop = true;
            this.radioSred.Text = "Средний";
            this.radioSred.UseVisualStyleBackColor = true;
            // 
            // radioSmall
            // 
            this.radioSmall.AutoSize = true;
            this.radioSmall.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSmall.Location = new System.Drawing.Point(444, 123);
            this.radioSmall.Name = "radioSmall";
            this.radioSmall.Size = new System.Drawing.Size(88, 19);
            this.radioSmall.TabIndex = 11;
            this.radioSmall.TabStop = true;
            this.radioSmall.Text = "Маленький";
            this.radioSmall.UseVisualStyleBackColor = true;
            // 
            // radioBig
            // 
            this.radioBig.AutoSize = true;
            this.radioBig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioBig.Location = new System.Drawing.Point(201, 121);
            this.radioBig.Name = "radioBig";
            this.radioBig.Size = new System.Drawing.Size(77, 19);
            this.radioBig.TabIndex = 9;
            this.radioBig.TabStop = true;
            this.radioBig.Text = "Большой";
            this.radioBig.UseVisualStyleBackColor = true;
            // 
            // Clear_bt
            // 
            this.Clear_bt.Location = new System.Drawing.Point(1050, 641);
            this.Clear_bt.Name = "Clear_bt";
            this.Clear_bt.Size = new System.Drawing.Size(173, 44);
            this.Clear_bt.TabIndex = 38;
            this.Clear_bt.Text = "Очистить поля";
            this.Clear_bt.UseVisualStyleBackColor = true;
            this.Clear_bt.Click += new System.EventHandler(this.Button_clear);
            // 
            // Clear_rch
            // 
            this.Clear_rch.Location = new System.Drawing.Point(863, 641);
            this.Clear_rch.Name = "Clear_rch";
            this.Clear_rch.Size = new System.Drawing.Size(181, 44);
            this.Clear_rch.TabIndex = 39;
            this.Clear_rch.Text = "Очистить  вывод";
            this.Clear_rch.UseVisualStyleBackColor = true;
            this.Clear_rch.Click += new System.EventHandler(this.Clear_rch_Click);
            // 
            // Price_textBox
            // 
            this.Price_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Price_textBox.Location = new System.Drawing.Point(113, 170);
            this.Price_textBox.Mask = "9999";
            this.Price_textBox.Name = "Price_textBox";
            this.Price_textBox.Size = new System.Drawing.Size(115, 27);
            this.Price_textBox.TabIndex = 40;
            this.Price_textBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.Price_textBox_MaskInputRejected_1);
            // 
            // Weight_textBox
            // 
            this.Weight_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Weight_textBox.Location = new System.Drawing.Point(334, 170);
            this.Weight_textBox.Mask = "999.00";
            this.Weight_textBox.Name = "Weight_textBox";
            this.Weight_textBox.Size = new System.Drawing.Size(115, 27);
            this.Weight_textBox.TabIndex = 41;
            // 
            // Save_in_file
            // 
            this.Save_in_file.Location = new System.Drawing.Point(1050, 38);
            this.Save_in_file.Name = "Save_in_file";
            this.Save_in_file.Size = new System.Drawing.Size(173, 44);
            this.Save_in_file.TabIndex = 42;
            this.Save_in_file.Text = "Сохранить в файл";
            this.Save_in_file.UseVisualStyleBackColor = true;
            this.Save_in_file.Click += new System.EventHandler(this.button1_Click);
            // 
            // Read_from_file
            // 
            this.Read_from_file.Location = new System.Drawing.Point(863, 38);
            this.Read_from_file.Name = "Read_from_file";
            this.Read_from_file.Size = new System.Drawing.Size(181, 44);
            this.Read_from_file.TabIndex = 43;
            this.Read_from_file.Text = "Прочитать из файла";
            this.Read_from_file.UseVisualStyleBackColor = true;
            this.Read_from_file.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_find
            // 
            this.button_find.Location = new System.Drawing.Point(675, 641);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(182, 44);
            this.button_find.TabIndex = 45;
            this.button_find.Text = "Поиск";
            this.button_find.UseVisualStyleBackColor = true;
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About,
            this.toolStripMenuItem1,
            this.сортировкаToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1256, 24);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(94, 20);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.About_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem1.Text = "Поиск";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сортировкаПоToolStripMenuItem,
            this.сортировкаПоСтранеToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // сортировкаПоToolStripMenuItem
            // 
            this.сортировкаПоToolStripMenuItem.Name = "сортировкаПоToolStripMenuItem";
            this.сортировкаПоToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.сортировкаПоToolStripMenuItem.Text = "Сортировка по дате";
            this.сортировкаПоToolStripMenuItem.Click += new System.EventHandler(this.сортировкаПоToolStripMenuItem_Click);
            // 
            // сортировкаПоСтранеToolStripMenuItem
            // 
            this.сортировкаПоСтранеToolStripMenuItem.Name = "сортировкаПоСтранеToolStripMenuItem";
            this.сортировкаПоСтранеToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.сортировкаПоСтранеToolStripMenuItem.Text = "Сортировка по стране";
            this.сортировкаПоСтранеToolStripMenuItem.Click += new System.EventHandler(this.сортировкаПоСтранеToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // label_stat
            // 
            this.label_stat.AutoSize = true;
            this.label_stat.Location = new System.Drawing.Point(333, 336);
            this.label_stat.Name = "label_stat";
            this.label_stat.Size = new System.Drawing.Size(144, 20);
            this.label_stat.TabIndex = 47;
            this.label_stat.Text = "Объектов пока нет ";
            this.label_stat.Click += new System.EventHandler(this.label_stat_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ivent_label
            // 
            this.ivent_label.AutoSize = true;
            this.ivent_label.Location = new System.Drawing.Point(333, 641);
            this.ivent_label.Name = "ivent_label";
            this.ivent_label.Size = new System.Drawing.Size(152, 20);
            this.ivent_label.TabIndex = 49;
            this.ivent_label.Text = "Последнее действие";
            this.ivent_label.Click += new System.EventHandler(this.ivent_label_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timer_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1256, 22);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer_label
            // 
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(118, 17);
            this.timer_label.Text = "toolStripStatusLabel1";
            this.timer_label.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1256, 706);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ivent_label);
            this.Controls.Add(this.label_stat);
            this.Controls.Add(this.button_find);
            this.Controls.Add(this.Read_from_file);
            this.Controls.Add(this.Save_in_file);
            this.Controls.Add(this.Weight_textBox);
            this.Controls.Add(this.Price_textBox);
            this.Controls.Add(this.Clear_rch);
            this.Controls.Add(this.radioBig);
            this.Controls.Add(this.Clear_bt);
            this.Controls.Add(this.radioSmall);
            this.Controls.Add(this.radioSred);
            this.Controls.Add(this.Phone_label);
            this.Controls.Add(this.Adres_label);
            this.Controls.Add(this.Organization_label);
            this.Controls.Add(this.Country_label);
            this.Controls.Add(this.Phone_textBox);
            this.Controls.Add(this.Adres_textBox);
            this.Controls.Add(this.Org_textBox);
            this.Controls.Add(this.Country_textBox);
            this.Controls.Add(this.Resume_richbox);
            this.Controls.Add(this.Quantity_trackBar);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Producer_label);
            this.Controls.Add(this.Price_label);
            this.Controls.Add(this.Count_label);
            this.Controls.Add(this.Type_label);
            this.Controls.Add(this.Date_of_recive_label);
            this.Controls.Add(this.Weight_label);
            this.Controls.Add(this.Size_label);
            this.Controls.Add(this.Invent_label);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.buttonAddToList);
            this.Controls.Add(this.DataPostyplenia_picker);
            this.Controls.Add(this.InvetarniNumber_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_trackBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.TextBox InvetarniNumber_textBox;
        private System.Windows.Forms.DateTimePicker DataPostyplenia_picker;
        private System.Windows.Forms.Button buttonAddToList;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Invent_label;
        private System.Windows.Forms.Label Size_label;
        private System.Windows.Forms.Label Weight_label;
        private System.Windows.Forms.Label Date_of_recive_label;
        private System.Windows.Forms.Label Type_label;
        private System.Windows.Forms.Label Count_label;
        private System.Windows.Forms.Label Price_label;
        private System.Windows.Forms.Label Producer_label;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TrackBar Quantity_trackBar;
        private System.Windows.Forms.RichTextBox Resume_richbox;
        private System.Windows.Forms.TextBox Country_textBox;
        private System.Windows.Forms.TextBox Org_textBox;
        private System.Windows.Forms.TextBox Adres_textBox;
        private System.Windows.Forms.MaskedTextBox Phone_textBox;
        private System.Windows.Forms.Label Country_label;
        private System.Windows.Forms.Label Organization_label;
        private System.Windows.Forms.Label Adres_label;
        private System.Windows.Forms.Label Phone_label;
        private System.Windows.Forms.RadioButton radioSred;
        private System.Windows.Forms.RadioButton radioSmall;
        private System.Windows.Forms.RadioButton radioBig;
        private System.Windows.Forms.Button Clear_bt;
        private System.Windows.Forms.Button Clear_rch;
        private System.Windows.Forms.MaskedTextBox Price_textBox;
        private System.Windows.Forms.MaskedTextBox Weight_textBox;
        private System.Windows.Forms.Button Save_in_file;
        private System.Windows.Forms.Button Read_from_file;
        private System.Windows.Forms.Button button_find;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаПоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаПоСтранеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.Label label_stat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label ivent_label;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timer_label;
    }
}

