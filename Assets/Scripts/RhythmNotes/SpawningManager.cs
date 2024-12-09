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

    public List<Notes> song = new List<Notes>();
    
    //Variables
    private float delaySongAfterStart = 3;
    private float songTime;

    private void Start()
    {
        spawnableDictionary = new Dictionary<string, GameObject>();
        CacheDictionary();
        TextAsset songFile = Resources.Load<TextAsset>("NewSong");
        ReadTextFile(songFile);
    }
    private void Update()
    {
        SongCalculations();
    }

    //splits the CVS File into readable values and fills a list of notes based on the CVS File.
    private void ReadTextFile(TextAsset file)
    {
        Notes note = new Notes();
        string[] data = file.text.Split('\n');

        //Debug.Log(data.Length);
        for (int i = 2; i < data.Length; i++)
        {
            note = new Notes();
            note.songSpeed = Convert.ToInt32(data[1].Trim());
            string[] row = data[i].Split(new char[] { ',' });
            note.time = ConvertTimeIntoFloat(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]));
            note.column = Convert.ToInt32(row[3]);

            note.obj = spawnableDictionary[row[4].Trim()];
            


            Debug.Log("Time: " + note.time);
            Debug.Log("Column: " + note.column);
            Debug.Log("Type: " + note.obj);
            song.Add(note);
            Debug.Log("Song Length: " + song.Count);
            
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
    
    public void resetSongData()
    {
        song = new List<Notes> { };
    }
    public struct Notes
    {
        [SerializeField] public int column;
        [SerializeField] public float time;
        [SerializeField] public GameObject obj;
        [SerializeField, Range(1, 4)] public float songSpeed;
    }

    private void SongCalculations()
    {
        //This will keep a time with delay
        songTime = Time.time - delaySongAfterStart;
        if (song.Count > 0 && songTime >= song[0].time)
        {
            Instantiate(song[0].obj, spawnLoc[song[0].column].position, Quaternion.identity);
            song.Remove(song[0]);
        }
    }
    
}
