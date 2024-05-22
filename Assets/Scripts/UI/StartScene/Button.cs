using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject closeGameObject;
    public GameObject openGameObject;


    public void GameOffBtn()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }
    public void CloseOpenBtn()
    {
        DestroyObject(closeGameObject);
        closeGameObject.SetActive(false);
        Instantiate(openGameObject);
        openGameObject.SetActive(true);
    }
    

    public void OpenBtn()
    {
        Instantiate(openGameObject);
        openGameObject.SetActive(true);
    }

    public void CloseBtn()
    {
        DestroyObject(closeGameObject);
    }

    public void MakePause()
    {
        Time.timeScale = 0f;
    }

    public void ResetPause()
    {
        Time.timeScale = 1f;
    }
}
