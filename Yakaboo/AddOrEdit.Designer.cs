namespace Yakaboo
{
    partial class AddOrEdit
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
            SuspendLayout();
            // 
            // AddOrEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 277);
            Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AddOrEdit";
            Text = "AddOrEdit";
            Load += AddOrEdit_Load;
            SizeChanged += AddOrEdit_SizeChanged;
            ResumeLayout(false);
        }

        #endregion
    }
}