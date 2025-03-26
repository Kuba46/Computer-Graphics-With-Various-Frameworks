namespace MainWindow
{
    partial class MainWindow
    {
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button openCubeButton;
        private System.Windows.Forms.Button openPyramidButton;
        private System.Windows.Forms.Button openIcosahedronButton;
        private System.Windows.Forms.Button openConeButton;
        private System.Windows.Forms.Button openCylinderButton;

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
            this.closeButton = new System.Windows.Forms.Button();
            this.openCubeButton = new System.Windows.Forms.Button();
            this.openPyramidButton = new System.Windows.Forms.Button();
            this.openIcosahedronButton = new System.Windows.Forms.Button();
            this.openConeButton = new System.Windows.Forms.Button();
            this.openCylinderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.openCubeButton.Location = new System.Drawing.Point(100, 100);
            this.openCubeButton.Name = "openCubeButton";
            this.openCubeButton.Size = new System.Drawing.Size(100, 50);
            this.openCubeButton.TabIndex = 1;
            this.openCubeButton.Text = "Open Cube";
            this.openCubeButton.UseVisualStyleBackColor = true;
            this.openCubeButton.Click += new System.EventHandler(this.openCube_Click);

            this.openPyramidButton.Location = new System.Drawing.Point(100, 200);
            this.openPyramidButton.Name = "openPyramidButton";
            this.openPyramidButton.Size = new System.Drawing.Size(100, 50);
            this.openPyramidButton.TabIndex = 2;
            this.openPyramidButton.Text = "Open Pyramid";
            this.openPyramidButton.UseVisualStyleBackColor = true;
            this.openPyramidButton.Click += new System.EventHandler(this.openPyramid_Click);

            this.openIcosahedronButton.Location = new System.Drawing.Point(100, 300);
            this.openIcosahedronButton.Name = "openIcosahedronButton";
            this.openIcosahedronButton.Size = new System.Drawing.Size(100, 50);
            this.openIcosahedronButton.TabIndex = 3;
            this.openIcosahedronButton.Text = "Open Icosahedron";
            this.openIcosahedronButton.UseVisualStyleBackColor = true;
            this.openIcosahedronButton.Click += new System.EventHandler(this.openIcosahedron_Click);

            this.openConeButton.Location = new System.Drawing.Point(100, 400);
            this.openConeButton.Name = "openConeButton";
            this.openConeButton.Size = new System.Drawing.Size(100, 50);
            this.openConeButton.TabIndex = 4;
            this.openConeButton.Text = "Open Cone";
            this.openConeButton.UseVisualStyleBackColor = true;
            this.openConeButton.Click += new System.EventHandler(this.openCone_Click);

            this.openCylinderButton.Location = new System.Drawing.Point(100, 500);
            this.openCylinderButton.Name = "openCylinderButton";
            this.openCylinderButton.Size = new System.Drawing.Size(100, 50);
            this.openCylinderButton.TabIndex = 5;
            this.openCylinderButton.Text = "Open Cylinder";
            this.openCylinderButton.UseVisualStyleBackColor = true;
            this.openCylinderButton.Click += new System.EventHandler(this.openCylinder_click);

            this.closeButton.Location = new System.Drawing.Point(100, 600);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 50);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openCubeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openPyramidButton);
            this.Controls.Add(this.openIcosahedronButton);
            this.Controls.Add(this.openConeButton);
            this.Controls.Add(this.openCylinderButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
        }

        #endregion

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void openCube_Click(object sender, EventArgs e)
        {
            RotatingCube rotatingCube = new RotatingCube();
            rotatingCube.Show();
        }

        private void openPyramid_Click(object sender, EventArgs e)
        {
            RotatingPyramid rotatingPyramid = new RotatingPyramid();
            rotatingPyramid.Show();
        }

        private void openIcosahedron_Click(object sender, EventArgs e)
        {
            RotatingIcosahedron rotatingIcosahedron = new RotatingIcosahedron();
            rotatingIcosahedron.Show();
        }

        private void openCone_Click(object sender, EventArgs e)
        {
            RotatingCone rotatingCone = new RotatingCone();
            rotatingCone.Show();
        }

        private void openCylinder_click(object sender, EventArgs e)
        {
            RotatingCylinder rotatingCylinder = new RotatingCylinder();
            rotatingCylinder.Show();
        }
    }
}
