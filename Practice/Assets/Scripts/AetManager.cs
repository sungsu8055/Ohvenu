using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetManager : MonoBehaviour
{
    public GameObject aet;

    public Player player;


    void Start()
    {
        // ������Ʈ�� �ҷ����� �κ��� �ڷ�ƾ ���ຸ�� �ڿ� ����Ǿ� �ڷ�ƾ �ȿ��� �ҷ����� ���ϴ� ���� �߻�
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        StartCoroutine(Create());
    }

    void Update()
    {
        
    }

    public IEnumerator Create()
    {
        while (player.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject a = Instantiate(aet);

            // �÷��� ��Ʈ�� ���� �� ������ ��Ʈ�� �÷��� ���� �� ��
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

            // �÷��� ��Ʈ�� ���� �� ������ ��Ʈ�� �÷��� ���� �� ��
            int x = Random.Range(-50, 51);
            int z = Random.Range(-50, 51);

            a.transform.position = new Vector3(x, 1, z);
        }
    }
    /*/
}
