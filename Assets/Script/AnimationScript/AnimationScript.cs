using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationScript : MonoBehaviour
{
    public Animator Animator;
    [Header("动画加载时间")]
    public float Time = 1f;
    public void StartGame(string SceneName)
    {
        StartCoroutine(LoadGame(SceneName));
    }

    IEnumerator LoadGame(string SceneName)
    {
        Animator.SetTrigger("Start");

        yield return new WaitForSeconds(Time);

        SceneManager.LoadScene(SceneName);
    }
    public void end()
    {
        Application.Quit();
    }
}
