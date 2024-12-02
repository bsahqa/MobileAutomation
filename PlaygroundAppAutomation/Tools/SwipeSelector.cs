using MobileAutomation.PageObjects;
using OpenQA.Selenium.Appium;
using System.Drawing;

namespace MobileAutomation.Tools
{
    class SwipeSelector : BasePage
    {
        private struct ScrollParams
        {
            public ScrollParams(int x, int y, int scrollLength)
            {
                X = x;
                Y = y;
                ScrollLength = scrollLength;
            }
            public int X { get; }
            public int Y { get; }
            public int ScrollLength { get; }
        }

        public SwipeSelector(AppiumDriver<AppiumWebElement> driver) : base(driver)
        { }

        public AppiumWebElement CancelButton => GetElement(MobileBy.Id("android:id/button2"));
        public AppiumWebElement OkButton => GetElement(MobileBy.Id("android:id/button1"));
        public AppiumWebElement SelectedOptionItem => GetElement(MobileBy.Id("android:id/numberpicker_input"));

        private ScrollParams SelectedItemCenterData
        {
            get
            {
                Rectangle selectedOptionShape = SelectedOptionItem.Rect;
                Point selectedOptionLocation = SelectedOptionItem.Location;
                int scrollStartX = selectedOptionLocation.X + selectedOptionShape.Width / 2;
                int scrollStartY = selectedOptionLocation.Y + selectedOptionShape.Height / 2;
                return new ScrollParams(scrollStartX, scrollStartY, selectedOptionShape.Height * 3 / 4);
            }
        }

        public void ScrollToOption(string requiredOption)
        {
            string selectedOption = SelectedOptionItem.Text;
            if (string.Compare(selectedOption, requiredOption) == 0)
                return;
            if (string.Compare(selectedOption, requiredOption) > 0)  // Selected option is alphabeticaly bigger than required
            {
                while (string.Compare(selectedOption, requiredOption) != 0)
                {
                    ScrollUp();
                }
            }
            else
            {
                while (string.Compare(selectedOption, requiredOption) != 0)
                {
                    ScrollDown();
                }
            }
        }

        public void ScrollUp()
        {
            action.Press(SelectedItemCenterData.X, SelectedItemCenterData.Y)
                .Wait(200)
                .MoveTo(SelectedItemCenterData.X, SelectedItemCenterData.Y + SelectedItemCenterData.ScrollLength)
                .Release()
                .Perform();
            action.Cancel();
        }

        public void ScrollDown()
        {
            action.Press(SelectedItemCenterData.X, SelectedItemCenterData.Y)
                .Wait(200)
                .MoveTo(SelectedItemCenterData.X, SelectedItemCenterData.Y - SelectedItemCenterData.ScrollLength)
                .Perform();
            action.Cancel();
        }

    }
}
