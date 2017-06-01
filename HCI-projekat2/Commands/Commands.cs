using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_projekat2.Commands
{
    public static class Commands
    {
        public static readonly RoutedUICommand Help = new RoutedUICommand(
            "Help",
            "Help",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F1)
            }
            );


        public static readonly RoutedUICommand newResource = new RoutedUICommand(
            "newResource",
            "New Resource",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand newResourceType = new RoutedUICommand(
            "newResourceType",
            "New Resource Type",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand newResourceLabel = new RoutedUICommand(
            "newResourceLabel",
            "New Resource Label",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand showResTable = new RoutedUICommand(
            "showResTable",
            "Show Resource Table",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand showLabTable = new RoutedUICommand(
            "showLabTable",
            "Show Label Table",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand showTypeTable = new RoutedUICommand(
            "showTypeTable",
            "Show Resource Type Table",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand saveProject = new RoutedUICommand(
            "saveProject",
            "Save Project",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand newUser = new RoutedUICommand(
            "newuser",
            "New User",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand changeIcon = new RoutedUICommand(
            "changeIcon",
            "Change Icon",
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.I, ModifierKeys.Control)
            }
            );
    }
}