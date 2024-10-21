using System;
using tp3.nsSpaceship;
using tp3.nsArmory;

namespace tp3.nsPlayer
{
    public class Player : IPlayer
    {
        private string FirstName { get; }
        private string LastName { get; }
        public string Alias { get; }
        public string Name { get; }
        public Spaceship BattleShip { get; set; }

        public Player(string firstname, string lastname, string alias, Spaceship spaceship)
        {
            FirstName = firstname;
            LastName = lastname;
            Alias = alias;
            Name = capitalizeName(FirstName) + " " + capitalizeName(LastName);
            BattleShip = spaceship;
        }

        private static string capitalizeName(string name)
        {
            string firstLetter = name[0].ToString().ToUpper();
            string restOfString = name.Substring(1);
            return firstLetter + restOfString;
        }

        public override string ToString()
        {
            return capitalizeName(FirstName) + " (" + capitalizeName(LastName) + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player player = (Player)obj;
                return player.Alias == this.Alias;
            }
            return false;
        }
    }
}