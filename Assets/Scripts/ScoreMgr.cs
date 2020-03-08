using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client{
    public class ScoreMgr : IBase{
        static string str = "BestScore";
        public static void Init(){
            if(PlayerPrefs.HasKey(str)){
                int temp = PlayerPrefs.GetInt(str);
            }else{
                PlayerPrefs.SetInt(str,0);
            }
        }

        public static void SetScore(){
            if(score > PlayerPrefs.GetInt(str)){
                PlayerPrefs.SetInt(str,score);
            }
        }
    }
}