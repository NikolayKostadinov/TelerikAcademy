using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop
{
    public class Producer
    {
        private ICollection<Model> models;

        public Producer() 
        {
            this.models = new List<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}