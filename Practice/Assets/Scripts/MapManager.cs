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
        // �� ���� ������Ʈ�� ���� �θ� ������Ʈ ����
        GameObject parent = new GameObject("Parent");

        // x�� for���� �� �� ��ȯ �� z�� for���� 100�� �����, x �� �������� z�� 100�� ����
        for (int x = 0; x < 100; x++)
        {
            for(int z = 0; z < 100; z++)
            {
                GameObject a = Instantiate(map);
                a.name = "x : " + x + " z : " + z;
                a.transform.position = new Vector3(x,0,z);

                // ¦�� ĭ�� Ȧ�� ĭ�� ������ ���͸��� ���� ����
                // ������ ���� �� 0���� �������� ¦�� 1�� ������ Ȧ���� �Ǵ� ������ ��ǥ�� ¦�� Ȧ���� ����
                /*/
                if(z % 2 == 0 && x % 2 == 0)
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0,0,0,255);
                else if(z % 2 == 1 && x % 2 == 1)
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 0, 255);
                /*/

                // �θ� ������Ʈ ����
                a.transform.SetParent(parent.transform);
            }
        }
        // �� ���� ������Ʈ�� �θ��� ��ġ�� �߾����� ����
        parent.transform.position = new Vector3(-50, 0, -50);
    }
}
