namespace MouseSwitch
{
    partial class msMain
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
            this.lightButton = new MetroFramework.Controls.MetroButton();
            this.darkButton = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // lightButton
            // 
            this.lightButton.Location = new System.Drawing.Point(23, 94);
            this.lightButton.Name = "lightButton";
            this.lightButton.Size = new System.Drawing.Size(110, 43);
            this.lightButton.TabIndex = 0;
            this.lightButton.Text = "Light";
            this.lightButton.UseSelectable = true;
            // 
            // darkButton
            // 
            this.darkButton.Location = new System.Drawing.Point(23, 143);
            this.darkButton.Name = "darkButton";
            this.darkButton.Size = new System.Drawing.Size(110, 50);
            this.darkButton.TabIndex = 1;
            this.darkButton.Text = "Dark";
            this.darkButton.UseSelectable = true;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // msMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.darkButton);
            this.Controls.Add(this.lightButton);
            this.Name = "msMain";
            this.Text = "Mouse Switch";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton lightButton;
        private MetroFramework.Controls.MetroButton darkButton;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
    }
}

