using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointProject
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public delegate void ShapeModeChangedEventHandler(bool line, bool rectangle, bool circle);
        public event PropertyChangedEventHandler PropertyChanged;
        IModel _model;
        const string LINE = "╱";
        const string RECTANGLE = "☐";
        const string CIRCLE = "○";
        const string MOUSE = "🖱";
        const string LINE_SHAPE = "線";
        const string RECTANGLE_SHAPE = "矩形";
        const string CIRCLE_SHAPE = "圓形";
        const string LINE_PROPERTY = "IsLine";
        const string RECTANGLE_PROPERTY = "IsRectangle";
        const string CIRCLE_PROPERTY = "IsCircle";
        const string POINTER_PROPERTY = "IsMouse";
        const int LINE_MODE = 0;
        const int RECTANGLE_MODE = 1;
        const int CIRCLE_MODE = 2;
        const int MOUSE_MODE = 3;
        /*bool _circleChecked = false;
        bool _lineChecked = false;
        bool _rectangleChecked = false;*/
        bool _isPressed = false;
        //for binding
        bool[] _buttonCheckedList = { false, false, false, true };
        string[] _buttonNameList = { LINE_SHAPE, RECTANGLE_SHAPE, CIRCLE_SHAPE, null };
        string _nowType = null;

        public PresentationModel(IModel model)
        {
            this._model = model;
            _nowType = null;
        }

        public bool LineCheck
        {
            get
            {
                return _buttonCheckedList[LINE_MODE];
            }
            set
            {
                _buttonCheckedList[LINE_MODE] = value;
            }
        }

        public bool MouseCheck
        {
            get
            {
                return _buttonCheckedList[MOUSE_MODE];
            }
            set
            {
                _buttonCheckedList[MOUSE_MODE] = value;
            }
        }

        public bool IsPressed
        {
            get
            {
                return _isPressed;
            }
            set
            {
                _isPressed = value;
            }
        }

        //方便測試寫的NowType
        public string NowType
        {
            get
            {
                return _nowType;
            }
        }

        //方便測試寫的IsLine
        public bool IsLine
        {
            get
            {
                return _buttonCheckedList[LINE_MODE];
            }
        }

        //方便測試寫的IsRectangle
        public bool IsRectangle
        {
            get
            {
                return _buttonCheckedList[RECTANGLE_MODE];
            }
        }

        //方便測試寫的IsCircle
        public bool IsCircle
        {
            get
            {
                return _buttonCheckedList[CIRCLE_MODE];
            }
        }

        //方便測試寫的IsMouse
        public bool IsMouse
        {
            get
            {
                return _buttonCheckedList[MOUSE_MODE];
            }
        }

        //處理繪圖模式的圖形
        /*public void ShapeMode(string nowMode)
        {
            switch (nowMode)
            {
                case LINE:
                    DoLineCase();
                    break;
                case RECTANGLE:
                    DoRectangleCase();
                    break;
                case CIRCLE:
                    DoCircleCase();
                    break;
                default:
                    SetNull();
                    NotifyShapeModelChanged();
                    break;
            }
        }

        //toolStrip按line
        void DoLineCase()
        {
            if (_lineChecked)
            {
                SetNull();
                NotifyShapeModelChanged();
                return;
            }
            SetNull();
            _lineChecked = true;
            NotifyShapeModelChanged();
            return;
        }

        //toolStrip按rectangle
        void DoRectangleCase()
        {
            if (_rectangleChecked)
            {
                SetNull();
                NotifyShapeModelChanged();
                return;
            }
            SetNull();
            _rectangleChecked = true;
            NotifyShapeModelChanged();
            return;
        }

        //toolStrip按circle
        void DoCircleCase()
        {
            if (_circleChecked)
            {
                SetNull();
                NotifyShapeModelChanged();
                return;
            }
            SetNull();
            _circleChecked = true;
            NotifyShapeModelChanged();
            return;
        }*/

        //設定check為null
        public void SetNull()
        {
            for (int i = 0; i < _buttonCheckedList.Count(); i++)
            {
                _buttonCheckedList[i] = false;
            }
        }

        // 按下 toolStrip 的 Line 按鍵
        public void PressedLineButton()
        {
            PressToolStrip(LINE_MODE);
            NotifyPropertyChanged();
        }

        // 按下 toolStrip 的 Rectangle 按鍵
        public void PressedRectangleButton()
        {
            PressToolStrip(RECTANGLE_MODE);
            NotifyPropertyChanged();
        }

        // 按下 toolStrip 的 Circle 按鍵
        public void PressedCircleButton()
        {
            PressToolStrip(CIRCLE_MODE);
            NotifyPropertyChanged();
        }

        // 按下 toolStrip 的 Pointer 按鍵
        public void PressedPointerButton()
        {
            if (!_buttonCheckedList[MOUSE_MODE])
            {
                SetNull();
                _buttonCheckedList[MOUSE_MODE] = true;
            }
            _nowType = null;
            _model.PointMode();
            NotifyPropertyChanged();
        }

        // check now shapeType and switch to new mode
        public void PressToolStrip(int modeNumber)
        {
            if (_buttonCheckedList[modeNumber])
            {
                _nowType = null;
                _buttonCheckedList[modeNumber] = false;
                _buttonCheckedList[MOUSE_MODE] = true;
                _model.PointMode();
            }
            else
            {
                _nowType = _buttonNameList[modeNumber];
                SetNull();
                _buttonCheckedList[modeNumber] = true;
                _model.DrawingMode();
            }
        }

        //通知view改變check
        /*void NotifyShapeModelChanged()
        {
            if (_shapeModelChanged != null)
                _shapeModelChanged(_lineChecked, _rectangleChecked, _circleChecked);
        }*/

        //確認shapeType
        /*public string CheckShapeType()
        {
            if (_lineChecked)
            {
                return LINE_SHAPE;
            }else if (_circleChecked)
            {
                return CIRCLE_SHAPE;
            }else if (_rectangleChecked)
            {
                return RECTANGLE_SHAPE;
            }
            else
            {
                return null;
            }
        }*/

        //呼叫model的pressedPointer
        public void PressedPointer(double firstX, double firstY)
        {
            if (firstX > 0 && firstY > 0)
            {
                _isPressed = true;
                _model.PressedPointer(_nowType, firstX, firstY);
            }
        }

        //呼叫Model的ReleasedPointer
        public void ReleasedPointer(double lastX, double lastY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _model.ReleasedPointer(_nowType, lastX, lastY);
                PressedPointerButton();
            }
        }
        
        //處理繪圖?
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));////////////////////////////
        }

        // 讓 model 畫縮圖
        public void DrawSlide(System.Drawing.Graphics graphics)
        {
            _model.DrawSlide(new WindowsFormsGraphicsAdaptor(graphics));
        }

        // pressed delete key
        public void PressDelete(Keys code)
        {
            if (code == Keys.Delete)
            {
                _model.PressDeleteKey();
            }
        }

        //Notify dataSourse
        public void NotifyPropertyChanged()
        {
            NotifyPropertyChanged(LINE_PROPERTY);
            NotifyPropertyChanged(RECTANGLE_PROPERTY);
            NotifyPropertyChanged(CIRCLE_PROPERTY);
            NotifyPropertyChanged(POINTER_PROPERTY);
        }

        //Notify dataSourse
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
