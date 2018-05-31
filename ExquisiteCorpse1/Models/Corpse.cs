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
        public virtual List<ApplicationUser> Players { get; set; }
        public int Rounds { get; set; }
        public int CurrentRound { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public List<UserCorpse> UserCorpses { get; set; }
        public string Status { get; set; } //Complete, Active, Awaitng, make Enum?


       //public Corpse(int currentRound = 0, int currrentPlayerIndex =0) { }

        public string GetLastStub()
        {

            return Sections[Sections.Count - 1].Stub;
        }

        public List<ApplicationUser> GetPlayers()
        {
            return Players;
        }

        public string GetCurrentPlayerId()
        {
            return Players[CurrentPlayerIndex].Id;
        }

       public string GetLastPlayerName()
        {
            return Players[CurrentPlayerIndex - 1].ProfileName;
        }

        public string GetNextPlayerNumber()
        {
            return Players[CurrentPlayerIndex].PhoneNumber;
        }

    

        public void SendInvite()
        {
            var invitePlayers = Players.ToList().Skip(1);
            foreach(ApplicationUser player in invitePlayers)
            {
                var body = Players[0].ProfileName + " has invited you to make a corpse INSERTURLHERE";
                var to = "+1" + player.PhoneNumber;
                new TextMessage { To = to, Body = body }.Send();
            }
        }

        public UserCorpse MakeJoin(ApplicationUser user)
        {
            return new UserCorpse
            {
                Corpse = this,
                CorpseId = this.CorpseId,
                ApplicationUser = user,
                UserId = user.Id,
                Status = "Awaiting"
            };
        }

       public void NextTurn()
        {

            var body = "It's your turn. " + GetLastPlayerName() + "has given you this to work with: " + GetLastStub() + "Go to INSERTROUTEHERE to continue the story.";
            new TextMessage { To = "+1" + GetNextPlayerNumber() , Body = body, }.Send();
            
        }


       public void EndGame()
        {
            var body = "It's Alive! Go to https://www.ThisExquisiteCorpse.com/Corpse/" + CorpseId + " to read what you've created";
            foreach (ApplicationUser p in Players)
            {
                 new TextMessage { To = "+1" + p.PhoneNumber, Body = body, }.Send();
            }
        }

        public void Increment()
        {
            if(CurrentPlayerIndex < Players.Count)
            {
                CurrentPlayerIndex += 1;
                NextTurn();
            }
            else if((CurrentPlayerIndex == Players.Count)&&(CurrentRound < Rounds))
            {
                CurrentRound += 1;
                CurrentPlayerIndex = 0;
                NextTurn();
            }
            else if ((CurrentPlayerIndex == Players.Count)&&(CurrentRound == Rounds))
            {
                EndGame();
            }

        }

       

    }
}
