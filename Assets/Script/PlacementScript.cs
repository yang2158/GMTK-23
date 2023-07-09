using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlacementScript : MonoBehaviour
{

    Vector3 pos = Vector3.zero;
    SpriteRenderer sr = null;
    // Start is called before the first frame update
    void Start()
    {
        sr =    transform.GetComponent<SpriteRenderer>();
    }

}
