﻿using AutoMapper;

using CaWorkshop.Application.Common.Mappings;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Priority,
                o => o.MapFrom(s => (int)s.Priority));
    }
}
