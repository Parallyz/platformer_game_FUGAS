using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);

    public bool isLeft;

    private Transform player;

    private int lastX;
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int curentX = Mathf.RoundToInt(player.position.x);
            if (curentX > lastX) isLeft = false;
            else if (curentX < lastX) isLeft = false;

            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if(isLeft)
            {
                target= transform.position = new Vector3(player.position.x - offset.x, player.position.y , transform.position.z);
            }
            else{
                target= transform.position = new Vector3(player.position.x + offset.x, player.position.y , transform.position.z);

            }

            Vector3 currentPos=Vector3.Lerp(transform.position,target,dumping*Time.deltaTime);
            transform.position=currentPos;
        }


    }

    public void FindPlayer(bool playerisLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerisLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, transform.position.y , transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        }
    }
}
