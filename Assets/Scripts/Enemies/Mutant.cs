using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : Enemy
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
