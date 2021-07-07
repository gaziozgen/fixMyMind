using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    public string[] otherSide;
    public string[] us;
    public int[] finishIndexes;
    public int[] happinesPoints;
}
