using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BestCsoreSaver : MonoBehaviour
{

    StreamReader streamReader;

    void Start()
    {
        LoadBestScore();
    }

    public void SaveBestScore()
    {
        if (File.Exists(Application.streamingAssetsPath + "/BestScore.txt"))
        {
            File.WriteAllText(Application.streamingAssetsPath + "/BestScore.txt", GlobalBase.BestScore.ToString());
        }
    }

    void LoadBestScore()
    {
        using (StreamReader sr = new StreamReader("Assets/StreamingAssets/BestScore.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                GlobalBase.BestScore = int.Parse(line);
            }
        }
    }
}
