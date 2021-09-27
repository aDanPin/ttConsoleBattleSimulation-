using System.Collections;
using System.Collections.Generic;

public class QueueMaker
{
    public static void SortQueue(List<Warrior> wPool) {
        wPool.Sort(DeterminingPriority.CompareWarriors);
    }
}
