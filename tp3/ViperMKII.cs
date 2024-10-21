using System;
using tp3.nsSpaceship;
using System.Collections.Generic;
using tp3.nsWeapon;
using tp3.nsEWeaponType;

namespace tp3.nsViperMKII{
    public class ViperMKII : Spaceship{
        public ViperMKII(bool belongsPlayer) : base("ViperMKII", 10, 15, belongsPlayer){
            Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.DIRECT, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.EXPLOSIVE, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.GUIDED, 4));
        }

        public override void ShootTarget(Spaceship target){
            /*Un ViperMKII utilise une seule des armes rechargée 
            (avec un compteur de rechargement à zéro) par tour 
            (si plusieurs armes disponible au même tour une seule peut servir).
            A vous de voir comment faire pour ne pas toujours utiliser 
            la mitrailleuse !*/
           
            List<Weapon> reloadedWeapons = new List<Weapon>();
            foreach(Weapon weapon in Weapons){
                if(weapon.TimeBeforReload == 0){
                    reloadedWeapons.Add(weapon);
                }
            }
            Random random = new Random();
            int index = random.Next(reloadedWeapons.Count);
            Weapon weaponToUse = reloadedWeapons[index];
            double damage = weaponToUse.Shoot();
            target.TakeDamages(damage);
        }

    }
}