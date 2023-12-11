using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointProject;
using PowerPointProjectTests.Model;
using PowerPointProjectTests.Model.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointProject.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        PrivateObject _preModelPrivate;
        PresentationModel _preModel;
        MockGraphic _graphic;
        MockModel _model = new MockModel();

        /*private int _notifyPropertyChangedCounter = 0;

        private void TestNotifyPropertyChanged()
        {
            _notifyPropertyChangedCounter++;
        }*/

        //initialize
        [TestInitialize()]
        public void initialize()
        {
            _graphic = new MockGraphic();
            _preModel = new PresentationModel(_model);
        }

        //test preset variable
        [TestMethod()]
        public void PresetTest()
        {
            Assert.AreEqual(null, _preModel.NowType);
            Assert.AreEqual(false, _preModel.IsLine);
            Assert.AreEqual(false, _preModel.IsRectangle);
            Assert.AreEqual(false, _preModel.IsCircle);
            Assert.AreEqual(true, _preModel.IsMouse);
        }

        //test setNull
        [TestMethod()]
        public void SetNullTest()
        {
            _preModel.SetNull();
            Assert.AreEqual(false, _preModel.IsLine);
            Assert.AreEqual(false, _preModel.IsRectangle);
            Assert.AreEqual(false, _preModel.IsCircle);
            Assert.AreEqual(false, _preModel.IsMouse);
        }

        //test PressedLineButton
        [TestMethod()]
        public void PressedLineButtonTest()
        {
            _preModel.NotifyPropertyChanged();
            _preModel.PressedLineButton();
        }

        //test pressedRectangleButton
        [TestMethod()]
        public void PressedRectangleButtonTest()
        {
            _preModel.NotifyPropertyChanged();
            _preModel.PressedRectangleButton();
        }

        //test pressedCircleButton
        [TestMethod()]
        public void PressedCircleButtonTest()
        {
            _preModel.NotifyPropertyChanged();
            _preModel.PressedCircleButton();
        }

        //test pressedPointer
        [TestMethod()]
        public void PressedPointerButtonTest()
        {
            Assert.IsTrue(_preModel.MouseCheck);
            _preModel.NotifyPropertyChanged();
            _preModel.MouseCheck = false;
            _preModel.PressedPointerButton();
            _preModel.MouseCheck = true;
            _preModel.PressedPointerButton();
        }

        //test pressed toolStrip
        [TestMethod()]
        public void PressedToolStripTest_CaseTrue()
        {
            Assert.IsFalse(_preModel.LineCheck);
            _preModel.NotifyPropertyChanged();
            _preModel.LineCheck = true;
            _preModel.PressToolStrip(1);
        }

        //test pressed toolStrip
        [TestMethod()]
        public void PressedToolStripTest_CaseFalse()
        {
            _preModel.NotifyPropertyChanged();
            _preModel.LineCheck = true;
            _preModel.PressToolStrip(0);
        }

        //test Pressed Pointer
        [TestMethod()]
        public void PressedPointerTest()
        {
            _model = new MockModel();
            _preModel = new PresentationModel(_model);
            _preModel.PressedPointer(3, 5);
            _preModel.PressedPointer(-1, 3);
            Assert.AreEqual(_model._pressedMouse, 1);
        }

        //test Released Pointer
        [TestMethod()]
        public void ReleasedPointerTest()
        {
            _model = new MockModel();
            _preModel = new PresentationModel(_model);
            _preModel.IsPressed = true;
            _preModel.ReleasedPointer(3, 5);
            _preModel.IsPressed = true;
            Assert.IsTrue(_preModel.IsPressed);
            _preModel.ReleasedPointer(-1, 3);
            _preModel.ReleasedPointer(-1, -2);
        }

        //test Draw
        [TestMethod()]
        public void DrawTest()
        {
            System.Drawing.Graphics graphic = null;
            _preModel.Draw(graphic);
        }

        //test DrawSlide
        [TestMethod()]
        public void DrawSlideTest()
        {
            System.Drawing.Graphics graphic = null;
            _preModel.DrawSlide(graphic);
        }

        //test pressedDelete
        [TestMethod()]
        public void PressDeleteTest_Case1()
        {
            Keys code = Keys.Delete;
            _preModel.PressDelete(code);
        }

        //test pressedDelete
        [TestMethod()]
        public void PressDeleteTest_Case2()
        {
            _preModel.PressDelete(Keys.K);
        }

        //test notify
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            _preModelPrivate = new PrivateObject(_preModel);
            bool eventRaised = false;
            _preModel.PropertyChanged += (Object sender, PropertyChangedEventArgs e) => eventRaised = true;
            _preModelPrivate.Invoke("NotifyPropertyChanged");
            Assert.IsTrue(eventRaised);
        }
    }
}