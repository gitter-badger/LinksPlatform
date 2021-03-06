﻿using System;

namespace Platform.Links.DataBase.CoreUnsafe.Structures
{
    public interface ILink : IEquatable<ILink>
    {
        ILink Source { get; }
        ILink Target { get; }

        void WalkThroughReferersBySource(Action<ILink> walker);
        void WalkThroughReferersByTarget(Action<ILink> walker);
    }
}