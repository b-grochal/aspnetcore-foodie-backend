﻿using MediatR;

namespace Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData
{
    public class GetAccountDataQuery : IRequest<GetAccountDataQueryResponse>
    {
        public int ApplicationUserId { get; set; }

        public GetAccountDataQuery(int applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }
    }
}
