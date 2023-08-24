using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    // Start is called before the first frame update
 void Start() {
         var ex = GetComponent<ParticleSystem>();
         ex.Play();
         Destroy(gameObject, ex.duration);
     }
}
