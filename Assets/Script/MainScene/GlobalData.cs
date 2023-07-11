using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameObjectData
{
    public GameObject dataObject;
    public bool IsUsing;
}

public class ListObjectData
{
    public object dataSource;
    public List<GameObjectData> poolDataList;
}
