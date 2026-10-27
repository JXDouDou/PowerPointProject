using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPointProject
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Selected
        {
            get;
            set;
        }

        //設定起始座標
        public abstract void SetStartCoordinate(Point startCoordinate);

        //設定終點座標
        public abstract void SetEndCoordinate(Point endCoordinate);

        //繪圖
        public abstract void Draw(IGraphics graphics);

        //draw slides
        public abstract void DrawSlide(IGraphics graphics, Size panelSize, Size slideSize);

        //畫外框
        public abstract void DrawSelectedOutlook(IGraphics graphics);

        //get shape name
        public abstract string GetShapeName();

        //get coordination
        public abstract string GetCoordinate();

        //get startPoint
        public abstract Point GetStartPosition();

        //get endPoint
        public abstract Point GetEndPosition();

        //check isSelected
        public abstract bool IsSelected(Point mousePosition);

        //zoom magnitude
        public abstract void Zoom(double nowX, double nowY);

        //reset Coordinate for zoom
        public abstract void ResetCoordinate();

        //Movement magnitude
        public abstract void Move(double diffX, double diffY);

        //Check is selected or not
        public abstract bool IsRightDownSelected(Point mousePosition);

        //回傳確認型態後的實體
        //public abstract Shape GetType();

        //set selected or not
        public abstract void SetSelected(bool select);

        /*//return information(還用不到)
        public abstract List<string> GetInfo();*/
        //通知變更
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
