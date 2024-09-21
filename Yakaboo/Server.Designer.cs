namespace Yakaboo
{
    partial class Server
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
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            comboBoxTables = new ComboBox();
            textBoxFind = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.GradientActiveCaption;
            dataGridView1.Location = new Point(0, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(747, 443);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = SystemColors.ActiveCaption;
            buttonAdd.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.Location = new Point(0, 0);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(154, 33);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = SystemColors.ActiveCaption;
            buttonEdit.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEdit.Location = new Point(160, 0);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(154, 33);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = SystemColors.ActiveCaption;
            buttonDelete.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.Location = new Point(320, 0);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(154, 33);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // comboBoxTables
            // 
            comboBoxTables.BackColor = SystemColors.GradientActiveCaption;
            comboBoxTables.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxTables.Items.AddRange(new object[] { "Authors", "Books", "Publishers" });
            comboBoxTables.Location = new Point(643, 3);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(104, 29);
            comboBoxTables.TabIndex = 0;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // textBoxFind
            // 
            textBoxFind.BackColor = SystemColors.GradientActiveCaption;
            textBoxFind.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxFind.Location = new Point(480, 3);
            textBoxFind.Name = "textBoxFind";
            textBoxFind.Size = new Size(157, 28);
            textBoxFind.TabIndex = 4;
            textBoxFind.TextChanged += textBoxFind_TextChanged;
            textBoxFind.Enter += textBoxFind_Enter;
            textBoxFind.Leave += textBoxFind_Leave;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(747, 478);
            Controls.Add(textBoxFind);
            Controls.Add(comboBoxTables);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            Name = "Server";
            Text = "Server";
            SizeChanged += Server_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private ComboBox comboBoxTables;
        private TextBox textBoxFind;
    }
}