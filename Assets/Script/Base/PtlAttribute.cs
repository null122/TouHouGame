using UnityEngine;

public class PtlAttribute : BaseInstance<PtlAttribute>
{
    /// <summary>
    /// 好感度
    /// </summary>
    public static int Feeling;
    /// <summary>
    /// 疲劳值
    /// </summary>
    public static int Fatigue;
    /// <summary>
    /// 环境值
    /// </summary>
    public static int Environmental;
    /// <summary>
    /// 知识值
    /// </summary>
    public static int Knowledge;
    /// <summary>
    /// 金钱
    /// </summary>
    public static int Money;
    /// <summary>
    /// 时间
    /// </summary>
    public static int Time;
    /// <summary>
    /// 天数
    /// </summary>
    public static int Day = 30;
    /// <summary>
    /// 当前图书馆对话事件
    /// </summary>
    public static string AtLibraryEvent = EventTag.拜访帕秋莉;
    /// <summary>
    /// 当前卧室事件
    /// </summary>
    public static string AtLivingRoomEvent = EventTag.起床;
    /// <summary>
    /// 是否买书
    /// </summary>
    public static int IsBook;
    /// <summary>
    /// 是否买扫把
    /// </summary>
    public static int IsSweeper=0;
    public static int IsFumo;
    public static bool IsYl;

    public static void UpPoint()
    {
        Fatigue = Fatigue >= 100 ? 100 : Fatigue;
        Environmental = Environmental >= 100 ? 100 : Environmental;
        Time = Time >= 100 ? 100 : Time;
        Fatigue = Fatigue <= 0 ? 0 : Fatigue;
        Environmental = Environmental <= 0 ? 0 : Environmental;
    }
}