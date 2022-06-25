using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSysTutorial
{
    public static class SaveSys
    {
        public static void  SaveByPlayerPrefs(string key , object data)
        {
            var json = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();

#if UNITY_EDITOR
            Debug.Log("Successfully saved data to PlayerPrefs.");
#endif
        }
    }
}

