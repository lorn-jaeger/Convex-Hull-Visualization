namespace CSCI332_Final
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
            JarvisMarch_Button = new Button();
            GrahamScan_Button = new Button();
            QuickHull_Button = new Button();
            label1 = new Label();
            TickSpeed = new TextBox();
            NumPoints = new TextBox();
            Submit_Button = new Button();
            SuspendLayout();
            // 
            // JarvisMarch_Button
            // 
            JarvisMarch_Button.BackColor = SystemColors.ButtonHighlight;
            JarvisMarch_Button.Location = new Point(0, 0);
            JarvisMarch_Button.Name = "JarvisMarch_Button";
            JarvisMarch_Button.Size = new Size(127, 34);
            JarvisMarch_Button.TabIndex = 0;
            JarvisMarch_Button.Text = "Jarvis March";
            JarvisMarch_Button.UseVisualStyleBackColor = false;
            JarvisMarch_Button.Click += JarvisMarch_Button_Click;
            // 
            // GrahamScan_Button
            // 
            GrahamScan_Button.BackColor = SystemColors.ButtonHighlight;
            GrahamScan_Button.Location = new Point(0, 40);
            GrahamScan_Button.Name = "GrahamScan_Button";
            GrahamScan_Button.Size = new Size(127, 34);
            GrahamScan_Button.TabIndex = 1;
            GrahamScan_Button.Text = "Graham Scan";
            GrahamScan_Button.UseVisualStyleBackColor = false;
            GrahamScan_Button.Click += GrahamScan_Button_Click;
            // 
            // QuickHull_Button
            // 
            QuickHull_Button.BackColor = SystemColors.ButtonHighlight;
            QuickHull_Button.Location = new Point(0, 80);
            QuickHull_Button.Name = "QuickHull_Button";
            QuickHull_Button.Size = new Size(127, 34);
            QuickHull_Button.TabIndex = 2;
            QuickHull_Button.Text = "QuickHull";
            QuickHull_Button.UseVisualStyleBackColor = false;
            QuickHull_Button.Click += QuickHull_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(190, 9);
            label1.Name = "label1";
            label1.Size = new Size(532, 27);
            label1.TabIndex = 3;
            label1.Text = "Select an algorithm, tick speed, and # of points. Then click submit";
            label1.Click += label1_Click;
            // 
            // TickSpeed
            // 
            TickSpeed.Location = new Point(0, 120);
            TickSpeed.Name = "TickSpeed";
            TickSpeed.PlaceholderText = "Tick Speed";
            TickSpeed.Size = new Size(127, 31);
            TickSpeed.TabIndex = 6;
            TickSpeed.TextAlign = HorizontalAlignment.Center;
            TickSpeed.TextChanged += TickSpeed_TextChanged;
            // 
            // NumPoints
            // 
            NumPoints.Location = new Point(0, 157);
            NumPoints.Name = "NumPoints";
            NumPoints.PlaceholderText = "# points";
            NumPoints.Size = new Size(127, 31);
            NumPoints.TabIndex = 7;
            NumPoints.TextAlign = HorizontalAlignment.Center;
            NumPoints.TextChanged += NumPoints_TextChanged;
            // 
            // Submit_Button
            // 
            Submit_Button.BackColor = Color.LimeGreen;
            Submit_Button.Location = new Point(0, 206);
            Submit_Button.Name = "Submit_Button";
            Submit_Button.Size = new Size(112, 110);
            Submit_Button.TabIndex = 8;
            Submit_Button.Text = "Submit!";
            Submit_Button.UseVisualStyleBackColor = false;
            Submit_Button.Click += Submit_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 504);
            Controls.Add(Submit_Button);
            Controls.Add(NumPoints);
            Controls.Add(TickSpeed);
            Controls.Add(label1);
            Controls.Add(QuickHull_Button);
            Controls.Add(GrahamScan_Button);
            Controls.Add(JarvisMarch_Button);
            Name = "Form1";
            Text = "Convex Hull Algorithms";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button JarvisMarch_Button;
        private Button GrahamScan_Button;
        private Button QuickHull_Button;
        private Label label1;
        private TextBox TickSpeed;
        private TextBox NumPoints;
        private Button Submit_Button;
    }
}
