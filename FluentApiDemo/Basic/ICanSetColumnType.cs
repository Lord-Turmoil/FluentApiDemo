﻿// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

namespace FluentApiDemo.Basic;

public interface ICanSetColumnType
{
    ICanSetColumnProperty OfType(string type);
}