using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Taker;
    public GameObject Yl;
    void Start()
    {
        Yl.SetActive(!PtlAttribute.IsYl);
        Taker.GetComponent<TakerSystem>().StartText(EventTag.香霖堂);
    }

    /// <summary>
    /// 书本
    /// </summary>
    public void Book()
    {
        if (PtlAttribute.Money<=1000)
        {
            Taker.GetComponent<TakerSystem>().StartText(EventTag.没钱时);
        }
        else
        {
            PtlAttribute.IsBook += 5;
            PtlAttribute.Money -= 1000;
            Taker.GetComponent<TakerSystem>().StartText(EventTag.购买成功);
        }
    }

    /// <summary>
    /// 扫把
    /// </summary>
    public void Sweeper()
    {
        if (PtlAttribute.Money <= 1000)
        {
            Taker.GetComponent<TakerSystem>().StartText(EventTag.没钱时);
        }
        else
        {
            PtlAttribute.IsSweeper += 5;
            PtlAttribute.Money -= 1000;
            Taker.GetComponent<TakerSystem>().StartText(EventTag.购买成功);
        }
    }

    /// <summary>
    /// 轮椅
    /// </summary>
    public void LY()
    {
        if (PtlAttribute.Money <= 2000)
        {
            Taker.GetComponent<TakerSystem>().StartText(EventTag.没钱时);
        }
        else
        {
            
            PtlAttribute.IsYl = true;
            PtlAttribute.Money -= 2000;
            Taker.GetComponent<TakerSystem>().StartText(EventTag.购买成功);
        }
    }

    /// <summary>
    /// fumo
    /// </summary>
    public void Fomo()
    {
        if (PtlAttribute.Money <= 1000)
        {
            Taker.GetComponent<TakerSystem>().StartText(EventTag.没钱时);
        }
        else
        {
            PtlAttribute.IsFumo += 5;
            PtlAttribute.Money -= 1000;
            Taker.GetComponent<TakerSystem>().StartText(EventTag.购买成功);
        }
    }
}
