using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject map;

    void Start()
    {
        MapCreate();
    }

    void Update()
    {
        
    }

    void MapCreate()
    {
        // 맵 구성 오브젝트가 속할 부모 오브젝트 생성
        GameObject parent = new GameObject("Parent");

        // x의 for문이 한 번 순환 시 z의 for문이 100번 실행됨, x 열 기준으로 z가 100번 생성
        for (int x = 0; x < 100; x++)
        {
            for(int z = 0; z < 100; z++)
            {
                GameObject a = Instantiate(map);
                a.transform.position = new Vector3(x,0,z);

                // 짝수 칸과 홀수 칸에 번갈아 매터리얼 색상 변경
                // 나머지 연산 후 0으로 떨어지면 짝수 1이 나오면 홀수가 되는 것으로 좌표의 짝수 홀수를 구분
                if(z % 2 == 0 && x % 2 == 0)
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0,0,0,255);
                else if(z % 2 == 1 && x % 2 == 1)
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 0, 255);

                // 부모 오브젝트 설정
                a.transform.SetParent(parent.transform);
            }
        }
        // 맵 구성 오브젝트의 부모의 위치를 중앙으로 맞춤
        parent.transform.position = new Vector3(-50, 0, -50);
    }
}
