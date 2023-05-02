using UnityEngine;

public class QuizPanel : MonoBehaviour
{
    private bool _one = false;
    private bool _two = false;
    private bool _three = false;
    private bool _four = false;
    private bool _quiz1 = false;
    private bool _quiz2 = false;
    private bool _quiz3 = false;
    private bool _quiz4 = false;
    
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject light4;
    [SerializeField] private GameObject lever1;
    [SerializeField] private GameObject lever2;
    [SerializeField] private GameObject lever3;
    [SerializeField] private GameObject lever4;
    [SerializeField] private Material onTexture;
    [SerializeField] private Material offTexture;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorOpenPosition;
    [SerializeField] private GameObject doorClosedPosition;
    
    private Vector3 _lever1Pos;
    private Vector3 _lever2Pos;
    private Vector3 _lever3Pos;
    private Vector3 _lever4Pos;
    
    private Vector3 _currentDoor;
    private Vector3 _current;
    private Vector3 _doorOpenDirection;
    private Vector3 _doorClosedDirection;

    private bool _isOpening = false;
    private float _doorOpenSpeed = 1f;
    
    void Start()
    {
        _current = transform.position;
        _doorOpenDirection = doorClosedPosition.transform.position - door.transform.position;
        _doorClosedDirection = door.transform.position - doorOpenPosition.transform.position;
        light1.GetComponent<MeshRenderer>().material = offTexture;
        light2.GetComponent<MeshRenderer>().material = offTexture;
        light3.GetComponent<MeshRenderer>().material = offTexture;
        light4.GetComponent<MeshRenderer>().material = offTexture;
        _lever1Pos = lever1.transform.position;
        _lever2Pos = lever2.transform.position;
        _lever3Pos = lever3.transform.position;
        _lever4Pos = lever4.transform.position;
    }

    void Update()
    {
        Quiz();
        CheckForFailure();
        ColorLights();
        if (_isOpening)
        {
            OpenDoor();
        }
    }
    

    private void OpenDoor()
    {
        Quaternion rotation = Quaternion.LookRotation(_doorOpenDirection);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, rotation, _doorOpenSpeed * Time.deltaTime);
    }

    void CheckForFailure()
    {
        if ((_quiz1 && _two || _four) && !_quiz2)
        {
            ResetAll();
        }

        if (_quiz2 && _four && !_quiz3)
        {
            ResetAll();
        }
    }



    void MoveIn(GameObject lever)
    {
        lever.transform.position = new Vector3(lever.transform.position.x, lever.transform.position.y,
            lever.transform.position.z + 0.07f);
    }
    void MoveOut(GameObject lever)
    {
        lever.transform.position = new Vector3(lever.transform.position.x, lever.transform.position.y,
            lever.transform.position.z - 0.07f);
    }
    public void One()
    {
        if (_one)
        {
            _one = false;

            MoveOut(lever1);
        }
        else
        {
            _one = true;

            MoveIn(lever1);
        }
    }
    public void Two()
    {
        if (_two)
        {
            _two = false;

            MoveOut(lever2);
        }
        else
        {
            _two = true;

            MoveIn(lever2);
        }
    }

    public void Three()
    {
        if (_three)
        {
            _three = false;

            MoveOut(lever3);
        }
        else
        {
            _three = true;

            MoveIn(lever3);
        }
    }

    public void Four()
    {
        if (_four)
        {
            _four = false;

            MoveOut(lever4);
        }
        else
        {
            _four = true;
            
            MoveIn(lever4);
        }
    }

    void Quiz()
    {
        if (_one && !_two && !_three && !_four)
        {
            _quiz1 = true;
        }
        

        if (_quiz1 && _three && !_two && !_four)
        {
            _quiz2 = true;
        }


        if (_quiz1 && _quiz2 && _two && !_four)
        {
            _quiz3 = true;
        }


        if (_quiz1 && _quiz2 && _quiz3 && _four)
        {
            _quiz4 = true;
        }


        if (_quiz1 && _quiz2 && _quiz3 && _quiz4)
        {
            _isOpening = true;
        }
    }

    void ResetAll()
    {
        _one = false;
        _two = false;
        _three = false;
        _four = false;
        _quiz1 = false;
        _quiz2 = false;
        _quiz3 = false;
        _quiz4 = false;
        lever1.transform.position = _lever1Pos;
        lever2.transform.position = _lever2Pos;
        lever3.transform.position = _lever3Pos;
        lever4.transform.position = _lever4Pos;
        

    }

    void ColorLights()
    {
        if (_quiz1)
        {
            light1.GetComponent<MeshRenderer>().material = onTexture;
        }
        else
        {
            light1.GetComponent<MeshRenderer>().material = offTexture;
        }
        if (_quiz2)
        {
            light2.GetComponent<MeshRenderer>().material = onTexture;
        }
        else
        {
            light2.GetComponent<MeshRenderer>().material = offTexture;
        }
        if (_quiz3)
        {
            light3.GetComponent<MeshRenderer>().material = onTexture;
        }
        else
        {
            light3.GetComponent<MeshRenderer>().material = offTexture;
        }
        if (_quiz4)
        {
            light4.GetComponent<MeshRenderer>().material = onTexture;
        }
        else
        {
            light4.GetComponent<MeshRenderer>().material = offTexture;
        }
    }

}
