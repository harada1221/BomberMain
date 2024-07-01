using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    [SerializeField, Header("”š”­‚Ü‚Å‚ÌŽžŠÔ")]
    private float _explosionTime = 2.5f;
    //[SerializeField, Header("”š”­”ÍˆÍ")]
    //private int _explosioinSize = 1;

    private float _explosionTimeCount = default;
    //private BomType _bomType = BomType.Cross;

    public enum BomType
    {
        Cross,
        Straight
    }

    private void Update()
    {
        _explosionTimeCount += Time.deltaTime;
        if (_explosionTimeCount >= _explosionTime)
        {
            Explosion();
        }
    }

    /// <summary>
    /// ”š”­
    /// </summary>
    private void Explosion()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.right, out hit))
        {

        }
        _explosionTimeCount = 0;
        this.gameObject.SetActive(false);
    }
}
