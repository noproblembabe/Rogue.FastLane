﻿using Rogue.FastLane.Collections.Items;
using Rogue.FastLane.Collections.State;
using Rogue.FastLane.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue.FastLane.Queries.Mixins
{
    public static class NodeMixins
    {
        public static void MoveAndInsert<TItem, TKey>(this UniqueKeyQuery<TItem, TKey> self, Coordinates[] coordinateSet, ValueNode<TItem> valNode)
        {
            ReferenceNode<TItem, TKey> previousRef = null;

            var coordinates = coordinateSet[coordinateSet.Length - 1];

            self.ForEachValuedNode(coordinateSet,
                (@ref, i) =>
                {
                    if (i < 1)
                    { previousRef = @ref; }

                    else if (previousRef == null)
                    { @ref.Values[i] = @ref.Values[i - 1]; }

                    else
                    {
                        previousRef.Values[
                            previousRef.Values.Length - 1] = @ref.Values[i];
                    }
                },r => {});
        }
    }
}