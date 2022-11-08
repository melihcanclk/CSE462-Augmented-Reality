using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject dotObject;
    // Taking txt file from user
    public TextAsset dotFile;

    public void Spawner()
    {
        Vector3[] positions = ReadFile();

        for (int i = 0; i < positions.Length; i++)
        {
            // Instantiate dotObject at position using positions array
            // And create as child of gameObject
            GameObject dot =
                Instantiate(dotObject,
                positions[i] + gameObject.transform.position,
                Quaternion.identity);
            dot.transform.parent = gameObject.transform;
        }
    }

    // Read file and get coordinates from it
    public Vector3[] ReadFile()
    {
        // Get all lines from dotFile TextAsset and store them line by line to lines array
        string[] lines = dotFile.text.Split("\n");

        //parse string to integer and assign to numberoflines variable
        int numberOfLines = int.Parse(lines[0]);
        Vector3[] coordinates = new Vector3[numberOfLines];

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] line = lines[i + 1].Split(' ');
            coordinates[i] =
                new Vector3(float.Parse(line[0], CultureInfo.InvariantCulture),
                    float.Parse(line[1], CultureInfo.InvariantCulture),
                    float.Parse(line[2], CultureInfo.InvariantCulture));
        }
        return coordinates;
    }
}
