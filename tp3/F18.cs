using System;
using tp3.nsSpaceship;
using tp3.nsAbility;
using System.Collections.Generic;

namespace tp3.nsF18{
    public class F18 : Spaceship, IAbility{

        public F18(bool belongsPlayer) : base("F-18", 15, 0, belongsPlayer){
        }

        /*
             Un F-18 ne possède pas d’armes, mais s’il est au contact (à côté) avec 
             le vaisseau joueur, il explose et lui fait 10 points de dégâts
        */
        //useAbility
        public void UseAbility(List<Spaceship> spaceships){
            int index = spaceships.IndexOf(this);
            if(index > 0 && spaceships[index - 1].BelongsPlayer){
                spaceships[index - 1].TakeDamages(10);
            }
            if(index < spaceships.Count - 1 && spaceships[index + 1].BelongsPlayer){
                spaceships[index + 1].TakeDamages(10);
            }
            //BOUM
            // this.IsDestroyed = true;
            this.CurrentStructure = 0;
            this.CurrentShield = 0;
   
        }

    }

}