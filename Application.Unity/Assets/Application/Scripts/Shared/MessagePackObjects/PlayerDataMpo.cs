using MessagePack;
using UnityEngine;

namespace Application.Shared.MessagePackObjects
{
    [MessagePackObject]
    public class PlayerDataMpo
    {
        [Key(0)] public string Name { get; set; }
        [Key(1)] public Vector3 Position { get; set; }
        [Key(2)] public Quaternion Rotation { get; set; }
    }
}