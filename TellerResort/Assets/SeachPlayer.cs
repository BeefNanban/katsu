using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeachPlayer : MonoBehaviour {

    public enum State
    {
        Walk = 3,
        Wait = 7,
        Chase = 5,
        Freeze = 9
    };

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            EnemyCon.EnemyState state = GetComponentInParent<EnemyCon>().GetState();
            if (state != EnemyCon.EnemyState.Chase)
            {
                Debug.Log("プレイヤー発見");
                GetComponentInParent<EnemyCon>().SetState("chase", col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {	
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            GetComponentInParent<EnemyCon>().SetState("wait");
        }
    }
}
