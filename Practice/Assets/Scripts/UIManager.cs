using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startUI;

    public GameObject ctrlUI;

    public GameObject endUI;

    void Start()
    {

    }

    void Update()
    {
        
    }

    // void는 리턴 값이 없다는 뜻
    public void Menu()
    {
        startUI.SetActive(false);
        ctrlUI.SetActive(true);        
    }

    public bool GameOverUI(bool isp)
    {
        endUI.SetActive(!isp);
        return isp;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MobileScene");
    }

}
