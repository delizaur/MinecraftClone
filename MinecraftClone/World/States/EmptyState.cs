using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {
    internal class EmptyState : State {
        public override State Deserialize(short serialized) {
            return new EmptyState();
        }

        public override short Serialize() {
            return 0;
        }
    }
}
