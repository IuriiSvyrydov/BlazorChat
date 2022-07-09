﻿using System.Net.Http.Json;
using BlazorChat.Client.Web.Infrastructure.Interfaces;
using BlazorChat.Common.Models.Pagination;
using BlazorChat.Common.Models.Queries;
using BlazorChat.Common.Models.RequestModel;

namespace BlazorChat.Client.Web.Infrastructure.Services
{
    public class EntryService: IEntryService
    {
        private readonly HttpClient _httpClient;

        public EntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetEntriesViewModel>> GetEntries()
        {
            var result =
                await _httpClient.GetFromJsonAsync<List<GetEntriesViewModel>>("/api/entry?todaysEntries=false&count=30");
            return result;
        }

        public async Task<GetEntryDetailViewModel> GetEntryDetail(Guid entryId)
        {
            var result =
                await _httpClient.GetFromJsonAsync<GetEntryDetailViewModel>($"/api/entry/{entryId}");
            return result;
        }

        public async Task<PageViewModel<GetEntryDetailViewModel>> GetMainPageEntries(int page, int pageSize)
        {
            var result =
                await _httpClient.GetFromJsonAsync<PageViewModel<GetEntryDetailViewModel>>($"/api/entry/mainpageentries?page={page}&pageSize={pageSize }");
            return result;
        }

        public async Task<PageViewModel<GetEntryDetailViewModel>> GetProfilePageEntries(int page, int pageSize, string userName = null)
        {
            var result =
                await _httpClient.GetFromJsonAsync<PageViewModel<GetEntryDetailViewModel>>
                    ($"/api/entry/UserEntries?userName={userName}&page={page}&pageSize={pageSize}");
            return result;
        }

        public async Task<PageViewModel<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize)
        {
            var result =
                await _httpClient.GetFromJsonAsync<PageViewModel<GetEntryCommentsViewModel>>($"/api/entry/comments/{entryId}?page={page}&pageSize={pageSize}");
            return result;
        }

        public async Task<Guid> CreateEntry(CreateEntryCommand command)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Entry/CreateEntry", command);
            if (!result.IsSuccessStatusCode)
                return Guid.Empty;
            var guidStr = await result.Content.ReadAsStringAsync();
            return new Guid(guidStr.Trim('"'));
        }

        public async Task<Guid> CreateEntryComment(CreateEntryCommentCommand command)
        {
            var res = await _httpClient.PostAsJsonAsync("/api/Entry/CreateEntryComment", command);
            if (!res.IsSuccessStatusCode)
                return Guid.Empty;
            var guidStr = await res.Content.ReadAsStringAsync();
            return new Guid(guidStr.Trim('"'));
        }

        public async Task<List<SearchEntryViewModel>> SearchBySubject(string searchText)
        {
            var result =
                await _httpClient.GetFromJsonAsync<List<SearchEntryViewModel>>(
                    $"/api/Entry/Search?searchText={searchText}");
            return result;
        }
    }
}
