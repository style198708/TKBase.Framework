// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TKBase.DotNetty.Transport.Channels
{
    public interface IMessageSizeEstimator
    {
        /// <summary>
        ///     Creates a new handle. The handle provides the actual operations.
        /// </summary>
        IMessageSizeEstimatorHandle NewHandle();
    }
}