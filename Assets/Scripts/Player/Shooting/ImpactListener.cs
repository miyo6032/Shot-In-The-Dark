using System;
using UnityEngine;
using Util;

namespace Damage_System
{
    public class ImpactListener : MonoBehaviour
    {
        private GameObject Source { get; set; }
        Listener<Collider2D> impactListener;
        public void AddImpactListener(Action<Collider2D> listener) => impactListener.AddEventListener(listener);

        private void Awake()
        {
            impactListener = new Listener<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != Source)
            {
                impactListener.FireEvent(collision);
            }
        }
    }
}
