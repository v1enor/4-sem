namespace laba_2
{
    partial class Form_find
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
            this.find_by_name_box = new System.Windows.Forms.TextBox();
            this.find_by_name_label = new System.Windows.Forms.Label();
            this.find_by_type_label = new System.Windows.Forms.Label();
            this.find_by_type_comboBox = new System.Windows.Forms.ComboBox();
            this.Price_from_box = new System.Windows.Forms.TextBox();
            this.Price_to_box = new System.Windows.Forms.TextBox();
            this.Sort_by_label = new System.Windows.Forms.Label();
            this.Price_from_label = new System.Windows.Forms.Label();
            this.Price_to_label = new System.Windows.Forms.Label();
            this.By_date_radio = new System.Windows.Forms.RadioButton();
            this.By_country_radio = new System.Windows.Forms.RadioButton();
            this.Find_button = new System.Windows.Forms.Button();
            this.Search_result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Find_count_label = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // find_by_name_box
            // 
            this.find_by_name_box.Location = new System.Drawing.Point(43, 62);
            this.find_by_name_box.Name = "find_by_name_box";
            this.find_by_name_box.Size = new System.Drawing.Size(158, 23);
            this.find_by_name_box.TabIndex = 0;
            this.find_by_name_box.TextChanged += new System.EventHandler(this.find_by_name_box_TextChanged);
            // 
            // find_by_name_label
            // 
            this.find_by_name_label.AutoSize = true;
            this.find_by_name_label.Location = new System.Drawing.Point(43, 44);
            this.find_by_name_label.Name = "find_by_name_label";
            this.find_by_name_label.Size = new System.Drawing.Size(80, 15);
            this.find_by_name_label.TabIndex = 1;
            this.find_by_name_label.Text = "По названию";
            this.find_by_name_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // find_by_type_label
            // 
            this.find_by_type_label.AutoSize = true;
            this.find_by_type_label.Location = new System.Drawing.Point(250, 44);
            this.find_by_type_label.Name = "find_by_type_label";
            this.find_by_type_label.Size = new System.Drawing.Size(51, 15);
            this.find_by_type_label.TabIndex = 2;
            this.find_by_type_label.Text = "По типу";
            // 
            // find_by_type_comboBox
            // 
            this.find_by_type_comboBox.FormattingEnabled = true;
            this.find_by_type_comboBox.Items.AddRange(new object[] {
            "Непродовольственные",
            "Продовольственные"});
            this.find_by_type_comboBox.Location = new System.Drawing.Point(250, 62);
            this.find_by_type_comboBox.Name = "find_by_type_comboBox";
            this.find_by_type_comboBox.Size = new System.Drawing.Size(124, 23);
            this.find_by_type_comboBox.TabIndex = 4;
            this.find_by_type_comboBox.SelectedIndexChanged += new System.EventHandler(this.find_by_type_comboBox_SelectedIndexChanged);
            // 
            // Price_from_box
            // 
            this.Price_from_box.Location = new System.Drawing.Point(43, 141);
            this.Price_from_box.Name = "Price_from_box";
            this.Price_from_box.Size = new System.Drawing.Size(100, 23);
            this.Price_from_box.TabIndex = 5;
            this.Price_from_box.TextChanged += new System.EventHandler(this.Price_from_box_TextChanged);
            // 
            // Price_to_box
            // 
            this.Price_to_box.Location = new System.Drawing.Point(174, 141);
            this.Price_to_box.Name = "Price_to_box";
            this.Price_to_box.Size = new System.Drawing.Size(100, 23);
            this.Price_to_box.TabIndex = 6;
            this.Price_to_box.TextChanged += new System.EventHandler(this.Price_to_box_TextChanged);
            // 
            // Sort_by_label
            // 
            this.Sort_by_label.AutoSize = true;
            this.Sort_by_label.Location = new System.Drawing.Point(43, 226);
            this.Sort_by_label.Name = "Sort_by_label";
            this.Sort_by_label.Size = new System.Drawing.Size(93, 15);
            this.Sort_by_label.TabIndex = 7;
            this.Sort_by_label.Text = "Сортировка по:";
            // 
            // Price_from_label
            // 
            this.Price_from_label.AutoSize = true;
            this.Price_from_label.Location = new System.Drawing.Point(43, 114);
            this.Price_from_label.Name = "Price_from_label";
            this.Price_from_label.Size = new System.Drawing.Size(50, 15);
            this.Price_from_label.TabIndex = 8;
            this.Price_from_label.Text = "Цена от";
            this.Price_from_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // Price_to_label
            // 
            this.Price_to_label.AutoSize = true;
            this.Price_to_label.Location = new System.Drawing.Point(174, 114);
            this.Price_to_label.Name = "Price_to_label";
            this.Price_to_label.Size = new System.Drawing.Size(51, 15);
            this.Price_to_label.TabIndex = 9;
            this.Price_to_label.Text = "Цена до";
            // 
            // By_date_radio
            // 
            this.By_date_radio.AutoSize = true;
            this.By_date_radio.Location = new System.Drawing.Point(56, 262);
            this.By_date_radio.Name = "By_date_radio";
            this.By_date_radio.Size = new System.Drawing.Size(145, 19);
            this.By_date_radio.TabIndex = 10;
            this.By_date_radio.TabStop = true;
            this.By_date_radio.Text = "По дате производства";
            this.By_date_radio.UseVisualStyleBackColor = true;
            this.By_date_radio.CheckedChanged += new System.EventHandler(this.By_date_radio_CheckedChanged);
            // 
            // By_country_radio
            // 
            this.By_country_radio.AutoSize = true;
            this.By_country_radio.Location = new System.Drawing.Point(224, 262);
            this.By_country_radio.Name = "By_country_radio";
            this.By_country_radio.Size = new System.Drawing.Size(150, 19);
            this.By_country_radio.TabIndex = 11;
            this.By_country_radio.TabStop = true;
            this.By_country_radio.Text = "Стране производителя";
            this.By_country_radio.UseVisualStyleBackColor = true;
            // 
            // Find_button
            // 
            this.Find_button.Location = new System.Drawing.Point(43, 306);
            this.Find_button.Name = "Find_button";
            this.Find_button.Size = new System.Drawing.Size(345, 79);
            this.Find_button.TabIndex = 12;
            this.Find_button.Text = "ПОИСК";
            this.Find_button.UseVisualStyleBackColor = true;
            this.Find_button.Click += new System.EventHandler(this.Find_button_Click);
            // 
            // Search_result_richTextBox
            // 
            this.Search_result_richTextBox.Location = new System.Drawing.Point(437, 44);
            this.Search_result_richTextBox.Name = "Search_result_richTextBox";
            this.Search_result_richTextBox.Size = new System.Drawing.Size(328, 307);
            this.Search_result_richTextBox.TabIndex = 13;
            this.Search_result_richTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.назадToolStripMenuItem.Text = "< Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // Find_count_label
            // 
            this.Find_count_label.AutoSize = true;
            this.Find_count_label.Location = new System.Drawing.Point(437, 370);
            this.Find_count_label.Name = "Find_count_label";
            this.Find_count_label.Size = new System.Drawing.Size(72, 15);
            this.Find_count_label.TabIndex = 17;
            this.Find_count_label.Text = "Количество";
            // 
            // Form_find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.Find_count_label);
            this.Controls.Add(this.Search_result_richTextBox);
            this.Controls.Add(this.Find_button);
            this.Controls.Add(this.By_country_radio);
            this.Controls.Add(this.By_date_radio);
            this.Controls.Add(this.Price_to_label);
            this.Controls.Add(this.Price_from_label);
            this.Controls.Add(this.Sort_by_label);
            this.Controls.Add(this.Price_to_box);
            this.Controls.Add(this.Price_from_box);
            this.Controls.Add(this.find_by_type_comboBox);
            this.Controls.Add(this.find_by_type_label);
            this.Controls.Add(this.find_by_name_label);
            this.Controls.Add(this.find_by_name_box);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_find";
            this.Text = "Поисковичок ж_ж";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox find_by_name_box;
        private System.Windows.Forms.Label find_by_name_label;
        private System.Windows.Forms.Label find_by_type_label;
        private System.Windows.Forms.ComboBox find_by_type_comboBox;
        private System.Windows.Forms.TextBox Price_from_box;
        private System.Windows.Forms.TextBox Price_to_box;
        private System.Windows.Forms.Label Sort_by_label;
        private System.Windows.Forms.Label Price_from_label;
        private System.Windows.Forms.Label Price_to_label;
        private System.Windows.Forms.RadioButton By_date_radio;
        private System.Windows.Forms.RadioButton By_country_radio;
        private System.Windows.Forms.Button Find_button;
        private System.Windows.Forms.RichTextBox Search_result_richTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.Label Find_count_label;
    }
}