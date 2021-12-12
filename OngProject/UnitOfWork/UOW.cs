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
        private SlideRepository _slideRepository;
        private TestimonialRepository _testimonialRepository;

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

        public UserRepository UserRepository
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

        public SlideRepository SlideRepository
        {
            get
            {
                if (_slideRepository == null)
                {
                    _slideRepository = new SlideRepository(_context);
                }
                return _slideRepository;
            }
        }

        public TestimonialRepository TestimonialRepository
        {
            get
            {
                if (_testimonialRepository == null)
                {
                    _testimonialRepository = new TestimonialRepository(_context);
                }
                return _testimonialRepository;
            }
        }

        #endregion        

    }
}
           
    
