using System;
using UnityEngine;

namespace Level_Objects
{
    public class BystanderRemoval : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Bystander"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}