using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelEditor : MonoBehaviour
{
    public string fileName; //the file that has the level

    public float xOffset; //x, y and z positions of grid start relative to game object
    public float yOffset;
    public float zOffset;


    //called before the first frame update
    void Start()
    {
        //open and read the file, store it to the variable, then close the file
        StreamReader reader = new StreamReader(fileName);
        string contentsOfFile = reader.ReadToEnd();
        reader.Close();

        //check for line break
        char[] newLineChar = {'\n'};

        //split based on \n
        string[] level = contentsOfFile.Split(newLineChar);

        //loop for each row in the level
        for(int i = 0; i < level.Length; i++)
        {
            //create row
            MakeRow(level[i], -i, -i);
        }
    }

    //called to make a row, takes 2 parameters, characters of the row and the y and z positions
    void MakeRow(string rowString, float y, float z)
    {
        //turn the row into an array of characters
        char[] rowArray = rowString.ToCharArray();
        //loop for however many characters there are
        for(int x = 0; x < rowString.Length; x++)
        {
            //store current character as variable c
            char c = rowArray[x];
            //if the character is X
            if(c == 'X')
            {
                //print("make tea sachet");
                //create sachet from the resources folder and set the position
                GameObject cube = Instantiate(Resources.Load("Cube")) as GameObject;
                cube.transform.position = new Vector3
                (
                    x * cube.transform.localScale.x + xOffset,
                    y * cube.transform.localScale.y + yOffset, 
                    z * cube.transform.localScale.z + zOffset
                );
            }
        }
    }
}
