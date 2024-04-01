// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

namespace FluentApiDemo.Advanced;

public class AdvancedTableDescriptor :
    ICanSetDatabase,
    ICanAddColumnFirst
{
    private readonly List<Tuple<string, string, string>> _columns = [];
    private string _database = null!;
    private string _name = null!;

    private AdvancedTableDescriptor()
    {
    }


    public ICanSetColumnType AddColumn(string name)
    {
        Tuple<string, string, string> column = Tuple.Create(name, "", "NULL");
        _columns.Add(column);
        return new AdvanceTableDescriptorImpl(_name, _database, _columns);
    }

    public ICanAddColumnFirst InDatabase(string database)
    {
        _database = database;
        return this;
    }

    public static ICanSetDatabase CreateTable(string name)
    {
        var descriptor = new AdvancedTableDescriptor();
        descriptor._name = name;
        return descriptor;
    }
}