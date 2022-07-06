﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Common.Infrastructure;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorChat.Api.Infrastructure.Persistence.Context;

public class SeedData
{
    private static List<User> GetUser()
    {
        var result = new Faker<User>("tr")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreateDate,
                i => i.Date.Between(DateTime.Now.AddDays(100),DateTime.Now))
            .RuleFor(i=>i.FirstName, i=>i.Person.FirstName)
            .RuleFor(i=>i.LastName,i=>i.Person.LastName)
            .RuleFor(i=>i.EmailAddress,i=>i.Internet.Email())
            .RuleFor(i=>i.UserName,i=>i.Internet.UserName())
            .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
            .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true,false))
            .Generate(500);
        return result;

    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        var context = new BlazorChatContext(dbContextBuilder.Options);
        if (context.Users.Any())
        {
            await Task.CompletedTask;
            return;
            
        }
        var users = GetUser();
        var userIds = users.Select(i => i.Id);
        await context.Users.AddRangeAsync(users);
        var guids = Enumerable.Range(0, 150)
            .Select(i => Guid.NewGuid()).ToList();
        int counter = 0;
        var entries = new Faker<Entry>("tr")
            .RuleFor(i => i.Id,i=> guids[counter++])
            .RuleFor(i=>i.CreateDate,i=>i.Date.Between(
                DateTime.Now.AddDays(-100),DateTime.Now))
            .RuleFor(i=>i.Subject,i=>i.Lorem.Sentence(5,5))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i=>i.CreateById,i=>i.PickRandom(userIds))
            .Generate(150);
        await context.Entries.AddRangeAsync(entries);
        var comments = new Faker<EntryComment>("tr").RuleFor(i => i.Id, i=>Guid.NewGuid())
            .RuleFor(i => i.CreateDate, i => i.Date.Between(
                DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.CreateById, i => i.PickRandom(userIds))
            .RuleFor(i => i.EntryId, i => i.PickRandom(guids))
            .Generate(1000);
        await context.Entries.AddRangeAsync(entries);
        await context.SaveChangesAsync();



    }
}