using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoundCount
{
    public static int Round{get {return round;} 
                            set {round = value;}}
    private static int round = 0;
}
