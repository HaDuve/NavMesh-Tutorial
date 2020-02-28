using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera Cam;
    public NavMeshAgent Agent;
    public ThirdPersonCharacter Character;

    void Start()
    {
        Agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // Move Agent
                Agent.SetDestination(hit.point);
            }
        }

        if (Agent.remainingDistance > Agent.stoppingDistance)
        {
            Character.Move(Agent.desiredVelocity, false, false);
        }
        else
        {
            Character.Move(Vector3.zero, false, false);
        }
        

    }
}
