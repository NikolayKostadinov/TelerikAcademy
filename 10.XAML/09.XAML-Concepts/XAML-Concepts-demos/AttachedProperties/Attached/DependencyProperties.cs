using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AttachedProperties.Attached
{
    public static class DependencyProperties
    {

        public static string GetSize(DependencyObject obj)
        {
            return (string)obj.GetValue(SizeProperty);
        }

        public static void SetSize(DependencyObject obj, string value)
        {
            obj.SetValue(SizeProperty, value);
        }

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached("Size", typeof(string), typeof(UIElement), new PropertyMetadata((snd,args)=>{
                var element = snd as Control;
                if (element == null)
                {
                    return;
                }

                var sizeArgs = args.NewValue.ToString().Split(';');
                var width = double.Parse(sizeArgs[0]);
                var height = double.Parse(sizeArgs[1]);
                element.Width = width;
                element.Height = height;
            }));


    }
}
