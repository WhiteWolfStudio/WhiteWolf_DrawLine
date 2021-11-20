using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WhiteWolf {

    [System.Serializable]
    public class StartEnd {

        public string name;

        [Space]

        public GameObject start;
        public GameObject end;
        [Range( 0, 1 )]
        public float interval = 0;
        public Color color;

    }

    public class WW_DrawLine : MonoBehaviour {

        public StartEnd[] startEnd;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Update(){

            for ( int i=0; i<startEnd.Length; i++ ){

                startEnd[ i ].name = $"{ startEnd[ i ].start.name } and { startEnd[ i ].end.name }";

                startEnd[ i ].color = new Color( startEnd[ i ].color.r, startEnd[ i ].color.g, startEnd[ i ].color.b, 255 );
                Debug.DrawLine( startEnd[ i ].start.transform.position, startEnd[ i ].end.transform.position, startEnd[ i ].color, startEnd[ i ].interval );

            }
            
        }

    }

}