using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class click : MonoBehaviour 
{
    private bool a = false;
    public int cash;
    private int pg;
    private int storage  ;
    private int storage_max = 10;
    public int ind;

    public Item[] item;


    public GameObject pb;
    public Text text_cash;
    public Text text_storage;

    protected int Cash
    {
        get { return cash; }
        set 
        {
            if(value >= 0 )
            {
                cash = value;
            }
            else
            {
                Debug.Log("Недостаточно денег");
            }
        }
    }
    private void Start()
    {
        Cash+=3;
        
    }
    private void FixedUpdate()
    {
        text_cash.text = "$ : " + cash;
        text_storage.text = storage + "/" + storage_max;
    }
    public void Click()
    {
        Index();
        if (storage > 0 && item[ind].vol > 0) 
        {
            if (pg >= 5)
            {
                pb.transform.localScale = new Vector2(pb.transform.localScale.x - pg * 3, pb.transform.localScale.y);
                cash += item[ind].sell;
                storage--;
                item[ind].vol--;
                pg = 0;
            }
            else
            {
                pg += 1;
                pb.transform.localScale = new Vector2(pb.transform.localScale.x + 3, pb.transform.localScale.y);
            }
        }
    }
    public void Index()
    {
        for (int i = 0; ;)
        {

            if (item[i].vol == 0)
            {
                i++;
            }
            else
            {
                ind = i;
                break;
            }
            if (i > item.Length - 1)
            {
                i = 0;
                break;
            }
        }
    }
    public void Worker()//покупка рабочего
    {
        if(cash>=1 && a != true)
        {
            Cash -=1;
            StartCoroutine(worker());
            a = true;
        }
    }
    IEnumerator worker ()
    {
        while(true)
        {
            Click();
            yield return new WaitForSeconds(1);
        }
    }
    public void Plus1(int i)
    {
        if (item[i].av == true)
        {
            if (storage < storage_max)
            {
                if (cash >= item[i].buy)
                {
                    item[i].vol++;
                    storage++;
                }
                Cash -= item[i].buy;
            }
            else
            {
                Debug.Log("Склад переполнен");
            }
        }
        else
        {
            Debug.Log("Недоступно");
        }
    }
    public void Aval(int i)
    {
        if (item[i].av == true)
        {
            if (storage < storage_max)
            {
                if (cash >= item[i].buy)
                {
                    item[item[i].ind].av = true;
                }
                Cash -= item[i].buy;
            }
            else
            {
                Debug.Log("Склад переполнен");
            }
        }
        else
        {
            Debug.Log("Недоступно");
        }
    }
    public void Storage(int c)
    {
        if (c < Cash)
        { 
            storage_max += 5;
        }
        Cash -= c;
    }

}

[Serializable]
public class Item
{
    public int buy;
    public int sell;
    public int vol;
    public bool av;
    public int ind;
}
