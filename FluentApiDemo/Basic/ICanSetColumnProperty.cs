﻿// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

namespace FluentApiDemo.Basic;

public interface ICanSetColumnProperty : ICanBuildTable
{
    ICanAddColumn IsKey();
    ICanAddColumn IsRequired();
}