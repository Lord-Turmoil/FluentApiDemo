// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

namespace FluentApiDemo;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("""
                          Copyright (C) 2024 Tony's Studio, All rights reserved.
                          ---------------------------------------------------------

                          This is a demo of building Fluent API in C#.
                          Here we have a simple example a SQL table builder.

                          In "Basic/", we have a basic implementation of a table builder, but
                          it will allow you to build invalid tables which has no column.

                          In "Advanced/", we have an advanced implementation of a table builder,
                          which will prevent you from building invalid tables.

                          The Test project contains tests for both implementations.

                          Enjoy! :)
                          """);
    }
}