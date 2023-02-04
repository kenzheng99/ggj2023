using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    private PlantData data;

    public void SetType(PlantType type) {
        data.type = type;
    }
}
