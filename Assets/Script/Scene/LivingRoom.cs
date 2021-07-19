using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivingRoom : MonoBehaviour
{
    [Header("白天黑夜图片")]
    public Sprite[] AtTime;
    [Header("是否黑夜")]
    public bool IsDay;
    [Header("对话控制器")]
    public GameObject takercontrol;
    [Header("天数")]
    public Text Day;

    void Start()
    {
        if (PtlAttribute.Day==0)
        {
            SceneManager.LoadScene("CG");
        }
        PtlAttribute.UpPoint();
        Day.text = PtlAttribute.Day.ToString();
        IsDay = PtlAttribute.Time >= 10 ? true : false;
        if (IsDay)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<Image>().sprite = AtTime[0];
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<Image>().sprite = AtTime[1];
        }
        takercontrol.GetComponent<TakerSystem>().StartText(PtlAttribute.AtLivingRoomEvent);
        PtlAttribute.AtLivingRoomEvent = EventTag.起床;
    }

    public void NextDay()
    {
        PtlAttribute.Day -= 1;
        PtlAttribute.Fatigue -= 50;
        PtlAttribute.Time = 0;
        PtlAttribute.AtLivingRoomEvent = EventTag.起床;
        SceneManager.LoadScene("LivingRoom");
    }
}
