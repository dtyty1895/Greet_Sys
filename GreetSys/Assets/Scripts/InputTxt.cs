
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputTxt : MonoBehaviour
{
    public TMP_InputField Target;
    public string inputTxt = "";
    // path �٨S�令�q�ɮצ�m�}�l��
    private string path = "D:/Unity_Project/GreetSys/Assets/waiter_prompt.txt";
    // �g�J
    private void WriteTxT(string p, string t)
    {
        try
        {
            StreamWriter sw = File.AppendText(p);
            sw.WriteLine(t);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Write Error" + e.Message);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    //�����s��üg�J ����i��ݭn�g�@�ӦA����J�ɲM�����
    public void endedit()
    {
        inputTxt = Target.GetComponent<TMP_InputField>().text;
        WriteTxT(path, inputTxt);
    }
}

