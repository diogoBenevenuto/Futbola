using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFxKillBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillFX());
    }
    IEnumerator KillFX()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
