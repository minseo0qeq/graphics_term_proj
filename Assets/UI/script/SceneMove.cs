using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScean : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
