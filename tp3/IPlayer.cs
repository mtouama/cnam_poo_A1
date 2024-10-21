using System;
using tp3.nsSpaceship;

namespace tp3.nsPlayer{
    public interface IPlayer
    {
        Spaceship BattleShip { get; set; }
        string Name { get; }
        string Alias { get; }
    }
}