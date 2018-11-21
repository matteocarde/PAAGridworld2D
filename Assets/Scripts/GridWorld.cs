using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GridWorld : MonoBehaviour
{

    public int gridSize;
    public float speed = 3f;
    public GameObject tile;
    public GameObject player;
    public List<Vector2> movements;
    public Camera myCamera;
    public Vector2 nextStepPoint;
    public int currentStep = 0;
    public Text text;

    // Use this for initialization
    void Start()
    {
        BuildWorld();
    }

    public void ResetWorld()
    {
        movements.Clear();
        currentStep = 0;
        List<GameObject> objectsToDestroy = new List<GameObject>();
        objectsToDestroy.AddRange(GameObject.FindGameObjectsWithTag("WALL"));
        objectsToDestroy.AddRange(GameObject.FindGameObjectsWithTag("FLOOR"));
        objectsToDestroy.AddRange(GameObject.FindGameObjectsWithTag("FLOOR_V"));

        foreach(GameObject toDestroy in objectsToDestroy){
            Destroy(toDestroy);
        }

        player.transform.position = new Vector3(0, 0, -1.01f);

        BuildWorld();
    }

    private void BuildWorld(){
        string path = "./robot.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(path);
        int gridWidth = int.Parse(reader.ReadLine());

        int x = 0;
        int y = 0;

        myCamera.transform.position = new Vector3((gridWidth - 1) / 2f, -(gridWidth - 1) / 2f, -1);
        myCamera.orthographicSize = gridWidth / 2f;

        for (int i = 0; i < gridWidth; i++)
        {
            reader.Read(); //Reading the first character |
            for (int j = 0; j < gridWidth; j++)
            {
                char type = (char)reader.Read();
                tile.GetComponent<SpriteRenderer>().color = type == '@' ? Color.black : Color.white;
                tile.tag = type == '@' ? "WALL" : "FLOOR";
                Vector3 tilePosition = new Vector3(x, y, 0.1f);
                Instantiate(tile, tilePosition, Quaternion.identity);
                x++;
            }
            reader.ReadLine();
            x = 0;
            y--;
        }

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] coordinates = line.Split(',');
            movements.Add(new Vector2(float.Parse(coordinates[1]), -float.Parse(coordinates[0])));
        }

        nextStepPoint = movements[0];
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Speed: " + speed;
        if (currentStep >= movements.Count ){
            return;
        }

        if ((Vector2)player.transform.position == nextStepPoint)
        {
            currentStep++;
            nextStepPoint = movements[currentStep];
        }

        // Move our position a step closer to the target.

        player.transform.position = Vector3.MoveTowards(player.transform.position, nextStepPoint, speed * Time.deltaTime);
    }

    public void addSpeed()
    {
        speed += 0.5f;
    }

    public void removeSpeed()
    {
        if(speed <= 0.5f){
            return;
        }
        speed -= 0.5f;
    }
}
