using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NETCORE.AutoMapper.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IMapper _mapper;


        public ValuesController(IUserInfoService userInfoService,
        IUnitOfWork unitOfWork, ILogger<ValuesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult AddUser(UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _mapper.Map<UserInfo>(model); //映射
            var repoUser = _unitOfWork.GetRepository<UserInfo>();
            repoUser.Insert(user);
            var r = _unitOfWork.SaveChanges();
            //_userInfoService.AddUserInfo();

        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {




            return new string[] { "value1", "value2" };
        }

    }
}
