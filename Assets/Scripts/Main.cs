using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.EventSystems;
public class Main : MonoBehaviour
{
    /// <summary>
    /// idenitfy age in UDP data.
    /// </summary>
    public UDPReceive udpReceive;
    private string data;
    string[] text;

    public Animator an;
    private bool btn_active = false;



    public GameObject Plus;
    public GameObject Edit;



    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip Test_sound;

    [SerializeField] private AudioClip[] sound1 = new AudioClip[6];

    /// <summary>
    /// How to call the age of the range.
    /// </summary>
    string Hello_Kid = "?A?n?A?p?k??";
    string Hello_Young = "?A?n?A???";
    string Hello_Old = "?A?n?A????";

    string Hello_Girl = "?A?n?A?p?k??";
    string Hello_Pretty = "?A?n?A???k";
    string Hello_Old_Girl = "?A?n?A????";

    /// <summary>
    /// Age of the number.
    /// </summary>
    int age_type;

    /// <summary>
    /// Canv Manager.
    /// </summary>
    public GameObject dropdwon_Manager;
    public GameObject OpenAi_Manager;
    public GameObject Import_Manager;

    public GameObject EditText;

    /// <summary>
    /// Edit dropdown.
    /// </summary>
    public TMP_InputField txt;
    /// <summary>
    /// Dropdown of num.
    /// </summary>
    public TMP_Dropdown dropdown_first;



    int Old_drop;
    Transform input;
    GameObject butnself;
    int content_count;
    bool edit_input;

    private bool start = false;

    List<string> dropdown_1 = new List<string>();

    void Start()
    {
        an = GetComponent<Animator>();
        txt = EditText.transform.GetChild(0).GetComponent<TMP_InputField>();
        Old_drop = dropdown_first.options.Count;
    }

    void Update()
    {
        if (data == null)
        {
            Thread.Sleep(100);
        }
        data = udpReceive.data;
        text = data.Split(',');

        if (btn_active == true)
        {

            //btn_active = false;
        }
        else
        {
            // Age();
        }
        UIManager();

    }
    #region 按下變更文字
    public void DropEditTxt()
    {
        edit_input = true;
        EditText.SetActive(true);
        Time.timeScale = 0;
        butnself = EventSystem.current.currentSelectedGameObject;
        input = butnself.transform.parent.parent;
        int count = input.transform.childCount;
        print(butnself.transform.parent.name);
        for (var i = 1; i < input.transform.childCount; i++)
        {
            content_count = i;
            print(content_count);
            if (input.Find(butnself.transform.parent.name) == true)
            {
                break;
            }
        }
    }
    #endregion
    #region 初始選單
    public void init_plus()
    {
        print(dropdown_1.Count);        //  1
        foreach (var item in dropdown_1)
        {
            dropdown_first.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }
    }
    #endregion
    #region 添加文字
    public void DropPlus()
    {
        edit_input = false;
        EditText.SetActive(true);
    }
    #endregion
    #region 輸入變更TXxt
    public void EditTxt()
    {
        if (edit_input == true)
        {
            //print(txt.text);
            //print(dropdown_1.Count);
            //print(dropdown_1[content_count-1]);
            dropdown_1[content_count - 1] = txt.text;
            // print(dropdown_1[content_count - 1]);
            dropdown_first.options.RemoveAt(0);

            print(dropdown_1.Count);
            // print(dropdown_1[0]);
            // print(dropdown_1[input.transform.childCount - 1]);
        }
        else
        {
            dropdown_1.Add(txt.text);
        }
        dropdown_first.options.Clear();
        foreach (var item in dropdown_1)
        {
            dropdown_first.options.Add(new TMP_Dropdown.OptionData() { text = item });
            print(item);
        }
        txt.text = "";
        Time.timeScale = 1;
        EditText.SetActive(false);
    }
    #endregion
    #region AGE
    void Age()
    {

        if (text[0] == "Male")
        {
            print("Male");
            if (text[1] == "0-2" || text[1] == "4-6" || text[1] == "8-12")
            {
                age_type = 0;
                an.SetBool("BowFlag", true);

                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }
            else if (text[1] == "15-20" || text[1] == "25-32" || text[1] == "38-43" || text[1] == "48-53")
            {
                age_type = 1;
                an.SetBool("WinFlag", true);
                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }

            else if (text[1] == "60-100")
            {
                age_type = 2;
                an.SetBool("DamagedFlag", true);
                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }
        }
        else if (text[0] == "Female")
        {
            print("Female");
            if (text[1] == "0-2" || text[1] == "4-6" || text[1] == "8-12")
            {
                age_type = 3;
                an.SetBool("JumpFlag", true);
                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }
            else if (text[1] == "15-20" || text[1] == "25-32" || text[1] == "38-43" || text[1] == "48-53")
            {
                age_type = 4;
                an.SetBool("LoseFlag", true);
                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }

            else if (text[1] == "60-100")
            {
                age_type = 5;
                an.SetBool("UmatobFlag", true);
                audioSource.clip = sound1[age_type];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                print(age_type);
            }
        }
        else if (data == "No face Detected,Checking next frame")
        {
            an.SetBool("BowFlag", false);
            an.SetBool("JumpFlag", false);
            an.SetBool("DamagedFlag", false);
            an.SetBool("UmatobFlag", false);
            an.SetBool("LoseFlag", false);
            an.SetBool("WinFlag", false);
        }


    }
    #endregion
    #region 測試聲音
    public void Test_Sound()
    {
        btn_active = true;
        audioSource.Stop();
        an.SetBool("HandupFlag", true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = Test_sound;
            audioSource.Play();
        }
        an.SetBool("HandupFlag", false);
    }
    #endregion
    #region UIManager
    public void UIManager()
    {
        if (Manager.Drop == true)
        {
            dropdwon_Manager.SetActive(true);
        }
        else
        {
            dropdwon_Manager.SetActive(false);
        }
        if (Manager.OpenAi == true)
        {
            OpenAi_Manager.SetActive(true);
        }
        else
        {
            OpenAi_Manager.SetActive(false);
        }
        if (Manager.import == true)
        {
            Import_Manager.SetActive(true);
        }
        else
        {
            Import_Manager.SetActive(false);
        }
    }
    #endregion
}

