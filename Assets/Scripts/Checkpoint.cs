﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<DeathOnCollision>().lastCheckpointPos = this.transform.position;
        }
    }
}
