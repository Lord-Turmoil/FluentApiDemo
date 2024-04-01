// Copyright (C) 2018 - 2024 Tony's Studio. All rights reserved.

using FluentApiDemo.Advanced;

namespace Test;

[TestClass]
public class AdvancedTest
{
    /// <summary>
    ///     Test building a valid table.
    /// </summary>
    [TestMethod]
    public void ValidTest()
    {
        const string answer = """
                              CREATE TABLE `Demo`.`ValidTable` (
                                `Id` int NOT NULL,
                                `Name` varchar(255) NOT NULL,
                                `Age` int NOT NULL,
                                `Email` varchar(255) NULL,
                                PRIMARY KEY (`Id`)
                              );
                              """;
        string sql = AdvancedTableDescriptor.CreateTable("ValidTable").InDatabase("Demo")
            .AddColumn("Id").OfType("int").IsKey()
            .AddColumn("Name").OfType("varchar(255)").IsRequired()
            .AddColumn("Age").OfType("int").IsRequired()
            .AddColumn("Email").OfType("varchar(255)")
            .Build();

        Assert.AreEqual(answer, sql.Trim());
    }

    /// <summary>
    ///     Test building an invalid table.
    /// </summary>
    [TestMethod]
    public void InvalidTest()
    {
        // The invalid table will be prevented from being built.
        // It won't even compile. :)

        /*
        AdvancedTableDescriptor.CreateTable("InvalidTable").InDatabase("Demo")
            .Build();
        */
        Assert.IsTrue(true);
    }
}