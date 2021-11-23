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

        [Space]

        public float dis;
        public Color disColor;

    }

    [System.Serializable]
    public class AutoDraw {

        public string name;

        [Space]

        public GameObject start;
        public string end;

        [Range( 0, 1 )]
        public float interval = 0;
        public Color color;

        [Space]

        public float dis;
        public Color disColor;

    }

    public class WW_DrawLine : MonoBehaviour {

        public bool auto;

        [Space]

        public StartEnd[] startEnd;
        public AutoDraw autoDraw;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        public Color _color;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Update(){

            if ( !auto ){

                for ( int i=0; i<startEnd.Length; i++ ){

                    startEnd[ i ].name = $"{ startEnd[ i ].start.name } and { startEnd[ i ].end.name }";

                    if ( Vector2.Distance( startEnd[ i ].start.transform.position, startEnd[ i ].end.transform.position ) <= startEnd[ i ].dis ){

                        _color = new Color( startEnd[ i ].disColor.r, startEnd[ i ].disColor.g, startEnd[ i ].disColor.b, 255 );

                    }
                    else {

                        _color = new Color( startEnd[ i ].color.r, startEnd[ i ].color.g, startEnd[ i ].color.b, 255 );

                    }

                    Debug.DrawLine( startEnd[ i ].start.transform.position, startEnd[ i ].end.transform.position, _color, startEnd[ i ].interval );

                }

            }
            else {

                GameObject[] objs = GameObject.FindGameObjectsWithTag( autoDraw.end );

                for ( int i=0; i<objs.Length; i++ ){

                    autoDraw.name = $"{ autoDraw.start.name } and { autoDraw.end } Tag";

                    if ( Vector2.Distance( autoDraw.start.transform.position, objs[ i ].transform.position ) <= autoDraw.dis ){

                        _color = new Color( autoDraw.disColor.r, autoDraw.disColor.g, autoDraw.disColor.b, 255 );

                    }
                    else {

                        _color = new Color( autoDraw.color.r, autoDraw.color.g, autoDraw.color.b, 255 );

                    }

                    Debug.DrawLine( autoDraw.start.transform.position, objs[ i ].transform.position, _color, autoDraw.interval );

                }

            }
            
        }

    }

}
