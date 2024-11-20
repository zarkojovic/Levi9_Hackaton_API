using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Players
{
    public class GetPlayerDTO
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double Elo { get; set; }
        public float HoursPlayed { get; set; }
        public Guid? TeamId { get; set; }
        public float ratingAdjustment { get; set; }
    }
}