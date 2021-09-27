using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private const int ITERATION_COUNT = 20;

    int turn;
    List<Warrior> battlefield;
    HashSet<Warrior> goneInThisRound; 

    void Start()
    {
        battlefield = InitialiseBattlefield();
        QueueMaker.SortQueue(battlefield);
        
        Debug.Log("ROUND " + RoundCount.Round);

        turn = 0;
        goneInThisRound = new HashSet<Warrior>();
    }

    private void Update() {
        if(turn < ITERATION_COUNT & PlayStillContinues(battlefield)) {
            Debug.Log("\n");
            Debug.Log("Turn " + turn);
            if(goneInThisRound.Count == battlefield.Count) { // Start new round
                RoundCount.Round++;
                QueueMaker.SortQueue(battlefield);

                goneInThisRound.Clear();

                Debug.Log("\n ROUND " + RoundCount.Round + "\n");
            } else {
                if(!goneInThisRound.Contains(battlefield[0])) {
                    goneInThisRound.Add(battlefield[0]);
                }

                if(battlefield[0].Army == battlefield[1].Army) {
                    // Pass turn
                    Debug.Log("Warrior " + battlefield[0] + " PASS TURN");
                    var w = battlefield[0];
                    battlefield.Remove(battlefield[0]);
                    battlefield.Add(w);
                } else {
                    // Kill warrior
                    Debug.Log("Warrior " + battlefield[0] + "  KILL  " + battlefield[1]);
                    battlefield.Remove(battlefield[1]);
                }
            }

            Debug.Log("Actual battlefield ");
            foreach(Warrior w in battlefield) {
                Debug.Log(w);
            }

            turn++;
        }
        else {
            Debug.Log("End Game");
            enabled = false;
        }
    }

    private List<Warrior> InitialiseBattlefield() {
        List<Warrior> battlefield = new List<Warrior>();

        /*
        1 ячейка - К1 - Инициатива = 8, Скорость = 4
        2 ячейка - К2 - Инициатива = 8, Скорость = 4
        3 ячейка - К3 - Инициатива = 9, Скорость = 5
        4 ячейка - К4 - Инициатива = 4, Скорость = 3
        5 ячейка - К5 - Инициатива = 2, Скорость = 3
        6 ячейка - К6 - Инициатива = 3, Скорость = 4
        7 ячейка - К7 - Инициатива = 1, Скорость = 1
        */
        battlefield.Add(new Warrior(ArmyEnum.Red, 1, 8, 4));
        battlefield.Add(new Warrior(ArmyEnum.Red, 2, 8, 4));
        battlefield.Add(new Warrior(ArmyEnum.Red, 3, 9, 5));
        battlefield.Add(new Warrior(ArmyEnum.Red, 4, 4, 3));
        battlefield.Add(new Warrior(ArmyEnum.Red, 5, 2, 3));
        battlefield.Add(new Warrior(ArmyEnum.Red, 6, 3, 4));
        battlefield.Add(new Warrior(ArmyEnum.Red, 7, 1, 1));

        /*
        1 ячейка - С1 - Инициатива = 6, Скорость = 6
        2 ячейка - С2 - Инициатива = 8, Скорость = 5
        3 ячейка - С3 - Инициатива = 9, Скорость = 5
        4 ячейка - С4 - Инициатива = 8, Скорость = 4
        5 ячейка - С5 - Инициатива = 2, Скорость = 3
        6 ячейка - С6 - Инициатива = 4, Скорость = 2
        7 ячейка - С7 - Инициатива = 1, Скорость = 1
        */
        battlefield.Add(new Warrior(ArmyEnum.Blue, 1, 6 ,6));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 2, 8 ,5));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 3, 9 ,5));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 4, 8 ,4));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 5, 2 ,3));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 6, 4 ,2));
        battlefield.Add(new Warrior(ArmyEnum.Blue, 7, 1 ,1));

        return battlefield;
    }

    private bool PlayStillContinues(List<Warrior> battlefield) {
        bool red = false, blue = false;

        foreach(Warrior w in battlefield) {
            if(w.Army == ArmyEnum.Red) red = true;
            if(w.Army == ArmyEnum.Red) blue = true;
        }

        return red & blue;
    }
}
