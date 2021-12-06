using OngProject.Repositories;
using OngProject.Data;

namespace OngProject.UnitOfWork
{
    public class UOW
    {
        private readonly ONGDBContext _context;

        #region Repositories Declaration

        private CategoryRepository _categoryRepository;
        private UserRepository _userRepository;

        private MemberRepository _memberRepository;
        
        #endregion
        public UOW()
        {
            
        }

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

        public UserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;


            }
        }
        public MemberRepository MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new MemberRepository(_context);
                }
                return _memberRepository;
            }
        }

        #endregion        

    }
}
           
    
