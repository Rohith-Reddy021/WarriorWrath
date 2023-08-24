using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanime : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anime;

    public void OnTriggerEnter(Collider other)
    {
    if(other.CompareTag("Player")){
        anime.SetBool("light",true);
    }
    }
}
