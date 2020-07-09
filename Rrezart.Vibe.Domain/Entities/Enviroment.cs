using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Enviroment : Entity
    { 
        public string EnviromentName { get; set; }
        
        public ICollection<Song> Songs { get; set; }
    }
}
