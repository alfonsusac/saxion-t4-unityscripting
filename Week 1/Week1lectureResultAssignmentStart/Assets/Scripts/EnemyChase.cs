using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public GameObject Player;
    public float speed;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        followPlayer(Player);
        checkLoseCondition(Player);
    }

    void followPlayer(GameObject g)
    {
        transform.LookAt(g.transform);
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void checkLoseCondition(GameObject g)
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < 1)
        {
            Player.GetComponent<PlayerMovement>().WalkSpeedMultiplier = 0;
            Debug.Log("GAME OVER");
        }
    }
}
