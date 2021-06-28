using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Windows;

public class DemoSavedMethods : MonoBehaviour
{
    string playername = "Shirini";
    int age = 20;
    string time = System.DateTime.Now.ToString();
    string systemResolutionInFloat;
    float systemmemory;
    // Start is called before the first frame update
    void Start()
    {
        Resolution systemResolution = Screen.currentResolution;
        systemResolutionInFloat = systemResolution.ToString();
        systemmemory = SystemInfo.systemMemorySize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetPlayerData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }
    void SetPlayerData()
    {
        // PlayerPrefs.SetInt("Score", 10);
        //print("Saved the player score");
        //PlayerPrefs.SetString("Playername", "Shirini");
        //PlayerPrefs.SetString("Time", System.DateTime.Now.ToString());
        string filepath = Application.persistentDataPath + "/Myfiles.file";
        // StreamWriter sw = new StreamWriter(filepath);
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryWriter sw = new BinaryWriter(fs);
        sw.Write(playername);
        sw.Write(age);
        sw.Write(time);

        sw.Write(time);
        fs.Close();
        // sw.WriteLine("Hi");
        //sw.WriteLine("My name is shirini");
        //sw.WriteLine("My age is 22");
        //sw.WriteLine(("My hobbies are playing shuutle and dancing"));
        //sw.WriteLine(time);
        sw.Close();
    }
    void GetPlayerData()
    {
        //int score= PlayerPrefs.GetInt("Score");
        //print("The player score is"+score);
        //string name = PlayerPrefs.GetString("Playername");
        //print("The player score is" + name);
        //string time = PlayerPrefs.GetString("Time");
        //print("Time is" + time);
        string filepath = Application.persistentDataPath + "/Myfiles.file";
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryReader sw = new BinaryReader(fs);
        playername = sw.ReadString();
        age = sw.ReadInt32();
        time = ((string)sw.ReadString());
        Debug.Log(("Player" + playername + "age:" + age + "time:" + time));
        fs.Close();
        //StreamReader sr = new StreamReader(filepath);
        //print(sr.ReadLine());
        //print(sr.ReadLine());
        //print(sr.ReadLine());
        //print(sr.ReadLine());
        //print(sr.ReadLine());
        sw.Close();
    }
}
