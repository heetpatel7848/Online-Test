using AutoMapper;
using MailKit;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class TestService : ITestService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ITestLinkRepository _testLinkRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IAnswerSheetRepository _answerSheetRepository;
        private readonly IMailOutboundRepository _mailOutboundRepository;
     


        #endregion

        #region Constructor
        public TestService(IMapper mapper, ITestRepository testRepository,IMailOutboundRepository mailOutboundRepository, IAnswerSheetRepository answerSheetRepository, IUserRoleRepository userRoleRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, ITechnologyRepository technologyRepository, ITestLinkRepository testLinkRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _technologyRepository = technologyRepository;
            _testLinkRepository = testLinkRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _answerSheetRepository = answerSheetRepository;
            _mailOutboundRepository = mailOutboundRepository;
            

        }
        #endregion

        #region Methods
        public ResponseDTO GetTests()
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTests().ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _testRepository.GetTestById(id);
                if (test == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test not found";
                    return response;
                }
                var data = _mapper.Map<GetTestDTO>(test);
                var questionsList = _mapper.Map<List<GetQuestionDTO>>(_questionRepository.GetQuestionsByTestId(test.Id).ToList());
                foreach (var question in questionsList)
                {
                    var answersList = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswersByQuestionId(question.Id).ToList());
                    question.Answers = answersList;
                }
                data.Questions = questionsList;
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestsPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTestsPaginated(page, limit).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestsByTechnologyId(int technologyId)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(technologyId);
                if (technologyById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
                var data = _mapper.Map<List<GetTestDTO>>(_testRepository.GetTestsByTechnologyId(technologyId).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddTest(AddTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(test.TechnologyId);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var existFlag = _testRepository.IsTestExists(test.TechnologyId, test.TestName);
                if (existFlag)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test already exists";
                    return response;
                }
                test.IsActive = true;
                test.CreatedOn = DateTime.UtcNow;
                var testId = _testRepository.AddTest(_mapper.Map<Test>(test));
                if (testId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add test";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = testId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateTest(UpdateTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(test.Id);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test does not exist";
                    return response;
                }
                var existFlag = _testRepository.IsTestExists(test.TechnologyId, test.TestName);
                if (existFlag)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Test already exists";
                    return response;
                }
                var updateFlag = _testRepository.UpdateTest(_mapper.Map<Test>(test));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update test";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO DeleteTest(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(id);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test does not exist";
                    return response;
                }
                testById.IsActive = false;
                var deleteFlag = _testRepository.DeleteTest(_mapper.Map<Test>(testById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete test";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddTestLink(int adminId, int testId, string email)
        {
            var response = new ResponseDTO();
            try
            {
                // check if user exists, if not then create one
                var userByEmail = _userRepository.GetUserByEmail(email);
                int userId;
                if (userByEmail == null)
                {
                    var user = new User
                    {
                        Name = email,
                        Email = email,
                        Password = "password",
                        MobileNo = "0000000000",
                        IsActive = true
                    };
                    userId = _userRepository.AddUser(user);
                    _userRoleRepository.AddRole(new UserRole
                    {
                        UserId = userId,
                        RoleId = 2
                    });
                }
                else
                {
                    userId = userByEmail.Id;
                }

                // check if test exists
                var testById = _testRepository.GetTestById(testId);
                if (testById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test does not exist";
                    return response;
                }

                // check if link has already been created and not expired
                var existFlag = _testLinkRepository.IsTestLinkExists(testId, userId);
                if (existFlag)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Test link already exists";
                    return response;
                }

                var testLink = new TestLink
                {
                    TestId = testId,
                    UserId = userId,
                    Token = Guid.NewGuid(),
                    AccessCount = 0,
                    ExpireOn = DateTime.UtcNow.AddDays(7),
                    Active = true,
                    CreatedBy = adminId,
                    CreatedOn = DateTime.UtcNow,
                    
                };

                var testLinkId = _testLinkRepository.AddTestLink(testLink);
                if (testLinkId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add test link";
                    return response;
                }
                
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestByLink(Guid token, string email)
        {
            var response = new ResponseDTO();
            try
            {
                var testLink = _testLinkRepository.GetTestLink(token);
                if (testLink == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test link has expired";
                    return response;
                }
                testLink.AccessCount += 1;
                _testLinkRepository.UpdateTestLink(testLink);
                var userId = testLink.UserId;
                var user = _userRepository.GetUserById(userId);
                if (email.ToLower() != user.Email.ToLower())
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Email is incorrect";
                    return response;
                }
                if (token != testLink.Token)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "token is not valid";
                }
                //check if test has already submitted
                if (testLink.SubmitedOn != null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Test has been already submitted";
                }
                var testId = testLink.TestId;
                response = GetTestById(testId);
                if (response.Status == 200)
                {
                    testLink.AccessOn = DateTime.UtcNow;
                    _testLinkRepository.UpdateTestLink(testLink);
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }

        public ResponseDTO SubmitTest(AddAnswerSheetDTO answerSheet)
        {
            var response = new ResponseDTO();
            try
            {
                var testLink = _testLinkRepository.GetTestLink(answerSheet.Token);
                if (testLink.SubmitedOn != null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "test has already submitted";
                    return response;
                }
                if (testLink.ExpireOn <= DateTime.UtcNow)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Test link has expired";
                    return response;
                }
                answerSheet.CreatedOn = DateTime.UtcNow;
                List<AnswerSheet> answerSheets = new List<AnswerSheet>();

                foreach (var question in answerSheet.Questions)
                {
                    var sheet = new AnswerSheet
                    {
                        Token = answerSheet.Token,
                        QuestionId = question.QuestionId,
                        AnswerId = question.AnswersId,
                        CreatedOn = answerSheet.CreatedOn
                        
                    };
                    answerSheets.Add(sheet);
                }
               _answerSheetRepository.AddAnswerSheet(answerSheets);
                testLink.SubmitedOn = DateTime.UtcNow;
                _testLinkRepository.UpdateTestLink(testLink);
                response.Status = 200;
                response.Message = "Ok";
                response.Data = answerSheets;
            }
             catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;


        }
        #endregion
    }
}

    
     

     
        
 



        
       
    