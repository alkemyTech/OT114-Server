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
        private RolesRepository _rolesRepository;
        private NewsRepository _newsRepository;
        private ActivityRepository _activityRepository;
        private TestimonialRepository _testimonialRepository;
        private ContactRepository _contactRepository;
        private CommentsRepository _commentsRepository;


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
        public NewsRepository NewsRepository 
        {
            get
            {
                if (_newsRepository == null) 
                {
                    _newsRepository = new NewsRepository(_context);
                }
                return _newsRepository;
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

        public ActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new ActivityRepository(_context);
                }
                return _activityRepository;
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

        public ContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_context);
                }
                return _contactRepository;
            }
        }

        public CommentsRepository CommentsRepository
        {
            get
            {
                if (_commentsRepository == null)
                {
                    _commentsRepository = new CommentsRepository(_context);
                }
                return _commentsRepository;
            }
        }

        #endregion        

    }
}
           
    
