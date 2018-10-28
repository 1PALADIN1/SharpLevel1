namespace SharpLesson7GuessNumber {
    partial class MainFrom {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDialog = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonGuess = new System.Windows.Forms.Button();
            this.tbGuess = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SharpLesson7GuessNumber.Properties.Resources.kisspng_dialog_box_clip_art_dialogue_5abc9dce6d75e2_5556029515223106064484;
            this.pictureBox2.Location = new System.Drawing.Point(196, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(276, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpLesson7GuessNumber.Properties.Resources.x_b6ffe339;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 376);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelDialog
            // 
            this.labelDialog.AutoSize = true;
            this.labelDialog.Location = new System.Drawing.Point(231, 47);
            this.labelDialog.Name = "labelDialog";
            this.labelDialog.Size = new System.Drawing.Size(47, 13);
            this.labelDialog.TabIndex = 2;
            this.labelDialog.Text = "Привет!";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.White;
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(298, 215);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonGuess
            // 
            this.buttonGuess.BackColor = System.Drawing.Color.White;
            this.buttonGuess.Enabled = false;
            this.buttonGuess.Location = new System.Drawing.Point(298, 227);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(75, 23);
            this.buttonGuess.TabIndex = 4;
            this.buttonGuess.Text = "Угадать";
            this.buttonGuess.UseVisualStyleBackColor = false;
            this.buttonGuess.Visible = false;
            this.buttonGuess.Click += new System.EventHandler(this.ButtonGuess_Click);
            // 
            // tbGuess
            // 
            this.tbGuess.Enabled = false;
            this.tbGuess.Location = new System.Drawing.Point(298, 201);
            this.tbGuess.Name = "tbGuess";
            this.tbGuess.Size = new System.Drawing.Size(75, 20);
            this.tbGuess.TabIndex = 5;
            this.tbGuess.Visible = false;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tbGuess);
            this.Controls.Add(this.buttonGuess);
            this.Controls.Add(this.labelDialog);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelDialog;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonGuess;
        private System.Windows.Forms.TextBox tbGuess;
    }
}

