using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class UserManager : IUserService
    {
        IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            user.CreatedAt = DateTime.Now;
           
            _userDal.Add(user);
        }

        public IDataResult<User> getAdmin(UserForLogin userForLogin)
        {


            
            User user = _userDal.Get((user) => user.roles == "admin" && user.Email==userForLogin.email);
            if (!(user.Email == userForLogin.email && user.Password == userForLogin.password))
            {
                return new ErrorDataResult<User>("giriş bilgilerinzii kontrol ediniz");
            }
            return new SuccessDataResult<User>(user, "kullanıcı var");

        }

        public List<User> GetAll()
        {

            return _userDal.GetAll();
        }

        public IDataResult<User> getByEmail(UserForLogin userForLogin)
        {
            User user = _userDal.Get((user) => user.Email == userForLogin.email);

            if (user == null || !(user.Email==userForLogin.email && user.Password==userForLogin.password) )
            {
                return new ErrorDataResult<User>("giriş bilgilerinzii kontrol ediniz");
            }
            return  new SuccessDataResult<User>(user,"kullanıcı var");
        }

        public IDataResult<User> GetById(int userId)
        {

            var result= _userDal.Get((user) => user.id == userId);
            if (result==null)
            {
                return new ErrorDataResult<User>("kullanıcı yok");
            }
            return new SuccessDataResult<User>(result);
        }

       
    }
}
