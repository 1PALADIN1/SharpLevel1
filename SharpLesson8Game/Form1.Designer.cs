namespace SharpLesson8Game {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.btFalse = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbQuestion
            // 
            this.tbQuestion.Enabled = false;
            this.tbQuestion.Location = new System.Drawing.Point(13, 13);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(559, 171);
            this.tbQuestion.TabIndex = 0;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(143, 236);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "Верю";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.BtTrue_Click);
            // 
            // btFalse
            // 
            this.btFalse.Location = new System.Drawing.Point(360, 236);
            this.btFalse.Name = "btFalse";
            this.btFalse.Size = new System.Drawing.Size(75, 23);
            this.btFalse.TabIndex = 2;
            this.btFalse.Text = "Не верю";
            this.btFalse.UseVisualStyleBackColor = true;
            this.btFalse.Click += new System.EventHandler(this.btFalse_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(253, 236);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "Начать";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.BtStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btFalse);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbQuestion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btFalse;
        private System.Windows.Forms.Button btStart;
    }
}

