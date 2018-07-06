using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

    private void Awake()
    {
        OnGetBackpack(0);
    }

    public void OnGetBackpack(int level)
    {
        string text = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Data/BagSize.csv"), Encoding.UTF8);
        List<string> token = new List<string>(text.Split('\n')[level + 1].Split(','));

        bullet[(int)BulletType.YELLOW].SetMax(int.Parse(token[1]));
        bullet[(int)BulletType.BLUE].SetMax(int.Parse(token[2]));
        bullet[(int)BulletType.GREEN].SetMax(int.Parse(token[3]));
        bullet[(int)BulletType.RED].SetMax(int.Parse(token[4]));

        //bomb.SetMax(int.Parse(token[6]));

        bandage.SetMax(int.Parse(token[7]));
        firstAidKit.SetMax(int.Parse(token[8]));
        soda.SetMax(int.Parse(token[9]));
        pill.SetMax(int.Parse(token[10]));
    }

}
