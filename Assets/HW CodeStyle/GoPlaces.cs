using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _targetContainer;
    private int _targetNumberInContainer = 0;

    private void Start()
    {
        int childrenCount = transform.childCount;

        _targetContainer = new Transform[childrenCount];

        for (int i = 0; i < childrenCount; i++)
            _targetContainer[i] = transform.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform currentTarget = _targetContainer[_targetNumberInContainer];
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position) 
            TakeNextTargetLogic();
    }

    private void TakeNextTargetLogic()
    {
        _targetNumberInContainer++;

        if (_targetNumberInContainer == _targetContainer.Length)
            _targetNumberInContainer = 0;

        var currentTargetPosition = _targetContainer[_targetNumberInContainer].transform.position;
        transform.forward = currentTargetPosition - transform.position;
    }
}