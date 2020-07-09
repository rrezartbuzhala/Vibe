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

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.GetById
{
    public class GetEnviromentByIdQueryHandler : IRequestHandler<GetEnviromentByIdQuery, GetEnviromentByIdQueryModel>
    {
        private readonly IVibeDbContext _context;
        public GetEnviromentByIdQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetEnviromentByIdQueryModel> Handle(GetEnviromentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context
               .Enviroments.AsNoTracking()
               .Where(e => e.Id == request.Id)
               .Select(enviroment => new GetEnviromentByIdQueryModel
               {
                   EnviromentName = enviroment.EnviromentName,
                   Songs = enviroment.Songs.Select(song => new SongModel
                   {
                       Id = song.Id,
                       Title = song.Title,
                   }),
               }).FirstOrDefaultAsync();
        }
    }
}
