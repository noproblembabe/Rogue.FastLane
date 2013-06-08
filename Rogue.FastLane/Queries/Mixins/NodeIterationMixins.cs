using System;
using Rogue.FastLane.Collections.Items;
using Rogue.FastLane.Collections.State;
using System.Collections.Generic;
using Rogue.FastLane.Collections;
using Rogue.FastLane.Collections.Mixins;
using Rogue.FastLane.Items;

namespace Rogue.FastLane.Queries.Mixins
{
    public static class NodeIterationMixins
	{
        public static IEnumerable<ReferenceNode<TItem, TKey>> IntoLowestRefs<TItem, TKey>(
            this UniqueKeyQuery<TItem, TKey> self, ReferenceNode<TItem, TKey> root, OneTimeValue[] offsets)
        {
            var iterator = 
                new LowestReferencesEnumerable<TItem, TKey>();

            return iterator.FromHereOn(root, offsets);
        }

        public static IEnumerable<ReferenceNode<TItem, TKey>> IntoLowestRefsReverse<TItem, TKey>(
            this UniqueKeyQuery<TItem, TKey> self, ReferenceNode<TItem, TKey> root, Pair[] coordinates)
        {
            var iterator =
                new LowestReferencesReverseEnumerable<TItem, TKey>();

            return iterator.UpToHere(root, coordinates);
        }

        public static void ForEachValuedNode<TItem, TKey>(this UniqueKeyQuery<TItem, TKey> self, 
            Coordinates[] offsetPerLvl, Action<ReferenceNode<TItem, TKey>, int> inEach, Action<ReferenceNode<TItem, TKey>> withLast)
        {
            var offset =
                offsetPerLvl[offsetPerLvl.Length - 1];
            
            ReferenceNode<TItem, TKey> @ref = null;
            var iterator = 
                IntoLowestRefsReverse(self, self.Root, offsetPerLvl).GetEnumerator();
            
            while (iterator.MoveNext())
            {
                @ref = iterator.Current;
                for (int i = @ref.Values.Length - 1; i > 0 && offset.OverallIndex < offset.Length; i--)
                {
                    offset.OverallIndex++;
                    inEach(@ref, i);
                }
            }

            //withLast(@ref);
        }
	}
}

