using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States
{
    internal abstract class State
    {

        public abstract short Serialize();

        public abstract State Deserialize(short serialized);

    }
}
