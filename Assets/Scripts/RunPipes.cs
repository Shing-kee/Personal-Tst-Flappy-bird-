using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client{
    public class RunPipes : MonoBehaviour
    {
        public GameObject pipesPrefab;
        // Start is called before the first frame update
        void Start()
        {
            pipesPrefab = Resources.Load("Prefab/Pipe") as GameObject;
            pipesPrefab.name = "clone";
        }

        IEnumerator Waitting(){
            yield return new WaitForSeconds(1);
            GameObject obj = Instantiate(pipesPrefab,new Vector3(3.5f,0,0),Quaternion.identity);
            GameManager.lstPipe.Add(obj.GetComponent<Move>());
            StartCoroutine(Create());
        }

        IEnumerator Create(){
            GameObject obj = Instantiate(pipesPrefab,new Vector3(3.5f,0,0),Quaternion.identity);
            GameManager.lstPipe.Add(obj.GetComponent<Move>());
            obj.GetComponent<Move>().enabled = false;
            yield return new WaitForSeconds(1.05f);
            obj.GetComponent<Move>().enabled = true;
        }

        public void ReBuild(){
            StartCoroutine(Waitting());
        }
    }
}
