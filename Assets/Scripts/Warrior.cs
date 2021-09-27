using System.Collections;
using System.Collections.Generic;

public class Warrior
{
    public ArmyEnum Army{get{ return army;}}
    ArmyEnum army;
    public int Cell{get { return cell;}}
    int cell;
    public int Initiative{get{ return initiative;}}
    int initiative;
    public int Speed{get{ return speed;}}
    int speed;

    static int actualId = 0;
    public int ID {get{ return id;}}
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
            "ID: " + id.ToString() + " " +
            "Cell: " + cell.ToString() + " " +
            "Army: " + army.ToString() + " " +
            "Initiative: " + initiative.ToString() + " " +
            "Speed: " + speed.ToString();
    }
}
