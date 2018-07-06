using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    protected enum Part { Helmet, Bag, Vest, Weapon };
    protected Part _part;
    protected int _level;

    public override void OnPickUp(Inventory inventory)
    {
        //TODO: 캐릭터에 같은 부위가 있으면 그 부위 삭제 후 장착
    }
}
