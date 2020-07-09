using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.Get
{
    public class GetEnviromentsQueryHandler : IRequestHandler<GetEnviromentsQuery, IList<GetEnviromentsQueryModel>>
    {
        public readonly IVibeDbContext _context;

        public GetEnviromentsQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async  Task<IList<GetEnviromentsQueryModel>> Handle(GetEnviromentsQuery request, CancellationToken cancellationToken)
        {
            return await _context
                .Enviroments.AsNoTracking()
                .Select(enviroment => new GetEnviromentsQueryModel 
                {
                    Id = enviroment.Id,
                    EnviromentName = enviroment.EnviromentName,
                    Songs = enviroment.Songs.Select(song => new SongModel 
                    {
                        Id = song.Id,
                        Title = song.Title,
                    })
                }).ToListAsync();
        }
    }
}
