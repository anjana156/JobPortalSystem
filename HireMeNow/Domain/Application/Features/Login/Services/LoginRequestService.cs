using AutoMapper;
using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Application.Features.Login.DTO;
using Domain.Application.Features.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Login.Services
{
    public class LoginRequestService : ILoginRequestService
    {
        ILoginRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        public LoginRequestService(ILoginRequestRepository _jobSeekerRepository, IMapper _mapper, IAuthUserRepository _authUserRepository)
        {
            jobSeekerRepository = _jobSeekerRepository;
            mapper = _mapper;

            authUserRepository = _authUserRepository;
        }

        public JobSeekerLoginDto login(string email, string password)
        {
            var user = jobSeekerRepository.GetUserByEmailpassword(email, password);
            if (user == null)
            {
                return null;
            }
            else
            {
                if ((password == user.Password))
                {
                    var userReturn = mapper.Map<JobSeekerLoginDto>(user);
                    userReturn.Token = authUserRepository.CreateToken(user);
                    return userReturn;
                }
                return null;
            }

        }
    }
}

//        public AdminLoginDTO Adminlogin(string email, string password)
//        {
//            var user = jobSeekerRepository.GetUserByEmail(email);
//            if (user == null)
//            {
//                return null;
//            }
//            else
//            {
//                if ((password == user.Password))
//                {
//                    var userReturn = mapper.Map<AdminLoginDTO>(user);
//                    userReturn.Token = authUserRepository.CreateToken(user);
//                    return userReturn;
//                }
//                return null;
//            }

//        }
//    }

//}

