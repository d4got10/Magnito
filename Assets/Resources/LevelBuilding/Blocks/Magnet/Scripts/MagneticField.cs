using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MagneticField : MonoBehaviour
{
    public Magnet Parent;
    public PolygonCollider2D MagneticFieldCollider;
  
    public event Action<MoveableObject> OnObjectEnter;
    public event Action<MoveableObject> OnObjectExit;

    private Mesh _magneticFieldMesh;
    private int _sideNumber = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enteredObject = collision.GetComponent<MoveableObject>();
        if (enteredObject != null)
        {
            OnObjectEnter?.Invoke(enteredObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var exitedObject = collision.GetComponent<MoveableObject>();
        if (exitedObject != null)
        {
            OnObjectExit?.Invoke(exitedObject);
        }
    }

    public void UpdateField()
    {      
        BuildMagneticField();

        GetComponent<MeshFilter>().mesh = _magneticFieldMesh;
    }

    private Mesh AddHitPoint(Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(Parent.transform.position, direction, distance, mask);

        if (hit)
        {
            return AddSubfieldToField(direction, hit.distance);
        }
        else
        {
            return AddSubfieldToField(direction, distance);
        }
    }

    private Mesh AddSubfieldToField(Vector2 direction, float distance)
    {
        var size = 1.2f;

        Vector3 startPoint = (Vector3)direction / 2 + new Vector3(direction.y, -direction.x) / 2 * size;
        int cells = Mathf.RoundToInt(distance - 0.5f);
        Vector3[] verticies = new Vector3[(cells + 1) * 2];
        int[] triangles = new int[cells * 2 * 3];
        Vector2[] uvs = new Vector2[verticies.Length];

        for(int i = 0; i < cells + 1; i++)
        {
            verticies[2 * i]     = (Vector3)direction * i + startPoint;
            verticies[2 * i + 1] = (Vector3)direction * i + startPoint - new Vector3(direction.y, -direction.x) * size;
            uvs[2 * i]     = new Vector2(0, 1 - (float)i / (cells == 0 ? 1 : cells));
            uvs[2 * i + 1] = new Vector2(1, 1 - (float)i / (cells == 0 ? 1 : cells));
        }

        for(int i = 0; i < cells; i++)
        {
            triangles[6 * i]     = 2 * i + 0;
            triangles[6 * i + 1] = 2 * i + 1;
            triangles[6 * i + 2] = 2 * i + 3;
            triangles[6 * i + 3] = 2 * i + 3;
            triangles[6 * i + 4] = 2 * i + 2;
            triangles[6 * i + 5] = 2 * i + 0;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        Vector2[] points = new Vector2[4];

        points[0] = new Vector2(0.2f, 0.5f);
        points[1] = new Vector2(0.2f, cells + 0.5f);
        points[2] = new Vector2(-0.2f, cells + 0.5f);
        points[3] = new Vector2(-0.2f, 0.5f);

        for (int i = 0; i < _sideNumber; i++)
            for(int j = 0; j < 4; j++)
                points[j] = new Vector2(points[j].y, -points[j].x);

        
        MagneticFieldCollider.SetPath(_sideNumber, points);
        _sideNumber = _sideNumber + 1 > 3 ? 0 : _sideNumber + 1;

        return mesh;      
    }

    private void BuildMagneticField()
    {
        int radius = Parent.MagneticFieldRadius;
        LayerMask mask = Parent.ObjectsToBoundMagneticFieldLayerMask;

        CombineInstance[] meshesToCombine = new CombineInstance[4];

        MagneticFieldCollider.pathCount = 4;

        meshesToCombine[0].mesh = AddHitPoint(Parent.transform.up,     radius, mask);    
        meshesToCombine[1].mesh = AddHitPoint(Parent.transform.right,  radius, mask);
        meshesToCombine[2].mesh = AddHitPoint(-Parent.transform.up,    radius, mask);
        meshesToCombine[3].mesh = AddHitPoint(-Parent.transform.right, radius, mask);

        Vector3 oldPosition = transform.position;
        Quaternion oldRotation = transform.rotation;
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        for (int i = 0; i < 4; i++)
        {
            meshesToCombine[i].subMeshIndex = 0;
            meshesToCombine[i].transform = transform.localToWorldMatrix;
        }

        transform.rotation = oldRotation;
        transform.position = oldPosition;
        

        if (_magneticFieldMesh)
            _magneticFieldMesh.Clear();
        else
            _magneticFieldMesh = new Mesh();

        _magneticFieldMesh.CombineMeshes(meshesToCombine);
        _magneticFieldMesh.RecalculateNormals();
    }
}
