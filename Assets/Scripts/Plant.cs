using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    private PlantData data;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite spriteSmall;
    [SerializeField] private Sprite spriteMedium;
    [SerializeField] private Sprite spriteLarge;

    void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

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
        Debug.Log(data.growth);
        switch (data.growth) {
            case PlantGrowth.MINIMUM:
                spriteRenderer.sprite = spriteSmall;
                break;
            case PlantGrowth.HALF:
                spriteRenderer.sprite = spriteMedium;
                break;
            case PlantGrowth.MAXIMUM:
                spriteRenderer.sprite = spriteLarge;
                break;
        }
    }
}
