using System;
using tp3.nsSpaceship;
using tp3.nsWeapon;
using tp3.nsEWeaponType;

namespace tp3.nsDart{
    class Dart : Spaceship{
        public Dart(bool belongsPlayer) : base("Dart", 10, 3, belongsPlayer) {
            Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.DIRECT, 0)); // reloadTime = 0, arme DIRECT

        }

        //override la fonction addweapon
        public override void AddWeapon(Weapon weapon){
            if(Weapons.Count < MaxWeapons){
                if(weapon.Type == EWeaponType.DIRECT){
                    weapon.ReloadTime = 0; //ou 1
                    weapon.TimeBeforReload = 0; //ou 1
                }
                Weapons.Add(weapon);
            }
        }


    }
}