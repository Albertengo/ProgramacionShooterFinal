using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    //solo para que cuando se instancie la loot, se autoelimine luego de 3 segundos.
    void Start()
    {
        Destroy(gameObject, 3f);
    }

}
