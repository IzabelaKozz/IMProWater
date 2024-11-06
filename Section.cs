using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMProWater
{
    public class Section
    {
        public string Id { get; set; } // Unikalny identyfikator sekcji
        public string Name { get; set; } // Nazwa sekcji
        public string StartTime { get; set; } // Godzina rozpoczęcia sekcji
        public string Duration { get; set; } // Czas trwania sekcji
        public List<string> SelectedDays { get; set; } = new List<string>(); // Lista wybranych dni tygodnia
    }
}
