namespace MyExcel
{
    partial class MyExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyExcel));
            this.btnCalc = new System.Windows.Forms.Button();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tlmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFormula = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.AutoSize = true;
            this.btnCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCalc.Location = new System.Drawing.Point(645, 28);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(128, 38);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "Обрахувати";
            this.btnCalc.UseVisualStyleBackColor = false;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvTable.Location = new System.Drawing.Point(-3, 75);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.Size = new System.Drawing.Size(800, 379);
            this.dgvTable.StandardTab = true;
            this.dgvTable.TabIndex = 1;
            this.dgvTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTable_CellBeginEdit);
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            this.dgvTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellEndEdit);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmFile,
            this.tlmEdit,
            this.tsmInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tlmFile
            // 
            this.tlmFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmOpen,
            this.tlmSave});
            this.tlmFile.ForeColor = System.Drawing.Color.Black;
            this.tlmFile.Name = "tlmFile";
            this.tlmFile.Size = new System.Drawing.Size(59, 26);
            this.tlmFile.Text = "Файл";
            // 
            // tlmOpen
            // 
            this.tlmOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmOpen.ForeColor = System.Drawing.Color.Black;
            this.tlmOpen.Image = ((System.Drawing.Image)(resources.GetObject("tlmOpen.Image")));
            this.tlmOpen.Name = "tlmOpen";
            this.tlmOpen.Size = new System.Drawing.Size(155, 26);
            this.tlmOpen.Text = "Відкрити";
            this.tlmOpen.Click += new System.EventHandler(this.tlmOpen_Click);
            // 
            // tlmSave
            // 
            this.tlmSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmSave.ForeColor = System.Drawing.Color.Black;
            this.tlmSave.Image = ((System.Drawing.Image)(resources.GetObject("tlmSave.Image")));
            this.tlmSave.Name = "tlmSave";
            this.tlmSave.Size = new System.Drawing.Size(155, 26);
            this.tlmSave.Text = "Зберегти";
            this.tlmSave.Click += new System.EventHandler(this.tlmSave_Click);
            // 
            // tlmEdit
            // 
            this.tlmEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmAdd,
            this.tlmDelete});
            this.tlmEdit.ForeColor = System.Drawing.Color.Black;
            this.tlmEdit.Name = "tlmEdit";
            this.tlmEdit.Size = new System.Drawing.Size(99, 26);
            this.tlmEdit.Text = "Редагувати";
            // 
            // tlmAdd
            // 
            this.tlmAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmAddRow,
            this.tlmAddColumn});
            this.tlmAdd.ForeColor = System.Drawing.Color.Black;
            this.tlmAdd.Image = ((System.Drawing.Image)(resources.GetObject("tlmAdd.Image")));
            this.tlmAdd.Name = "tlmAdd";
            this.tlmAdd.Size = new System.Drawing.Size(158, 26);
            this.tlmAdd.Text = "Додати";
            // 
            // tlmAddRow
            // 
            this.tlmAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmAddRow.Name = "tlmAddRow";
            this.tlmAddRow.Size = new System.Drawing.Size(158, 26);
            this.tlmAddRow.Text = "Рядок";
            this.tlmAddRow.Click += new System.EventHandler(this.tlmAddRow_Click);
            // 
            // tlmAddColumn
            // 
            this.tlmAddColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmAddColumn.Name = "tlmAddColumn";
            this.tlmAddColumn.Size = new System.Drawing.Size(158, 26);
            this.tlmAddColumn.Text = "Стовпець";
            this.tlmAddColumn.Click += new System.EventHandler(this.tlmAddColumn_Click);
            // 
            // tlmDelete
            // 
            this.tlmDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmDeleteRow,
            this.tlmDeleteColumn});
            this.tlmDelete.ForeColor = System.Drawing.Color.Black;
            this.tlmDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlmDelete.Image")));
            this.tlmDelete.Name = "tlmDelete";
            this.tlmDelete.Size = new System.Drawing.Size(158, 26);
            this.tlmDelete.Text = "Видалити";
            // 
            // tlmDeleteRow
            // 
            this.tlmDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmDeleteRow.Name = "tlmDeleteRow";
            this.tlmDeleteRow.Size = new System.Drawing.Size(158, 26);
            this.tlmDeleteRow.Text = "Рядок";
            this.tlmDeleteRow.Click += new System.EventHandler(this.tlmDeleteRow_Click);
            // 
            // tlmDeleteColumn
            // 
            this.tlmDeleteColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlmDeleteColumn.Name = "tlmDeleteColumn";
            this.tlmDeleteColumn.Size = new System.Drawing.Size(158, 26);
            this.tlmDeleteColumn.Text = "Стовпець";
            this.tlmDeleteColumn.Click += new System.EventHandler(this.tlmDeleteColumn_Click);
            // 
            // tsmInfo
            // 
            this.tsmInfo.Name = "tsmInfo";
            this.tsmInfo.Size = new System.Drawing.Size(77, 26);
            this.tsmInfo.Text = "Довідка";
            this.tsmInfo.Click += new System.EventHandler(this.tsmInfo_Click);
            // 
            // tbFormula
            // 
            this.tbFormula.AccessibleName = "";
            this.tbFormula.AllowDrop = true;
            this.tbFormula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbFormula.Location = new System.Drawing.Point(91, 36);
            this.tbFormula.Name = "tbFormula";
            this.tbFormula.Size = new System.Drawing.Size(548, 22);
            this.tbFormula.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "XML Files(*.xml)|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "XML Files(*.xml)|*.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Формула:";
            // 
            // MyExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFormula);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyExcel";
            this.Text = "MyExcel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyExcel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tlmFile;
        private System.Windows.Forms.ToolStripMenuItem tlmOpen;
        private System.Windows.Forms.ToolStripMenuItem tlmSave;
        private System.Windows.Forms.ToolStripMenuItem tlmEdit;
        private System.Windows.Forms.ToolStripMenuItem tlmAdd;
        private System.Windows.Forms.ToolStripMenuItem tlmAddRow;
        private System.Windows.Forms.ToolStripMenuItem tlmAddColumn;
        private System.Windows.Forms.ToolStripMenuItem tlmDelete;
        private System.Windows.Forms.ToolStripMenuItem tlmDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem tlmDeleteColumn;
        private System.Windows.Forms.ToolStripMenuItem tsmInfo;
        private System.Windows.Forms.TextBox tbFormula;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
    }
}

