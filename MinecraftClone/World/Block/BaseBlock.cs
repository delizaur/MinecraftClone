using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block
{
    internal abstract class BaseBlock
    {

        public virtual BlockTextureData GetTextureData()
        {
            return null;
        }

        public abstract string Name();

    }
}
