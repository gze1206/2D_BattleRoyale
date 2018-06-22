using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    int count = 0;

    public virtual void Use()
    {
        count -= 1;
    }


}
