// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

namespace FluentApiDemo.Advanced;

public interface ICanAddColumn : ICanBuildTable
{
    ICanSetColumnType AddColumn(string name);
}