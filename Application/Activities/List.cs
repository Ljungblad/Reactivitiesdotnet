using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {}

        public class Hander : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext __context;
            public Hander(DataContext _context)
            {
            __context = _context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await __context.Activities.ToListAsync();
            }
        }
    }
}