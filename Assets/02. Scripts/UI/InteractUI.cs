using System.Collections;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public IEnumerator FadeOutErrorMsg()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
