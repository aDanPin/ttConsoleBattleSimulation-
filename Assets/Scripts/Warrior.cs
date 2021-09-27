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

    static int actualId = 0;
    public int ID {get;}
    int id;

    public Warrior(ArmyEnum a, int c, int i, int s) {
        id = actualId;
        ++actualId;
        
        army = a;
        cell = c;
        initiative = i;
        speed = s;
    }

    public override string ToString()
    {
        return base.ToString() + ": " +
            "ID: " + id.ToString() +
            "Cell: " + cell.ToString() +
            "Army: " + army.ToString() +
            "Initiative: " + initiative.ToString() +
            "Speed: " + speed.ToString();
    }
}
