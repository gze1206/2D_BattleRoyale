using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Equipment> equipUiList;

    public Backpack backpack;
    public List<Scope> scopeList;

    public Weapon []weapon = new Weapon[2];
    public Bullet[] bullet = new Bullet[(int)BulletType.MAX];

    public Bombs bomb;
    public Bombs smoke;

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
        //smoke.SetMax(int.Parse(token[6]));

        bandage.SetMax(int.Parse(token[7]));
        firstAidKit.SetMax(int.Parse(token[8]));
        soda.SetMax(int.Parse(token[9]));
        pill.SetMax(int.Parse(token[10]));

        if (level != 0)
        {
            backpack.gameObject.SetActive(true);
        }
    }

    public void ShowEquipUi(Equipment equip)
    {
        int index;
        for (index = 0; index < equipUiList.Count; index++)
        {
            if (equipUiList[index].gameObject.activeSelf == false 
             || equipUiList[index]._part == equip._part)
            {
                SetEquipUi(index, equip);
                return;
            }
        }
    }

    private void SetEquipUi(int index, Equipment info)
    {
        Transform targetUi = equipUiList[index].transform;

        targetUi.gameObject.SetActive(true);
        targetUi.GetChild(0).GetComponent<Text>().text = info.GetData();
    }
}
