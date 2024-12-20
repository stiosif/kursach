namespace WindowsFormsApp2
{
    partial class InStockMaterials
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InStockMaterials));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kptypoDataSet = new WindowsFormsApp2.kptypoDataSet();
            this.kptypoDataSet1 = new WindowsFormsApp2.kptypoDataSet1();
            this.inStockMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inStockMaterialsTableAdapter = new WindowsFormsApp2.kptypoDataSet1TableAdapters.InStockMaterialsTableAdapter();
            this.selectInStockMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectInStockMaterialsTableAdapter = new WindowsFormsApp2.kptypoDataSet1TableAdapters.SelectInStockMaterialsTableAdapter();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuFormCaptionButton1 = new Bunifu.UI.WinForms.BunifuFormCaptionButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptypoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptypoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inStockMaterialsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectInStockMaterialsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(200)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(200)))), ((int)(((byte)(232)))));
            this.dataGridView1.Location = new System.Drawing.Point(16, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(699, 307);
            this.dataGridView1.TabIndex = 0;
            // 
            // kptypoDataSet
            // 
            this.kptypoDataSet.DataSetName = "kptypoDataSet";
            this.kptypoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kptypoDataSet1
            // 
            this.kptypoDataSet1.DataSetName = "kptypoDataSet1";
            this.kptypoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inStockMaterialsBindingSource
            // 
            this.inStockMaterialsBindingSource.DataMember = "InStockMaterials";
            this.inStockMaterialsBindingSource.DataSource = this.kptypoDataSet1;
            // 
            // inStockMaterialsTableAdapter
            // 
            this.inStockMaterialsTableAdapter.ClearBeforeFill = true;
            // 
            // selectInStockMaterialsBindingSource
            // 
            this.selectInStockMaterialsBindingSource.DataMember = "SelectInStockMaterials";
            this.selectInStockMaterialsBindingSource.DataSource = this.kptypoDataSet1;
            // 
            // selectInStockMaterialsTableAdapter
            // 
            this.selectInStockMaterialsTableAdapter.ClearBeforeFill = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuFormCaptionButton1
            // 
            this.bunifuFormCaptionButton1.AllowAnimations = true;
            this.bunifuFormCaptionButton1.AllowBorderColorChanges = true;
            this.bunifuFormCaptionButton1.AllowDefaults = true;
            this.bunifuFormCaptionButton1.AllowMouseEffects = true;
            this.bunifuFormCaptionButton1.AnimationSpeed = 200;
            this.bunifuFormCaptionButton1.AutoSizeCaptions = true;
            this.bunifuFormCaptionButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormCaptionButton1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.bunifuFormCaptionButton1.BackHoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormCaptionButton1.BackPressedColor = System.Drawing.Color.Silver;
            this.bunifuFormCaptionButton1.BorderColor = System.Drawing.Color.AliceBlue;
            this.bunifuFormCaptionButton1.BorderHoverColor = System.Drawing.Color.DarkGray;
            this.bunifuFormCaptionButton1.BorderPressedColor = System.Drawing.Color.DarkGray;
            this.bunifuFormCaptionButton1.BorderRadius = 1;
            this.bunifuFormCaptionButton1.BorderStyle = Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderStyles.Solid;
            this.bunifuFormCaptionButton1.BorderThickness = 1;
            this.bunifuFormCaptionButton1.CaptionType = Bunifu.UI.WinForms.BunifuFormCaptionButton.CaptionTypes.Close;
            this.bunifuFormCaptionButton1.ColorContrastOnClick = 30;
            this.bunifuFormCaptionButton1.ColorContrastOnHover = 30;
            this.bunifuFormCaptionButton1.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuFormCaptionButton1.CustomizableEdges = borderEdges1;
            this.bunifuFormCaptionButton1.DefaultBorderColor = System.Drawing.Color.AliceBlue;
            this.bunifuFormCaptionButton1.DefaultColor = System.Drawing.Color.AliceBlue;
            this.bunifuFormCaptionButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuFormCaptionButton1.IconColor = System.Drawing.Color.Black;
            this.bunifuFormCaptionButton1.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormCaptionButton1.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormCaptionButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuFormCaptionButton1.Image")));
            this.bunifuFormCaptionButton1.ImageMargin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.bunifuFormCaptionButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.bunifuFormCaptionButton1.Location = new System.Drawing.Point(694, 1);
            this.bunifuFormCaptionButton1.Name = "bunifuFormCaptionButton1";
            this.bunifuFormCaptionButton1.ShowBorders = true;
            this.bunifuFormCaptionButton1.Size = new System.Drawing.Size(36, 20);
            this.bunifuFormCaptionButton1.TabIndex = 27;
            this.bunifuFormCaptionButton1.Click += new System.EventHandler(this.bunifuFormCaptionButton1_Click);
            // 
            // InStockMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(731, 353);
            this.Controls.Add(this.bunifuFormCaptionButton1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InStockMaterials";
            this.Text = "InStockMaterials";
            this.Load += new System.EventHandler(this.InStockMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptypoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptypoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inStockMaterialsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectInStockMaterialsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private kptypoDataSet kptypoDataSet;
        private kptypoDataSet1 kptypoDataSet1;
        private System.Windows.Forms.BindingSource inStockMaterialsBindingSource;
        private kptypoDataSet1TableAdapters.InStockMaterialsTableAdapter inStockMaterialsTableAdapter;
        private System.Windows.Forms.BindingSource selectInStockMaterialsBindingSource;
        private kptypoDataSet1TableAdapters.SelectInStockMaterialsTableAdapter selectInStockMaterialsTableAdapter;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuFormCaptionButton bunifuFormCaptionButton1;
    }
}