using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followes : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(player.position.x > transform.position.x){
			transform.position = new Vector3(player.position.x,transform.position.y,transform.position.z);
		}
			
        
    }
}
