using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationScene : MonoBehaviour
{
    [SerializeField] private Transform _obstaclesParent;
    [SerializeField] private Ball _ballPrefab;

    private Scene _simulationScene;
    private PhysicsScene2D _physicsScene;

    public event System.Action<int, Vector2> TrajectorySimulated;

    private void Start()
    {
        CreatePhysicsScene();
    }

    private void CreatePhysicsScene()
    {
        _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        _physicsScene = _simulationScene.GetPhysicsScene2D();

        SimulateGhostObjects();
    }

    private void SimulateGhostObjects()
    {
        foreach (Transform obj in _obstaclesParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
        }
    }

    public void UpdatePositionsGhostObjects()
    {
        foreach (var item in _simulationScene.GetRootGameObjects())
        {
            Destroy(item);
        }

        SimulateGhostObjects();
    }


    public void SimulateTrajectory(Vector2 pos, Vector2 velocity, int maxPhysicsFrameIteration, float timeIteration)
    {
        var ghostObj = Instantiate(_ballPrefab, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

        ghostObj.Push(velocity, true);

        for (int i = 0; i < maxPhysicsFrameIteration; i++)
        {
            _physicsScene.Simulate(timeIteration);
            //_physicsScene.Simulate(Time.fixedDeltaTime);

            TrajectorySimulated?.Invoke(i, ghostObj.transform.position);
        }

        Destroy(ghostObj.gameObject);
    }
}
