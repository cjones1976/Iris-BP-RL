namespace iris_classification
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
            this.Learn = new System.Windows.Forms.Button();
            this.LoadArray = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLearnRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.chkEnhanced = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEpochs = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCorrect = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Learn
            // 
            this.Learn.Location = new System.Drawing.Point(100, 88);
            this.Learn.Name = "Learn";
            this.Learn.Size = new System.Drawing.Size(75, 23);
            this.Learn.TabIndex = 0;
            this.Learn.Text = "GO";
            this.Learn.UseVisualStyleBackColor = true;
            this.Learn.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadArray
            // 
            this.LoadArray.Location = new System.Drawing.Point(100, 44);
            this.LoadArray.Name = "LoadArray";
            this.LoadArray.Size = new System.Drawing.Size(75, 23);
            this.LoadArray.TabIndex = 1;
            this.LoadArray.Text = "load Data";
            this.LoadArray.UseVisualStyleBackColor = true;
            this.LoadArray.Click += new System.EventHandler(this.LoadArray_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(351, 48);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(76, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inputs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hidden";
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(351, 74);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(76, 20);
            this.txtHidden.TabIndex = 5;
            this.txtHidden.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Outputs";
            // 
            // txtOutputs
            // 
            this.txtOutputs.Location = new System.Drawing.Point(351, 100);
            this.txtOutputs.Name = "txtOutputs";
            this.txtOutputs.Size = new System.Drawing.Size(76, 20);
            this.txtOutputs.TabIndex = 7;
            this.txtOutputs.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Learn Rate";
            // 
            // txtLearnRate
            // 
            this.txtLearnRate.Location = new System.Drawing.Point(351, 149);
            this.txtLearnRate.Name = "txtLearnRate";
            this.txtLearnRate.Size = new System.Drawing.Size(76, 20);
            this.txtLearnRate.TabIndex = 9;
            this.txtLearnRate.Text = "0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Inital Repeat";
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(351, 199);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(76, 20);
            this.txtRepeat.TabIndex = 11;
            this.txtRepeat.Text = "50";
            // 
            // chkEnhanced
            // 
            this.chkEnhanced.AutoSize = true;
            this.chkEnhanced.Location = new System.Drawing.Point(288, 175);
            this.chkEnhanced.Name = "chkEnhanced";
            this.chkEnhanced.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnhanced.Size = new System.Drawing.Size(116, 17);
            this.chkEnhanced.TabIndex = 13;
            this.chkEnhanced.Text = "Reluctant Learning";
            this.chkEnhanced.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "epochs";
            // 
            // txtEpochs
            // 
            this.txtEpochs.Location = new System.Drawing.Point(351, 123);
            this.txtEpochs.Name = "txtEpochs";
            this.txtEpochs.Size = new System.Drawing.Size(76, 20);
            this.txtEpochs.TabIndex = 14;
            this.txtEpochs.Text = "1000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCorrect);
            this.groupBox1.Location = new System.Drawing.Point(43, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 66);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Inputs";
            // 
            // txtCorrect
            // 
            this.txtCorrect.Location = new System.Drawing.Point(94, 23);
            this.txtCorrect.Name = "txtCorrect";
            this.txtCorrect.Size = new System.Drawing.Size(76, 20);
            this.txtCorrect.TabIndex = 4;
            this.txtCorrect.Text = "0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEpochs);
            this.Controls.Add(this.chkEnhanced);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLearnRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutputs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHidden);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.LoadArray);
            this.Controls.Add(this.Learn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Learn;
        private System.Windows.Forms.Button LoadArray;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHidden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutputs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLearnRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.CheckBox chkEnhanced;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEpochs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCorrect;
    }
}

