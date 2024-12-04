using UnityEngine;

public class PipeScriptMove : MonoBehaviour
{

    //We need to make a move speed so we move the pipes to the left. We made it constant just for fun. 
    //We can still change it in the inspector.
    public float moveSpeed = 5;

    //Create a variable for the deadzone.
    public float deadZone = -11;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //We can't just make it a vector2 and got to use vector 3 since there are three demensions into play for the pipe. 
        //We can't also just change the x coordinate. We have to change the whole vector.
        //We can just keep updating the old position by adding. 
        //We need to do Vector3.left to move sure it moves left.
        //This updates the movement at every frame which is BAD.
        //If some pcs are faster then it will move faster. We can't allow that. So we need to multiply everything by 
        //a constant speed which is the deltatime.
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //Now if the pipe goes out of frame this object will be destroyed.s
        if(transform.position.x < deadZone){

            //The Destroy lets us easily destroy the object thats running this.    
            Destroy(gameObject);
        }
    }
}
