namespace PFT2
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.materialRaisedButton10 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(24, 79);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(740, 464);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // materialRaisedButton10
            // 
            this.materialRaisedButton10.Depth = 0;
            this.materialRaisedButton10.Location = new System.Drawing.Point(287, 551);
            this.materialRaisedButton10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton10.Name = "materialRaisedButton10";
            this.materialRaisedButton10.Primary = true;
            this.materialRaisedButton10.Size = new System.Drawing.Size(180, 38);
            this.materialRaisedButton10.TabIndex = 32;
            this.materialRaisedButton10.Text = "OK";
            this.materialRaisedButton10.UseVisualStyleBackColor = true;
            this.materialRaisedButton10.Click += new System.EventHandler(this.materialRaisedButton10_Click);
            // 
            // License
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(788, 599);
            this.Controls.Add(this.materialRaisedButton10);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "License";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton10;
    }
}