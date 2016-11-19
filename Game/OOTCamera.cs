using System.Collections;
using UnityEngine;

public class OOTCamera : MonoBehaviour
{
    private GameObject player;
    public float distance;
    private float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    //get player object, player need to be tagged
        speed=player.GetComponent<PlayerController>().speed;    //get speed from player script
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);   //get the distance between camera and player

        Vector3 behind = player.transform.position - new Vector3(player.transform.forward.x * distance, player.transform.forward.y - 1.0f, player.transform.forward.z * distance); 
        transform.LookAt(player.transform);
        //transform.position = Vector3.MoveTowards(transform.position, behind, Time.deltaTime);
        if (Input.GetKey(KeyCode.H)) //reset camera behind player
        {
            transform.position = Vector3.MoveTowards(transform.position,behind,distance);
        }
        if (dist < distance) //if player is close to camera stop camera movement
        {
            transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(player.transform);
        }
        else if (dist > distance * 2) //if player is far away, move camera behind the player fast
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z - distance),speed*2*Time.deltaTime);
        }
        else if (dist < distance * 2 && dist > distance) //if player is in range, slowly moving camera towards player
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z - distance),Time.deltaTime);           
        }
    }
    public bool IsCameraReversed(bool curr)
    {
        if (transform.rotation.y>-0.3&&transform.rotation.y<0.3&&!player.GetComponent<PlayerController>().IsMovementKeyPressed())
        {
            return false;
        } else if (transform.rotation.y < -0.7&& !player.GetComponent<PlayerController>().IsMovementKeyPressed() || transform.rotation.y > 0.7&&!player.GetComponent<PlayerController>().IsMovementKeyPressed())
        {
            return true;
        }
        return curr;
    }
}
