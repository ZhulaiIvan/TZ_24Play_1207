using System.Collections;
using UnityEngine;

public class CollectCubeText : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroyText());
    }

    private IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
