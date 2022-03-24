using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetManager : MonoBehaviour
{
    public GameObject aet;

    void Start()
    {
        StartCoroutine(Create());
    }

    void Update()
    {
        
    }


    public IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject a = Instantiate(aet);

            // 플롯은 인트를 받을 수 있으나 인트는 플롯을 받지 못 함
            int x = Random.Range(-50, 51);
            int z = Random.Range(-50, 51);

            a.transform.position = new Vector3(x, 1, z);
        }
    }

    /*/
    public IEnumerator PoisonFeedCreate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject a = Instantiate(aet);

            // 플롯은 인트를 받을 수 있으나 인트는 플롯을 받지 못 함
            int x = Random.Range(-50, 51);
            int z = Random.Range(-50, 51);

            a.transform.position = new Vector3(x, 1, z);
        }
    }
    /*/
}
