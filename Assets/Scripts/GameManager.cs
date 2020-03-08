using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client{
    public class GameManager : IBase
    {
        private static GameManager _instance;
        public static GameManager GM{
            get{
                return _instance;
            }
        }
        public static List<Move> lstPipe = new List<Move>();
        void Awake()
        {
            Init();
            Enabled(false);
        }

        void Start(){
            InitOther();
        }

        void Init(){
            if(_instance == null){
                _instance = this;
            }else{
                return;
            }
        }
        void InitOther(){
            ScoreMgr.Init();
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            SetScorePanelActives(false);
            SetTitledActives(true);
            btnStart.onClick.AddListener(delegate(){
                GameStart(true);
            });
            btnReStart.onClick.AddListener(delegate(){
                GameReStart(true);
            });
            btnMenu.onClick.AddListener(delegate(){
                GameReturn(true);
            });
        }

        void GameStart(bool state){
            SetScorePanelActives(!state);
            SetTitledActives(!state);
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            Enabled(state);
            rps.ReBuild();
            isState = true;
        }
        void GameReStart(bool state){
            ResetDisplayScore();
            isState = true;
            SetScorePanelActives(!state);
            player.GetComponent<Transform>().position = new Vector3(0,0,0);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            DeletePrefab();
            rps.ReBuild();
            Enabled(state);
        }
        void GameReturn(bool state){
            ResetDisplayScore();
            DeletePrefab();        
            Enabled(!state);
            SetScorePanelActives(!state);
            SetTitledActives(state);
            player.GetComponent<Transform>().position = new Vector3(0,0,0);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        void Enabled(bool state){
            player.enabled = state;
            rps.enabled = state;
            bg.enabled = state;
        }
        void SetScorePanelActives(bool state){
            imgscorePanel.gameObject.SetActive(state);
            btnReStart.gameObject.SetActive(state);
            btnMenu.gameObject.SetActive(state);  
        }
        void SetTitledActives(bool state){
            imgtitle.gameObject.SetActive(state);
            btnStart.gameObject.SetActive(state);
        }
        void DeletePrefab(){
            while(lstPipe.Count > 0){
                int i = 0;
                Destroy(lstPipe[i].gameObject);
                lstPipe.Remove(lstPipe[i]);
                i +=1;
            }
        }
        void ResetDisplayScore(){
            score = 0;
            txtScore.text = score.ToString();
        }
    }
}