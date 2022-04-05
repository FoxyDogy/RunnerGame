using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Code;
using _Game.Code.Base;
using Foxy.Utils;
using UnityEngine;

public class EndlessController : DataBehaviour<EndlessController>
{
    private PoolSystem<Block> pool;
    public Block blockPrefab;
    public GameObject parent;
    public Block lastSpawnedBlock;

    private void Awake()
    {
        var list = new List<Block>();
        for (int i = 0; i < 30; i++)
        {
         var block =   Instantiate(blockPrefab,parent.transform);
         block.Deactivate();
         list.Add(block);
        }
        pool = new PoolSystem<Block>(list);
        FirstSpawns();
    }

    public void FirstSpawns()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnNewBlock();
        }
    }
    private void SpawnNewBlock()
    {
       var newBlock = pool.GetObjectSorted();
       AddToGame(newBlock);
    }
    private Vector3 GetPositionForNewBlock()
    {
        return lastSpawnedBlock.GetJointPoint();
    }

    public void AddToGame(Block block)
    {
        block.transform.position = GetPositionForNewBlock();
        lastSpawnedBlock = block;
        block.transform.SetParent(parent.transform);
        block.Activate();
    }
}