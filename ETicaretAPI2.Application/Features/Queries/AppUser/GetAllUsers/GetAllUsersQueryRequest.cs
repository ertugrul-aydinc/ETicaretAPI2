﻿using MediatR;

namespace ETicaretAPI2.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
