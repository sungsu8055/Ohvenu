using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedCollCheck : MonoBehaviour
{
    public Player player;
    void Start()
    {
        // ���̾��Ű ���� ������Ʈ Ž���� �±� ����� ���� ����
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    // �����ۿ� ���� �̺�Ʈ�� ȣ������ / ������ٵ� �߰� �ʼ�
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("�浹");

            player.AetFeed();

            Destroy(this.gameObject);
        }         
    }
}
