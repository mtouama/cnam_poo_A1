using System;
using tp3.nsEWeaponType;

namespace tp3.nsWeapon
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage { get; set; }
        public double ReloadTime { get; set; }
        public double TimeBeforReload { get; set; }
        public bool IsReload { get; set; }
        public EWeaponType Type { get; set; }
        private static Random random = new Random();

        public Weapon(string name, int minDamage, int maxDamage, EWeaponType eWeaponType, double reloadTime)
        {
            this.Name = name;
            this.Type = eWeaponType;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.AverageDamage = (minDamage + maxDamage) / 2;
            this.ReloadTime = reloadTime;
            this.TimeBeforReload = reloadTime; // initialisé à la valeur du temps de rechargement à la création de l’arme
            this.IsReload = true;
        }

        public double Shoot()
        {
            double damage = 0.0;
            if (TimeBeforReload == 0)
            {
                damage = random.Next((int)MinDamage, (int)MaxDamage);
                switch (Type)
                {
                    case EWeaponType.DIRECT:
                        bool chanceOutOfTen = HasChance(10);
                        if (chanceOutOfTen) { damage = 0.0; }
                        break;
                    case EWeaponType.EXPLOSIVE:
                        bool chanceOutOfFour = HasChance(4);
                        if (!chanceOutOfFour)
                        {
                            damage = damage * 2.0;
                            ReloadTime = ReloadTime * 2.0;
                        }
                        break;
                    case EWeaponType.GUIDED:
                        damage = MinDamage;
                        break;
                }
            }

            return damage;


        }

        // calcul 1 / chance
        public bool HasChance(int chance)
        {
            int randomNum = random.Next(chance);
            return randomNum == 0; //une chance sur luck de tomber sur 0

        }

        // tp1
        public void Display()
        {
            Console.WriteLine("Name : ", this.Name);
            Console.WriteLine("MinDamage : ", this.MinDamage);
            Console.WriteLine("MaxDamage : ", this.MaxDamage);
        }
    }
}