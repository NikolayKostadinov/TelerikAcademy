using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UserMenuControl
{
    public class MenuItem
    {
        private string title;
        private string url;

        public MenuItem(string title, string url)
        {
            this.Title = title;
            this.Url = url;
        }

        public string Title 
        {
            get 
            {
                return this.title;
            }

            private set 
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Title of menu item cannot be empty");
                }
                this.title = value;
            }
        }

        public string Url 
        {
            get 
            {
                return this.url;
            }

            private set 
            {
                if (Regex.IsMatch(value, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-.?,'/\\+&amp;%\\=$#_]*)?$"))
                {
                    // Successful match
                    this.url = value;
                }
                else
                {
                    // Match attempt failed
                    throw new ArgumentException(string.Format("Invalid URL! {0}",value));
                } 
                
            }
        }

    }
}