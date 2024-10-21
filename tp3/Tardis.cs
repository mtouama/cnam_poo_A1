using System;
using tp3.nsSpaceship;
using tp3.nsAbility;
using System.Collections.Generic;

namespace tp3.nsTardis{
    // implement l'interface IAbility.cs
    class Tardis : Spaceship, IAbility{

        /*
        L’aptitude spéciale du Tardis est de déplacer un vaisseau au hasard et 
        de le mettre à un autre endroit dans la liste, toujours au hasard.
        */

        public Tardis(bool belongsPlayer) : base("Tardis", 1, 0, belongsPlayer){
        }

        //liste de vaisseaux = vaisseaux sur les terrains (ennemi et allié)
        public void UseAbility(List<Spaceship> spaceships){
            Random random = new Random();
            int firstIndex = random.Next(0, spaceships.Count);
            int secondIndex = random.Next(0, spaceships.Count);
            Spaceship tmp = spaceships[firstIndex];
            spaceships[firstIndex] = spaceships[secondIndex];
            spaceships[secondIndex] = tmp;
        }

    }
}