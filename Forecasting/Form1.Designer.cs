namespace Forecasting {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.swordDemand = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sesAlpha = new System.Windows.Forms.Label();
            this.sesError = new System.Windows.Forms.Label();
            this.desAlpha = new System.Windows.Forms.Label();
            this.desBeta = new System.Windows.Forms.Label();
            this.desError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.swordDemand)).BeginInit();
            this.SuspendLayout();
            // 
            // swordDemand
            // 
            chartArea1.Name = "ChartArea1";
            this.swordDemand.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.swordDemand.Legends.Add(legend1);
            this.swordDemand.Location = new System.Drawing.Point(12, 12);
            this.swordDemand.Name = "swordDemand";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.swordDemand.Series.Add(series1);
            this.swordDemand.Size = new System.Drawing.Size(1233, 444);
            this.swordDemand.TabIndex = 0;
            this.swordDemand.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "SES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "DES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Alpha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Alpha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Beta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 529);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Error:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 529);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Error:";
            // 
            // sesAlpha
            // 
            this.sesAlpha.AutoSize = true;
            this.sesAlpha.Location = new System.Drawing.Point(56, 483);
            this.sesAlpha.Name = "sesAlpha";
            this.sesAlpha.Size = new System.Drawing.Size(35, 13);
            this.sesAlpha.TabIndex = 9;
            this.sesAlpha.Text = "label9";
            // 
            // sesError
            // 
            this.sesError.AutoSize = true;
            this.sesError.Location = new System.Drawing.Point(56, 529);
            this.sesError.Name = "sesError";
            this.sesError.Size = new System.Drawing.Size(35, 13);
            this.sesError.TabIndex = 10;
            this.sesError.Text = "label9";
            // 
            // desAlpha
            // 
            this.desAlpha.AutoSize = true;
            this.desAlpha.Location = new System.Drawing.Point(361, 483);
            this.desAlpha.Name = "desAlpha";
            this.desAlpha.Size = new System.Drawing.Size(35, 13);
            this.desAlpha.TabIndex = 11;
            this.desAlpha.Text = "label9";
            // 
            // desBeta
            // 
            this.desBeta.AutoSize = true;
            this.desBeta.Location = new System.Drawing.Point(361, 506);
            this.desBeta.Name = "desBeta";
            this.desBeta.Size = new System.Drawing.Size(35, 13);
            this.desBeta.TabIndex = 12;
            this.desBeta.Text = "label9";
            // 
            // desError
            // 
            this.desError.AutoSize = true;
            this.desError.Location = new System.Drawing.Point(361, 529);
            this.desError.Name = "desError";
            this.desError.Size = new System.Drawing.Size(35, 13);
            this.desError.TabIndex = 13;
            this.desError.Text = "label9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 608);
            this.Controls.Add(this.desError);
            this.Controls.Add(this.desBeta);
            this.Controls.Add(this.desAlpha);
            this.Controls.Add(this.sesError);
            this.Controls.Add(this.sesAlpha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.swordDemand);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.swordDemand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart swordDemand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label sesAlpha;
        private System.Windows.Forms.Label sesError;
        private System.Windows.Forms.Label desAlpha;
        private System.Windows.Forms.Label desBeta;
        private System.Windows.Forms.Label desError;
    }
}

