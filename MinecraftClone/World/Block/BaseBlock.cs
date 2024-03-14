using MinecraftClone.World.States;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block
{
    internal abstract class BaseBlock : RegistryObject
    {

        public virtual BlockTextureData GetTextureData(BlockState state)
        {
            return null;
        }

        public virtual State GetDefaultState() {
            return new EmptyState();
        }

        public abstract string Name();

        public virtual void OnRightClick(MinecraftWorld world, BlockState state, Vector3i pos) { }

    }
}
