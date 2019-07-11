﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Data.Commnds.Search;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMentorRepository : IProgrammerSearch, IDisposable
    {
        int GetCount();
        Task<IEnumerable<Mentor>> GetMentorsSliceAsync(int begin, int end);
        Task<IEnumerable<Mentor>> GetMentorsAsync();
        Task<Mentor> GetMentorAsync(ulong id);
        Task InsertMentorAsync(Mentor mentor);
        Task DeleteMentorAsync(ulong id);
        Task UpdateMentorAsync(Mentor mentor);
        Task SaveAsync();
    }
}