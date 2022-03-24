using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 move;

    public bool isFeed = true;

    public GameObject players;

    public GameObject playersMove;

    public List<GameObject> bodyList;

    // 키코드는 열거형이므로 아래와 같이 선언 시 인스펙터 창에서 드랍다운 확인 가능
    // public KeyCode keyValue;

    void Start()
    {
        // players는 프리팹을 포인터한 것에 지나지 않음 하이어라키에는 올라가지 않음
        // 해서 playersMove라는 하이어라키에 올라가는 게임오브젝트를 생성해 움직임을 줌
        playersMove = Instantiate(players);

        bodyList.Add(playersMove);

        // while문은 계속 실행 되기 때문에 start에서 한 번만 실행 해주면 업데이트와 같은 효과
        StartCoroutine(Movement());
    }

    // 업데이트는 콜백 함수임 / 이동과 같은 상시 활성 기능을 돌리기 위해 업데이트에 부하를 줄 필요가 없음
    void Update()
    {
        // 키 입력 기능과 입력 값을 받아 실행하는 부분을 나누어 줌
        // 추후 키 입력 방식을 바꿀 때 함수로 빼서 쓰면 됨으로 훨씬 용이함 
        /*/
        if(Input.GetKey(KeyCode.DownArrow))
        {
            move = Vector3.back;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector3.right;
        }
        /*/

        MobileMovement();

        // 정지 기능
        if (Input.GetKey(KeyCode.Space))
        {
            move = Vector3.zero;
        }
    }

    void MobileMovement()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move = Vector3.back;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector3.right;
        }
    }

    IEnumerator Movement()
    {
        // while문은 계속 반복 됨으로 브레이크가 필수로 있어야함
        while (true)
        {
            
            yield return new WaitForSeconds(0.0001f);

            if (isFeed)
            {
                if(bodyList.Count <= 1)
                {
                    bodyList[0].transform.position += move;
                }
                else 
                {
                    // 0번이 1번 앞으로 가면 순서 인덱스를 바꿔야함
                    Debug.Log("배열 변환");
                    
                    bodyList[bodyList.Count - 1].transform.position = bodyList[0].transform.position + move;
                    bodyList[0].GetComponent<MeshRenderer>().material.color = Color.blue;

                    bodyList.Insert(0, bodyList[bodyList.Count - 1]);                 
                    bodyList.RemoveAt(bodyList.Count - 1);
                    bodyList[0].GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            else
            {
                playersMove = Instantiate(players);
                // 1번 리스트에 오브젝트 추가
                bodyList.Add (playersMove);
                // 카운트로 리스트 수를 불러옴(2 -1 = 1마지막 리스트 수) 
                bodyList[bodyList.Count-1].transform.position = bodyList[0].transform.position + move;
                isFeed = true;
            }
        }
    }

    public void AetFeed()
    {
        Debug.Log("생성");

        isFeed = false;
    }

    /*/
    - 맵을 클릭하여 이동하는 방법은 1000x1000 타일을 만들고 해당 타일이 클릭되면 이동되도록 하는 것
- 유니티 내장 네비게이션 시스템은 엉망임
- 유니티는 싱글스레드로서 코루틴으로 시간 딜레이 주는 것이 가능(invoke 등 기능은 호불호가 있음)
- 프로그램을 개발할 때 시작과 끝이 명확한 한 사이클을 구축 해놓고 개발해야함
각종 에셋들에서 작업 기간이 늘어지면 안 됨

- 업데이트는 자원을 많이 씀
- 카메라 위치를 잡을 때엔 전체 맵을 조망하도록 설정
- 해상도 설정은 처음에 진행 후 바꾸지 않는 것을 권장(변경에 따른 비용을 생각)
- 슬리더 같은 움직임을 구현할 때 뒷번의 오브젝트가 따라오는 것이 아닌 이동할 방향으로 오브젝트를 앞으로 이어붙이는 형식으로 이동
*/
}
