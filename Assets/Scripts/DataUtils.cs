using System;

public static class DataUtils {
    public static PlantType ConvertCorpseTypeToPlantType(CorpseType corpseType) {
        switch (corpseType) {
            case CorpseType.TYPE1:
                return PlantType.PLANT1;
            case CorpseType.TYPE2:
                return PlantType.PLANT2;
            case CorpseType.TYPE3:
                return PlantType.PLANT3;
            default:
                return PlantType.NONE;
        }
    }

    public static PlantGrowth IncrementPlantGrowth(PlantGrowth plantGrowth) {
        switch (plantGrowth) {
            case PlantGrowth.MINIMUM:
                return PlantGrowth.HALF;
            case PlantGrowth.HALF:
                return PlantGrowth.MAXIMUM;
            case PlantGrowth.MAXIMUM:
                return PlantGrowth.MAXIMUM;
            default:
                return PlantGrowth.NONE;
        }
    }

    public static PlantType IndexToPlantType(int index) {
        switch (index) {
            case 0:
                return PlantType.PLANT1;
            case 1:
                return PlantType.PLANT2;
            case 2:
                return PlantType.PLANT3;
            default:
                return PlantType.NONE;
        }
    }
    
    public static CorpseType IndexToCorpseType(int index) {
        switch (index) {
            case 0:
                return CorpseType.TYPE1;
            case 1:
                return CorpseType.TYPE2;
            case 2:
                return CorpseType.TYPE3;
            default:
                return CorpseType.NONE;
        }
    }

    public static string PlantToString(PlantType plant) {
        switch (plant) {
            case PlantType.PLANT1:
                return "Karrot";
            case PlantType.PLANT2:
                return "Funion";
            case PlantType.PLANT3:
                return "Slowtato";
            default:
                return "";
        }
    }
}