using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSceneManager : MonoBehaviour
{
    public GameObject indicator;
    public GameObject ohvenu;

    ARRaycastManager arRayManager;
    GameObject placedObject;

    public float relocationDistance = 1.0f;

    void Start()
    {
        indicator.SetActive(false);

        arRayManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        DetectedGround();

        // 마커 활성화 중 터치 시 오베누 모델 생성
        if(indicator.activeInHierarchy && Input.touchCount > 0)
        {
            // 첫번째 터치 상태 가져옴
            Touch touch = Input.GetTouch(0);
            // 터치 상태가 시작 상태이면 오베누 모델링을 마커 위치에 생성
            if(touch.phase == TouchPhase.Began)
            {
                // 생성된 오브젝트가 없을 시 모델 생성 후 placedObject에 할당
                if(placedObject == null)
                {
                    placedObject = Instantiate(ohvenu, indicator.transform.position, indicator.transform.rotation);
                }
                // 오브젝트가 있다면 모델링 위치 조정
                else
                {
                    if(Vector3.Distance(placedObject.transform.position, indicator.transform.position) > relocationDistance)
                    {
                        placedObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                    }
                }
            }
        }
    }

    // 바닥면 인식 후 마커 출력
    public void DetectedGround()
    {
        // 스크린 중앙값을 가져오는 변수 설정
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        // 충돌 위치 값을 저장할 리스트
        List<ARRaycastHit> hitInfo = new List<ARRaycastHit> ();

        // 스크린 중앙으로 레이 발사 후 충돌 값이 있을 경우
        if(arRayManager.Raycast (screenCenter, hitInfo, TrackableType.All))
        {
            // 마커 활성화
            indicator.SetActive (true);

            // 마커 위치를 충돌 위치로 설정
            indicator.transform.position = hitInfo[0].pose.position;
            indicator.transform.rotation = hitInfo[0].pose.rotation;

            // 바닥면과 겹치지 않도록 0.1 만큼 위쪽으로 배치
            indicator.transform.position += indicator.transform.up * 0.1f;
        }
        else
        {
            indicator.SetActive (false);
        }

    }
}
