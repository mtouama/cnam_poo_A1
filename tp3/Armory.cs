using System;
using System.Collections.Generic;
using tp3.nsWeapon;
using tp3.nsEWeaponType;

namespace tp3.nsArmory
{

    public class Armory
    {
        public List<Weapon> weapons = new List<Weapon>{
            //new Weapon("NOM", minDamage, maxDamage, EWeaponType, reloadTime)
            new Weapon("Laser", 2, 3, EWeaponType.DIRECT, 2),
            new Weapon("Hammer", 1, 8, EWeaponType.EXPLOSIVE, (double)1.5),
            new Weapon("Torpille", 3, 3, EWeaponType.GUIDED, 2),
            new Weapon("Mitrailleuse", 6, 8, EWeaponType.DIRECT, 1),
            new Weapon("EMG", 1, 7, EWeaponType.EXPLOSIVE, (double)1.5),
            new Weapon("Missile", 4, 100, EWeaponType.GUIDED, 4)
        };

        public Armory() { }


        //tp1
        public void Init()
        {
            foreach (EWeaponType eWeaponType in Enum.GetValues(typeof(EWeaponType)))
            {
                Weapon w = new Weapon("GUN!", 1, 1, eWeaponType, (double)2);
                weapons.Add(w);
            }
        }

        //tp1
        public void AddWeaponToArmory(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        //tp1
        public void RemoveWeaponFromArmory(Weapon weapon)
        {
            weapons.Remove(weapon);
        }
        
        //tp1
        public void ViewArmory()
        {
            foreach (Weapon weapon in this.weapons)
            {
                weapon.Display();
            }
        }

    }
}