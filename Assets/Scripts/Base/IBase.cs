using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Client
{
    public class IBase : MonoBehaviour
    {
        protected static BackGround bg;
        protected static Player player;
        protected static RunPipes rps;
        protected static Button btnStart;
        protected static Button btnReStart;
        protected static Button btnMenu;
        protected static Image imgMedal;
        protected static Image imgscorePanel;
        protected static Image imgtitle;
        [SerializeField]
        protected static TextMeshProUGUI txtScore;
        protected static TextMeshProUGUI txtBestScore;
        protected static TextMeshProUGUI txtCurrentScore;
        protected static bool isState;
        protected static int score;
        
        void Awake(){
            bg              = GameObject.Find("bg").transform.GetComponent<BackGround>();
            player          = GameObject.Find("bird0_0").transform.GetComponent<Player>();
            rps             = GameObject.Find("BG").transform.GetComponent<RunPipes>();
        }
        
        void Start()
        {
            btnStart        = GameObject.Find("Start").GetComponent<Button>();
            btnReStart      = GameObject.Find("ReStart").GetComponent<Button>();
            btnMenu         = GameObject.Find("Menu").GetComponent<Button>();
            imgtitle        = GameObject.Find("Title").GetComponent<Image>();
            imgscorePanel   = GameObject.Find("ScorePanel").GetComponent<Image>();
            imgMedal        = GameObject.Find("Medal").GetComponent<Image>();
            txtScore        = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            txtBestScore    = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
            txtCurrentScore = GameObject.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        }
    }
}

