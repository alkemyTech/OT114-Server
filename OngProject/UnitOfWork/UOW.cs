using OngProject.Repositories;
using OngProject.Data;

namespace OngProject.UnitOfWork
{
    public class UOW
    {
        private readonly ONGDBContext _context;

        #region Repositories Declaration

        private CategoryRepository _categoryRepository;
        
        #endregion

        public UOW(ONGDBContext context)
        {
            _context = context;
        }

        #region Repositories Implementation

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

        #endregion        

    }
}
           
    
