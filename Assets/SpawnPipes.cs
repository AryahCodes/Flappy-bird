using UnityEngine;
using System.Collections.Generic;

public class SpawnPipes : MonoBehaviour{

    //We need to use th prefab pipes and that is an gameobject now.
    public GameObject pipe;

    public LogicScript logic;

    //Timer and the spawnRate.
    //Inspector can change the spawn rate.
    //Timer is private since it doesn't have to be changed.
    public float spawnRate = 2;
    private float timer = 0;

    //We need a float so we can offset the Y position of the spawner.
    public float offSet = 5;

    private List<GameObject> spawnedPipes = new List<GameObject>(); // List to track spawned pipes


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        spawnPipe();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update(){
        //This method is built in so that it creates an game object every frame.
        //This has three parameters(the object, where position u want it to spawn, what rotation you want it to spawn)
        //We spawn the pipe at the spawner position and spawner rotation.
        //We do this every frame which is bad and we don't need that.
        //Instantiate(pipe, transform.position, transform.rotation);

        //We need to make it so there is a timer and it spawns in at that timer.
        //We need to make it so that timer ticks for every frame until it hits the spawnRate then make it back to 0;
        //We use Time.deltaTime since everyones frame rate is different and so deltaTime makes it constant.

        if (logic.isGameOver)
        {
            // Stop the movement of all pipes when the game is over
            foreach (GameObject spawnedPipe in spawnedPipes)
            {
                PipeScriptMove pipeScript = spawnedPipe.GetComponent<PipeScriptMove>();
                if (pipeScript != null)
                {
                    pipeScript.StopMovement();
                }
            }
            return; // Stop spawning new pipes
        }


        if(timer < spawnRate){
            timer += Time.deltaTime;
        }else{
            
            //Now we spawn the pipe and set timer to 0 again.
            spawnPipe();
            timer = 0;
        }
    }

    //Create a spawnPipe function since we need to spawn pipes in more than one spot.
    void spawnPipe(){

        //Here we change where the pipes y position will spawn.
        //We will use the spawner position and just add or subtract with the offSet;
        float smallHeight = transform.position.y - 2;
        float highHeight = transform.position.y + offSet;

        //We we need a random number between the two heights. Use Random.Range;
        float height = Random.Range(smallHeight, highHeight);

        //Now we need a new vector with 3 demenstions and make the Y different from the spawner.
        Vector3 vec = new Vector3(transform.position.x, height, transform.position.z);

        GameObject newPipe = Instantiate(pipe, vec, transform.rotation);
        spawnedPipes.Add(newPipe); // Add the new pipe to the list of spawned pipes
    }
}
