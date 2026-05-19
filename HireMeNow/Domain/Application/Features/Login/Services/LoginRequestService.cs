using AutoMapper;
<<<<<<< HEAD
using Domain.Application.Features.Authuser.Interfaces;
using Domain.Application.Features.Login.DTO;
using Domain.Service.Login.DTOs;
using Domain.Service.Login.Interfaces;
=======
using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Application.Features.Login.DTO;
using Domain.Application.Features.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/nasilanasry

namespace Domain.Application.Features.Login.Services
{
    public class LoginRequestService : ILoginRequestService
    {
<<<<<<< HEAD
        private readonly ILoginRequestRepository _loginRepository;

        private readonly IAuthUserRepository _authUserRepository;

        private readonly IMapper _mapper;

        public LoginRequestService(ILoginRequestRepository loginRepository,IAuthUserRepository authUserRepository,
            IMapper mapper)
        {
            _loginRepository = loginRepository;

            _authUserRepository = authUserRepository;

            _mapper = mapper;
        }

        //login
        public LoginResponseDto Login(LoginRequestDto request)
        {
            // CHECK USER

            var user =_loginRepository.GetUserByEmailpassword(request.Email, request.Password);

            if (user == null)
            {
                throw new Exception("Invalid Email or Password");
            }

            // MAP USER TO DTO

            var response =_mapper.Map<LoginResponseDto>(user);

            // GENERATE TOKEN

            response.Token =_authUserRepository.CreateToken(user);
            return response;
        }



    }
       
    }
=======
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
>>>>>>> origin/nasilanasry

