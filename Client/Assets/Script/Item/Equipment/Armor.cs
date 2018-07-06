using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{


    public override string GetData()
    {
        return _name + "레벨" + _level.ToString();
    }
}
