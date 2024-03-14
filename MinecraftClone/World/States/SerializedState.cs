using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {
    internal struct SerializedState {

        private short serialized;

        public SerializedState(short serialized) {
            this.serialized = serialized;
        }

        public T Get<T>() where T : State, new() {
            return (T)new T().Deserialize(serialized);
        }

    }
}
