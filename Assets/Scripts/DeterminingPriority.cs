using System.Collections;
using System.Collections.Generic;

public class DeterminingPriority
{
    static bool IsFirstHavePriority(Warrior f, Warrior s, int round) {
        if(f.Initiative == s.Initiative) {
            if(f.Speed == s.Speed) {
                if(f.Army == s.Army) {
                    return f.Cell < s.Cell;
                } else { // f.Army != s.Army
                    if (round % 2 == 0) { // even
                        return f.Army == Warrior.ArmyEnum.Blue;
                    } else { // odd
                        return f.Army == Warrior.ArmyEnum.Red;
                    }
                }
            } else { // f.Speed != s.Speed
                return f.Speed > s.Speed;
            }
        } else { // f.Initiative != s.Initiative
            return f.Initiative > s.Initiative;
        }
    }
}
