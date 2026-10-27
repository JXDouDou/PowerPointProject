
namespace PowerPointProject
{
    partial class View
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._caption = new System.Windows.Forms.ToolStripMenuItem();
            this._about = new System.Windows.Forms.ToolStripMenuItem();
            this._recordShapes = new System.Windows.Forms.DataGridView();
            this._deleteTheRow = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._coordinateInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._slide1 = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._lineButton = new PowerPointProject.ToolStripBindingButton();
            this._rectangleButton = new PowerPointProject.ToolStripBindingButton();
            this._circleButton = new PowerPointProject.ToolStripBindingButton();
            this._mouseButton = new PowerPointProject.ToolStripBindingButton();
            this._undo = new System.Windows.Forms.ToolStripButton();
            this._redo = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new PowerPointProject.DoubleBufferedPanel();
            this._menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._recordShapes)).BeginInit();
            this._groupBox1.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            this._groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip1
            // 
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._caption});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menuStrip1.Size = new System.Drawing.Size(1363, 27);
            this._menuStrip1.TabIndex = 0;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _caption
            // 
            this._caption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._about});
            this._caption.Name = "_caption";
            this._caption.Size = new System.Drawing.Size(53, 23);
            this._caption.Text = "說明";
            // 
            // _about
            // 
            this._about.Name = "_about";
            this._about.Size = new System.Drawing.Size(122, 26);
            this._about.Text = "關於";
            // 
            // _recordShapes
            // 
            this._recordShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._recordShapes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._recordShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._recordShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteTheRow,
            this._shape,
            this._coordinateInfo});
            this._recordShapes.EnableHeadersVisualStyles = false;
            this._recordShapes.Location = new System.Drawing.Point(0, 66);
            this._recordShapes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._recordShapes.Name = "_recordShapes";
            this._recordShapes.ReadOnly = true;
            this._recordShapes.RowHeadersVisible = false;
            this._recordShapes.RowHeadersWidth = 51;
            this._recordShapes.RowTemplate.Height = 27;
            this._recordShapes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._recordShapes.Size = new System.Drawing.Size(358, 508);
            this._recordShapes.TabIndex = 1;
            this._recordShapes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowDataGridView1CellContent);
            // 
            // _deleteTheRow
            // 
            this._deleteTheRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._deleteTheRow.DataPropertyName = "_column1";
            this._deleteTheRow.FillWeight = 66.14996F;
            this._deleteTheRow.Frozen = true;
            this._deleteTheRow.HeaderText = "刪除";
            this._deleteTheRow.MinimumWidth = 6;
            this._deleteTheRow.Name = "_deleteTheRow";
            this._deleteTheRow.ReadOnly = true;
            this._deleteTheRow.Width = 40;
            // 
            // _shape
            // 
            this._shape.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._shape.DataPropertyName = "_column2";
            this._shape.FillWeight = 112.2995F;
            this._shape.HeaderText = "形狀";
            this._shape.MinimumWidth = 6;
            this._shape.Name = "_shape";
            this._shape.ReadOnly = true;
            this._shape.Width = 45;
            // 
            // _coordinateInfo
            // 
            this._coordinateInfo.DataPropertyName = "_column3";
            this._coordinateInfo.FillWeight = 121.5506F;
            this._coordinateInfo.HeaderText = "資訊";
            this._coordinateInfo.MinimumWidth = 6;
            this._coordinateInfo.Name = "_coordinateInfo";
            this._coordinateInfo.ReadOnly = true;
            // 
            // _comboBox1
            // 
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓形"});
            this._comboBox1.Location = new System.Drawing.Point(133, 29);
            this._comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(113, 23);
            this._comboBox1.TabIndex = 2;
            this._comboBox1.SelectedIndexChanged += new System.EventHandler(this.ShapeCatalog);
            // 
            // _slide1
            // 
            this._slide1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._slide1.Location = new System.Drawing.Point(0, 0);
            this._slide1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(201, 120);
            this._slide1.TabIndex = 3;
            this._slide1.UseVisualStyleBackColor = false;
            this._slide1.Click += new System.EventHandler(this.Button1Click);
            this._slide1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintSlide);
            // 
            // _button3
            // 
            this._button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._button3.Location = new System.Drawing.Point(29, 18);
            this._button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(83, 42);
            this._button3.TabIndex = 5;
            this._button3.Text = "新增";
            this._button3.UseVisualStyleBackColor = false;
            this._button3.Click += new System.EventHandler(this.CreateNewShape);
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._button3);
            this._groupBox1.Controls.Add(this._comboBox1);
            this._groupBox1.Controls.Add(this._recordShapes);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._groupBox1.Size = new System.Drawing.Size(358, 563);
            this._groupBox1.TabIndex = 6;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "資料顯示";
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._mouseButton,
            this._undo,
            this._redo});
            this._toolStrip1.Location = new System.Drawing.Point(0, 27);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1363, 32);
            this._toolStrip1.TabIndex = 8;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._lineButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F);
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(29, 29);
            this._lineButton.Text = "╱";
            this._lineButton.ToolTipText = "toolStripButton1\r\n\r\n";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._rectangleButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(29, 29);
            this._rectangleButton.Text = "☐";
            this._rectangleButton.ToolTipText = "RECTANGLE";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._circleButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(31, 29);
            this._circleButton.Text = "○";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _mouseButton
            // 
            this._mouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._mouseButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this._mouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mouseButton.Name = "_mouseButton";
            this._mouseButton.Size = new System.Drawing.Size(31, 29);
            this._mouseButton.Text = "🖱️";
            this._mouseButton.Click += new System.EventHandler(this.ClickMouseButton);
            // 
            // _undo
            // 
            this._undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undo.Image = global::WindowsProject.Properties.Resources.Undo;
            this._undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(29, 29);
            this._undo.Text = "_undo";
            this._undo.ToolTipText = "Undo";
            this._undo.Click += new System.EventHandler(this.IsUndoClick);
            // 
            // _redo
            // 
            this._redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redo.Image = global::WindowsProject.Properties.Resources.Redo;
            this._redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(29, 29);
            this._redo.Text = "_redo";
            this._redo.ToolTipText = "Redo";
            this._redo.Click += new System.EventHandler(this.IsRedoClick);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.Location = new System.Drawing.Point(0, 59);
            this._splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._groupBox2);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1363, 563);
            this._splitContainer1.SplitterDistance = 206;
            this._splitContainer1.TabIndex = 10;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MovedSpliter1);
            // 
            // _groupBox2
            // 
            this._groupBox2.Controls.Add(this._slide1);
            this._groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox2.Location = new System.Drawing.Point(0, 0);
            this._groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._groupBox2.Size = new System.Drawing.Size(206, 563);
            this._groupBox2.TabIndex = 12;
            this._groupBox2.TabStop = false;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer2.Size = new System.Drawing.Size(1153, 563);
            this._splitContainer2.SplitterDistance = 791;
            this._splitContainer2.TabIndex = 11;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MovedSpliter2);
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.BackColor = System.Drawing.SystemColors.Window;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(788, 443);
            this._canvas.TabIndex = 9;
            this._canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            this._canvas.MouseLeave += new System.EventHandler(this.HandleMouseLeavePanel);
            this._canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleMouseInPanel);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 622);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "View";
            this.Text = "View";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressKey);
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._recordShapes)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._groupBox2.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _caption;
        private System.Windows.Forms.DataGridView _recordShapes;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.Button _slide1;
        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ToolStripMenuItem _about;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteTheRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _coordinateInfo;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private ToolStripBindingButton _lineButton;
        private ToolStripBindingButton _rectangleButton;
        private ToolStripBindingButton _circleButton;
        private DoubleBufferedPanel _canvas;
        private ToolStripBindingButton _mouseButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private System.Windows.Forms.ToolStripButton _undo;
        private System.Windows.Forms.ToolStripButton _redo;
    }
}

