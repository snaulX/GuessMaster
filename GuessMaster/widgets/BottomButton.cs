using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GuessMaster.widgets
{
    public class BottomButton : Button
    {
        public BottomButton()
        {
            Margin = new Thickness(10, 30, 10, 30);
            FontSize = 18;
        }
    }
}
