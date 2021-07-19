using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public GameObject take;
    void Start()
    {
        take.GetComponent<TakerSystem>().StartText(EventTag.博丽神社);
        PtlAttribute.Time += 2;
        PtlAttribute.Money += 200;
    }
}
