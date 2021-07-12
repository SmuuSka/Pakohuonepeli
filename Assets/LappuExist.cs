//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LappuExist : MonoBehaviour
//{
//    private void Start()
//    {
 
//    }
//    void Update()
//    {
//        //Lappu();
//    }
//    private void Lappu()
//    {
//        if (GameObject.Find("LappuVastaukset(Clone)") == null)
//        {
//            Debug.Log("Lappu does not exist!");
//            return;
//        }
//        else
//        {
//            GameObject.Find("LappuVastaukset(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 5;
//            if (GameObject.Find("LappuVastaukset(Clone)").GetComponent<DontDestroyLappuClone>() == null)
//            {
//                GameObject.Find("LappuVastaukset(Clone)").AddComponent<DontDestroyLappuClone>();
//            }
            
//        }
//    }
//}
