using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { YELLOW, RED, GREEN, BLUE, MAX };
public class Bullet : Item
{
    private BulletType _type;

    public override void OnPickUp(Inventory target)
    {
        base.OnPickUp(target);
        target.bullet[(int)_type].AddCount(_count);
    }

}
