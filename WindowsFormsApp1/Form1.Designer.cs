
namespace WindowsFormsApp1
{
    partial class Form1
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
            if (disposing && (components != null))
            {
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
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFirstType = new System.Windows.Forms.ComboBox();
            this.cmbSecondType = new System.Windows.Forms.ComboBox();
            this.cmbResultType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(108, 43);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(98, 20);
            this.txtFirst.TabIndex = 0;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged);
            this.txtFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirst_KeyPress);
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(108, 80);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(98, 20);
            this.txtSecond.TabIndex = 1;
            this.txtSecond.TextChanged += new System.EventHandler(this.txtSecond_TextChanged);
            this.txtSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecond_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Первое значение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Второе значение";
            // 
            // cmbOperation
            // 
            this.cmbOperation.FormattingEnabled = true;
            this.cmbOperation.Items.AddRange(new object[] {
            "сложение",
            "вычитание",
            "умножение",
            "сравнение"});
            this.cmbOperation.Location = new System.Drawing.Point(108, 12);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(97, 21);
            this.cmbOperation.TabIndex = 4;
            this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.cmbOperation_SelectedIndexChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(108, 117);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(97, 20);
            this.txtResult.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Действие";
            // 
            // cmbFirstType
            // 
            this.cmbFirstType.FormattingEnabled = true;
            this.cmbFirstType.Location = new System.Drawing.Point(212, 42);
            this.cmbFirstType.Name = "cmbFirstType";
            this.cmbFirstType.Size = new System.Drawing.Size(61, 21);
            this.cmbFirstType.TabIndex = 7;
            this.cmbFirstType.SelectedIndexChanged += new System.EventHandler(this.cmbFirstType_SelectedIndexChanged);
            // 
            // cmbSecondType
            // 
            this.cmbSecondType.FormattingEnabled = true;
            this.cmbSecondType.Location = new System.Drawing.Point(212, 79);
            this.cmbSecondType.Name = "cmbSecondType";
            this.cmbSecondType.Size = new System.Drawing.Size(61, 21);
            this.cmbSecondType.TabIndex = 8;
            this.cmbSecondType.SelectedIndexChanged += new System.EventHandler(this.cmbSecondType_SelectedIndexChanged);
            // 
            // cmbResultType
            // 
            this.cmbResultType.FormattingEnabled = true;
            this.cmbResultType.Location = new System.Drawing.Point(212, 116);
            this.cmbResultType.Name = "cmbResultType";
            this.cmbResultType.Size = new System.Drawing.Size(61, 21);
            this.cmbResultType.TabIndex = 9;
            this.cmbResultType.SelectedIndexChanged += new System.EventHandler(this.cmbResultType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(212, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Единицы измерения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Результат";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 22);
            this.button1.TabIndex = 12;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Введите число";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Введите число";
            this.label7.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 173);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbResultType);
            this.Controls.Add(this.cmbSecondType);
            this.Controls.Add(this.cmbFirstType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmbOperation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSecond);
            this.Controls.Add(this.txtFirst);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOperation;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFirstType;
        private System.Windows.Forms.ComboBox cmbSecondType;
        private System.Windows.Forms.ComboBox cmbResultType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

