using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedCollCheck : MonoBehaviour
{
    public Player player;
    void Start()
    {
        // 하이어라키 상의 오브젝트 탐색은 태그 비용이 가장 저렴
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    // 물리작용 없이 이벤트만 호출해줌 / 리지드바디 추가 필수
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌");

            player.AetFeed();

            Destroy(this.gameObject);
        }         
    }
}
