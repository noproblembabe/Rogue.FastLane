﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rogue.FastLane.Collections.Items;
using Rogue.FastLane.Collections.State;

namespace Rogue.FastLane.Collections
{
    public class LowestReferencesEnumerable<TItem, TKey>: IEnumerable<ReferenceNode<TItem, TKey>>
    {
        protected ReferenceNode<TItem, TKey> Root;

        public LowestReferencesEnumerable(ReferenceNode<TItem, TKey> root)
        {
            Root = root;
        }

        //protected IEnumerable<ReferenceNode<TItem, TKey>> GetEnumerator<TItem, TKey>(ReferenceNode<TItem, TKey> node, UniqueKeyQueryState state, int levelIndex)
        protected IEnumerator<ReferenceNode<TItem, TKey>> GetEnumerator<TItem, TKey>(ReferenceNode<TItem, TKey> node)
        {
            if (node.Values != null)
            {
                yield return node;
            }
            else if (node.References != null)
            {
                foreach (var child in node.References)
                {
                    var iterator = 
                        GetEnumerator(child);
                    
                    while(iterator.MoveNext())
                    {
                        yield return iterator.Current;
                    }
                }
            }
        }

        public IEnumerator<ReferenceNode<TItem, TKey>> GetEnumerator()
        {
            return GetEnumerator(Root);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator(Root);
        }
    }
}
