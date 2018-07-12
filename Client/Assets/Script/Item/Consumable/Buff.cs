using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : Heal {

    public float speed;

    protected override void StartHeal()
    {
        base.StartHeal();
        //TODO: 캐릭터 이속 증가
    }

    protected override void EndHeal()
    {
        base.EndHeal();
        //TODO: 이속증가 해제
    }

    public override void OnPickUp(Inventory target)
    {
        base.OnPickUp(target);
        if (_name == "Soda")
            target.soda.AddCount(_count);
        else if (_name == "Pill")
            target.pill.AddCount(_count);
    }
}
