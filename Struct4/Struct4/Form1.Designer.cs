namespace Struct3
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
            this.components = new System.ComponentModel.Container();
            this.generate = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.ComboBox();
            this.run = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.graph = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.algorithm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.generate.Location = new System.Drawing.Point(12, 297);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(300, 40);
            this.generate.TabIndex = 0;
            this.generate.Text = "Сгенерировать данные";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // data
            // 
            this.data.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.data.FormattingEnabled = true;
            this.data.Items.AddRange(new object[] {
            "Случайные числа",
            "Кусочно отсортированные",
            "Несколько замен чисел",
            "Отсортированные",
            "В обратном порядке",
            "Несколько перестановок чисел",
            "Повторение 10%",
            "Повторение 25%",
            "Повторение 50%",
            "Повторение 75%",
            "Повторение 90%"});
            this.data.Location = new System.Drawing.Point(12, 62);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(300, 30);
            this.data.TabIndex = 1;
            this.data.SelectedIndexChanged += new System.EventHandler(this.data_SelectedIndexChanged);
            // 
            // run
            // 
            this.run.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.run.Location = new System.Drawing.Point(12, 367);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(300, 40);
            this.run.TabIndex = 4;
            this.run.Text = "Запустить тесты";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.save.Location = new System.Drawing.Point(12, 438);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(300, 40);
            this.save.TabIndex = 5;
            this.save.Text = "Сохранить результаты";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Группа тестовых данных";
            // 
            // graph
            // 
            this.graph.Location = new System.Drawing.Point(349, 37);
            this.graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(877, 594);
            this.graph.TabIndex = 8;
            this.graph.UseExtendedPrintDialog = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Группа алгоритмов";
            // 
            // algorithm
            // 
            this.algorithm.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.algorithm.FormattingEnabled = true;
            this.algorithm.Items.AddRange(new object[] {
            "Первая группа",
            "Вторая группа",
            "Третья группа"});
            this.algorithm.Location = new System.Drawing.Point(12, 148);
            this.algorithm.Name = "algorithm";
            this.algorithm.Size = new System.Drawing.Size(300, 30);
            this.algorithm.TabIndex = 2;
            this.algorithm.SelectedIndexChanged += new System.EventHandler(this.algorithm_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип данных";
            // 
            // type
            // 
            this.type.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Натуральные числа",
            "Рациональные числа",
            "Символы",
            "Слова",
            "Дата и время"});
            this.type.Location = new System.Drawing.Point(12, 236);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(300, 30);
            this.type.TabIndex = 11;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.run);
            this.Controls.Add(this.algorithm);
            this.Controls.Add(this.data);
            this.Controls.Add(this.generate);
            this.Name = "Form1";
            this.Text = "Тестирование алгоритмов сортировки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.ComboBox data;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox algorithm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox type;
    }
}

