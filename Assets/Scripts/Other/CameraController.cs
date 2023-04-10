using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player; // get reference to player

    // Start is called before the first frame update
    void Start()
    {
        // get player game object
        player = GameObject.FindGameObjectWithTag("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        // transform the position of the camera in x and y to the player's position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
