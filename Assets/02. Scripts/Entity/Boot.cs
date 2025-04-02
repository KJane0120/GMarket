using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임 시작시 초기화를 담당하는 클래스
/// 싱글톤 매니저를 한데 모아 초기화를 진행
/// </summary>
public class Boot : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadStartSceneAfterDelay(0.02f));
    }

    private IEnumerator LoadStartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UIManager.Instance.StartSceneLoadInit();
        SceneManager.LoadScene("StartScene");
    }
}
