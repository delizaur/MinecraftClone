using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone {
    internal class RegistryObject {
        // how to make this so that it can only be set once by the registry?

        private short id;

        // pretty please this should only be called during registration
        public void SetId(short id) {
            this.id = id;
        }

        public short GetId() {
            return id;
        }
    }
}
