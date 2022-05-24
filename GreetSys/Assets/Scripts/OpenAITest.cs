using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class OpenAITest : MonoBehaviour
{
    // path 還沒改成從檔案位置開始找
    private string path = "D:/Unity_Project/GreetSys/Assets/waiter_prompt.txt";
    public string rep = "";
    public TMP_Text text;
    //寫入
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
    private void Start()
    {
    }

    //執行GPT-3
    public void runGPT()
    {
        var task = StartAsync();
        
    }
    async Task StartAsync()
    {
        //讀取
        if (File.Exists(path) == false)
        {
            Debug.LogError("txt missing: " + path);
        }
        var txt = File.ReadAllText(path);

        //api金鑰
        var apikey = "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";

        //訓練模組設定
        var api = new OpenAI_API.OpenAIAPI(apikey, engine: "text-davinci-002");
        string prompt = txt;
        var result = await api.Completions.CreateCompletionAsync(
            prompt,
            temperature: 0.9,
            max_tokens: 150,
            top_p: 1);

        //var result = await api.Search.GetBestMatchAsync("RaycastHit", "Unity3D", "Godot", "Unreal Engine", "GameMaker");
        //Console.WriteLine(result.ToString());

        //輸出
        text.text = result.ToString();
        //寫入文件
        WriteTxT(path, result.ToString() + "\nHuman: ");
    }
}