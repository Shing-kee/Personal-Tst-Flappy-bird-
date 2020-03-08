using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Client{
    public class BackGround : MonoBehaviour
    {
        public Transform bg;
        private Vector3 vec;
        // Start is called before the first frame update
        void Start()
        {
            bg = this.transform;
            vec = new Vector3(3,0,0.5f);
        }

        void Update()
        {
            if(bg.position.x > -2.9f){
                bg.Translate(-0.03f,0,0);
            }else{
                bg.position = vec;
            }
        }
    }
}

