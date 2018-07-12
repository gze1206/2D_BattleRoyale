using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : Equipment {


    public override void OnPickUp(Inventory inventory)
    {
        base.OnPickUp(inventory);
        inventory.OnGetBackpack(_level);
        inventory.ShowEquipUi(this);
        //TODO: 캐릭터에 같은 부위가 있으면 그 부위 삭제 후 장착
    }
}
