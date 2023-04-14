using UnityEngine;
using System.Collections.Generic;

public class GptChangeMaterials : MonoBehaviour
{
    public List<Material> materialsList;
    public List<GameObject> objectsList;
    private int[] currentMaterialIndices;

    void Start()
    {
        int numObjects = objectsList.Count;
        currentMaterialIndices = new int[numObjects];
        for (int i = 0; i < numObjects; i++)
        {
            currentMaterialIndices[i] = i % materialsList.Count;
            Renderer renderer = objectsList[i].GetComponent<Renderer>();
            renderer.material = materialsList[currentMaterialIndices[i]];
        }
    }

    public void ChangeMaterialsForward()
    {
        int numObjects = objectsList.Count;
        for (int i = 0; i < numObjects; i++)
        {
            currentMaterialIndices[i] = (currentMaterialIndices[i] + 1) % materialsList.Count;
            Renderer renderer = objectsList[i].GetComponent<Renderer>();
            renderer.material = materialsList[currentMaterialIndices[i]];
        }
    }

    public void ChangeMaterialsBackward()
    {
        int numObjects = objectsList.Count;
        for (int i = 0; i < numObjects; i++)
        {
            currentMaterialIndices[i] = (currentMaterialIndices[i] - 1 + materialsList.Count) % materialsList.Count;
            Renderer renderer = objectsList[i].GetComponent<Renderer>();
            renderer.material = materialsList[currentMaterialIndices[i]];
        }
    }
}
