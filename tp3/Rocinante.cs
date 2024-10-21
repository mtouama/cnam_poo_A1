using System;
using tp3.nsSpaceship;
using tp3.nsWeapon;
using tp3.nsEWeaponType;

namespace tp3.nsRocinante
{
    class Rocinante : Spaceship
    {

        public Rocinante(bool belongsPlayer) : base("Rocinante", 3, 5, belongsPlayer)
        {
            Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.GUIDED, 0));
        }

        public override void TakeDamages(double damages)
        {

            /*
                Le Rocinante est plus rapide et esquive beaucoup mieux les tirs. Il a deux fois moins de
                chance de se faire toucher qu’un vaisseau normal
            */
            Random random = new Random();
            int randomInt = random.Next(2);
            if (randomInt == 0)
            {
                if (CurrentShield != 0 && CurrentShield >= damages)
                {
                    CurrentShield = CurrentShield - damages;
                }
                else
                {
                    double damageToStructure = damages - CurrentShield;
                    CurrentStructure = CurrentStructure - damageToStructure;
                    CurrentShield = 0;
                }
            }

        }
    }
}