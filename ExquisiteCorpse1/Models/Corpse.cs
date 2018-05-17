using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;

namespace ExquisiteCorpse1.Models
{
    [Table("Corpses")]
    public class Corpse
    {
        [Key]
        public int CorpseId { get; set; }
        public string Title { get; set; }
        public List<Section> Sections { get; set; }
        public List<ApplicationUser> Players { get; set; }
        public int Rounds { get; set; }
        public int CurrentRound { get; set; }
        public int CurrentPlayerInedx { get; set; }
        public List<UserCorpse> UserCorpses { get; set; }


       public Corpse(int currentRound = 0, int currrentPlayerIndex =0) { }

       


       public void EndGame()
        {
            //var playerNumbers = 
            //new TextMessage completionMessage = new TextMessage { }
        }

       public void Increment()
        {
            if(CurrentPlayerInedx < Players.Count)
            {
                CurrentPlayerInedx += 1;
            }
            else if((CurrentPlayerInedx == Players.Count)&&(CurrentRound < Rounds))
            {
                CurrentRound += 1;
                CurrentPlayerInedx = 0;
            }
            else if ((CurrentPlayerInedx == Players.Count)&&(CurrentRound == Rounds))
            {
                EndGame();
            }

        }

       

    }
}
