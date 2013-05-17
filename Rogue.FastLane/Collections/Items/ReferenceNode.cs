﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue.FastLane.Items;

namespace Rogue.FastLane.Collections.Items
{
    public class ReferenceNode<TItem, TKey> : Node<TItem, TKey>
    {        
        public TKey Key { get; set; }
        public ReferenceNode<TItem, TKey>[] References { get; set; }
        public ValueNode<TItem>[] Values { get; set; }
    }
}
