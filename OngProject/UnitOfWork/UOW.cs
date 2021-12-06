using OngProject.Repositories;
using OngProject.Data;

namespace OngProject.UnitOfWork
{
    public class UOW
    {
        private readonly ONGDBContext _context;
        private CategoryRepository _categoryRepository;
        private RolesRepository _rolesRepository;
                

        public UOW(ONGDBContext context, CategoryRepository categoryRepository, RolesRepository rolesRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _rolesRepository = rolesRepository;
        }
        
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public RolesRepository RolesRepository
        {
            get
            {
                if (_rolesRepository == null)
                {
                    _rolesRepository = new RolesRepository(_context);
                }
                return _rolesRepository;
            }
        }

    }
}


