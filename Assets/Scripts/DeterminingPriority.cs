using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminingPriority : MonoBehaviour
{
    public static bool IsFirstHavePriority(Warrior f, Warrior s, int round) {
        if(f.Initiative == s.Initiative) {
            if(f.Speed == s.Speed) {
                if(f.Army == s.Army) {
                    return f.Cell < s.Cell;
                } else { // f.Army != s.Army
                    if (round % 2 == 0) { // even
                        return f.Army == ArmyEnum.Blue;
                    } else { // odd
                        return f.Army == ArmyEnum.Red;
                    }
                }
            } else { // f.Speed != s.Speed
            Debug.Log(2);
                
                return f.Speed > s.Speed;
            }
        } else { // f.Initiative != s.Initiative
            Debug.Log(1);
            return f.Initiative > s.Initiative;
        }
    }

    public static int CompareWarriors(Warrior f, Warrior s) {
        if(f.ID == s.ID) return 0;
        if(IsFirstHavePriority(f, s, RoundCount.Round)) return 1;
        return -1;
    }
}
