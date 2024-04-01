// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

using System.Text;

namespace FluentApiDemo.Basic;

public class BasicTableDescriptor :
    ICanSetDatabase,
    ICanAddColumn,
    ICanSetColumnType,
    ICanSetColumnProperty,
    ICanBuildTable
{
    private readonly List<Tuple<string, string, string>> _columns = [];
    private readonly List<string> _keys = [];
    private int _currentColumn = -1;
    private string _database = null!;
    private string _name = null!;

    private BasicTableDescriptor()
    {
    }


    public ICanSetColumnType AddColumn(string name)
    {
        Tuple<string, string, string> column = Tuple.Create(name, "", "NULL");
        _columns.Add(column);
        _currentColumn++;

        return this;
    }


    public string Build()
    {
        // If key is missing, add the first column as key.
        if (_keys.Count == 0)
        {
            if (_columns.Count == 0)
            {
                throw new InvalidOperationException("Table must have at least one column");
            }

            _keys.Add(_columns[0].Item1);
            _columns[0] = Tuple.Create(_columns[0].Item1, _columns[0].Item2, "NOT NULL");
        }

        var sql = new StringBuilder();
        sql.AppendLine($"CREATE TABLE `{_database}`.`{_name}` (");
        foreach (Tuple<string, string, string> column in _columns)
        {
            sql.AppendLine($"  `{column.Item1}` {column.Item2} {column.Item3},");
        }

        sql.Append("  PRIMARY KEY (");
        for (int i = 0; i < _keys.Count; i++)
        {
            sql.Append($"`{_keys[i]}`");
            if (i != _keys.Count - 1)
            {
                sql.Append(", ");
            }
        }

        sql.AppendLine(")");
        sql.AppendLine(");");

        return sql.ToString();
    }

    public ICanAddColumn IsKey()
    {
        _columns[_currentColumn] =
            Tuple.Create(_columns[_currentColumn].Item1, _columns[_currentColumn].Item2, "NOT NULL");
        _keys.Add(_columns[_currentColumn].Item1);
        return this;
    }

    public ICanAddColumn IsRequired()
    {
        _columns[_currentColumn] =
            Tuple.Create(_columns[_currentColumn].Item1, _columns[_currentColumn].Item2, "NOT NULL");
        return this;
    }

    public ICanSetColumnProperty OfType(string type)
    {
        _columns[_currentColumn] = Tuple.Create(_columns[_currentColumn].Item1, type, "NULL");
        return this;
    }

    public ICanAddColumn InDatabase(string database)
    {
        _database = database;
        return this;
    }

    public static ICanSetDatabase CreateTable(string name)
    {
        var descriptor = new BasicTableDescriptor();
        descriptor._name = name;
        return descriptor;
    }
}