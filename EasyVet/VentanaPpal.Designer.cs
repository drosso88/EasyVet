namespace EasyVet
{
    partial class VentanaPpal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPpal));
            this.Menu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.tabPage1);
            this.Menu.Controls.Add(this.tabPage2);
            this.Menu.ImageList = this.imageList1;
            this.Menu.Location = new System.Drawing.Point(-5, -2);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(961, 693);
            this.Menu.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 67);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mascotas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.ImageKey = "diagnostico.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 67);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(953, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servicios diagnósticos";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mascotas.jpg");
            this.imageList1.Images.SetKeyName(1, "diagnostico.png");
            this.imageList1.Images.SetKeyName(2, "free-30-instagram-stories-icons53_122600.ico");
            this.imageList1.Images.SetKeyName(3, "mascotas.jpg");
            this.imageList1.Images.SetKeyName(4, "pastillas.png");
            this.imageList1.Images.SetKeyName(5, "Pokedex_tool_icon-icons.com_67529.ico");
            this.imageList1.Images.SetKeyName(6, "pokedex-icon-3.jpg");
            this.imageList1.Images.SetKeyName(7, "veterinaria.png");
            this.imageList1.Images.SetKeyName(8, "veterinarianhospital_89244.ico");
            this.imageList1.Images.SetKeyName(9, "veterinario.png");
            // 
            // VentanaPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 686);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaPpal";
            this.Text = "VentanaPpal";
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
    }
}