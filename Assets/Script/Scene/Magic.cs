using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject Taker;
    void Start()
    {
        PtlAttribute.Fatigue += 30;
        PtlAttribute.Knowledge += 20;
        PtlAttribute.Money += 100 + Random.Range(50, 400);
        Taker.GetComponent<TakerSystem>().StartText(EventTag.魔法之森);
    }
}
