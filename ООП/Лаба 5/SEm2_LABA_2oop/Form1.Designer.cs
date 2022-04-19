
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
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.InvetarniNumber_textBox = new System.Windows.Forms.TextBox();
            this.DataPostyplenia_picker = new System.Windows.Forms.DateTimePicker();
            this.buttonSaveInFile = new System.Windows.Forms.Button();
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
            this.buttonIzFile = new System.Windows.Forms.Button();
            this.radioSred = new System.Windows.Forms.RadioButton();
            this.radioSmall = new System.Windows.Forms.RadioButton();
            this.radioBig = new System.Windows.Forms.RadioButton();
            this.Clear_bt = new System.Windows.Forms.Button();
            this.Clear_rch = new System.Windows.Forms.Button();
            this.Price_textBox = new System.Windows.Forms.MaskedTextBox();
            this.Weight_textBox = new System.Windows.Forms.MaskedTextBox();
            this.Abstc_realization = new System.Windows.Forms.Button();
            this.Factory_1_radio = new System.Windows.Forms.RadioButton();
            this.Factory_2_radio = new System.Windows.Forms.RadioButton();
            this.Object_1 = new System.Windows.Forms.RadioButton();
            this.Object_2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Singletone_bt = new System.Windows.Forms.Button();
            this.prototype = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bilder_btn = new System.Windows.Forms.Button();
            this.Adapter = new System.Windows.Forms.Button();
            this.Observer_btn = new System.Windows.Forms.Button();
            this.iterator_textbox = new System.Windows.Forms.TextBox();
            this.Add_iterator_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name_textBox
            // 
            this.Name_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name_textBox.Location = new System.Drawing.Point(201, 25);
            this.Name_textBox.MaxLength = 36;
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(196, 27);
            this.Name_textBox.TabIndex = 0;
            this.Name_textBox.TextChanged += new System.EventHandler(this.Name_textBox_TextChanged);
            // 
            // InvetarniNumber_textBox
            // 
            this.InvetarniNumber_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InvetarniNumber_textBox.Location = new System.Drawing.Point(201, 75);
            this.InvetarniNumber_textBox.Name = "InvetarniNumber_textBox";
            this.InvetarniNumber_textBox.Size = new System.Drawing.Size(196, 27);
            this.InvetarniNumber_textBox.TabIndex = 1;
            this.InvetarniNumber_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTB_ONLY_NUMBER_KeyPress);
            // 
            // DataPostyplenia_picker
            // 
            this.DataPostyplenia_picker.Location = new System.Drawing.Point(295, 561);
            this.DataPostyplenia_picker.MaxDate = new System.DateTime(3002, 8, 2, 0, 0, 0, 0);
            this.DataPostyplenia_picker.MinDate = new System.DateTime(2002, 8, 2, 0, 0, 0, 0);
            this.DataPostyplenia_picker.Name = "DataPostyplenia_picker";
            this.DataPostyplenia_picker.Size = new System.Drawing.Size(155, 27);
            this.DataPostyplenia_picker.TabIndex = 2;
            this.DataPostyplenia_picker.ValueChanged += new System.EventHandler(this.DataPostyplenia_picker_ValueChanged);
            // 
            // buttonSaveInFile
            // 
            this.buttonSaveInFile.BackColor = System.Drawing.Color.White;
            this.buttonSaveInFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveInFile.Location = new System.Drawing.Point(728, 38);
            this.buttonSaveInFile.Name = "buttonSaveInFile";
            this.buttonSaveInFile.Size = new System.Drawing.Size(255, 37);
            this.buttonSaveInFile.TabIndex = 3;
            this.buttonSaveInFile.Text = "Сохранить в файл";
            this.buttonSaveInFile.UseVisualStyleBackColor = false;
            this.buttonSaveInFile.Click += new System.EventHandler(this.buttonSaveInFile_Click);
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
            this.Weight_label.Location = new System.Drawing.Point(241, 177);
            this.Weight_label.Name = "Weight_label";
            this.Weight_label.Size = new System.Drawing.Size(48, 15);
            this.Weight_label.TabIndex = 13;
            this.Weight_label.Text = "Вес (кг)";
            this.Weight_label.Click += new System.EventHandler(this.Weight_label_Click);
            // 
            // Date_of_recive_label
            // 
            this.Date_of_recive_label.AutoSize = true;
            this.Date_of_recive_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Date_of_recive_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Date_of_recive_label.Location = new System.Drawing.Point(295, 525);
            this.Date_of_recive_label.Name = "Date_of_recive_label";
            this.Date_of_recive_label.Size = new System.Drawing.Size(106, 15);
            this.Date_of_recive_label.TabIndex = 14;
            this.Date_of_recive_label.Text = "Дата поступления";
            // 
            // Type_label
            // 
            this.Type_label.AutoSize = true;
            this.Type_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Type_label.Location = new System.Drawing.Point(33, 221);
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
            this.Count_label.Location = new System.Drawing.Point(40, 525);
            this.Count_label.Name = "Count_label";
            this.Count_label.Size = new System.Drawing.Size(72, 15);
            this.Count_label.TabIndex = 16;
            this.Count_label.Text = "Количество";
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
            this.Producer_label.Location = new System.Drawing.Point(32, 308);
            this.Producer_label.Name = "Producer_label";
            this.Producer_label.Size = new System.Drawing.Size(123, 19);
            this.Producer_label.TabIndex = 18;
            this.Producer_label.Text = "Производитель:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(67, 245);
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
            this.checkBox2.Location = new System.Drawing.Point(67, 270);
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
            this.Quantity_trackBar.Location = new System.Drawing.Point(40, 554);
            this.Quantity_trackBar.Maximum = 1000;
            this.Quantity_trackBar.Name = "Quantity_trackBar";
            this.Quantity_trackBar.Size = new System.Drawing.Size(210, 45);
            this.Quantity_trackBar.SmallChange = 100;
            this.Quantity_trackBar.TabIndex = 24;
            this.Quantity_trackBar.TickFrequency = 100;
            this.Quantity_trackBar.Scroll += new System.EventHandler(this.trackBarColichestvo_Scroll);
            // 
            // Resume_richbox
            // 
            this.Resume_richbox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Resume_richbox.Location = new System.Drawing.Point(717, 101);
            this.Resume_richbox.Name = "Resume_richbox";
            this.Resume_richbox.Size = new System.Drawing.Size(527, 521);
            this.Resume_richbox.TabIndex = 26;
            this.Resume_richbox.Text = "";
            // 
            // Country_textBox
            // 
            this.Country_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Country_textBox.Location = new System.Drawing.Point(201, 349);
            this.Country_textBox.Name = "Country_textBox";
            this.Country_textBox.Size = new System.Drawing.Size(209, 27);
            this.Country_textBox.TabIndex = 28;
            this.Country_textBox.TextChanged += new System.EventHandler(this.Country_textBox_TextChanged);
            this.Country_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTB_ONLY_CHAR_KeyPress);
            // 
            // Org_textBox
            // 
            this.Org_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Org_textBox.Location = new System.Drawing.Point(201, 421);
            this.Org_textBox.Name = "Org_textBox";
            this.Org_textBox.Size = new System.Drawing.Size(209, 27);
            this.Org_textBox.TabIndex = 29;
            // 
            // Adres_textBox
            // 
            this.Adres_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Adres_textBox.Location = new System.Drawing.Point(201, 385);
            this.Adres_textBox.Name = "Adres_textBox";
            this.Adres_textBox.Size = new System.Drawing.Size(209, 27);
            this.Adres_textBox.TabIndex = 30;
            // 
            // Phone_textBox
            // 
            this.Phone_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Phone_textBox.Location = new System.Drawing.Point(201, 462);
            this.Phone_textBox.Mask = "(999) 000-0000";
            this.Phone_textBox.Name = "Phone_textBox";
            this.Phone_textBox.Size = new System.Drawing.Size(209, 27);
            this.Phone_textBox.TabIndex = 32;
            this.Phone_textBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.Phone_textBox_MaskInputRejected);
            // 
            // Country_label
            // 
            this.Country_label.AutoSize = true;
            this.Country_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Country_label.Location = new System.Drawing.Point(67, 356);
            this.Country_label.Name = "Country_label";
            this.Country_label.Size = new System.Drawing.Size(46, 15);
            this.Country_label.TabIndex = 33;
            this.Country_label.Text = "Страна";
            // 
            // Organization_label
            // 
            this.Organization_label.AutoSize = true;
            this.Organization_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Organization_label.Location = new System.Drawing.Point(67, 428);
            this.Organization_label.Name = "Organization_label";
            this.Organization_label.Size = new System.Drawing.Size(79, 15);
            this.Organization_label.TabIndex = 34;
            this.Organization_label.Text = "Организация";
            // 
            // Adres_label
            // 
            this.Adres_label.AutoSize = true;
            this.Adres_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Adres_label.Location = new System.Drawing.Point(67, 392);
            this.Adres_label.Name = "Adres_label";
            this.Adres_label.Size = new System.Drawing.Size(40, 15);
            this.Adres_label.TabIndex = 35;
            this.Adres_label.Text = "Адрес";
            // 
            // Phone_label
            // 
            this.Phone_label.AutoSize = true;
            this.Phone_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Phone_label.Location = new System.Drawing.Point(67, 469);
            this.Phone_label.Name = "Phone_label";
            this.Phone_label.Size = new System.Drawing.Size(55, 15);
            this.Phone_label.TabIndex = 36;
            this.Phone_label.Text = "Телефон";
            // 
            // buttonIzFile
            // 
            this.buttonIzFile.BackColor = System.Drawing.Color.White;
            this.buttonIzFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonIzFile.Location = new System.Drawing.Point(990, 38);
            this.buttonIzFile.Name = "buttonIzFile";
            this.buttonIzFile.Size = new System.Drawing.Size(255, 37);
            this.buttonIzFile.TabIndex = 37;
            this.buttonIzFile.Text = "Прочитать из файла";
            this.buttonIzFile.UseVisualStyleBackColor = false;
            this.buttonIzFile.Click += new System.EventHandler(this.buttonIzFile_Click);
            // 
            // radioSred
            // 
            this.radioSred.AutoSize = true;
            this.radioSred.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSred.Location = new System.Drawing.Point(169, 124);
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
            this.radioSmall.Location = new System.Drawing.Point(248, 126);
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
            this.radioBig.Location = new System.Drawing.Point(86, 124);
            this.radioBig.Name = "radioBig";
            this.radioBig.Size = new System.Drawing.Size(77, 19);
            this.radioBig.TabIndex = 9;
            this.radioBig.TabStop = true;
            this.radioBig.Text = "Большой";
            this.radioBig.UseVisualStyleBackColor = true;
            // 
            // Clear_bt
            // 
            this.Clear_bt.Location = new System.Drawing.Point(1064, 652);
            this.Clear_bt.Name = "Clear_bt";
            this.Clear_bt.Size = new System.Drawing.Size(181, 44);
            this.Clear_bt.TabIndex = 38;
            this.Clear_bt.Text = "Очистить поля";
            this.Clear_bt.UseVisualStyleBackColor = true;
            this.Clear_bt.Click += new System.EventHandler(this.Button_clear);
            // 
            // Clear_rch
            // 
            this.Clear_rch.Location = new System.Drawing.Point(867, 652);
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
            this.Price_textBox.Mask = "$999,999.00";
            this.Price_textBox.Name = "Price_textBox";
            this.Price_textBox.Size = new System.Drawing.Size(115, 27);
            this.Price_textBox.TabIndex = 40;
            // 
            // Weight_textBox
            // 
            this.Weight_textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Weight_textBox.Location = new System.Drawing.Point(295, 170);
            this.Weight_textBox.Mask = "999.00";
            this.Weight_textBox.Name = "Weight_textBox";
            this.Weight_textBox.Size = new System.Drawing.Size(115, 27);
            this.Weight_textBox.TabIndex = 41;
            // 
            // Abstc_realization
            // 
            this.Abstc_realization.Location = new System.Drawing.Point(456, 200);
            this.Abstc_realization.Name = "Abstc_realization";
            this.Abstc_realization.Size = new System.Drawing.Size(244, 28);
            this.Abstc_realization.TabIndex = 42;
            this.Abstc_realization.Text = "Фабрика";
            this.Abstc_realization.UseVisualStyleBackColor = true;
            this.Abstc_realization.Click += new System.EventHandler(this.button1_Click);
            // 
            // Factory_1_radio
            // 
            this.Factory_1_radio.AutoSize = true;
            this.Factory_1_radio.Location = new System.Drawing.Point(462, 120);
            this.Factory_1_radio.Name = "Factory_1_radio";
            this.Factory_1_radio.Size = new System.Drawing.Size(80, 24);
            this.Factory_1_radio.TabIndex = 43;
            this.Factory_1_radio.TabStop = true;
            this.Factory_1_radio.Text = "Завод 1";
            this.Factory_1_radio.UseVisualStyleBackColor = true;
            this.Factory_1_radio.CheckedChanged += new System.EventHandler(this.Factory_1_radio_CheckedChanged);
            // 
            // Factory_2_radio
            // 
            this.Factory_2_radio.AutoSize = true;
            this.Factory_2_radio.Location = new System.Drawing.Point(605, 120);
            this.Factory_2_radio.Name = "Factory_2_radio";
            this.Factory_2_radio.Size = new System.Drawing.Size(80, 24);
            this.Factory_2_radio.TabIndex = 44;
            this.Factory_2_radio.TabStop = true;
            this.Factory_2_radio.Text = "Завод 2";
            this.Factory_2_radio.UseVisualStyleBackColor = true;
            this.Factory_2_radio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Object_1
            // 
            this.Object_1.AutoSize = true;
            this.Object_1.Location = new System.Drawing.Point(6, 18);
            this.Object_1.Name = "Object_1";
            this.Object_1.Size = new System.Drawing.Size(89, 24);
            this.Object_1.TabIndex = 45;
            this.Object_1.TabStop = true;
            this.Object_1.Text = "Объект 1";
            this.Object_1.UseVisualStyleBackColor = true;
            // 
            // Object_2
            // 
            this.Object_2.AutoSize = true;
            this.Object_2.Location = new System.Drawing.Point(149, 18);
            this.Object_2.Name = "Object_2";
            this.Object_2.Size = new System.Drawing.Size(89, 24);
            this.Object_2.TabIndex = 46;
            this.Object_2.TabStop = true;
            this.Object_2.Text = "Объект 2";
            this.Object_2.UseVisualStyleBackColor = true;
            this.Object_2.CheckedChanged += new System.EventHandler(this.Object_2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Object_2);
            this.groupBox1.Controls.Add(this.Object_1);
            this.groupBox1.Location = new System.Drawing.Point(456, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 48);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // Singletone_bt
            // 
            this.Singletone_bt.Location = new System.Drawing.Point(456, 405);
            this.Singletone_bt.Name = "Singletone_bt";
            this.Singletone_bt.Size = new System.Drawing.Size(244, 29);
            this.Singletone_bt.TabIndex = 49;
            this.Singletone_bt.Text = "Singletone";
            this.Singletone_bt.UseVisualStyleBackColor = true;
            this.Singletone_bt.Click += new System.EventHandler(this.Singletone_bt_Click);
            // 
            // prototype
            // 
            this.prototype.Location = new System.Drawing.Point(456, 331);
            this.prototype.Name = "prototype";
            this.prototype.Size = new System.Drawing.Size(113, 29);
            this.prototype.TabIndex = 50;
            this.prototype.Text = "Клонируем";
            this.prototype.UseVisualStyleBackColor = true;
            this.prototype.Click += new System.EventHandler(this.prototype_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(575, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 29);
            this.button2.TabIndex = 51;
            this.button2.Text = "Вставка клона";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bilder_btn
            // 
            this.bilder_btn.Location = new System.Drawing.Point(456, 292);
            this.bilder_btn.Name = "bilder_btn";
            this.bilder_btn.Size = new System.Drawing.Size(244, 33);
            this.bilder_btn.TabIndex = 52;
            this.bilder_btn.Text = "Строитель";
            this.bilder_btn.UseVisualStyleBackColor = true;
            this.bilder_btn.Click += new System.EventHandler(this.bilder_btn_Click);
            // 
            // Adapter
            // 
            this.Adapter.Location = new System.Drawing.Point(514, 490);
            this.Adapter.Name = "Adapter";
            this.Adapter.Size = new System.Drawing.Size(129, 28);
            this.Adapter.TabIndex = 53;
            this.Adapter.Text = "Adapter";
            this.Adapter.UseVisualStyleBackColor = true;
            this.Adapter.Click += new System.EventHandler(this.Adapter_Click);
            // 
            // Observer_btn
            // 
            this.Observer_btn.Location = new System.Drawing.Point(514, 535);
            this.Observer_btn.Name = "Observer_btn";
            this.Observer_btn.Size = new System.Drawing.Size(129, 31);
            this.Observer_btn.TabIndex = 54;
            this.Observer_btn.Text = "Observer";
            this.Observer_btn.UseVisualStyleBackColor = true;
            this.Observer_btn.Click += new System.EventHandler(this.Observer_btn_Click);
            // 
            // iterator_textbox
            // 
            this.iterator_textbox.Location = new System.Drawing.Point(494, 599);
            this.iterator_textbox.Name = "iterator_textbox";
            this.iterator_textbox.Size = new System.Drawing.Size(191, 27);
            this.iterator_textbox.TabIndex = 55;
            this.iterator_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Add_iterator_btn
            // 
            this.Add_iterator_btn.Location = new System.Drawing.Point(494, 632);
            this.Add_iterator_btn.Name = "Add_iterator_btn";
            this.Add_iterator_btn.Size = new System.Drawing.Size(191, 34);
            this.Add_iterator_btn.TabIndex = 56;
            this.Add_iterator_btn.Text = "Add iterator";
            this.Add_iterator_btn.UseVisualStyleBackColor = true;
            this.Add_iterator_btn.Click += new System.EventHandler(this.Add_iterator_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1256, 706);
            this.Controls.Add(this.Add_iterator_btn);
            this.Controls.Add(this.iterator_textbox);
            this.Controls.Add(this.Observer_btn);
            this.Controls.Add(this.Adapter);
            this.Controls.Add(this.bilder_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.prototype);
            this.Controls.Add(this.Singletone_bt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Factory_2_radio);
            this.Controls.Add(this.Factory_1_radio);
            this.Controls.Add(this.Abstc_realization);
            this.Controls.Add(this.Weight_textBox);
            this.Controls.Add(this.Price_textBox);
            this.Controls.Add(this.Clear_rch);
            this.Controls.Add(this.radioBig);
            this.Controls.Add(this.Clear_bt);
            this.Controls.Add(this.radioSmall);
            this.Controls.Add(this.buttonIzFile);
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
            this.Controls.Add(this.buttonSaveInFile);
            this.Controls.Add(this.DataPostyplenia_picker);
            this.Controls.Add(this.InvetarniNumber_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_trackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.TextBox InvetarniNumber_textBox;
        private System.Windows.Forms.DateTimePicker DataPostyplenia_picker;
        private System.Windows.Forms.Button buttonSaveInFile;
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
        private System.Windows.Forms.Button buttonIzFile;
        private System.Windows.Forms.RadioButton radioSred;
        private System.Windows.Forms.RadioButton radioSmall;
        private System.Windows.Forms.RadioButton radioBig;
        private System.Windows.Forms.Button Clear_bt;
        private System.Windows.Forms.Button Clear_rch;
        private System.Windows.Forms.MaskedTextBox Price_textBox;
        private System.Windows.Forms.MaskedTextBox Weight_textBox;
        private System.Windows.Forms.Button Abstc_realization;
        private System.Windows.Forms.RadioButton Factory_1_radio;
        private System.Windows.Forms.RadioButton Factory_2_radio;
        private System.Windows.Forms.RadioButton Object_1;
        private System.Windows.Forms.RadioButton Object_2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Singletone_bt;
        private System.Windows.Forms.Button prototype;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bilder_btn;
        private System.Windows.Forms.Button Adapter;
        private System.Windows.Forms.Button Observer_btn;
        private System.Windows.Forms.TextBox iterator_textbox;
        private System.Windows.Forms.Button Add_iterator_btn;
    }
}

