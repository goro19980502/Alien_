using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PathMove : MonoBehaviour
{
    private GameObject[] _movePath;

    private Vector3 _MinPath;
    public Vector3 MinPath
    {
        get { return _MinPath; }
    }

    private Vector3 _MaxPath;
    public Vector3 MaxPath
    {
        get { return _MaxPath; }
    }

    public Vector3 GetRandomVector()
    {
        return new Vector3(Random.Range(MinPath.x, MaxPath.x), Random.Range(MinPath.y, MaxPath.y),
            Random.Range(MinPath.z, MaxPath.z));
    }

    void Awake ()
    {
        _movePath = GameObject.FindGameObjectsWithTag("MovePathTag");

        List<Vector3> Vec3List = new List<Vector3>();
        foreach (GameObject refObj in _movePath)
        {
            Vec3List.Add(refObj.transform.position);
        }
        _MaxPath.x = Vec3List.Max(pos => pos.x);
        _MaxPath.y = Vec3List.Max(pos => pos.y);
        _MaxPath.z = Vec3List.Max(pos => pos.z);
        _MinPath.x = Vec3List.Min(pos => pos.x);
        _MinPath.y = Vec3List.Min(pos => pos.y);
        _MinPath.z = Vec3List.Min(pos => pos.z);
    }
}
