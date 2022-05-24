using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using UnityEngine.UI;
using System.Threading.Tasks;


public class Main : MonoBehaviour
{
    public UDPReceive udpReceive;
    private string data;
    string[] text;
    
    public Animator an;
    public GameObject btn;
    private bool btn_active = false;


    int count = 1;
    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip btn_sound;

    [SerializeField] private AudioClip[] sound1 = new AudioClip[6] ;

    //�^��
    string Hello_Kid = "�A�n�A�p�k��";
    string Hello_Young = "�A�n�A�ӭ�";
    string Hello_Old = "�A�n�A����";

    string Hello_Girl = "�A�n�A�p�k��";
    string Hello_Pretty = "�A�n�A���k";
    string Hello_Old_Girl = "�A�n�A����";

    //�����n��
    bool m_ToggleChange = true;
    bool m_Play = true;
    //�~�ְ϶�
    int age_type;

    public GameObject dropdwon_Manager;

    public Dropdown dropdown_first;
    public Dropdown dropdown_second;
    public Dropdown dropdown_third;

   List<string> dropdown_2 = new List<string>();
   List<string> dropdown_3 = new List<string>();

    string options_txt ;
    float time = 0f;
    private float timer = 0;
    void stat()
    {
        an = GetComponent<Animator>();
       
    }
    #region ���2

    public void dropdown_s(int val)
    {

        if(val == 0 )
        {
            dropdown_2.Add("C");
            dropdown_2.Add("D");
        }
        else if(val == 1 )
        {

            dropdown_2.Add("E");
            dropdown_2.Add("F");
        }
        else if (val == 2)
        {
            dropdown_2.Add("G");
            dropdown_2.Add("H");
        }
        dropdown_second.options.Clear();
        foreach (var item in dropdown_2)
        {
            dropdown_second.options.Add(new Dropdown.OptionData() { text = item });
        }
        dropdown_2.Clear();
    }
    #endregion

    #region ���3

    public void dropdown_t(int val)
    {
        if (val == 0)
        {
            dropdown_3.Add("I");
            dropdown_3.Add("J");
        }
        else if (val == 1)
        {

            dropdown_3.Add("K");
            dropdown_3.Add("L");
        }
        dropdown_third.options.Clear();
        foreach (var item in dropdown_3)
        {
            dropdown_third.options.Add(new Dropdown.OptionData() { text = item }) ; 
        }

      
        dropdown_3.Clear();
    }
    #endregion
    public void dropdown_animation( )
    {

        options_txt = dropdown_third.captionText.text;

        if (options_txt == "I")
        {
            an.Play("Bow"); print(dropdown_third.captionText.text);
        }
        else if (options_txt == "J")
        {
            an.Play("WIN00", 0, 0.25f); print(dropdown_third.captionText.text);
        }
        else if (options_txt == "K")
        {
            an.Play("DAMAGED00"); print(dropdown_third.captionText.text);
        }
        else if (options_txt == "L")
        {
            an.Play("JUMP01"); print(dropdown_third.captionText.text);
        }
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
            if (Edit.edit_ == true)
            {
                dropdwon_Manager.SetActive(true);
            }
            else
            {
                dropdwon_Manager.SetActive(false);
            }
    }

    #region �~��
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
    public void intro()
    {
        btn_active = true;
        audioSource.Stop();
        an.SetBool("HandupFlag", true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = btn_sound;
            audioSource.Play();
        }
        an.SetBool("HandupFlag", false);
    }


    public void hello()
    {
        an.Play("WIN00");
    }
}

