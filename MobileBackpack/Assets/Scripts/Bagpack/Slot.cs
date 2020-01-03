using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 物品槽类
/// </summary>
public class Slot : MonoBehaviour, IPointerClickHandler,IDragHandler,IEndDragHandler
{

    public GameObject itemPrefab;//需要存储的物品预设
    private ItemUI pickedUpItem;
    private Transform pickedUpSlot;
    /// <summary>
    ///(重点) 向物品槽中添加（存储）物品，如果自身下面已经有Item了，那就Item.amount++;
    /// 如果没有，那就根据ItemPrefab去实例化一个Item，放在其下面
    /// </summary>
    public void StoreItem(Item item)
    {
        if (this.transform.childCount == 0)//如果这个物品槽下没有物品，那就实例化一个物品
        {
            GameObject itemGO = Instantiate<GameObject>(itemPrefab) as GameObject;
            itemGO.transform.SetParent(this.transform);//设置物品为物品槽的子物体
            itemGO.transform.localScale = Vector3.one;//正确保存物品的缩放比例
            itemGO.transform.localPosition = Vector3.zero;//设置物品的局部坐标，为了与其父亲物品槽相对应
            itemGO.GetComponent<ItemUI>().SetItem(item);//更新ItemUI
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddItemAmount();//默认添加一个
        }
    }

    //判断物品个数是否超过物品槽的容量Capacity
    public bool isFiled()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capacity; //true表示当前数量大于等于容量，false表示当前数量小于容量
    }

    //根据索引器得到当前物品槽中的物品类型
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }

    //根据索引器得到当前物品槽中的物品ID
    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log(eventData.pointerPress.name);
        if (this.transform.childCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && eventData.pointerPress.tag == "Slot")
        {
            pickedUpSlot = this.transform;
            pickedUpItem = this.transform.GetChild(0).GetComponent<ItemUI>();
            InventoryManager.Instance.PickUpItem(pickedUpItem.Item, pickedUpItem.Amount);
            pickedUpItem.Hide();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (InventoryManager.Instance.IsPickedItem == false) return;
        if (eventData.pointerCurrentRaycast.isValid == false)
        {
            Debug.Log("reset");
            pickedUpItem.transform.localPosition = Vector3.zero;
            pickedUpItem.transform.localScale = Vector3.one;
        }
        GameObject endSlot = eventData.pointerCurrentRaycast.gameObject;
        if (Input.GetTouch(0).phase == TouchPhase.Ended && endSlot.transform.childCount == 0 && endSlot.tag == "Slot")
        {
            Debug.Log("put");
            pickedUpItem.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            pickedUpItem.transform.localScale = Vector3.one;
            pickedUpItem.transform.localPosition = Vector3.zero;

        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended && endSlot.transform.childCount > 0 && endSlot.tag == "Slot")
        {
            Transform exist = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0);
            exist.SetParent(pickedUpSlot);
            exist.localScale = Vector3.one;
            exist.localPosition = Vector3.zero;
            pickedUpItem.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            pickedUpItem.transform.localScale = Vector3.one;
            pickedUpItem.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("reset");
            pickedUpItem.transform.localPosition = Vector3.zero;
            pickedUpItem.transform.localScale = Vector3.one;
        }
        pickedUpItem.Show();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Input.touchCount > 0 && this.transform.childCount > 0 && eventData.pointerPress.tag == "Slot")
        {
            Debug.Log("Down");
            string tips = this.transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            Debug.Log(tips);
            InventoryManager.Instance.ShowToolTip(tips);
        }
    }
}
