using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Edit
{
    public static bool edit_;
}
public class Menu_Btu : MonoBehaviour
{
    public void Edit_Btu()
    {
        SceneManager.LoadScene("SampleScene");
        Edit.edit_ = true; print("b");
    }
    public void Greet_Btu()
    {
        SceneManager.LoadScene("SampleScene");
        Edit.edit_ = false;
        print("a");
    }

}
