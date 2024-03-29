﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TKBase.DotNetty.Codecs
{
    public interface INameValidator<in T>
    {
        void ValidateName(T name);
    }
}
