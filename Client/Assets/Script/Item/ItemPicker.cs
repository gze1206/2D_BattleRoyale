using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPicker : MonoBehaviour
{
    public Inventory inventory;

    public Text _infoText;
    public GameObject _infoObject;

    [SerializeField]
    private Item _target = null;
    private Coroutine coroutine = null;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(new Vector3(-0.3f, 0, 0));

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector3(0.3f, 0, 0));

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(new Vector3(0, -0.3f, 0));

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(new Vector3(0, 0.3f, 0));
    }

    //아이템과 충돌시 정보창 활성화
    public void OnEnterItem(Item target)
    {
        ShowInfo(true, target);
        if (coroutine == null)
            coroutine = StartCoroutine("InputUpdate");
    }

    //아이템 충돌 범위를 벗어났을떄 정보창 비활성화
    public void OnExitItem(Item target)
    {
        if (_target != target)
            return;

        ShowInfo(false, null);
        StopCoroutine(coroutine);
        coroutine = null;
    }

    //아이템 정보 화면에 출력
    void ShowInfo(bool isShow, Item itemData)
    {
        if (itemData)
            _infoText.text = itemData.GetData();
        _target = itemData;
        _infoObject.transform.position = transform.position;
        _infoObject.SetActive(isShow);
    }

    //아이템 획득
    private void GetItem()
    {
        _target.OnPickUp(inventory);
        ShowInfo(false, null);
    }

    //F눌렀는지 확인
    IEnumerator InputUpdate()
    {
        while (true)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                GetItem();
                coroutine = null;
                yield break;
            }
            yield return null;
        }
    }
}
