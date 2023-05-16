<<<<<<< HEAD
using Content.Server.Worldgen.Prototypes;
=======
﻿using Content.Server.Worldgen.Prototypes;
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))
using Content.Server.Worldgen.Systems.GC;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Worldgen.Components.GC;

/// <summary>
///     This is used for whether or not a GCable object is "dirty". Firing GCDirtyEvent on the object is the correct way to
///     set this up.
/// </summary>
[RegisterComponent]
[Access(typeof(GCQueueSystem))]
<<<<<<< HEAD
public sealed partial class GCAbleObjectComponent : Component
=======
public sealed class GCAbleObjectComponent : Component
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))
{
    /// <summary>
    ///     Which queue to insert this object into when GCing
    /// </summary>
    [DataField("queue", required: true, customTypeSerializer: typeof(PrototypeIdSerializer<GCQueuePrototype>))]
    public string Queue = default!;
<<<<<<< HEAD

    [ViewVariables(VVAccess.ReadOnly)]
    [DataField("linkedGridEntity")]
    public EntityUid LinkedGridEntity = EntityUid.Invalid;
=======
>>>>>>> e91fc652a3 (Dynamic space world generation and debris. (#15120))
}

