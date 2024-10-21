using System;
using System.Collections.Generic;
using tp3.nsWeapon;
using System.Linq;

namespace tp3.nsSpaceship
{
    public abstract class Spaceship : ISpaceship
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public int MaxWeapons { get; } = 3;
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public double AverageDamages => (Weapons.Sum(x => x.MinDamage) + Weapons.Sum(x => x.MaxDamage)) / 2;
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer { get; }
        public bool IsDestroyed { get; }

        public Spaceship(string name, double structure, double shield, bool belongsPlayer)
        {
            Name = name;
            Structure = structure;
            CurrentStructure = structure;
            Shield = shield;
            CurrentShield = shield;
            BelongsPlayer = belongsPlayer;
            IsDestroyed = false;
        }

        public virtual void TakeDamages(double damages)
        {
            if (CurrentShield != 0 && CurrentShield >= damages)
            {
                CurrentShield = CurrentShield - damages;
            }
            else
            {
                double damagesToStructure = damages - CurrentShield;
                CurrentStructure = CurrentStructure - damagesToStructure;
                CurrentShield = 0;
            }
        }

        public virtual void ShootTarget(Spaceship target)
        {
            foreach (Weapon weapon in Weapons)
            {
                if (weapon.IsReload)
                {
                    target.TakeDamages(weapon.Shoot());
                }
            }
        }

        public void ReloadWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.TimeBeforReload = weapon.TimeBeforReload - 1;
            }
        }

        public virtual void RepairShield(double repair)
        {
            if (repair > Shield)
            {
                CurrentShield = repair;
            }
            else
            {
                CurrentShield = repair;
            }
        }

        //tp1
        public virtual void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count < MaxWeapons)
            {
                Weapons.Add(weapon);
            }
        }

        //tp1
        public virtual void RemoveWeapon(Weapon oWeapon)
        {
            if (Weapons.Contains(oWeapon))
            {
                Weapons.Remove(oWeapon);
            }
        }

        //tp1
        public virtual void ClearWeapons()
        {
            Weapons.Clear();
        }

        //tp1
        public virtual void ViewWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.Display();
            }
        }

        public virtual void ViewShip()
        {
            Console.WriteLine("NAME : ", this.Name);
            Console.WriteLine("Structure : ", this.Structure);
            Console.WriteLine("Shield : ", this.Shield);
            Console.WriteLine("CurrentShield : ", this.CurrentShield);
            Console.WriteLine("CurrentStructure : ", this.CurrentStructure);
            Console.WriteLine("IsDestroyed : ", this.IsDestroyed);
            Console.WriteLine("MaxWeapons : ", this.MaxWeapons);
            Console.WriteLine("AverageDamages : ", this.AverageDamages);
            Console.WriteLine("BelongsPlayer : ", this.BelongsPlayer);
            ViewWeapons();
        }
    }
}