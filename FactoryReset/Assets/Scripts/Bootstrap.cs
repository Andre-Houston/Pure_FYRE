using Unity.Entities;
using Unity.Transforms;
using Unity.Transforms2D;
using UnityEngine;

public class Bootstrap
{
    public EntityArchetype PlayerArchetype { get; private set; }

    public static Bootstrap Instance { get; } = new Bootstrap();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeWorld()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        Instance.PlayerArchetype = entityManager.CreateArchetype(typeof(TransformMatrix), typeof(Position2D));

        Instance.GenerateSpriteMeshes();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void AutoStart()
    {
        Instance.StartNewGame();
    }

    public void StartNewGame()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        Entity player = entityManager.CreateEntity(PlayerArchetype);
    }

    void GenerateSpriteMeshes()
    {

    }
}
