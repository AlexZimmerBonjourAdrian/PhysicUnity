using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CBlade : MonoBehaviour
{
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

    private Vector3[] _vertices;
    private int[] _triangles;
    private int _frameCount;

    private Vector3 _PreviousTipPosition;
    private Vector3 _previousBasPosition;
    private Vector3 _TriangleEnterTiPosition;
    private Vector3 _triggerExitTipPosition;

    public int PolySides;
    public int PolyPoints;
    public int polyTriggles;

    
     void Start()
    {
       // _meshParent.transform.position = Vector3.zero;
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        //_meshParent.GetComponent<MeshFilter>().mesh = _mesh;
        CreateShape();
        UpdateMesh();
        //_meshParent.transform.position = Vector3.zero;
        //_mesh = new Mesh();
        //_meshParent.GetComponent<MeshFilter>().mesh = _mesh;
    }

    void CreateShape ()
    {
        _vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3 (1,0,1),
        };
        _triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };

    }

     void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

        _mesh.RecalculateNormals();
    }
}
