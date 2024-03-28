using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Norbu{




public class Destroyer : MonoBehaviour {

    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
}
