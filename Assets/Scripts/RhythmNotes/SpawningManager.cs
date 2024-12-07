using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnLoc;
    public List<Transform> SpawnLoc { get => spawnLoc; set => spawnLoc = value; }
    [SerializeField] List<GameObject> spawnableObjects;
    private Dictionary<string, GameObject> spawnableDictionary;

    [SerializeField] TextAsset spawnTextAsset;
    //temp spawning logic

    private void Start()
    {
        spawnableDictionary = new Dictionary<string, GameObject>();
        CacheDictionary();
        TextAsset songFile = Resources.Load<TextAsset>("NewSong");
        ReadTextFile(songFile);
    }
    public void spawningLogic(List<int> locations)
    {
        List<int> newLocations = new List<int>();
        
        foreach (int location in locations)
        {
            newLocations.AddRange(locations);
            //Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count - 1)], SpawnLoc[locations[i]].position, Quaternion.identity);
        }
    }
    
    IEnumerable RepeatSpawning()
    {
        while (true)
        {
            //spawningLogic(possibleLocations[Random.Range(0,possibleLocations.Count-1)]);
            yield return new WaitForSeconds(2);
        }
    }
    private void ReadTextFile(TextAsset file)
    {
        SongNoteData song = new SongNoteData();
        Notes note = new Notes();
        string[] data = file.text.Split('\n');

        Debug.Log(data.Length);
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            note.time = ConvertTimeIntoFloat(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]));
            note.column = Convert.ToInt32(row[3]);
            //note.obj = spawnableDictionary[row[4]];
            Debug.Log("Time: " + note.time);
            Debug.Log("Column: " + note.column);
            Debug.Log("Type: " + note.obj);
            //song.notes.Add(note);
        }
    }
    private float ConvertTimeIntoFloat(int min, int sec, int mil)
    {
        //Debug.Log("Finished Time " + ((60f * min) + (sec) + (mil / 1000f)));
        return ((60f * min) + (sec) + (mil / 1000f));
    }
    private void CacheDictionary()
    {
        foreach (GameObject obj in spawnableObjects)
        {
            if (obj != null)
            {
                spawnableDictionary.Add(obj.name, obj);
                Debug.Log(spawnableDictionary["Note"]);
            }
        }
    }
    public struct Notes
    {
        [SerializeField] public int column;
        [SerializeField] public float time;
        [SerializeField] public GameObject obj;
    }
    public struct SongNoteData
    {
        [SerializeField] public List<Notes> notes;
    }


}
