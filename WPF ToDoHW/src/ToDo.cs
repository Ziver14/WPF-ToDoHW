using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_5.src
{
    public class ToDo
    {
        public bool Done { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ToDo() { }
        public ToDo(string title, string description, DateTime date)
        {
            Title = title;
            Date = date;
            Description = description;
        }
    }
}
