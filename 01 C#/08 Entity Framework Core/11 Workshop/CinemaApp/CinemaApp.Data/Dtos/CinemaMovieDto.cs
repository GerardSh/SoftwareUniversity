using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Dtos
{
    internal class CinemaMovieDto
    {
        public string Movie { get; set; }
        public string Cinema { get; set; }
        public int AvailableTickets { get; set; }
        public bool IsDeleted { get; set; }
        public string Showtimes { get; set; }
    }
}
