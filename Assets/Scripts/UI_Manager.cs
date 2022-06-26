using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
{
    public void Edit_Btu()
    {
        SceneManager.LoadScene(1);
        Manager.Drop = true;
        Manager.OpenAi = false;
        Manager.import = true;
    }
    public void Greet_Btu()
    {
        SceneManager.LoadScene(1);
        Manager.Drop = false;
        Manager.OpenAi = true;
        Manager.import = false;
    }
}
