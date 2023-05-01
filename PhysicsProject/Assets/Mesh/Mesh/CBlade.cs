using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CBlade : MonoBehaviour
{

    private const int NUM_VERTICES = 12;
    [SerializeField]
    [Tooltip("The blade object")]
    private GameObject _blade = null;

    [SerializeField]
    private GameObject _tip = null;

    [SerializeField]
    private GameObject _base = null;



    [SerializeField]
    private GameObject _meshParent = null;

    [SerializeField]
    private Color _colour = Color.red;

    public Mesh _mesh;

    [SerializeField]
    [Tooltip("The number of frame that the trail should be rendered for")]
    private int _trailFrameLength = 3;

    private Vector3[] _vertices;
    private int[] _triangles;
    private int _frameCount;
    
    private Vector3 _previousTipPosition;
    private Vector3 _previousBasePosition;
    private Vector3 _triggerEnterTipPosition;
    private Vector3 _triggerEnterBasePosition;
    private Vector3 _triggerExitTipPosition;

    public int PolySides;
    public int PolyPoints;
    public int polyTriggles;

    
     void Start()
    {
        _meshParent.transform.position = Vector3.zero;
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        //_meshParent.GetComponent<MeshFilter>().mesh = _mesh;
        //_vertices = new Vector3[_t]
        _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
        _triangles = new int[_vertices.Length];

        _previousTipPosition = _tip.transform.position;
      _previousBasePosition = _base.transform.position;
       
        //
        //_meshParent.transform.position = Vector3.zero;
        //_mesh = new Mesh();
        //_meshParent.GetComponent<MeshFilter>().mesh = _mesh;
    }
    private void LateUpdate()
    {
        CreateShape();
        UpdateMesh();
    }
    void CreateShape()
    {
        if (_frameCount == (_trailFrameLength * NUM_VERTICES))
        {
            _frameCount = 0;
        }
        //_vertices[_frameCount] = _base.transform.position;
        //_vertices[_frameCount + 1] = _tip.transform.position;
        //_vertices[_frameCount + 2] = _previousTipPosition;
        //_vertices[_frameCount + 3] = _base.transform.position;
        //_vertices[_frameCount + 4] = _previousTipPosition;
        //_vertices[_frameCount + 5] = _tip.transform.position;
        _vertices[_frameCount] = _base.transform.position;
        _vertices[_frameCount + 1] = _tip.transform.position;
        _vertices[_frameCount + 2] = _blade.transform.position;
        _vertices[_frameCount + 3] = _base.transform.position;
        _vertices[_frameCount + 4] = _blade.transform.position;
        _vertices[_frameCount + 5] = _tip.transform.position;
        //_vertices = new Vector3[]
        //{
        _triangles[_frameCount] = _frameCount;
        _triangles[_frameCount + 1] = _frameCount + 1;
        _triangles[_frameCount + 2] = _frameCount + 2;
        _triangles[_frameCount + 3] = _frameCount + 3;
        _triangles[_frameCount + 4] = _frameCount + 4;
        _triangles[_frameCount + 5] = _frameCount + 5;
        //};
        //_triangles = new int[]
        //{
        //    0,1,2,
        //    1,3,2
        //};
        _frameCount += NUM_VERTICES;
    }

     void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

        _mesh.RecalculateNormals();
    }
}
