using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadStartSceneAfterDelay(0.1f));
    }

    private IEnumerator LoadStartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UIManager.Instance.StartSceneLoadInit();
        SceneManager.LoadScene("StartSampleScene");
    }
}
