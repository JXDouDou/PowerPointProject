using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsProject.View
{
    public partial class CoordinateForm : Form
    {
        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;
        private TextBox _startCoordinateTextBoxX;
        private TextBox _startCoordinateTextBoxY;
        private TextBox _endCoordinateTextBoxX;
        private TextBox _endCoordinateTextBoxY;
        private Button _okButton;
        private Button _cancelButton;
        bool _isEnabled1;
        bool _isEnabled2;
        bool _isEnabled3;
        bool _isEnabled4;
        const string TITLE = "輸入座標範圍";
        const string START_COORDINATE_LABEL_X = "左上角座標X：";
        const string START_COORDINATE_INPUT_X = "_topLeftInputX";
        const string START_COORDINATE_LABEL_Y = "左上角座標Y：";
        const string START_COORDINATE_INPUT_Y = "_topLeftInputY";
        const string END_COORDINATE_LABEL_X = "右下角座標X：";
        const string END_COORDINATE_INPUT_X = "_bottomRightInputX";
        const string END_COORDINATE_LABEL_Y = "右下角座標Y：";
        const string END_COORDINATE_IUPUT_Y = "_bottomRightInputY";
        const string CONFIRM = "確定";
        const string CANCEL = "取消";
        const string NEGATIVE = "-";
        const string DOT = ".";

        const int MAIN_FORM_SIZE_X = 450;
        const int MAIN_FORM_SIZE_Y = 300;

        const int LABEL1_POINT_X = 15;
        const int LABEL1_POINT_Y = 15;
        const int START_TEXT_BOX_X_LOCATION_X = 15;
        const int START_TEXT_BOX_X_LOCATION_Y = 50;
        const int START_COORDINATE_TEXT_BOX_X_SIZE_X = 150;
        const int START_COORDINATE_TEXT_BOX_X_SIZE_Y = 30;

        const int LABEL2_POINT_X = 225;
        const int LABEL2_POINT_Y = 15;
        const int START_TEXT_BOX_Y_LOCATION_X = 225;
        const int START_TEXT_BOX_Y_LOCATION_Y = 50;
        const int START_COORDINATE_TEXT_BOX_Y_SIZE_X = 150;
        const int START_COORDINATE_TEXT_BOX_Y_SIZE_Y = 30;

        const int LABEL3_POINT_X = 15;
        const int LABEL3_POINT_Y = 120;
        const int END_TEXT_BOX_X_LOCATION_X = 15;
        const int END_TEXT_BOX_X_LOCATION_Y = 160;
        const int END_COORDINATE_TEXT_BOX_X_SIZE_X = 150;
        const int END_COORDINATE_TEXT_BOX_X_SIZE_Y = 30;

        const int LABEL4_POINT_X = 225;
        const int LABEL4_POINT_Y = 120;
        const int END_TEXT_BOX_Y_LOCATION_X = 225;
        const int END_TEXT_BOX_Y_LOCATION_Y = 160;
        const int END_COORDINATE_TEXT_BOX_Y_SIZE_X = 150;
        const int END_COORDINATE_TEXT_BOX_Y_SIZE_Y = 30;

        const int OK_BUTTON_LOCATION_X = 15;
        const int OK_BUTTON_LOCATION_Y = 220;

        const int CANCEL_BUTTON_LOCATION_X = 225;
        const int CANCEL_BUTTON_LOCATION_Y = 220;

        public CoordinateForm()
        {
            InitializeComponent();
            InitializeNewComponent();
            SetMainForm();
            SetTopLeftComponent();
            SetBottomRightComponent();
            SetOkCancelButton();
            AddControl();
            _isEnabled1 = _isEnabled2 = _isEnabled3 = _isEnabled4 = false;
        }

        // 初始化控件
        private void InitializeNewComponent()
        {
            _label1 = new Label();
            _label2 = new Label();
            _label3 = new Label();
            _label4 = new Label();
            _startCoordinateTextBoxX = new TextBox();
            _startCoordinateTextBoxY = new TextBox();
            _endCoordinateTextBoxX = new TextBox();
            _endCoordinateTextBoxY = new TextBox();
            _okButton = new Button();
            _cancelButton = new Button();
        }

        // 設定對話框屬性
        private void SetMainForm()
        {
            this.Text = TITLE;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(MAIN_FORM_SIZE_X, MAIN_FORM_SIZE_Y);
        }

        // 左上元件設定
        private void SetTopLeftComponent()
        {
            _label1.Text = START_COORDINATE_LABEL_X;
            _label1.Location = new Point(LABEL1_POINT_X, LABEL1_POINT_Y);
            _startCoordinateTextBoxX.ImeMode = ImeMode.Disable;
            _startCoordinateTextBoxX.Name = START_COORDINATE_INPUT_X;
            _startCoordinateTextBoxX.Location = new Point(START_TEXT_BOX_X_LOCATION_X, START_TEXT_BOX_X_LOCATION_Y);
            _startCoordinateTextBoxX.Size = new Size(START_COORDINATE_TEXT_BOX_X_SIZE_X, START_COORDINATE_TEXT_BOX_X_SIZE_Y);
            _startCoordinateTextBoxX.TextChanged += ChangedTextBox1Text;

            _label2.Text = START_COORDINATE_LABEL_Y;
            _label2.Location = new Point(LABEL2_POINT_X, LABEL2_POINT_Y);
            _startCoordinateTextBoxY.ImeMode = ImeMode.Disable;
            _startCoordinateTextBoxY.Name = START_COORDINATE_INPUT_Y;
            _startCoordinateTextBoxY.Location = new Point(START_TEXT_BOX_Y_LOCATION_X, START_TEXT_BOX_Y_LOCATION_Y);
            _startCoordinateTextBoxY.Size = new Size(START_COORDINATE_TEXT_BOX_Y_SIZE_X, START_COORDINATE_TEXT_BOX_Y_SIZE_Y);
            _startCoordinateTextBoxY.TextChanged += ChangedTextBox2Text;
        }

        // 右下元件設定
        private void SetBottomRightComponent()
        {
            _label3.Text = END_COORDINATE_LABEL_X;
            _label3.Location = new Point(LABEL3_POINT_X, LABEL3_POINT_Y);
            _endCoordinateTextBoxX.ImeMode = ImeMode.Disable;
            _endCoordinateTextBoxX.Name = END_COORDINATE_INPUT_X;
            _endCoordinateTextBoxX.Location = new Point(END_TEXT_BOX_X_LOCATION_X, END_TEXT_BOX_X_LOCATION_Y);
            _endCoordinateTextBoxX.Size = new Size(END_COORDINATE_TEXT_BOX_X_SIZE_X, END_COORDINATE_TEXT_BOX_X_SIZE_Y);
            _endCoordinateTextBoxX.TextChanged += ChangedTextBox3Text;

            _label4.Text = END_COORDINATE_LABEL_Y;
            _label4.Location = new Point(LABEL4_POINT_X, LABEL4_POINT_Y);
            _endCoordinateTextBoxY.ImeMode = ImeMode.Disable;
            _endCoordinateTextBoxY.Name = END_COORDINATE_IUPUT_Y;
            _endCoordinateTextBoxY.Location = new Point(END_TEXT_BOX_Y_LOCATION_X, END_TEXT_BOX_Y_LOCATION_Y);
            _endCoordinateTextBoxY.Size = new Size(END_COORDINATE_TEXT_BOX_Y_SIZE_X, END_COORDINATE_TEXT_BOX_Y_SIZE_Y);
            _endCoordinateTextBoxY.TextChanged += ChangedTextBox4Text;
        }

        // ok cancel button 設定
        private void SetOkCancelButton()
        {
            _okButton.Text = CONFIRM;
            _okButton.Location = new Point(OK_BUTTON_LOCATION_X, OK_BUTTON_LOCATION_Y);
            _okButton.Enabled = false;
            _okButton.Click += ClickOkButton;

            _cancelButton.Text = CANCEL;
            _cancelButton.Location = new Point(CANCEL_BUTTON_LOCATION_X, CANCEL_BUTTON_LOCATION_Y);
            _cancelButton.Click += ClickCancelButton;
        }

        // 加入control
        private void AddControl()
        {
            this.Controls.Add(_label1);
            this.Controls.Add(_startCoordinateTextBoxX);
            this.Controls.Add(_label2);
            this.Controls.Add(_startCoordinateTextBoxY);
            this.Controls.Add(_label3);
            this.Controls.Add(_endCoordinateTextBoxX);
            this.Controls.Add(_label4);
            this.Controls.Add(_endCoordinateTextBoxY);
            this.Controls.Add(_okButton);
            this.Controls.Add(_cancelButton);
        }

        // TextBox_TextChanged
        private void ChangedTextBox1Text(object sender, EventArgs e)
        {
            _isEnabled1 = !_startCoordinateTextBoxX.Text.Contains(NEGATIVE) && !_startCoordinateTextBoxX.Text.Contains(DOT) && _startCoordinateTextBoxX.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox2Text(object sender, EventArgs e)
        {
            _isEnabled2 = !_startCoordinateTextBoxY.Text.Contains(NEGATIVE) && !_startCoordinateTextBoxY.Text.Contains(DOT) && _startCoordinateTextBoxY.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox3Text(object sender, EventArgs e)
        {
            _isEnabled3 = !_endCoordinateTextBoxX.Text.Contains(NEGATIVE) && !_endCoordinateTextBoxX.Text.Contains(DOT) && _endCoordinateTextBoxX.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox4Text(object sender, EventArgs e)
        {
            _isEnabled4 = !_endCoordinateTextBoxY.Text.Contains(NEGATIVE) && !_endCoordinateTextBoxY.Text.Contains(DOT) && _endCoordinateTextBoxY.Text.Length != 0;
            IsOkButtonValid();
        }

        // ok button 確認狀態
        private void IsOkButtonValid()
        {
            if (_isEnabled1 && _isEnabled2 && _isEnabled3 && _isEnabled4)
            {
                _okButton.Enabled = true;
            }
            else
            {
                _okButton.Enabled = false;
            }
        }

        //按下OK鍵
        private void ClickOkButton(object sender, EventArgs e)
        {
            // 在這裡處理按下確定按鈕的邏輯，可以將座標回傳給主視窗
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //按下取消鍵
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // get startPoint
        public Point GetStartPoint()
        {
            return new Point(Int32.Parse(_startCoordinateTextBoxX.Text), Int32.Parse(_startCoordinateTextBoxY.Text));
        }

        // get endPoint
        public Point GetEndPoint()
        {
            return new Point(Int32.Parse(_endCoordinateTextBoxX.Text), Int32.Parse(_endCoordinateTextBoxY.Text));
        }
    }
}
