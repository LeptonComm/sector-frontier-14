using System.Numerics;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Array;

namespace Content.Server.Worldgen.Prototypes;

/// <summary>
///     This is a prototype for biome selection, allowing the component list of a chunk to be amended based on the output
///     of noise channels at that location.
/// </summary>
[Prototype("spaceBiome")]
public sealed partial class BiomePrototype : IPrototype, IInheritingPrototype
{
    /// <inheritdoc />
    [ParentDataField(typeof(AbstractPrototypeIdArraySerializer<BiomePrototype>))] // Frontier: EntityPrototype<BiomePrototype
    public string[]? Parents { get; private set; }

    /// <inheritdoc />
    [NeverPushInheritance]
    [AbstractDataField]
    public bool Abstract { get; private set; }

    /// <inheritdoc />
    [IdDataField]
    public string ID { get; private set; } = default!;

    // Frontier: distances
    /// <summary>
    ///     The valid range of biome coordinate lengths (3000, 4000) => 5000
    ///     Chunks with center points within this range may be generated with this biome.
    /// </summary>
    [ViewVariables]
    private Vector2? _distanceRange;

    /// <summary>
    ///     Accessor for range
    /// </summary>
    [DataField]
    public Vector2? DistanceRange
    {
        get { return _distanceRange; }
        private set
        {
            _distanceRange = value;

            if (value == null)
                DistanceRangeSquared = null;
            else
                DistanceRangeSquared = value * value;
        }
    }

    [ViewVariables]
    public Vector2? DistanceRangeSquared { get; private set; }
    // Frontier: distances

    /// <summary>
    ///     The valid ranges of noise values under which this biome can be picked.
    /// </summary>
    [DataField("noiseRanges", required: true)]
    public Dictionary<string, List<Vector2>> NoiseRanges = default!;

    /// <summary>
    ///     Higher priority biomes get picked before lower priority ones.
    /// </summary>
    [DataField("priority", required: true)]
<<<<<<< HEAD
    public int Priority { get; private set; }
=======
    public int Priority { get; }
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))

    /// <summary>
    ///     The components that get added to the target map.
    /// </summary>
    [DataField("chunkComponents")]
    [AlwaysPushInheritance]
<<<<<<< HEAD
    public ComponentRegistry ChunkComponents = new();
=======
    public EntityPrototype.ComponentRegistry ChunkComponents { get; } = new();
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))

    //TODO: Get someone to make this a method on componentregistry that does it Correctly.
    /// <summary>
    ///     Applies the worldgen config to the given target (presumably a map.)
    /// </summary>
    public void Apply(EntityUid target, ISerializationManager serialization, IEntityManager entityManager)
    {
        // Add all components required by the prototype. Engine update for this whenst.
        foreach (var data in ChunkComponents.Values)
        {
            var comp = (Component) serialization.CreateCopy(data.Component, notNullableOverride: true);
<<<<<<< HEAD
=======
            comp.Owner = target; // look im sorry ok this .owner has to live until engine api exists
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))
            entityManager.AddComponent(target, comp);
        }
    }
}

