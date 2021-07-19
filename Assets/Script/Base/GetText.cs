using Newtonsoft.Json.Linq;
using UnityEngine;

public class GetText : BaseInstance<GetText>
{
    /// <summary>
    /// 获取事件剧情
    /// </summary>
    /// <param name="eventname">事件名称</param>
    /// <param name="textAsset">剧情的json</param>
    /// <returns></returns>
    public string[] GetEventText(string eventname,TextAsset textAsset)
    {
        var json = textAsset.text;
        var text = JObject.Parse(json)[eventname]["Text"].ToObject<string[]>();
        return text;
    }
    
    /// <summary>
    /// 获取头像
    /// </summary>
    /// <param name="path">头像路径</param>
    /// <returns></returns>
    public Sprite GetFace(string text)
    {
        string[] path = text.Split(':');
        return Resources.Load<Sprite>("TakerFace"+path[0].ToString());
    }
}
