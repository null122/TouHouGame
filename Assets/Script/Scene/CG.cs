using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CG : MonoBehaviour
{
    public GameObject Taker;
    public Sprite bg;
    void Start()
    {
        if (PtlAttribute.IsYl && PtlAttribute.Feeling >= 700 && PtlAttribute.Knowledge >= 700)
        {
            gameObject.GetComponent<Image>().sprite = bg;
            Taker.GetComponent<TakerSystem>().StartText(EventTag.邀请成功);
        }
        else
        {
            Taker.GetComponent<TakerSystem>().StartText(EventTag.邀请失败);
        }
        gameObject.GetComponent<Image>().sprite = bg;
        Taker.GetComponent<TakerSystem>().StartText(EventTag.邀请成功);
    }

    public void end()
    {
        Application.Quit();
    }
}

