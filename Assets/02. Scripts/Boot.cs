using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.SetInt(DescriptionUI.AlreadyDescKey, 0);//***빌드 할 경우 해당 명령어 삭제 필요
        StartCoroutine(LoadMainSceneAfterDelay(0.1f));
    }

    private IEnumerator LoadMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("StartSampleScene");
    }
}
