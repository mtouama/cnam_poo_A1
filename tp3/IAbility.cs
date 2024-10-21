using System;
using tp3.nsSpaceship;
using System.Collections.Generic;

namespace tp3.nsAbility
{
    public interface IAbility
    {
        void UseAbility(List<Spaceship> spaceships);
    }
}