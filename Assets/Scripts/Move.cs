using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client{
    public class Move : MonoBehaviour
    {
        public float dis = -19;
        float velocity = 3;
        Vector3 endPos;

        float posY;
        // Start is called before the first frame update
        void Start()
        {
            endPos = transform.position + new Vector3(dis,0,0);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,endPos,Time.deltaTime * velocity);
            if(transform.position.x == endPos.x){
                float temp = transform.position.y;
                posY = Random.Range(-1.5f,3f);
                if(temp == posY){
                    posY = Random.Range(-1.75f,3f);
                    transform.position = new Vector3(3.5f,posY,0);
                }else{
                    transform.position = new Vector3(3.5f,posY,0);
                }
                endPos = transform.position + new Vector3(dis,0,0);
            }
        }
        public void Stop(){
            this.gameObject.GetComponent<Move>().enabled = false;
        }
    }
}

