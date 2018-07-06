using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    [SerializeField]
    private Text _text = null;
    [SerializeField]
    protected string _name;

    [SerializeField]
    protected int _count = 0;
    protected int _maxCount = 1;

    private Collider2D target = null;

    public virtual void Use(int count = 1)
    {
        _count -= count;
        UiUpdate();
    }

    public virtual void AddCount(int count)
    {
        _count = Mathf.Min(_maxCount, _count + count);
        UiUpdate();
    }

    public void SetMax(int maxCount)
    {
        _maxCount = maxCount;
    }

    public virtual void OnPickUp(Inventory target)
    {
        gameObject.SetActive(false);
    }

    public virtual string GetData()
    {
        return _name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && target == null)
        {
            target = collision;
            collision.GetComponent<ItemPicker>().OnEnterItem(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target == collision)
        {
            collision.GetComponent<ItemPicker>().OnExitItem();
            target = null;
        }
    }

    private void UiUpdate()
    {
        if(_text)
            _text.text = _count.ToString();
    }
}
