using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private Dot _dot;
    [SerializeField] private Transform _dotParent;
    [SerializeField] private float _dotSpacing;
    [SerializeField] private int _dotCount;

    [Range(0, 1f)]
    [SerializeField] private float _minSclaeOfDot;

    [SerializeField] private SimulationScene _simulationScene;

    [HideInInspector] public bool Showing;

    private Dot[] _dots;

    private void Start()
    {
        CreateDots();
        Hide();
    }

    private void OnEnable()
    {
        _simulationScene.TrajectorySimulated += _simulationScene_TrajectorySimulated;
    }

    public void Simulate(Vector2 pos, Vector2 velocity)
    {
        _simulationScene.SimulateTrajectory(pos, velocity, _dotCount, _dotSpacing);
    }

    public void SetTransparentToDots(float transparent)
    {
        foreach (var dot in _dots)
        {
            dot.SetAlphaToColor(transparent);
        }
    }

    public void Show()
    {
        _simulationScene.UpdatePositionsGhostObjects();
        _dotParent.gameObject.SetActive(true);

        Showing = true;
    }

    public void Hide()
    {
        _dotParent.gameObject.SetActive(false);
        Showing = false;
    }

    private void CreateDots()
    {
        _dots = new Dot[_dotCount];

        for (int i = 0; i < _dots.Length; i++)
        {
            _dots[i] = Instantiate(_dot, _dotParent);
        }
    }

    private void _simulationScene_TrajectorySimulated(int indexOfFrame, Vector2 pos)
    {
        _dots[indexOfFrame].transform.position = pos;

        SetScaleToDots(indexOfFrame);
    }

    private void SetScaleToDots(int index)
    {
        float scale = 1 - (1 - _minSclaeOfDot) / (_dots.Length-1)  * index;

        _dots[index].transform.localScale = Vector3.one * scale;
    }

    private void OnDisable()
    {
        _simulationScene.TrajectorySimulated -= _simulationScene_TrajectorySimulated;
    }
}
