
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
    // path 還沒改成從檔案位置開始找
    private string path = "D:/Unity_Project/GreetSys/Assets/waiter_prompt.txt";
    // 寫入
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

    //結束編輯並寫入 之後可能需要寫一個再次輸入時清空欄位
    public void endedit()
    {
        inputTxt = Target.GetComponent<TMP_InputField>().text;
        WriteTxT(path, inputTxt);
    }
}

