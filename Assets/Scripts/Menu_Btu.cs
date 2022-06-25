using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Btu : MonoBehaviour
{
    public void Edit_Btu()
    {
        SceneManager.LoadScene("SampleScene");
        Manager.Drop = true;
        Manager.OpenAi = false;
        Manager.Export = true;
    }
    public void Greet_Btu()
    {
        SceneManager.LoadScene("SampleScene");
        Manager.Drop = false;
        Manager.OpenAi = true;
        Manager.Export = false;
    }

}
