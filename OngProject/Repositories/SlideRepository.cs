using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class SlideRepository : BaseRepository<Slide, ONGDBContext>, ISlideRepository
    {
        public SlideRepository(ONGDBContext context)
            : base(context)
        {

        }
       
    }
}
