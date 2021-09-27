using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private const int ITERATION_COUNT = 20;

    void Start()
    {
        main();
    }

    private void main() {

        List<Warrior> battlefield = InitialiseBattlefield();
        //battlefield.Sort(DeterminingPriority.CompareWarriors);
        QueueMaker.SortQueue(battlefield);

        
        for(int i = 0; i < battlefield.Count; i++) {
            Debug.Log(battlefield[i]);
        }
        

        Debug.Log("Round " + RoundCount.Round);
        //PlayGame(battlefield);

        PlayStillContinues(battlefield);
    }

    private List<Warrior> InitialiseBattlefield() {
        List<Warrior> bf = new List<Warrior>();

        /*
        1 ячейка - К1 - Инициатива = 8, Скорость = 4
        2 ячейка - К2 - Инициатива = 8, Скорость = 4
        3 ячейка - К3 - Инициатива = 9, Скорость = 5
        4 ячейка - К4 - Инициатива = 4, Скорость = 3
        5 ячейка - К5 - Инициатива = 2, Скорость = 3
        6 ячейка - К6 - Инициатива = 3, Скорость = 4
        7 ячейка - К7 - Инициатива = 1, Скорость = 1
        */
        bf.Add(new Warrior(ArmyEnum.Red, 1, 8, 4));
        bf.Add(new Warrior(ArmyEnum.Red, 2, 8, 4));
        bf.Add(new Warrior(ArmyEnum.Red, 3, 9, 5));
        bf.Add(new Warrior(ArmyEnum.Red, 4, 4, 3));
        bf.Add(new Warrior(ArmyEnum.Red, 5, 2, 3));
        bf.Add(new Warrior(ArmyEnum.Red, 6, 3, 4));
        bf.Add(new Warrior(ArmyEnum.Red, 7, 1, 1));

        /*
        1 ячейка - С1 - Инициатива = 6, Скорость = 6
        2 ячейка - С2 - Инициатива = 8, Скорость = 5
        3 ячейка - С3 - Инициатива = 9, Скорость = 5
        4 ячейка - С4 - Инициатива = 8, Скорость = 4
        5 ячейка - С5 - Инициатива = 2, Скорость = 3
        6 ячейка - С6 - Инициатива = 4, Скорость = 2
        7 ячейка - С7 - Инициатива = 1, Скорость = 1
        */
        bf.Add(new Warrior(ArmyEnum.Blue, 1, 6 ,6));
        bf.Add(new Warrior(ArmyEnum.Blue, 2, 8 ,5));
        bf.Add(new Warrior(ArmyEnum.Blue, 3, 9 ,5));
        bf.Add(new Warrior(ArmyEnum.Blue, 4, 8 ,4));
        bf.Add(new Warrior(ArmyEnum.Blue, 5, 2 ,3));
        bf.Add(new Warrior(ArmyEnum.Blue, 6, 4 ,2));
        bf.Add(new Warrior(ArmyEnum.Blue, 7, 1 ,1));

        return bf;
    }

    private void PlayGame(List<Warrior> bf) {
        int turn = 0;
        int firstWarrionId = bf[0].ID;

        while(turn < ITERATION_COUNT & PlayStillContinues(bf)) {
            if(bf[0].ID == firstWarrionId) { // Start new round
                RoundCount.Round++;
                QueueMaker.SortQueue(bf);
                firstWarrionId = bf[0].ID;

                Debug.Log("Round " + RoundCount.Round);
            } else {
                if(bf[0].Army == bf[1].Army) {
                    // Pass turn
                    Debug.Log("Warrior " + bf[0] + " pass turn");
                    var w = bf[0];
                    bf.Remove(bf[0]);
                    bf.Add(w);
                } else {
                    // Kill warrior
                    bf.Remove(bf[1]);
                    Debug.Log("Warrior " + bf[0] + " kill " + bf[1]);
                }
            }

            Debug.Log("Actual battlefield ");
            foreach(Warrior w in bf) {
                Debug.Log(w);
            }
            Debug.Log(" ");
        }
        Debug.Log("End Game");
    }

    private bool PlayStillContinues(List<Warrior> bf) {
        bool red = false, blue = false;

        foreach(Warrior w in bf) {
            if(w.Army == ArmyEnum.Red) red = true;
            if(w.Army == ArmyEnum.Red) blue = true;
        }

        return red & blue;
    }
}
