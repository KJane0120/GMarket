using System.Collections;
using UnityEngine;

/// <summary>
/// 상호작용 UI 클래스입니다.
/// </summary>
public class InteractUI : MonoBehaviour
{
    /// <summary>
    /// 에러 메시지를 표시합니다.
    /// 1초 뒤에 사라집니다.
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeOutErrorMsg()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
