using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish List", menuName = "Fish List")]
public class ListOfFishes : ScriptableObject
{
    public Fish[] listOfFishes;
}
