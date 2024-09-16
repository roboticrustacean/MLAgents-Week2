using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : Agent
{
    [SerializeField] Material win;
    [SerializeField] Material lose;
    [SerializeField] MeshRenderer floorMesh;
    public Transform target;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(0.5f, 7.5f), 0f,
       Random.Range(-7.5f, 7.5f));
        // Move the target to a new spot
        target.localPosition = new Vector3(Random.Range(-7.5f, -0.5f), 0f,
       Random.Range(-7.5f, 7.5f));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

    }
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        float moveX = actionBuffers.ContinuousActions[0];
        float moveZ = actionBuffers.ContinuousActions[1];

        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * 14f;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target")
        {
            SetReward(1.0f);
            floorMesh.material = win;
            EndEpisode();
        }
        else if (other.tag == "wall")
        {
            SetReward(-1.0f);
            floorMesh.material = lose;
            EndEpisode();
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");
    }


}




