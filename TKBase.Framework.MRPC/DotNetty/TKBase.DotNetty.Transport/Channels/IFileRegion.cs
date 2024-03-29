﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TKBase.DotNetty.Transport.Channels
{
    using System.IO;
    using  TKBase.DotNetty.Common;

    public interface IFileRegion : IReferenceCounted
    {
        long Position { get; }

        long Transferred { get; }

        long Count { get; }

        long TransferTo(Stream target, long position);
    }
}
