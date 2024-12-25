using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScean : MonoBehaviour
{
    public void LoadFFKSampleScene()
    {
        SceneManager.LoadScene("FFK Sample Scene");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
