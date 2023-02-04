using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    private PlantData data;

    public void SetData(PlantData plantData) {
        data = plantData;
        Render();
    }

    public PlantData GetData() {
        return data;
    }

    public void Grow() {
        data.growth = DataUtils.IncrementPlantGrowth(data.growth);
        Render();
    }

    private void Render() {
        float yScale = 0;
        // TODO switch this to sprite changes
        switch (data.growth) {
            case PlantGrowth.MINIMUM:
                yScale = 0.1f;
                break;
            case PlantGrowth.HALF:
                yScale = 0.5f;
                break;
            case PlantGrowth.MAXIMUM:
                yScale = 1.0f;
                break;
        }

        transform.localScale = new Vector3(1, 5 * yScale, 1);
    }
}
