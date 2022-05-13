namespace ImageQuantization
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGaussSmooth = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.nudMaskSize = new System.Windows.Forms.NumericUpDown();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGaussSigma = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.quantize_button = new System.Windows.Forms.Button();
            this.KClustBox = new System.Windows.Forms.TextBox();
            this.DistColBox = new System.Windows.Forms.TextBox();
            this.DistCol = new System.Windows.Forms.Label();
            this.KClust = new System.Windows.Forms.Label();
            this.MSTSum = new System.Windows.Forms.Label();
            this.MSTSumBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.operationsSWBox = new System.Windows.Forms.TextBox();
            this.DistColTLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 360);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(191, 526);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(109, 76);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 484);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1004, 484);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Smoothed Image";
            // 
            // btnGaussSmooth
            // 
            this.btnGaussSmooth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaussSmooth.Location = new System.Drawing.Point(867, 527);
            this.btnGaussSmooth.Margin = new System.Windows.Forms.Padding(4);
            this.btnGaussSmooth.Name = "btnGaussSmooth";
            this.btnGaussSmooth.Size = new System.Drawing.Size(109, 76);
            this.btnGaussSmooth.TabIndex = 5;
            this.btnGaussSmooth.Text = "Gauss Smooth";
            this.btnGaussSmooth.UseVisualStyleBackColor = true;
            this.btnGaussSmooth.Click += new System.EventHandler(this.btnGaussSmooth_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1010, 542);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mask Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(984, 581);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gauss Sigma";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(86, 574);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(75, 27);
            this.txtHeight.TabIndex = 8;
            // 
            // nudMaskSize
            // 
            this.nudMaskSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaskSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaskSize.Location = new System.Drawing.Point(1112, 542);
            this.nudMaskSize.Margin = new System.Windows.Forms.Padding(4);
            this.nudMaskSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudMaskSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaskSize.Name = "nudMaskSize";
            this.nudMaskSize.Size = new System.Drawing.Size(76, 27);
            this.nudMaskSize.TabIndex = 10;
            this.nudMaskSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(86, 527);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(75, 27);
            this.txtWidth.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 530);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 577);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // txtGaussSigma
            // 
            this.txtGaussSigma.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGaussSigma.Location = new System.Drawing.Point(1113, 577);
            this.txtGaussSigma.Margin = new System.Windows.Forms.Padding(4);
            this.txtGaussSigma.Name = "txtGaussSigma";
            this.txtGaussSigma.Size = new System.Drawing.Size(75, 27);
            this.txtGaussSigma.TabIndex = 14;
            this.txtGaussSigma.Text = "1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 456);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(628, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 456);
            this.panel2.TabIndex = 16;
            // 
            // quantize_button
            // 
            this.quantize_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.quantize_button.Location = new System.Drawing.Point(628, 524);
            this.quantize_button.Name = "quantize_button";
            this.quantize_button.Size = new System.Drawing.Size(124, 77);
            this.quantize_button.TabIndex = 17;
            this.quantize_button.Text = "Quantize";
            this.quantize_button.UseVisualStyleBackColor = true;
            this.quantize_button.Click += new System.EventHandler(this.btnQuantize_Click);
            // 
            // KClustBox
            // 
            this.KClustBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.KClustBox.Location = new System.Drawing.Point(523, 591);
            this.KClustBox.Name = "KClustBox";
            this.KClustBox.Size = new System.Drawing.Size(79, 27);
            this.KClustBox.TabIndex = 18;
            this.KClustBox.Text = "1";
            // 
            // DistColBox
            // 
            this.DistColBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.DistColBox.Location = new System.Drawing.Point(522, 555);
            this.DistColBox.Name = "DistColBox";
            this.DistColBox.ReadOnly = true;
            this.DistColBox.Size = new System.Drawing.Size(80, 27);
            this.DistColBox.TabIndex = 0;
            // 
            // DistCol
            // 
            this.DistCol.AutoSize = true;
            this.DistCol.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.DistCol.Location = new System.Drawing.Point(370, 558);
            this.DistCol.Name = "DistCol";
            this.DistCol.Size = new System.Drawing.Size(146, 21);
            this.DistCol.TabIndex = 19;
            this.DistCol.Text = "Distinct Colours";
            // 
            // KClust
            // 
            this.KClust.AutoSize = true;
            this.KClust.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.KClust.Location = new System.Drawing.Point(483, 594);
            this.KClust.Name = "KClust";
            this.KClust.Size = new System.Drawing.Size(22, 21);
            this.KClust.TabIndex = 20;
            this.KClust.Text = "K";
            // 
            // MSTSum
            // 
            this.MSTSum.AutoSize = true;
            this.MSTSum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.MSTSum.Location = new System.Drawing.Point(427, 520);
            this.MSTSum.Name = "MSTSum";
            this.MSTSum.Size = new System.Drawing.Size(89, 21);
            this.MSTSum.TabIndex = 22;
            this.MSTSum.Text = "MST Sum";
            // 
            // MSTSumBox
            // 
            this.MSTSumBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.MSTSumBox.Location = new System.Drawing.Point(523, 517);
            this.MSTSumBox.Name = "MSTSumBox";
            this.MSTSumBox.ReadOnly = true;
            this.MSTSumBox.Size = new System.Drawing.Size(80, 27);
            this.MSTSumBox.TabIndex = 21;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(522, 484);
            this.timeBox.Name = "timeBox";
            this.timeBox.ReadOnly = true;
            this.timeBox.Size = new System.Drawing.Size(80, 22);
            this.timeBox.TabIndex = 23;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.timeLabel.Location = new System.Drawing.Point(464, 486);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(51, 21);
            this.timeLabel.TabIndex = 24;
            this.timeLabel.Text = "Time";
            // 
            // DistColTBox
            // 
            this.operationsSWBox.Location = new System.Drawing.Point(752, 484);
            this.operationsSWBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.operationsSWBox.Name = "DistColTBox";
            this.operationsSWBox.ReadOnly = true;
            this.operationsSWBox.Size = new System.Drawing.Size(80, 22);
            this.operationsSWBox.TabIndex = 25;
            // 
            // DistColTLabel
            // 
            this.DistColTLabel.AutoSize = true;
            this.DistColTLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.DistColTLabel.Location = new System.Drawing.Point(624, 485);
            this.DistColTLabel.Name = "DistColTLabel";
            this.DistColTLabel.Size = new System.Drawing.Size(122, 21);
            this.DistColTLabel.TabIndex = 26;
            this.DistColTLabel.Text = "Dist Col Time";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 626);
            this.Controls.Add(this.DistColTLabel);
            this.Controls.Add(this.operationsSWBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.MSTSum);
            this.Controls.Add(this.MSTSumBox);
            this.Controls.Add(this.KClust);
            this.Controls.Add(this.DistCol);
            this.Controls.Add(this.DistColBox);
            this.Controls.Add(this.KClustBox);
            this.Controls.Add(this.quantize_button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtGaussSigma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.nudMaskSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGaussSmooth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Image Quantization...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGaussSmooth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.NumericUpDown nudMaskSize;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGaussSigma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button quantize_button;
        private System.Windows.Forms.TextBox KClustBox;
        private System.Windows.Forms.TextBox DistColBox;
        private System.Windows.Forms.Label DistCol;
        private System.Windows.Forms.Label KClust;
        private System.Windows.Forms.Label MSTSum;
        private System.Windows.Forms.TextBox MSTSumBox;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox operationsSWBox;
        private System.Windows.Forms.Label DistColTLabel;
    }
}

