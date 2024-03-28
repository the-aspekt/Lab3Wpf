using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab3Wpf
{
    internal class MyCommands
    {
        

        public static RoutedUICommand Exit { get; set; }

        static MyCommands()
        {
            InputGestureCollection exitGesture = new InputGestureCollection
            {
                new KeyGesture(Key.Q, ModifierKeys.Alt, "Alt+Q")
            };
            Exit = new RoutedUICommand("Выход", "Exit", typeof(MyCommands), exitGesture);
        }

    }
}
