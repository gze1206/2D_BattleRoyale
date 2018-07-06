using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Backpack backpack;
    public List<Scope> scopeList;

    public Weapon []weapon = new Weapon[2];
    public Bullet[] bullet = new Bullet[(int)BulletType.MAX];
    public Bombs bomb;

    public Armor helmet;
    public Armor vest;

    public Heal bandage;
    public Heal firstAidKit;
    public Buff soda;
    public Buff pill;

    public void OnGetBackpack(int level)
    {

    }

}
