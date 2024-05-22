using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Setting setting;
    public GameObject closeGameObject;
    public GameObject openGameObject;

    private void Awake()
    {
        setting = openGameObject.GetComponent<Setting>();
    }

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

}
