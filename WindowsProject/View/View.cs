using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointProject
{//PressedPointer的e.X,e.Y可以直接在裡面new Point(e.X, e.Y)
    public partial class View : Form
    {
        private const string LINE_PROPERTY = "IsLine";
        private const string RECTANGLE_PROPERTY = "IsRectangle";
        private const string CIRCLE_PROPERTY = "IsCircle";
        private const string POINTER_PROPERTY = "IsMouse";
        private const string CHECKED_PROPERTY = "Checked";
        private const int INDEX = 0;
        private ModelOfDataGridView _model = new ModelOfDataGridView();
        PresentationModel _presentationModel;

        public View(ModelOfDataGridView model)
        {
            InitializeComponent();
            this._model = model;
            _presentationModel = new PresentationModel(_model);
            _lineButton.DataBindings.Add(CHECKED_PROPERTY, _presentationModel, LINE_PROPERTY);
            _rectangleButton.DataBindings.Add(CHECKED_PROPERTY, _presentationModel, RECTANGLE_PROPERTY);
            _circleButton.DataBindings.Add(CHECKED_PROPERTY, _presentationModel, CIRCLE_PROPERTY);
            _mouseButton.DataBindings.Add(CHECKED_PROPERTY, _presentationModel, POINTER_PROPERTY);
            _model._modelChanged += HandleModelChanged;
            _model._modelChanged += DoDataGridView;//更新dataGridView
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _slide1.Paint += PaintSlide;

        }//view裡滑鼠的點擊放開以及移動都是用事件通知presentationModel

        /*public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new PresentationModel.WindowsFormsGraphicsAdaptor(e.Graphics));
        }*/
        /*protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }*/
        //處理滑鼠按下
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)//有文字的丟presentationModel
        {
            _presentationModel.PressedPointer(e.X, e.Y);//用presentationModel的bool去決定Model接收的shapeName就好
        }

        //處理滑鼠放開
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.ReleasedPointer(e.X, e.Y);
        }

        //處理滑鼠移動
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        //處理畫面改變(繪圖模式)
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //重畫
        public void HandleModelChanged()
        {
            _canvas.Invalidate();
        }

        //重畫
        public void ShapeChanged()
        {
            Invalidate(true);
        }

        //被通知後執行按鈕check轉換
        public void StripChecked(bool line, bool rectangle, bool circle)
        {
            _lineButton.Checked = line;
            _rectangleButton.Checked = rectangle;
            _circleButton.Checked = circle;
        }//已被取代

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        //shape可選種類
        private void ShapeCatalog(object sender, EventArgs e)
        {

        }

        //更新dataGridView
        private void DoDataGridView()
        {
            _recordShapes.DataSource = _model.GetModelGridView();
        }

        //shape資訊欄位
        private void ShowDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == INDEX && e.RowIndex >= 0)
            {
                _model.DeleteShape(e.RowIndex);
            }
        }

        // draw on tiny panel
        void PaintSlide(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawSlide(e.Graphics);
        }

        //暫時未知
        private void Button1Click(object sender, EventArgs e)
        {

        }

        //暫時未知
        private void Button2Click(object sender, EventArgs e)
        {

        }

        //建立新shape
        private void CreateNewShape(object sender, EventArgs e)
        {
            _model.CreateShapes(_comboBox1.Text);
            DoDataGridView();
            //_recordShapes.DataSource = _model.GetModelGridView();           
        }

        //點擊panel?
        private void CanvasClick(object sender, EventArgs e)
        {

        }

        //繪圖
        private void CanvasPaint(object sender, PaintEventArgs e)
        {

        }           

        //處理滑鼠在panel中的鼠標
        private void HandleMouseInPanel(object sender, MouseEventArgs e)
        {
            if (_presentationModel.NowType == null)
            {
                Cursor = Cursors.Default;
                return;
            }
            Cursor = Cursors.Cross;
        }

        //處理滑鼠離開的鼠標
        private void HandleMouseLeavePanel(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //整個strip的按鍵呼叫
        private void ShapeStripClick(object sender, EventArgs e)
        {
            /*ToolStripButton shapeButton = sender as ToolStripButton;
            _presentationModel.ShapeMode(shapeButton.Text);*/
        }

        //click line button
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.PressedLineButton();
        }

        //click rectangle button
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.PressedRectangleButton();
        }

        //click circle button
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.PressedCircleButton();
        }

        //click mouse button
        private void ClickMouseButton(object sender, EventArgs e)
        {
            _presentationModel.PressedPointerButton();
        }

        // receive pressed key
        private void PressKey(object sender, KeyEventArgs e)
        {
            _presentationModel.PressDelete(e.KeyCode);
        }
    }
}
