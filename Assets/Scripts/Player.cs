using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Client{
    public class Player : IBase
    {
        public AudioClip clip;//Get the Audio Sources
        private static AudioSource audioSource; //opera Audio
        public float velocity = 4.5f;
        Dictionary<string,AudioClip> dicAudio = new Dictionary<string,AudioClip>();//About some voice' dictionary
        // Start is called before the first frame update
        void Awake(){
            clip = gameObject.GetComponent<AudioClip>();
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        void Start()
        {
            dicAudio.Add("fly",Resources.Load("Audio/fly",typeof(AudioClip)) as AudioClip);
            dicAudio.Add("touch",Resources.Load("Audio/touch",typeof(AudioClip)) as AudioClip);
            dicAudio.Add("getScore",Resources.Load("Audio/getScore",typeof(AudioClip)) as AudioClip);
        }

        // Update is called once per frame
        void Update()
        {
            if(isState){
                if(Input.GetMouseButtonDown(0)){
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,velocity,0);
                    Sound(dicAudio["fly"]);
                }else if(Input.touchCount > 0){
                    if(Input.GetTouch(0).phase == TouchPhase.Began){
                        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,velocity,0);
                        Sound(dicAudio["fly"]);
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.tag == "Jam" || col.gameObject.tag == "Floor"){
                if(isState){
                    Sound(dicAudio["touch"]);
                    ScoreMgr.SetScore();
                    txtCurrentScore.text = txtScore.text;
                    txtBestScore.text = string.Format(PlayerPrefs.GetInt("BestScore").ToString());
                    foreach(var item in GameManager.lstPipe){
                        item.Stop();
                    }
                    isState = false;
                    GameOver(true);
                }           
            }
        }

        void OnTriggerExit2D(Collider2D col){
            if(col.gameObject.tag == "Target"){
                if(isState){
                    score +=1;
                    txtScore.text = string.Format(score.ToString());
                    Sound(dicAudio["getScore"]);
                }
                else{
                    score = 0;
                }
            }
        }

        void Sound(AudioClip _clip){
            clip = _clip;
            audioSource.PlayOneShot(clip);
        }

        void GameOver(bool state){
                GameManager.bg.enabled = !state;
                imgscorePanel.gameObject.SetActive(state);
                btnReStart.gameObject.SetActive(state);
                btnMenu.gameObject.SetActive(state);
        }
    }
}

