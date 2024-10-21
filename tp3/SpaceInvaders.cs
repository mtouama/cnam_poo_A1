using System;
using System.Collections.Generic;
using System.Linq;
using tp3.nsEWeaponType;
using tp3.nsArmory;
using tp3.nsSpaceship;
using tp3.nsWeapon;
using tp3.nsPlayer;
using tp3.nsTardis;
using tp3.nsF18;
using tp3.nsDart;
using tp3.nsBWings;
using tp3.nsRocinante;
using tp3.nsF18;
using tp3.nsViperMKII;

/*
LANCER LE PROJET :
make
./main.exe
*/

namespace tp3
{
    public class SpaceInvaders
    {
        public SpaceInvaders() { }
        List<Spaceship> spaceships = new List<Spaceship>();//terrain avec alliés et ennemis
        List<Player> players = new List<Player>();//joueurs

        public void Init()
        {
            Dart dartOne = new Dart(true);

            Player playerOne = new Player("john", "bill", "cgroxu", dartOne);

            players.Add(playerOne);

            spaceships.Add(new Tardis(false));
            spaceships.Add(new F18(false));
            spaceships.Add(dartOne);

            spaceships = ShuffleSpaceships(spaceships);
        }

        public void PlayRound()
        {
            int nbTour = 1;
            Spaceship playerShip = null;
            List<Spaceship> ennemies = new List<Spaceship>();

            //calculer le nombre d'ennemis
            foreach (Spaceship spaceship in this.spaceships)
            {
                if (!spaceship.BelongsPlayer && !spaceship.IsDestroyed)
                {
                    ennemies.Add(spaceship);
                }
            }

            foreach (Spaceship spaceship in this.spaceships)
            {
                if (spaceship.BelongsPlayer && !spaceship.IsDestroyed)
                {
                    playerShip = spaceship;
                    //calculer la chance : nbTour / nbEnnemis
                    int chance = nbTour / ennemies.Count;
                    Random random = new Random();
                    int randomInt = random.Next(chance);
                    if (randomInt == 0)
                    {
                        //le joueur tire sur un ennemi
                        int randomInt2 = random.Next(ennemies.Count);
                        Spaceship ennemy = ennemies[randomInt2];
                        playerShip.ShootTarget(ennemy);
                    }

                }
                else if (!spaceship.BelongsPlayer && !spaceship.IsDestroyed)
                {
                    //le vaisseau ennemi tire sur le joueur
                    spaceship.ShootTarget(playerShip);
                }
                nbTour++;
            }
            repairShip(spaceships);


        }

        private void repairShip(List<Spaceship> spaceships)
        {
            foreach (Spaceship spaceship in spaceships)
            {
                if (!spaceship.IsDestroyed)
                {
                    spaceship.RepairShield(2);
                }

            }

        }

        private List<Spaceship> ShuffleSpaceships(List<Spaceship> spaceships)
        {
            Random random = new Random();
            for (int i = spaceships.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Spaceship temp = spaceships[i];
                spaceships[i] = spaceships[j];
                spaceships[j] = temp;
            }
            return spaceships;
        }

        public static void Main(string[] args)
        {
  
        }
    }
}