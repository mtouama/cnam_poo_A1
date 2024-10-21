using System;
using tp3.nsSpaceship;
using tp3.nsWeapon;
using tp3.nsEWeaponType;

namespace tp3.nsBWings
{
    class BWings : Spaceship
    {
        public BWings(bool belongsPlayer) : base("BWings", 30, 0, belongsPlayer)
        {
            Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.EXPLOSIVE, 0)); //pas de reload pour les types explosive
        }

        //override la fonction addweapon
        public override void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count < MaxWeapons)
            {
                if (weapon.Type == EWeaponType.EXPLOSIVE)
                {
                    weapon.ReloadTime = 0; //ou 1 (à voir selon le fonctionnement du tour)
                    weapon.TimeBeforReload = 0; //ou 1
                }
                Weapons.Add(weapon);
            }
        }


    }
}