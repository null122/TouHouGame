using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakerSystem : MonoBehaviour
{
    [Header("对话框预制体")]
    /// <summary>
    /// 对话框所需预制体
    /// </summary>
    public Image Face;
    public Text Text;
    [Header("剧情文本")]
    public TextAsset PlotText;
    [Header("获取到的字符串")]
    public string[] json;
    [Header("当前读取行数")]
    public int Index;

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& Index == json.Length)
        {
            gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && Index != json.Length)
        {
            RefreshText();   
        }
    }

    public void Pass()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 刷新文本
    /// </summary>
    public void RefreshText()
    {
        Face.sprite = GetText.GetInstance().GetFace(json[Index]);
        Text.text = json[Index].Split(':')[1];
        Index++;
    }

    /// <summary>
    /// 刷新对话UI
    /// </summary>
    public void StartText(string text)
    {
        gameObject.SetActive(true);
        Index = 0;
        json = GetText.GetInstance().GetEventText(text, PlotText);
        RefreshText();
    }
    
}
