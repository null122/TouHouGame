using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Library : MonoBehaviour
{
    [Header("图书馆背景")]
    public Image BackGround;
    [Header("剧情文件")]
    public TextAsset text;
    [Header("背景")]
    public Sprite[] Librarys;
    public GameObject Home;
    private Image BG;
    [Header("帕秋莉模型")]
    public GameObject[] ThreePCL;
    [Header("对话框")]
    public GameObject take;
    [Header("选项")]
    public GameObject Chose;
    [Header("人物属性")]
    public Text Feeling;
    public Text Fatigue;
    public Text Environmental;
    public Text Knowledge;
    public Text Money;
    public Text Time;
    private void Start()
    {
        PtlAttribute.UpPoint();
        ActivePoint();
        foreach (var item in ThreePCL)
        {
            item.SetActive(false);
        }
        Chose.SetActive(false);
        BG = GetComponent<Image>();
        DisplayPCL();
        take.GetComponent<TakerSystem>().StartText(PtlAttribute.AtLibraryEvent);
        PtlAttribute.AtLibraryEvent = EventTag.拜访帕秋莉;
        SetLibraryBG(0);
    }

    /// <summary>
    /// 环境值增减
    /// </summary>
    /// <param name="point">增减点数</param>
    public void SetLibraryBG(int point)
    {
        PtlAttribute.Environmental += point;
        var PTL = PtlAttribute.Environmental;
        BG.sprite = PTL > 0 && PTL <= 25 ? Librarys[0] : BG.sprite;
        BG.sprite = PTL > 25 && PTL <= 50 ? Librarys[1] : BG.sprite;
        BG.sprite = PTL > 50 && PTL <= 75 ? Librarys[2] : BG.sprite;
        BG.sprite = PTL > 75 && PTL <= 100 ? Librarys[3] : BG.sprite;
        PtlAttribute.Environmental = PTL > 100 ? 100 : PtlAttribute.Environmental;
        PtlAttribute.Environmental = PTL < 0 ? 0 : PtlAttribute.Environmental;
    }

    /// <summary>
    /// 隐藏三个帕秋莉
    /// </summary>
    public void TouchHidePCL()
    {
        foreach (var item in ThreePCL)
        {
            item.SetActive(false);
        }
        if (PtlAttribute.Time > 10)
        {
            take.GetComponent<TakerSystem>().StartText(EventTag.时间太晚);
            DisplayPCL();
        }
        else
        {
            Chose.SetActive(true);
        }
    }

    /// <summary>
    /// 随机显示一个帕秋莉
    /// </summary>
    public void DisplayPCL()
    {
        ThreePCL[Random.Range(0, 3)].gameObject.SetActive(true);
    }

    /// <summary>
    /// 购物选项
    /// </summary>
    public void Shop()
    {
        if (PtlAttribute.Fatigue >= 100)
        {
            DisplayPCL();
            Chose.SetActive(false);
            return;
        }
        PtlAttribute.Environmental += 10;
        PtlAttribute.Time += 2;
        DisplayPCL();
        Chose.SetActive(false);
    }

    /// <summary>
    /// 打扫选项
    /// </summary>
    public void Clean()
    {
        if (PtlAttribute.Fatigue >= 100)
        {
            PtlAttribute.AtLibraryEvent = EventTag.疲劳过高;
            DisplayPCL();
            Chose.SetActive(false);
            return;
        }
        PtlAttribute.Time += 2;
        SetLibraryBG(-20-PtlAttribute.IsSweeper);
        PtlAttribute.AtLibraryEvent = EventTag.打扫之后;
        Chose.SetActive(false);
    }

    /// <summary>
    /// 读书选项
    /// </summary>
    public void Read()
    {
        if (PtlAttribute.Fatigue >= 100)
        {
            DisplayPCL();
            Chose.SetActive(false);
            PtlAttribute.AtLibraryEvent = EventTag.疲劳过高;
            return;
        }
        PtlAttribute.Knowledge += 20-(PtlAttribute.Environmental/10+10)+PtlAttribute.IsBook;
        PtlAttribute.Fatigue += 20;
        PtlAttribute.Feeling += 20-(PtlAttribute.Environmental / 10 + 10)+PtlAttribute.IsFumo;
        PtlAttribute.Time += 2;
        SetLibraryBG(10);
        PtlAttribute.AtLibraryEvent = EventTag.读书之后;
        Chose.SetActive(false);
    }

    /// <summary>
    /// 休息选项
    /// </summary>
    public void Rest()
    {
        PtlAttribute.Fatigue -= 40;
        PtlAttribute.Time += 2;
        PtlAttribute.AtLibraryEvent = EventTag.休息之后;
        SetLibraryBG(10);
        Chose.SetActive(false);
    }

    /// <summary>
    /// 工作选项
    /// </summary>
    public void Work()
    {
        if (PtlAttribute.Fatigue >= 100)
        {
            PtlAttribute.AtLibraryEvent = EventTag.疲劳过高;
            DisplayPCL();
            Chose.SetActive(false);
            return;
        }
        PtlAttribute.Time += 2;
        PtlAttribute.Money += Random.Range(10,90);
        PtlAttribute.Fatigue += 20;
        SetLibraryBG(10);
        Chose.SetActive(false);
    }

    /// <summary>
    /// 返回菜单
    /// </summary>
    public void BackHome()
    {
        if (PtlAttribute.Time>=10)
        {
            PtlAttribute.AtLivingRoomEvent = EventTag.晚上回家1;
        }
        else
        {
            PtlAttribute.AtLivingRoomEvent = EventTag.回房间时;
        }
    }

    /// <summary>
    /// 菜单返回按钮
    /// </summary>
    public void ReturnButton()
    {
        DisplayPCL();
        Chose.SetActive(false);
    }

    /// <summary>
    /// 刷新菜单
    /// </summary>
    public void ActivePoint()
    {
        Feeling.text = PtlAttribute.Feeling.ToString();
        Fatigue.text = PtlAttribute.Fatigue.ToString();
        Environmental.text = PtlAttribute.Environmental.ToString();
        Knowledge.text = PtlAttribute.Knowledge.ToString();
        Money.text = PtlAttribute.Money.ToString();
        Time.text = PtlAttribute.Time.ToString();
    }
}
