namespace DocBienSoXe
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowImg = new System.Windows.Forms.Button();
            this.picImgOrigin = new System.Windows.Forms.PictureBox();
            this.picImgCroped = new System.Windows.Forms.PictureBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnDetection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImgOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImgCroped)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn ảnh:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btnBrowImg
            // 
            this.btnBrowImg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowImg.Location = new System.Drawing.Point(509, 25);
            this.btnBrowImg.Name = "btnBrowImg";
            this.btnBrowImg.Size = new System.Drawing.Size(75, 23);
            this.btnBrowImg.TabIndex = 2;
            this.btnBrowImg.Text = "Brown";
            this.btnBrowImg.UseVisualStyleBackColor = true;
            this.btnBrowImg.Click += new System.EventHandler(this.btnBrowImg_Click);
            // 
            // picImgOrigin
            // 
            this.picImgOrigin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picImgOrigin.Location = new System.Drawing.Point(25, 85);
            this.picImgOrigin.Name = "picImgOrigin";
            this.picImgOrigin.Size = new System.Drawing.Size(224, 241);
            this.picImgOrigin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgOrigin.TabIndex = 3;
            this.picImgOrigin.TabStop = false;
            // 
            // picImgCroped
            // 
            this.picImgCroped.BackColor = System.Drawing.SystemColors.Highlight;
            this.picImgCroped.Location = new System.Drawing.Point(360, 85);
            this.picImgCroped.Name = "picImgCroped";
            this.picImgCroped.Size = new System.Drawing.Size(224, 241);
            this.picImgCroped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgCroped.TabIndex = 3;
            this.picImgCroped.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(170, 379);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(247, 42);
            this.txtResult.TabIndex = 4;
            // 
            // btnDetection
            // 
            this.btnDetection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetection.Location = new System.Drawing.Point(268, 186);
            this.btnDetection.Name = "btnDetection";
            this.btnDetection.Size = new System.Drawing.Size(75, 30);
            this.btnDetection.TabIndex = 5;
            this.btnDetection.Text = "Read  >>";
            this.btnDetection.UseVisualStyleBackColor = true;
            this.btnDetection.Click += new System.EventHandler(this.btnDetection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.btnDetection);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.picImgCroped);
            this.Controls.Add(this.picImgOrigin);
            this.Controls.Add(this.btnBrowImg);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Đọc biển số xe";
            ((System.ComponentModel.ISupportInitialize)(this.picImgOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImgCroped)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBrowImg;
        private System.Windows.Forms.PictureBox picImgOrigin;
        private System.Windows.Forms.PictureBox picImgCroped;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnDetection;
    }
}

