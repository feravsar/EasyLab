using System.Collections.Generic;

namespace EasyLab.Core.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }


        public virtual List<Assignment> Assignments { get; set; }
    }
}