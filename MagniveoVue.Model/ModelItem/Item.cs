using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagniveoVue.Model.ModelItem
{
    public class Item
    {
        [Key]
        public int ItemID{get;set;}
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
