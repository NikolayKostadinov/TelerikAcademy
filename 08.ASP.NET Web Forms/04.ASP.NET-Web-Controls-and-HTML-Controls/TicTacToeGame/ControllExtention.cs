using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TicTacToeGame
{
    public static class ControllExtention
    {
        public static IList<T> FindControlsOfType<T>(this Control parent)
                                                        where T : Control
        {
            var controls = new List<T>();
            foreach (Control child in parent.Controls)
            {
                if (child is T)
                {
                    controls.Add((T)child);
                }
            }

            return controls;
        }
    }
}