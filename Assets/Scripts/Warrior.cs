using System.Collections;
using System.Collections.Generic;

public class Warrior
{
    public enum  ArmyEnum{
        Red, Blue
    };

    public ArmyEnum Army{get;}
    ArmyEnum army;
    public int Cell{get;}
    int cell;
    public int Initiative{get;}
    int initiative;
    public int Speed{get;}
    int speed;

    Warrior(ArmyEnum a, int c, int i, int s) {
        army = a;
        cell = c;
        initiative = i;
        speed = s;
    } 
}
