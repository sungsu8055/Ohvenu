using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Player set_IsPlaying;

    UIManager uiManager;

    void Start()
    {
        set_IsPlaying = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Debug.Log(set_IsPlaying.isPlaying);

        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    void Update()
    {
        if(transform.position.x >= 50 || transform.position.x <= -50)
        {
            Debug.Log(transform.position.x);

            this.transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        /*/
        else if (transform.position.x <= -50)
        {
            Debug.Log(transform.position.x);

            this.transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        //*/
        else if (transform.position.z >= 50 || transform.position.z <= -50)
        {
            Debug.Log(transform.position.z);

            this.transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }
        /*/
        else if (transform.position.z <= -50)
        {
            Debug.Log(transform.position.z);

            this.transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }
        //*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("자체 충돌");

            set_IsPlaying.isPlaying = false;

            uiManager.GameOverUI(set_IsPlaying.isPlaying);
        }
    }
}
