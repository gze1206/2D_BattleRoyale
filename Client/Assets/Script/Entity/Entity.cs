using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int HP;
    public bool DeadObj;

    public virtual void Dameged(int damege)
    {
        if(DeadObj)
            HP -= damege;
    }
}
