using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Domain;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext context;
            private readonly ILogger logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                this.context = context;
                this.logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (var i = 0; i < 15; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(10, cancellationToken);
                        this.logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (Exception ex) when (ex is TaskCanceledException)
                {
                    this.logger.LogInformation("Task was cancelled");
                }

                var activities = await this.context.Activities.ToListAsync();

                return activities;
            }
        }
    }
}